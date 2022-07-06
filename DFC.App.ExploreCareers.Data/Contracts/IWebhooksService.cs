using System;
using System.Net;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.Data.Enums;

namespace DFC.App.ExploreCareers.Data.Contracts
{
    public interface IWebhooksService
    {
        Task<HttpStatusCode> ProcessMessageAsync(WebhookCacheOperation webhookCacheOperation, Guid eventId, Guid contentId, string apiEndpoint);
    }
}
