using System.Net.Mime;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.Controllers;
using DFC.App.ExploreCareers.Cosmos;

using FakeItEasy;

using FluentAssertions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Xunit;

namespace DFC.App.ExploreCareers.UnitTests.ControllerTests
{
    [Trait("Category", "Sitemap Controller Unit Tests")]
    public class SitemapControllerTests
    {
        private ILogger<SitemapController> FakeLogger { get; } = A.Fake<ILogger<SitemapController>>();

        private IJobCategoryDocumentService FakeDocumentService { get; } = A.Fake<IJobCategoryDocumentService>();

        [Fact]
        public async Task SitemapControllerSitemapReturnsSuccess()
        {
            // Arrange
            using var controller = BuildSitemapController();

            // Act
            var result = await controller.Sitemap();

            // Assert
            var contentResult = Assert.IsType<ContentResult>(result);

            contentResult.ContentType.Should().Be(MediaTypeNames.Application.Xml);
        }

        private SitemapController BuildSitemapController()
        {
            var controller = new SitemapController(FakeLogger, FakeDocumentService)
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
