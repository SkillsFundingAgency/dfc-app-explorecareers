using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.ViewModels;

using FakeItEasy;

using FluentAssertions;

using Microsoft.AspNetCore.Mvc;

using Xunit;

namespace DFC.App.ExploreCareers.UnitTests.ControllerTests.HealthControllerTests
{
    [Trait("Category", "Health Controller Unit Tests")]
    public class HealthControllerHealthTests : BaseHealthControllerTests
    {
        [Fact]
        public async Task HealthControllerHealthReturnsSuccessWhenHealthy()
        {
            // Arrange
            bool expectedResult = true;
            using var controller = BuildHealthController(MediaTypeNames.Application.Json);

            A.CallTo(() => FakeDocumentService.PingAsync()).Returns(expectedResult);

            // Act
            var result = await controller.Health();

            // Assert
            A.CallTo(() => FakeDocumentService.PingAsync()).MustHaveHappenedOnceExactly();

            var jsonResult = Assert.IsType<OkObjectResult>(result);
            var models = Assert.IsAssignableFrom<List<HealthItemViewModel>>(jsonResult.Value);

            models.Count.Should().BeGreaterThan(0);
            models.First().Service.Should().NotBeNullOrWhiteSpace();
            models.First().Message.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public async Task HealthControllerHealthReturnsServiceUnavailableWhenUnhealthy()
        {
            // Arrange
            bool expectedResult = false;
            using var controller = BuildHealthController(MediaTypeNames.Application.Json);

            A.CallTo(() => FakeDocumentService.PingAsync()).Returns(expectedResult);

            // Act
            var result = await controller.Health();

            // Assert
            A.CallTo(() => FakeDocumentService.PingAsync()).MustHaveHappenedOnceExactly();

            var statusResult = Assert.IsType<StatusCodeResult>(result);

            A.Equals((int)HttpStatusCode.ServiceUnavailable, statusResult.StatusCode);
        }

        [Theory]
        [MemberData(nameof(HtmlMediaTypes))]
        public async Task HealthControllerViewHtmlReturnsSuccess(string mediaTypeName)
        {
            // Arrange
            bool expectedResult = true;
            var controller = BuildHealthController(mediaTypeName);

            A.CallTo(() => FakeDocumentService.PingAsync()).Returns(expectedResult);

            // Act
            var result = await controller.Health();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            _ = Assert.IsAssignableFrom<HealthViewModel>(viewResult.ViewData.Model);

            controller.Dispose();
        }

        [Theory]
        [MemberData(nameof(JsonMediaTypes))]
        public async Task HealthControllerViewJsonReturnsSuccess(string mediaTypeName)
        {
            // Arrange
            bool expectedResult = true;
            var controller = BuildHealthController(mediaTypeName);

            A.CallTo(() => FakeDocumentService.PingAsync()).Returns(expectedResult);

            // Act
            var result = await controller.Health();

            // Assert
            var jsonResult = Assert.IsType<OkObjectResult>(result);
            _ = Assert.IsAssignableFrom<IList<HealthItemViewModel>>(jsonResult.Value);

            controller.Dispose();
        }

        [Theory]
        [MemberData(nameof(InvalidMediaTypes))]
        public async Task HealthControllerHealthViewReturnsNotAcceptable(string mediaTypeName)
        {
            // Arrange
            bool expectedResult = true;
            var controller = BuildHealthController(mediaTypeName);

            A.CallTo(() => FakeDocumentService.PingAsync()).Returns(expectedResult);

            // Act
            var result = await controller.Health();

            // Assert
            var statusResult = Assert.IsType<StatusCodeResult>(result);

            A.Equals((int)HttpStatusCode.NotAcceptable, statusResult.StatusCode);

            controller.Dispose();
        }
    }
}
