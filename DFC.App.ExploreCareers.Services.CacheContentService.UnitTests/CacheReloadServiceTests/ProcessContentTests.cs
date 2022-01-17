using System;
using System.Net;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.Data.Models.CmsApiModels;
using DFC.App.ExploreCareers.Data.Models.ContentModels;

using FakeItEasy;

using Xunit;

namespace DFC.App.ExploreCareers.Services.CacheContentService.UnitTests.CacheReloadServiceTests
{
    public class ProcessContentTests : BaseCacheReloadServiceTests
    {
        [Fact]
        public async Task CacheReloadServiceProcessContentAsyncForCreateReturnsSuccess()
        {
            // Arrange
            var expectedResponse = HttpStatusCode.Created;
            var expectedValidContentItemApiDataModel = BuildValidContentItemApiDataModel();
            var expectedValidContentItemModel = BuildValidContentItemModel();
            var url = new Uri("https://somewhere.com");

            A.CallTo(() => FakeCmsApiService.GetItemAsync<CmsApiJobCategoryModel>(A<Uri>.Ignored)).Returns(expectedValidContentItemApiDataModel);
            A.CallTo(() => FakeMapper.Map<JobCategoryContentItemModel>(A<CmsApiJobCategoryModel>.Ignored)).Returns(expectedValidContentItemModel);
            A.CallTo(() => FakeDocumentService.GetByIdAsync(A<Guid>.Ignored, A<string>.Ignored)).Returns(expectedValidContentItemModel);
            A.CallTo(() => FakeDocumentService.UpsertAsync(A<JobCategoryContentItemModel>.Ignored)).Returns(HttpStatusCode.Created);

            // Act
            var result = await CacheReloadService.ProcessContentAsync(url);

            // Assert
            A.CallTo(() => FakeCmsApiService.GetItemAsync<CmsApiJobCategoryModel>(A<Uri>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeMapper.Map<JobCategoryContentItemModel>(A<CmsApiJobCategoryModel>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeDocumentService.UpsertAsync(A<JobCategoryContentItemModel>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeDocumentService.DeleteAsync(A<Guid>.Ignored)).MustNotHaveHappened();

            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task CacheReloadServiceProcessContentAsyncForUpdateReturnsSuccess()
        {
            // Arrange
            var expectedResponse = HttpStatusCode.OK;
            var expectedValidContentItemApiDataModel = BuildValidContentItemApiDataModel();
            var expectedValidContentItemModel = BuildValidContentItemModel();
            var url = new Uri("https://somewhere.com");

            A.CallTo(() => FakeCmsApiService.GetItemAsync<CmsApiJobCategoryModel>(A<Uri>.Ignored)).Returns(expectedValidContentItemApiDataModel);
            A.CallTo(() => FakeMapper.Map<JobCategoryContentItemModel>(A<CmsApiJobCategoryModel>.Ignored)).Returns(expectedValidContentItemModel);
            A.CallTo(() => FakeDocumentService.GetByIdAsync(A<Guid>.Ignored, A<string>.Ignored)).Returns(expectedValidContentItemModel);
            A.CallTo(() => FakeDocumentService.UpsertAsync(A<JobCategoryContentItemModel>.Ignored)).Returns(HttpStatusCode.OK);

            // Act
            var result = await CacheReloadService.ProcessContentAsync(url);

            // Assert
            A.CallTo(() => FakeCmsApiService.GetItemAsync<CmsApiJobCategoryModel>(A<Uri>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeMapper.Map<JobCategoryContentItemModel>(A<CmsApiJobCategoryModel>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeDocumentService.UpsertAsync(A<JobCategoryContentItemModel>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeDocumentService.DeleteAsync(A<Guid>.Ignored)).MustNotHaveHappened();

            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task CacheReloadServiceProcessContentAsyncForUpdateReturnsNoContent()
        {
            // Arrange
            var expectedResponse = HttpStatusCode.NoContent;
            var expectedValidContentItemApiDataModel = BuildValidContentItemApiDataModel();
            JobCategoryContentItemModel? expectedValidContentItemModel = default;
            var url = new Uri("https://somewhere.com");

            A.CallTo(() => FakeCmsApiService.GetItemAsync<CmsApiJobCategoryModel>(A<Uri>.Ignored)).Returns(expectedValidContentItemApiDataModel);
            A.CallTo(() => FakeMapper.Map<JobCategoryContentItemModel?>(A<CmsApiJobCategoryModel>.Ignored)).Returns(expectedValidContentItemModel);

            // Act
            var result = await CacheReloadService.ProcessContentAsync(url);

            // Assert
            A.CallTo(() => FakeCmsApiService.GetItemAsync<CmsApiJobCategoryModel>(A<Uri>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeMapper.Map<JobCategoryContentItemModel>(A<CmsApiJobCategoryModel>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeDocumentService.GetByIdAsync(A<Guid>.Ignored, A<string>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => FakeDocumentService.UpsertAsync(A<JobCategoryContentItemModel>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => FakeDocumentService.DeleteAsync(A<Guid>.Ignored)).MustNotHaveHappened();

            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task CacheReloadServiceProcessContentAsyncForUpdateReturnsBadRequest()
        {
            // Arrange
            var expectedResponse = HttpStatusCode.BadRequest;
            var expectedValidContentItemApiDataModel = BuildValidContentItemApiDataModel();
            var expectedValidContentItemModel = new JobCategoryContentItemModel();
            var url = new Uri("https://somewhere.com");

            A.CallTo(() => FakeCmsApiService.GetItemAsync<CmsApiJobCategoryModel>(A<Uri>.Ignored)).Returns(expectedValidContentItemApiDataModel);
            A.CallTo(() => FakeMapper.Map<JobCategoryContentItemModel>(A<CmsApiJobCategoryModel>.Ignored)).Returns(expectedValidContentItemModel);

            // Act
            var result = await CacheReloadService.ProcessContentAsync(url);

            // Assert
            A.CallTo(() => FakeCmsApiService.GetItemAsync<CmsApiJobCategoryModel>(A<Uri>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeMapper.Map<JobCategoryContentItemModel>(A<CmsApiJobCategoryModel>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeDocumentService.GetByIdAsync(A<Guid>.Ignored, A<string>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => FakeDocumentService.UpsertAsync(A<JobCategoryContentItemModel>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => FakeDocumentService.DeleteAsync(A<Guid>.Ignored)).MustNotHaveHappened();

            Assert.Equal(expectedResponse, result);
        }
    }
}
