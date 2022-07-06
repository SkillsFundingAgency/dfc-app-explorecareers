using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.Data.Enums;
using DFC.App.ExploreCareers.Data.Models.ContentModels;

using FakeItEasy;

using Xunit;

namespace DFC.App.ExploreCareers.Services.CacheContentService.UnitTests.WebhooksServiceTests
{
    [Trait("Category", "Webhooks Service ProcessMessageAsync Unit Tests")]
    public class ProcessMessageTests : BaseWebhooksServiceTests
    {
        [Fact]
        public async Task WebhooksServiceProcessMessageAsyncNoneOptionReturnsSuccess()
        {
            // Arrange
            const HttpStatusCode expectedResponse = HttpStatusCode.BadRequest;
            var url = "https://somewhere.com";
            var service = BuildWebhooksService();

            // Act
            var result = await service.ProcessMessageAsync(WebhookCacheOperation.None, Guid.NewGuid(), ContentIdForCreate, url);

            // Assert
            A.CallTo(() => FakeCacheReloadService.ProcessContentAsync(A<Uri>.Ignored, A<CancellationToken>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => FakeSharedContentItemDocumentService.DeleteAsync(A<Guid>.Ignored)).MustNotHaveHappened();

            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task WebhooksServiceProcessMessageAsyncContentThrowsErrorForInvalidUrl()
        {
            // Arrange
            var url = "/somewhere.com";
            var service = BuildWebhooksService();

            A.CallTo(() => FakeSharedContentItemDocumentService.UpsertAsync(A<JobCategoryContentItemModel>.Ignored)).Returns(HttpStatusCode.Created);

            // Act
            await Assert.ThrowsAsync<InvalidDataException>(async () => await service.ProcessMessageAsync(WebhookCacheOperation.CreateOrUpdate, Guid.NewGuid(), ContentIdForCreate, url));
        }

        [Fact]
        public async Task WebhooksServiceProcessMessageAsyncContentCreateReturnsSuccess()
        {
            // Arrange
            const HttpStatusCode expectedResponse = HttpStatusCode.Created;
            var url = "https://somewhere.com";
            var service = BuildWebhooksService();

            A.CallTo(() => FakeCacheReloadService.ProcessContentAsync(A<Uri>.Ignored, A<CancellationToken>.Ignored)).Returns(HttpStatusCode.Created);

            // Act
            var result = await service.ProcessMessageAsync(WebhookCacheOperation.CreateOrUpdate, Guid.NewGuid(), ContentIdForCreate, url);

            // Assert
            A.CallTo(() => FakeCacheReloadService.ProcessContentAsync(A<Uri>.Ignored, A<CancellationToken>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeSharedContentItemDocumentService.DeleteAsync(A<Guid>.Ignored)).MustNotHaveHappened();

            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task WebhooksServiceProcessMessageAsyncContentUpdateReturnsSuccess()
        {
            // Arrange
            const HttpStatusCode expectedResponse = HttpStatusCode.OK;
            var url = "https://somewhere.com";
            var service = BuildWebhooksService();

            A.CallTo(() => FakeCacheReloadService.ProcessContentAsync(A<Uri>.Ignored, A<CancellationToken>.Ignored)).Returns(HttpStatusCode.OK);

            // Act
            var result = await service.ProcessMessageAsync(WebhookCacheOperation.CreateOrUpdate, Guid.NewGuid(), ContentIdForUpdate, url);

            // Assert
            A.CallTo(() => FakeCacheReloadService.ProcessContentAsync(A<Uri>.Ignored, A<CancellationToken>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeSharedContentItemDocumentService.DeleteAsync(A<Guid>.Ignored)).MustNotHaveHappened();

            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task WebhooksServiceProcessMessageAsyncContentDeleteReturnsSuccess()
        {
            // Arrange
            const HttpStatusCode expectedResponse = HttpStatusCode.OK;
            var url = "https://somewhere.com";
            var service = BuildWebhooksService();

            A.CallTo(() => FakeSharedContentItemDocumentService.DeleteAsync(A<Guid>.Ignored)).Returns(true);

            // Act
            var result = await service.ProcessMessageAsync(WebhookCacheOperation.Delete, Guid.NewGuid(), ContentIdForDelete, url);

            // Assert
            A.CallTo(() => FakeCacheReloadService.ProcessContentAsync(A<Uri>.Ignored, A<CancellationToken>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => FakeSharedContentItemDocumentService.DeleteAsync(A<Guid>.Ignored)).MustHaveHappenedOnceExactly();

            Assert.Equal(expectedResponse, result);
        }
    }
}
