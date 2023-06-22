using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.Data.Contracts;
using DFC.App.ExploreCareers.Data.Models.CmsApiModels;
using DFC.App.ExploreCareers.Data.Models.ContentModels;
using DFC.Compui.Cosmos.Contracts;
using DFC.Content.Pkg.Netcore.Data.Contracts;

using Microsoft.Extensions.Logging;

namespace DFC.App.ExploreCareers.Services.CacheContentService
{
    public class CacheReloadService : ICacheReloadService
    {
        private readonly ILogger<CacheReloadService> logger;
        private readonly AutoMapper.IMapper mapper;
        private readonly IDocumentService<JobCategoryContentItemModel> documentService;
        private readonly IContentTypeMappingService contentTypeMappingService;
        private readonly IApiCacheService apiCacheService;
        private readonly ICmsApiService cmsApiService;

        public CacheReloadService(
            ILogger<CacheReloadService> logger,
            AutoMapper.IMapper mapper,
            IDocumentService<JobCategoryContentItemModel> documentService,
            IContentTypeMappingService contentTypeMappingService,
            IApiCacheService apiCacheService,
            ICmsApiService cmsApiService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.documentService = documentService;
            this.contentTypeMappingService = contentTypeMappingService;
            this.apiCacheService = apiCacheService;
            this.cmsApiService = cmsApiService;
        }

        public async Task Reload(CancellationToken stoppingToken)
        {
            try
            {
                logger.LogInformation("Reload cache started");

                contentTypeMappingService.AddMapping("Jobprofilecategory", typeof(CmsApiJobCategoryModel));

                apiCacheService.StartCache();

                var summaryList = await GetSummaryListAsync();

                if (stoppingToken.IsCancellationRequested)
                {
                    logger.LogWarning("Reload cache cancelled");

                    return;
                }

                if (summaryList.Count > 0)
                {
                    await ProcessSummaryListAsync(summaryList, stoppingToken);
                }

                logger.LogInformation("Reload cache completed");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in cache reload");
                throw;
            }
            finally
            {
                apiCacheService.StopCache();
            }

            async Task<IList<CmsApiSummaryItemModel>> GetSummaryListAsync()
            {
                logger.LogInformation("Get summary list");

                var summaryList = await cmsApiService.GetSummaryAsync<CmsApiSummaryItemModel>();

                logger.LogInformation("Get summary list completed");

                return summaryList ?? Array.Empty<CmsApiSummaryItemModel>();
            }

            async Task ProcessSummaryListAsync(IList<CmsApiSummaryItemModel> summaryList, CancellationToken stoppingToken)
            {
                logger.LogInformation("Process summary list started");

                //We need delete only necessary not delete all
                var listdoc = await documentService.GetAllAsync();

                if (listdoc != null)
                {
                    foreach (var doc in listdoc)
                    {
                        if (!summaryList.Select(sl => sl.Title).Contains(doc.Title))
                        {
                            await documentService.DeleteAsync(doc.Id);
                        }
                    }
                }

                foreach (var item in summaryList)
                {
                    await ProcessContentAsync(item.Url!, stoppingToken);
                }

                logger.LogInformation("Process summary list completed");
            }
        }

        public async Task<HttpStatusCode> ProcessContentAsync(Uri url, CancellationToken stoppingToken = default)
        {
            try
            {
                logger.LogInformation($"Get details for {url}");

                var apiDataModel = await cmsApiService.GetItemAsync<CmsApiJobCategoryModel>(url);
                var jobCategoryModel = mapper.Map<JobCategoryContentItemModel>(apiDataModel);

                if (jobCategoryModel is null)
                {
                    logger.LogWarning($"No details returned from {url}");
                    return HttpStatusCode.NoContent;
                }

                if (stoppingToken.IsCancellationRequested)
                {
                    logger.LogWarning($"{nameof(ProcessContentAsync)} cancelled.");
                    return HttpStatusCode.NoContent;
                }

                if (!TryValidateModel(jobCategoryModel))
                {
                    return HttpStatusCode.BadRequest;
                }

                logger.LogInformation($"Updating cache with {url}");

                return await documentService.UpsertAsync(jobCategoryModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error in {nameof(ProcessContentAsync)} for {url}");
                return HttpStatusCode.InternalServerError;
            }
        }

        public bool TryValidateModel(JobCategoryContentItemModel? contentItemModel)
        {
            _ = contentItemModel ?? throw new ArgumentNullException(nameof(contentItemModel));

            var validationContext = new ValidationContext(contentItemModel, null, null);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(contentItemModel, validationContext, validationResults, true);

            if (!isValid && validationResults.Any())
            {
                foreach (var validationResult in validationResults)
                {
                    logger.LogError($"Error validating {contentItemModel.Title} - {contentItemModel.CanonicalName}: {string.Join(",", validationResult.MemberNames)} - {validationResult.ErrorMessage}");
                }
            }

            return isValid;
        }
    }
}