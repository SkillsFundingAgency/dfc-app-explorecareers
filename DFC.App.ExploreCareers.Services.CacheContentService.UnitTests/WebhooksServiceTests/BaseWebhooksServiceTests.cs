using DFC.App.ExploreCareers.Data.Contracts;
using DFC.App.ExploreCareers.Data.Models;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using DFC.App.ExploreCareers.ApiService.Extensions;
using DFC.App.ExploreCareers.PageService;

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
            FakeEventMessageService = A.Fake<IEventMessageService<JobCategory>>();
            FakeMapper = A.Fake<AutoMapper.IMapper>();
            FakeApiExtensions = A.Fake<IApiExtensions>();

        }

        protected Guid ContentIdForCreate { get; } = Guid.NewGuid();

        protected Guid ContentIdForUpdate { get; } = Guid.NewGuid();

        protected Guid ContentIdForDelete { get; } = Guid.NewGuid();
        
        protected ILogger<WebhooksService> Logger { get; }

        protected IApiExtensions FakeApiExtensions { get; }

        protected IEventMessageService<JobCategory> FakeEventMessageService { get; }

        protected AutoMapper.IMapper FakeMapper { get; }

        protected static string BuildValidJobCategoryHtmlString()
        {
            return "<div>testing<div>";
        }

        protected WebhooksService BuildWebhooksService()
        {
            var service = new WebhooksService(Logger, FakeMapper, FakeEventMessageService, FakeApiExtensions);

            return service;
        }
    }
}