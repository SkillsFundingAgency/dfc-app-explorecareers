using System.Net.Mime;

using DFC.App.ExploreCareers.Controllers;

using FakeItEasy;

using FluentAssertions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Xunit;

namespace DFC.App.ExploreCareers.UnitTests.ControllerTests
{
    [Trait("Category", "Robot Controller Unit Tests")]
    public class RobotControllerTests
    {
        private ILogger<RobotController> FakeLogger { get; } = A.Fake<ILogger<RobotController>>();

        private IWebHostEnvironment FakeHostingEnvironment { get; } = A.Fake<IWebHostEnvironment>();

        [Fact]
        public void RobotControllerRobotReturnsSuccess()
        {
            // Arrange
            using var controller = BuildRobotController();

            // Act
            var result = controller.Robot();

            // Assert
            var contentResult = Assert.IsType<ContentResult>(result);

            contentResult.ContentType.Should().Be(MediaTypeNames.Text.Plain);
        }

        private RobotController BuildRobotController()
        {
            var controller = new RobotController(FakeLogger, FakeHostingEnvironment)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext(),
                },
            };

            return controller;
        }
    }
}
