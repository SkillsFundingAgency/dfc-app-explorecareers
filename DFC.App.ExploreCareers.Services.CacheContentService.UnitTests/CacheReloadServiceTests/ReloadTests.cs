using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.Data.Models.CmsApiModels;
using DFC.App.ExploreCareers.Data.Models.ContentModels;

using FakeItEasy;

using Xunit;

namespace DFC.App.ExploreCareers.Services.CacheContentService.UnitTests.CacheReloadServiceTests
{
    public class ReloadTests : BaseCacheReloadServiceTests
    {
        [Fact]
        public async Task CacheReloadServiceReloadAllCancellationRequestedCancels()
        {
            //Arrange
            var cancellationToken = new CancellationToken(true);

            //Act
            await CacheReloadService.Reload(cancellationToken);

            //Assert
            A.CallTo(() => FakeCmsApiService.GetSummaryAsync<CmsApiSummaryItemModel>()).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeCmsApiService.GetItemAsync<CmsApiJobCategoryModel>(A<string>.Ignored, A<Guid>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => FakeDocumentService.UpsertAsync(A<JobCategoryContentItemModel>.Ignored)).MustNotHaveHappened();
        }

        [Fact]
        public async Task CacheReloadServiceReloadAllReloadsItems()
        {
            //Arrange
            var dummyContentItem = A.Dummy<CmsApiJobCategoryModel>();
            var expectedValidContentItemModel = BuildValidContentItemModel();

            var list = new List<CmsApiSummaryItemModel> { new CmsApiSummaryItemModel { Title = "Some Title", Url = new Uri("http://sample.com") } };
            A.CallTo(() => FakeCmsApiService.GetSummaryAsync<CmsApiSummaryItemModel>()).Returns(list);
            A.CallTo(() => FakeMapper.Map<JobCategoryContentItemModel>(A<CmsApiJobCategoryModel>.Ignored)).Returns(expectedValidContentItemModel);
            A.CallTo(() => FakeCmsApiService.GetItemAsync<CmsApiJobCategoryModel>(A<Uri>.Ignored)).Returns(dummyContentItem);

            //Act
            await CacheReloadService.Reload(CancellationToken.None);

            //Assert
            A.CallTo(() => FakeCmsApiService.GetSummaryAsync<CmsApiSummaryItemModel>()).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeCmsApiService.GetItemAsync<CmsApiJobCategoryModel>(A<Uri>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeDocumentService.UpsertAsync(A<JobCategoryContentItemModel>.Ignored)).MustHaveHappenedOnceExactly();
        }
    }
}
