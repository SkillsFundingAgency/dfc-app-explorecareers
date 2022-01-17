using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.Data.Models.ContentModels;
using DFC.App.ExploreCareers.ViewModels;

using FakeItEasy;

using FluentAssertions;

using Microsoft.AspNetCore.Mvc;

using Xunit;

namespace DFC.App.ExploreCareers.UnitTests.ControllerTests.ExploreCareersControllerTests
{
    public class HeadRouteTests : BaseControllerTests
    {
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

            viewModel.Title.Should().Be("Explore Careers | National Careers Service");
            viewModel.CanonicalUrl!.OriginalString.Should().Be("/explore-careers");
        }

        [Fact]
        public async Task ExploreCareersBodyReturnsHtml()
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);

            var model = BuildValidContentItemModel();
            var expectedViewModel = BuildValidViewModel();
            A.CallTo(() => FakeDocumentService.GetAllAsync(A<string>.Ignored)).Returns(new List<JobCategoryContentItemModel>() { model });
            A.CallTo(() => FakeMapper.Map<List<JobCategoryViewModel>>(A<IEnumerable<JobCategoryContentItemModel>>.Ignored)).Returns(new List<JobCategoryViewModel> { expectedViewModel });

            var result = await controller.BodyAsync();

            // Assert
            var viewModel = result.Should().BeOfType<ViewResult>()
                .Which.ViewData.Model.Should().BeOfType<BodyViewModel>()
                .Which;

            viewModel.JobCategories.Should().NotBeNullOrEmpty();
            var jobCategory = viewModel.JobCategories![0];
            jobCategory.Name.Should().Be(expectedViewModel.Name);
            jobCategory.CanonicalName.Should().Be(expectedViewModel.CanonicalName);

            A.CallTo(() => FakeDocumentService.GetAllAsync(null)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task ExploreCareersDocumentReturnsHtml()
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);

            var model = BuildValidContentItemModel();
            var expectedViewModel = BuildValidViewModel();
            A.CallTo(() => FakeDocumentService.GetAllAsync(A<string>.Ignored)).Returns(new List<JobCategoryContentItemModel>() { model });
            A.CallTo(() => FakeMapper.Map<List<JobCategoryViewModel>>(A<IEnumerable<JobCategoryContentItemModel>>.Ignored)).Returns(new List<JobCategoryViewModel> { expectedViewModel });

            var result = await controller.DocumentAsync();

            // Assert
            var viewModel = result.Should().BeOfType<ViewResult>()
                .Which.ViewData.Model.Should().BeOfType<DocumentViewModel>()
                .Which;

            viewModel.Body.Should().NotBeNull();
            viewModel.Head.Should().NotBeNull();

            A.CallTo(() => FakeDocumentService.GetAllAsync(null)).MustHaveHappenedOnceExactly();
        }
    }
}
