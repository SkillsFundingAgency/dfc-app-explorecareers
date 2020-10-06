using DFC.App.ExploreCareers.Data.Enums;
using DFC.App.ExploreCareers.Data.Models;
using FakeItEasy;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DFC.App.ExploreCareers.Services.CacheContentService.UnitTests.WebhooksServiceTests
{
    [Trait("Category", "Webhooks Service ProcessMessageAsync Unit Tests")]
    public class WebhooksServiceProcessMessageTests : BaseWebhooksServiceTests
    {
        [Fact]
        public async Task WebhooksServiceProcessMessageAsyncNoneOptionReturnsSuccess()
        {
            // Arrange
            const HttpStatusCode expectedResponse = HttpStatusCode.BadRequest;
            var url = new Uri("https://somewhere.com");
            var service = BuildWebhooksService();

            // Act
            var result = await service.ProcessMessageAsync(WebhookCacheOperation.None, Guid.NewGuid(), ContentIdForCreate, url).ConfigureAwait(false);

            // Assert
            A.CallTo(() => FakeApiExtensions.LoadDataAsync()).MustNotHaveHappened();
            A.CallTo(() => FakeEventMessageService.DeleteAllAsync()).MustNotHaveHappened();
            A.CallTo(() => FakeEventMessageService.CreateOrUpdateAsync(A<JobCategory>.Ignored)).MustNotHaveHappened();

            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task WebhooksServiceProcessMessageAsyncContentUpdateReturnsSuccess()
        {
            // Arrange
            const HttpStatusCode expectedResponse = HttpStatusCode.OK;
            var url = new Uri("https://somewhere.com");
            var service = BuildWebhooksService();

            A.CallTo(() => FakeApiExtensions.LoadDataAsync()).Returns(BuildValidJobCategoryHtmlString());
            A.CallTo(() => FakeEventMessageService.DeleteAllAsync()).Returns(HttpStatusCode.OK);
            A.CallTo(() => FakeEventMessageService.CreateOrUpdateAsync(A<JobCategory>.Ignored)).Returns(HttpStatusCode.OK);

            // Act
            var result = await service.ProcessMessageAsync(WebhookCacheOperation.CreateOrUpdate, Guid.NewGuid(), ContentIdForUpdate, url).ConfigureAwait(false);

            // Assert
            A.CallTo(() => FakeApiExtensions.LoadDataAsync()).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeEventMessageService.DeleteAllAsync()).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeEventMessageService.CreateOrUpdateAsync(A<JobCategory>.Ignored)).MustHaveHappenedOnceExactly();
            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task WebhooksServiceProcessMessageAsyncContentDeleteReturnsSuccess()
        {
            // Arrange
            const HttpStatusCode expectedResponse = HttpStatusCode.OK;
            var url = new Uri("https://somewhere.com");
            var service = BuildWebhooksService();

            A.CallTo(() => FakeApiExtensions.LoadDataAsync()).Returns(BuildValidJobCategoryHtmlString());
            A.CallTo(() => FakeEventMessageService.DeleteAllAsync()).Returns(HttpStatusCode.OK);
            A.CallTo(() => FakeEventMessageService.CreateOrUpdateAsync(A<JobCategory>.Ignored)).Returns(HttpStatusCode.OK);

            // Act
            var result = await service.ProcessMessageAsync(WebhookCacheOperation.Delete, Guid.NewGuid(), ContentIdForDelete, url).ConfigureAwait(false);

            // Assert
            A.CallTo(() => FakeApiExtensions.LoadDataAsync()).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeEventMessageService.DeleteAllAsync()).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeEventMessageService.CreateOrUpdateAsync(A<JobCategory>.Ignored)).MustHaveHappenedOnceExactly();

            Assert.Equal(expectedResponse, result);
        }
    }
}
