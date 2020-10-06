﻿using DFC.App.ExploreCareers.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using DFC.Compui.Cosmos.Contracts;

namespace DFC.App.ExploreCareers.Repository.CosmosDb
{
    [ExcludeFromCodeCoverage]
    public class CosmosRepository<T> : Data.Contracts.ICosmosRepository<T>
        where T : class, IContentPageModel
    {
        private readonly CosmosDbConnection cosmosDbConnection;
        private readonly IDocumentClient documentClient;
        private readonly IHostingEnvironment env;
        private readonly PartitionKey partitionKey = new PartitionKey(typeof(T).Name.ToLower());

        public CosmosRepository(CosmosDbConnection cosmosDbConnection, IDocumentClient documentClient, IHostingEnvironment env)
        {
            this.cosmosDbConnection = cosmosDbConnection;
            this.documentClient = documentClient;
            this.env = env;
            InitialiseDevEnvironment().GetAwaiter().GetResult();
        }

        private Uri DocumentCollectionUri => UriFactory.CreateDocumentCollectionUri(cosmosDbConnection.DatabaseId, cosmosDbConnection.CollectionId);

        public async Task InitialiseDevEnvironment()
        {
            if (env.IsDevelopment())
            {
                await CreateDatabaseIfNotExistsAsync().ConfigureAwait(false);
                await CreateCollectionIfNotExistsAsync().ConfigureAwait(false);
            }
        }

        public async Task<bool> PingAsync()
        {
            var query = documentClient.CreateDocumentQuery<T>(DocumentCollectionUri, new FeedOptions { MaxItemCount = 1, PartitionKey = partitionKey })
                                       .AsDocumentQuery();

            if (query == null)
            {
                return false;
            }

            var models = await query.ExecuteNextAsync<T>().ConfigureAwait(false);
            var firstModel = models.FirstOrDefault();

            return firstModel != null;
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> where)
        {
            var query = documentClient.CreateDocumentQuery<T>(DocumentCollectionUri, new FeedOptions { MaxItemCount = 1, PartitionKey = partitionKey })
                                      .Where(where)
                                      .AsDocumentQuery();

            if (query == null)
            {
                return default;
            }

            var models = await query.ExecuteNextAsync<T>().ConfigureAwait(false);

            if (models != null && models.Count > 0)
            {
                return models.FirstOrDefault();
            }

            return default;
        }

        public async Task<IEnumerable<T?>?> GetListAsync(Expression<Func<T, bool>> where)
        {
            var query = documentClient.CreateDocumentQuery<T>(DocumentCollectionUri, new FeedOptions { MaxItemCount = 1, PartitionKey = partitionKey })
                                      .Where(where)
                                      .AsDocumentQuery();

            if (query == null)
            {
                return default;
            }

            var models = await query.ExecuteNextAsync<T>().ConfigureAwait(false);

            if (models != null && models.Count > 0)
            {
                return models;
            }

            return default;
        }

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
            var query = documentClient.CreateDocumentQuery<T>(DocumentCollectionUri, new FeedOptions { PartitionKey = partitionKey })
                                      .AsDocumentQuery();

            var models = new List<T>();

            while (query.HasMoreResults)
            {
                var result = await query.ExecuteNextAsync<T>().ConfigureAwait(false);

                models.AddRange(result);
            }

            return models.Any() ? models : default;
        }

        public async Task<HttpStatusCode> UpsertAsync(T model)
        {
            if (model != null)
            {
                var accessCondition = new AccessCondition { Condition = model.Etag, Type = AccessConditionType.IfMatch };

                var result = await documentClient.UpsertDocumentAsync(DocumentCollectionUri, model, new RequestOptions { AccessCondition = accessCondition, PartitionKey = partitionKey }).ConfigureAwait(false);

                return result.StatusCode;
            }

            return HttpStatusCode.BadRequest;
        }

        public async Task<HttpStatusCode> DeleteAsync(Guid documentId)
        {
            var documentUri = CreateDocumentUri(documentId);

            var model = await GetAsync(d => d.DocumentId == documentId).ConfigureAwait(false);

            if (model != null)
            {
                var accessCondition = !string.IsNullOrEmpty(model.Etag) ? new AccessCondition { Condition = model.Etag, Type = AccessConditionType.IfMatch } : new AccessCondition();

                var result = await documentClient.DeleteDocumentAsync(documentUri, new RequestOptions { AccessCondition = accessCondition, PartitionKey = partitionKey }).ConfigureAwait(false);

                return result.StatusCode;
            }

            return HttpStatusCode.NotFound;
        }

        public async Task<HttpStatusCode> DeleteAllAsync()
        {
            var query = documentClient.CreateDocumentQuery<T>(DocumentCollectionUri, new FeedOptions { PartitionKey = partitionKey })
                                      .AsDocumentQuery();

            var models = new List<T>();

            while (query.HasMoreResults)
            {
                var result = await query.ExecuteNextAsync<T>().ConfigureAwait(false);

                models.AddRange(result);
            }

            foreach (var result in models)
            {
                await DeleteAsync(result.DocumentId!.Value).ConfigureAwait(false);
            }

            return HttpStatusCode.OK;
        }

        private async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                await documentClient.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(cosmosDbConnection.DatabaseId)).ConfigureAwait(false);
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await documentClient.CreateDatabaseAsync(new Database { Id = cosmosDbConnection.DatabaseId }).ConfigureAwait(false);
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task CreateCollectionIfNotExistsAsync()
        {
            try
            {
                await documentClient.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(cosmosDbConnection.DatabaseId, cosmosDbConnection.CollectionId)).ConfigureAwait(false);
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    var partitionKeyDefinition = new PartitionKeyDefinition
                    {
                        Paths = new Collection<string>() { cosmosDbConnection.PartitionKey! },
                    };

                    await documentClient.CreateDocumentCollectionAsync(
                                UriFactory.CreateDatabaseUri(cosmosDbConnection.DatabaseId),
                                new DocumentCollection { Id = cosmosDbConnection.CollectionId, PartitionKey = partitionKeyDefinition },
                                new RequestOptions { OfferThroughput = 1000 }).ConfigureAwait(false);
                }
                else
                {
                    throw;
                }
            }
        }

        private Uri CreateDocumentUri(Guid documentId)
        {
            return UriFactory.CreateDocumentUri(cosmosDbConnection.DatabaseId, cosmosDbConnection.CollectionId, documentId.ToString());
        }
    }
}
