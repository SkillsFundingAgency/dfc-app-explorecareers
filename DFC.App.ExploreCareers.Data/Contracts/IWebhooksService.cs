using DFC.App.ExploreCareers.Data.Enums;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.Data.Contracts
{
    public interface IWebhooksService
    {
        Task<HttpStatusCode> UpdateContentAsync();

        Task<HttpStatusCode> ProcessMessageAsync(WebhookCacheOperation webhookCacheOperation, Guid eventId, Guid contentId, Uri url);
    }
}
