using System.Net.Mime;

using DFC.App.ExploreCareers.Controllers;
using DFC.App.ExploreCareers.ViewModels;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

using Xunit;

namespace DFC.App.ExploreCareers.UnitTests.ControllerTests
{
    [Trait("Category", "Home Controller Unit Tests")]
    public class HomeControllerTests
    {
        [Fact]
        public void HomeControllerErrorTestsReturnsSuccess()
        {
            // Arrange
            using var controller = BuildHomeController(MediaTypeNames.Text.Html);

            // Act
            var result = controller.Error();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            _ = Assert.IsAssignableFrom<ErrorViewModel>(viewResult.ViewData.Model);
        }

        private HomeController BuildHomeController(string mediaTypeName)
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers[HeaderNames.Accept] = mediaTypeName;

            var controller = new HomeController()
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                },
            };

            return controller;
        }
    }
}
