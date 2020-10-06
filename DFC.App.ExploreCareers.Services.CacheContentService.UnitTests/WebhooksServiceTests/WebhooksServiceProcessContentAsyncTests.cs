using DFC.App.ExploreCareers.Data.Models;
using FakeItEasy;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DFC.App.ExploreCareers.Services.CacheContentService.UnitTests.WebhooksServiceTests
{
    [Trait("Category", "Webhooks Service ProcessContentAsync Unit Tests")]
    public class WebhooksServiceProcessContentAsyncTests : BaseWebhooksServiceTests
    {
        [Fact]
        public async Task WebhooksServiceProcessContentAsyncForCreateAndUpdateReturnsSuccess()
        {
            // Arrange
            const HttpStatusCode expectedResponse = HttpStatusCode.Created;
            var expectedValidApiContentModel = BuildValidJobCategoryHtmlString();
            var url = new Uri("https://somewhere.com");
            var service = BuildWebhooksService();

            A.CallTo(() => FakeApiExtensions.LoadDataAsync()).Returns(expectedValidApiContentModel);
            A.CallTo(() => FakeEventMessageService.DeleteAllAsync()).Returns(HttpStatusCode.OK);
            A.CallTo(() => FakeEventMessageService.CreateOrUpdateAsync(A<JobCategory>.Ignored)).Returns(HttpStatusCode.Created);

            // Act
            var result = await service.UpdateContentAsync().ConfigureAwait(false);

            // Assert
            A.CallTo(() => FakeApiExtensions.LoadDataAsync()).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeEventMessageService.DeleteAllAsync()).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeEventMessageService.CreateOrUpdateAsync(A<JobCategory>.Ignored)).MustHaveHappenedOnceExactly();

            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task WebhooksServiceProcessContentAsyncForUpdateReturnsBadRequest()
        {
            // Arrange
            const HttpStatusCode expectedResponse = HttpStatusCode.BadRequest;
            var expectedValidApiContentModel = BuildValidJobCategoryHtmlString();
            var url = new Uri("https://somewhere.com");
            var service = BuildWebhooksService();

            A.CallTo(() => FakeApiExtensions.LoadDataAsync()).Returns(string.Empty);

            // Act
            var result = await service.UpdateContentAsync().ConfigureAwait(false);

            // Assert
            A.CallTo(() => FakeApiExtensions.LoadDataAsync()).MustHaveHappenedOnceExactly();
            A.CallTo(() => FakeEventMessageService.DeleteAllAsync()).Returns(HttpStatusCode.OK);
            A.CallTo(() => FakeEventMessageService.CreateOrUpdateAsync(A<JobCategory>.Ignored)).MustNotHaveHappened();

            Assert.Equal(expectedResponse, result);
        }
    }
}
