using System;

using AutoMapper;

using DFC.App.ExploreCareers.Data.Models.CmsApiModels;
using DFC.App.ExploreCareers.Data.Models.ContentModels;
using DFC.Compui.Cosmos.Contracts;
using DFC.Content.Pkg.Netcore.Data.Contracts;

using FakeItEasy;

using Microsoft.Extensions.Logging;

namespace DFC.App.ExploreCareers.Services.CacheContentService.UnitTests.CacheReloadServiceTests
{
    public abstract class BaseCacheReloadServiceTests
    {
        protected BaseCacheReloadServiceTests()
        {
            FakeMapper = A.Fake<IMapper>();
            FakeDocumentService = A.Fake<IDocumentService<JobCategoryContentItemModel>>();
            FakeCmsApiService = A.Fake<ICmsApiService>();
            FakeContentTypeMappingService = A.Fake<IContentTypeMappingService>();
            FakeApiCacheService = A.Fake<IApiCacheService>();
            CacheReloadService = new CacheReloadService(A.Fake<ILogger<CacheReloadService>>(), FakeMapper, FakeDocumentService, FakeContentTypeMappingService, FakeApiCacheService, FakeCmsApiService);
        }

        protected Guid ContentIdForUpdate { get; } = Guid.NewGuid();

        protected IMapper FakeMapper { get; }

        protected IDocumentService<JobCategoryContentItemModel> FakeDocumentService { get; }

        protected ICmsApiService FakeCmsApiService { get; }

        protected IContentTypeMappingService FakeContentTypeMappingService { get; }

        protected IApiCacheService FakeApiCacheService { get; }

        protected CacheReloadService CacheReloadService { get; }

        protected static CmsApiJobCategoryModel BuildValidContentItemApiDataModel()
        {
            var model = new CmsApiJobCategoryModel
            {
                Title = "an-article",
                Url = new Uri("https://localhost"),
                CanonicalName = "an-article",
                Published = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow,
            };

            return model;
        }

        protected JobCategoryContentItemModel BuildValidContentItemModel()
        {
            var model = new JobCategoryContentItemModel()
            {
                Id = ContentIdForUpdate,
                Etag = Guid.NewGuid().ToString(),
                Title = "an-article",
                CanonicalName = "an-article",
                PageLocation = "/an-article"
            };

            return model;
        }
    }
}
