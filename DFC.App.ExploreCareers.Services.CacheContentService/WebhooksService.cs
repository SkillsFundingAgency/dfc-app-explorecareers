using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.Data.Contracts;
using DFC.App.ExploreCareers.Data.Enums;
using DFC.App.ExploreCareers.Data.Models.ContentModels;
using DFC.Compui.Cosmos.Contracts;

using Microsoft.Extensions.Logging;

namespace DFC.App.ExploreCareers.Services.CacheContentService
{
    public class WebhooksService : IWebhooksService
    {
        private readonly ILogger<WebhooksService> logger;
        private readonly ICacheReloadService cacheService;
        private readonly IDocumentService<JobCategoryContentItemModel> documentService;

        public WebhooksService(
            ILogger<WebhooksService> logger,
            ICacheReloadService cacheService,
            IDocumentService<JobCategoryContentItemModel> documentService)
        {
            this.logger = logger;
            this.cacheService = cacheService;
            this.documentService = documentService;
        }

        public async Task<HttpStatusCode> ProcessMessageAsync(WebhookCacheOperation webhookCacheOperation, Guid eventId, Guid contentId, string apiEndpoint)
        {
            switch (webhookCacheOperation)
            {
                case WebhookCacheOperation.Delete:
                    return await DeleteContentAsync(contentId);

                case WebhookCacheOperation.CreateOrUpdate:
                    if (!Uri.TryCreate(apiEndpoint, UriKind.Absolute, out Uri? url))
                    {
                        throw new InvalidDataException($"Invalid Api url '{apiEndpoint}' received for Event Id: {eventId}");
                    }

                    return await cacheService.ProcessContentAsync(url);

                default:
                    logger.LogError($"Event Id: {eventId} got unknown cache operation - {webhookCacheOperation}");
                    return HttpStatusCode.BadRequest;
            }
        }

        public async Task<HttpStatusCode> DeleteContentAsync(Guid contentId)
        {
            var result = await documentService.DeleteAsync(contentId);

            return result ? HttpStatusCode.OK : HttpStatusCode.NoContent;
        }
    }
}
