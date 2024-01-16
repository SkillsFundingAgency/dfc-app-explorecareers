using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.Controllers;
using DFC.App.ExploreCareers.GraphQl;
using DFC.App.ExploreCareers.ViewModels;
using DFC.App.ExploreCareers.ViewModels.ExploreCareers;

using FakeItEasy;

using FluentAssertions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

using Xunit;

using static DFC.App.ExploreCareers.UnitTests.TestData.TestDataFactory;

namespace DFC.App.ExploreCareers.UnitTests.ControllerTests
{
    public class ExploreCareersControllerTests
    {
        private ILogger<ExploreCareersController> FakeLogger { get; } = A.Fake<ILogger<ExploreCareersController>>();

        private IGraphQlService FakeGraphQlService { get; } = A.Fake<IGraphQlService>();

        [Fact]
        public void ExploreCareersHeadReturnsHtml()
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);

            // Act
            var result = controller.Head();

            // Assert
            var viewModel = result.Should().BeOfType<ViewResult>()
                .Which.ViewData.Model.Should().BeOfType<HeadViewModel>()
                .Which;

            viewModel.Title.Should().Be(ExploreCareersController.DefaultPageTitleSuffix);
            viewModel.CanonicalUrl!.OriginalString.Should().Be("/explore-careers");
        }

        [Fact]
        public void ExploreCareersBodyTopReturnsHtml()
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);

            // Act
            var result = controller.BodyTop();

            // Assert
            result.Should().BeOfType<ViewResult>()
                .Which.ViewData.Model.Should().BeNull();
        }

        [Fact]
        public async Task ExploreCareersBodyReturnsHtml()
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);

            var model = BuildJobCategoryContentItemModel();
            var expectedViewModel = BuildJobCategoryViewModel();
            A.CallTo(() => FakeGraphQlService.GetJobCategoriesAsync()).Returns(new List<JobCategoryViewModel> { expectedViewModel });

            var result = await controller.BodyAsync();

            // Assert
            var viewModel = result.Should().BeOfType<ViewResult>()
                .Which.ViewData.Model.Should().BeOfType<BodyViewModel>()
                .Which;

            viewModel.JobCategories.Should().NotBeNullOrEmpty();
            var jobCategory = viewModel.JobCategories![0];
            jobCategory.Name.Should().Be(expectedViewModel.Name);
            jobCategory.CanonicalName.Should().Be(expectedViewModel.CanonicalName);

            A.CallTo(() => FakeGraphQlService.GetJobCategoriesAsync()).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task ExploreCareersDocumentReturnsHtml()
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);

            var model = BuildJobCategoryContentItemModel();
            var expectedViewModel = BuildJobCategoryViewModel();
            A.CallTo(() => FakeGraphQlService.GetJobCategoriesAsync()).Returns(new List<JobCategoryViewModel> { expectedViewModel });

            var result = await controller.DocumentAsync();

            // Assert
            var viewModel = result.Should().BeOfType<ViewResult>()
                .Which.ViewData.Model.Should().BeOfType<DocumentViewModel>()
                .Which;

            viewModel.Body.Should().NotBeNull();
            viewModel.Head.Should().NotBeNull();

            A.CallTo(() => FakeGraphQlService.GetJobCategoriesAsync()).MustHaveHappenedOnceExactly();
        }

        private ExploreCareersController BuildController(string mediaTypeName)
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers[HeaderNames.Accept] = mediaTypeName;

            var controller = new ExploreCareersController(FakeLogger, FakeGraphQlService)
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
