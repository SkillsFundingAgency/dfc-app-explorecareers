using DFC.App.ExploreCareers.Data.Contracts;
using DFC.App.ExploreCareers.Data.Enums;
using DFC.App.ExploreCareers.Data.Models;
using DFC.Compui.Cosmos.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DFC.App.ExploreCareers.ApiService.Extensions;

namespace DFC.App.ExploreCareers.Services.CacheContentService
{
    public class WebhooksService : IWebhooksService
    {
        private readonly ILogger<WebhooksService> logger;
        private readonly AutoMapper.IMapper mapper;
        private readonly IEventMessageService<JobCategory> eventMessageService;
        private readonly IApiExtensions apiExtensions;

        public WebhooksService(
            ILogger<WebhooksService> logger,
            AutoMapper.IMapper mapper,
            IEventMessageService<JobCategory> eventMessageService, IApiExtensions apiExtensions)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.eventMessageService = eventMessageService;
            this.apiExtensions = apiExtensions;
        }

        public async Task<HttpStatusCode> ProcessMessageAsync(WebhookCacheOperation webhookCacheOperation, Guid eventId, Guid contentId, Uri url)
        {
            switch (webhookCacheOperation)
            {
                case WebhookCacheOperation.Delete:
                case WebhookCacheOperation.CreateOrUpdate:
                    return await UpdateContentAsync().ConfigureAwait(false);
                default:
                    logger.LogError($"Event Id: {eventId} got unknown cache operation - {webhookCacheOperation}");
                    return HttpStatusCode.BadRequest;
            }
        }


        public async Task<HttpStatusCode> UpdateContentAsync()
        {
            var jobCategory = await apiExtensions.LoadDataAsync().ConfigureAwait(false);
            await eventMessageService.DeleteAllAsync().ConfigureAwait(false);
            if (string.IsNullOrEmpty(jobCategory))
            {
                return HttpStatusCode.BadRequest;
            }

            var result = await eventMessageService.CreateOrUpdateAsync(new JobCategory
                { Id = Guid.NewGuid(), Html = jobCategory, Version = Guid.NewGuid() }).ConfigureAwait(false);

            return result;
        }
    }
}
