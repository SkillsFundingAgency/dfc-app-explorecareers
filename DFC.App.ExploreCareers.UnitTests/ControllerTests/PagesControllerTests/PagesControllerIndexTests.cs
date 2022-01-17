using System.Net;

using DFC.App.ExploreCareers.ViewModels;

using FakeItEasy;

using Microsoft.AspNetCore.Mvc;

using Xunit;

namespace DFC.App.ExploreCareers.UnitTests.ControllerTests.PagesControllerTests
{
    [Trait("Category", "Pages Controller Unit Tests")]
    public class PagesControllerIndexTests : BasePagesControllerTests
    {
        [Theory]
        [MemberData(nameof(HtmlMediaTypes))]
        public void PagesControllerIndexHtmlReturnsSuccess(string mediaTypeName)
        {
            // Arrange
            using var controller = BuildPagesController(mediaTypeName);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IndexViewModel>(viewResult.ViewData.Model);

            A.Equals(4, model.Documents!.Count);
        }

        [Theory]
        [MemberData(nameof(JsonMediaTypes))]
        public void PagesControllerIndexJsonReturnsSuccess(string mediaTypeName)
        {
            // Arrange
            using var controller = BuildPagesController(mediaTypeName);

            // Act
            var result = controller.Index();

            // Assert
            var jsonResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IndexViewModel>(jsonResult.Value);

            A.Equals(4, model.Documents!.Count);
        }

        [Theory]
        [MemberData(nameof(InvalidMediaTypes))]
        public void PagesControllerIndexReturnsNotAcceptable(string mediaTypeName)
        {
            // Arrange
            using var controller = BuildPagesController(mediaTypeName);

            // Act
            var result = controller.Index();

            // Assert
            var statusResult = Assert.IsType<StatusCodeResult>(result);

            A.Equals((int)HttpStatusCode.NotAcceptable, statusResult.StatusCode);
        }
    }
}
