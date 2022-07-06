using System;

using DFC.App.ExploreCareers.Data.Contracts;
using DFC.App.ExploreCareers.Data.Models.ContentModels;
using DFC.Compui.Cosmos.Contracts;

using FakeItEasy;

using Microsoft.Extensions.Logging;

namespace DFC.App.ExploreCareers.Services.CacheContentService.UnitTests.WebhooksServiceTests
{
    public abstract class BaseWebhooksServiceTests
    {
        protected const string EventTypePublished = "published";
        protected const string EventTypeDraft = "draft";
        protected const string EventTypeDraftDiscarded = "draft-discarded";
        protected const string EventTypeDeleted = "deleted";
        protected const string EventTypeUnpublished = "unpublished";

        protected BaseWebhooksServiceTests()
        {
            Logger = A.Fake<ILogger<WebhooksService>>();
            FakeCacheReloadService = A.Fake<ICacheReloadService>();
            FakeSharedContentItemDocumentService = A.Fake<IDocumentService<JobCategoryContentItemModel>>();
        }

        protected Guid ContentIdForCreate { get; } = Guid.NewGuid();

        protected Guid ContentIdForUpdate { get; } = Guid.NewGuid();

        protected Guid ContentIdForDelete { get; } = Guid.NewGuid();

        protected ILogger<WebhooksService> Logger { get; }

        protected ICacheReloadService FakeCacheReloadService { get; }

        protected IDocumentService<JobCategoryContentItemModel> FakeSharedContentItemDocumentService { get; }

        protected WebhooksService BuildWebhooksService()
        {
            var service = new WebhooksService(Logger, FakeCacheReloadService, FakeSharedContentItemDocumentService);

            return service;
        }
    }
}
