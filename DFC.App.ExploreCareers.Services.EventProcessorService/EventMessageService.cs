using DFC.App.ExploreCareers.Data.Contracts;
using DFC.Compui.Cosmos.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.Services.EventProcessorService
{
    public class EventMessageService<TModel> : IEventMessageService<TModel>
           where TModel : class, IDocumentModel
    {
        private readonly ILogger<EventMessageService<TModel>> logger;
        private readonly IDocumentService<TModel> DocumentService;

        public EventMessageService(ILogger<EventMessageService<TModel>> logger, IDocumentService<TModel> documentService)
        {
            this.logger = logger;
            this.DocumentService = documentService;
        }

        public async Task<IList<TModel>?> GetAllCachedCanonicalNamesAsync()
        {
            var serviceDataModels = await DocumentService.GetAllAsync().ConfigureAwait(false);

            return serviceDataModels.ToList();
        }

        public async Task<HttpStatusCode> CreateOrUpdateAsync(TModel? upsertDocumentModel)
        {
            if (upsertDocumentModel == null)
            {
                return HttpStatusCode.BadRequest;
            }

            var existingDocument = await DocumentService.GetByIdAsync(Guid.Empty).ConfigureAwait(false);
            if (existingDocument == null)
            {
                var createResponse = await DocumentService.UpsertAsync(upsertDocumentModel).ConfigureAwait(false);

                logger.LogInformation($"{nameof(CreateOrUpdateAsync)} has Created content for: {upsertDocumentModel.Id} with response code {createResponse}");

                return createResponse;
            }

            upsertDocumentModel.Etag = existingDocument.Etag;

            var response = await DocumentService.UpsertAsync(upsertDocumentModel).ConfigureAwait(false);

            logger.LogInformation($"{nameof(CreateOrUpdateAsync)} has upserted content for: {upsertDocumentModel.Id} with response code {response}");

            return response;
        }

        public async Task<HttpStatusCode> DeleteAsync(Guid id)
        {
            var isDeleted = await DocumentService.DeleteAsync(id).ConfigureAwait(false);

            if (isDeleted)
            {
                logger.LogInformation($"{nameof(DeleteAsync)} has deleted content for document Id: {id}");
                return HttpStatusCode.OK;
            }
            else
            {
                logger.LogWarning($"{nameof(DeleteAsync)} has returned no content for: {id}");
                return HttpStatusCode.NotFound;
            }
        }

        public async Task<HttpStatusCode> DeleteAllAsync()
        {
            var existingDocument = await DocumentService.GetAllAsync().ConfigureAwait(false);

            if (existingDocument != null && existingDocument.Any())
            {
                foreach (var documentModel in existingDocument.ToList())
                {
                    await DocumentService.DeleteAsync(documentModel.Id).ConfigureAwait(false);
                }
            }

            logger.LogInformation($"{nameof(DeleteAllAsync)} All Documents Deleted");

            return HttpStatusCode.OK;
        }
    }
}
