﻿using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

using AutoMapper;

using DFC.App.ExploreCareers.AutoMapperProfiles;
using DFC.App.ExploreCareers.AzureSearch;
using DFC.App.ExploreCareers.Controllers;
using DFC.App.ExploreCareers.Cosmos;
using DFC.App.ExploreCareers.ViewModels;
using DFC.App.ExploreCareers.ViewModels.JobCategories;

using FakeItEasy;

using FluentAssertions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

using Xunit;

namespace DFC.App.ExploreCareers.UnitTests.ControllerTests
{
    public class JobCategoriesControllerTests
    {
        private const string CategoryName = "category-name";

        private IMapper Mapper { get; } = new MapperConfiguration(cfg => cfg.AddProfile(new JobProfileContentItemModelProfile())).CreateMapper();

        private ILogger<JobCategoriesController> Logger { get; } = A.Fake<ILogger<JobCategoriesController>>();

        private IJobCategoryDocumentService DocumentService { get; } = A.Fake<IJobCategoryDocumentService>();

        private IAzureSearchService AzureSearchService { get; } = A.Fake<IAzureSearchService>();

        [Fact]
        public void HeadReturnsHtml()
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);

            // Act
            var result = controller.Head(CategoryName);

            // Assert
            var viewModel = result.Should().BeOfType<ViewResult>()
                .Which.ViewData.Model.Should().BeOfType<HeadViewModel>()
                .Which;

            viewModel.Title.Should().Be("Category name | Explore careers");
            viewModel.CanonicalUrl!.OriginalString.Should().Be("/job-categories");
        }

        [Fact]
        public void HeadEmptyCategoryReturnsBadRequest()
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);

            // Act
            var result = controller.Head(string.Empty);

            // Assert
            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task BreadcrumbReturnsHtml()
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);
            var jobCategory = new JobCategoryViewModel { Name = "Category name", CanonicalName = CategoryName };
            A.CallTo(() => DocumentService.GetJobCategoriesAsync($"/{CategoryName}")).Returns(new List<JobCategoryViewModel> { jobCategory });

            // Act
            var result = await controller.Breadcrumb(CategoryName);

            // Assert
            var viewModel = result.Should().BeOfType<ViewResult>()
                .Which.ViewData.Model.Should().BeOfType<BreadcrumbViewModel>()
                .Which;

            viewModel.Breadcrumbs
                .Should().NotBeNullOrEmpty()
                .And.HaveCount(3);
            viewModel.Breadcrumbs![0].Title.Should().Be("Home");
            viewModel.Breadcrumbs[0].Route.Should().Be("/");
            viewModel.Breadcrumbs[1].Title.Should().Be("Explore Careers");
            viewModel.Breadcrumbs[1].Route.Should().Be("/explore-careers");
            viewModel.Breadcrumbs[2].Title.Should().Be("Category name");
            viewModel.Breadcrumbs[2].Route.Should().Be("#");
        }

        [Fact]
        public async Task BreadcrumbUnknwonCategoryReturnsNotFound()
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);
            A.CallTo(() => DocumentService.GetJobCategoriesAsync($"/{CategoryName}")).Returns(new List<JobCategoryViewModel>());

            // Act
            var result = await controller.Breadcrumb(CategoryName);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task BreadcrumbEmptyCategoryReturnsBadRequest()
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);

            // Act
            var result = await controller.Breadcrumb(string.Empty);

            // Assert
            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task BodyReturnsHtml()
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);
            var jobCategory = new JobCategoryViewModel { Name = "Category name", CanonicalName = CategoryName };
            var jobProfileIndex = new JobProfileIndex { Title = jobCategory.Name, Overview = "some overview", UrlName = CategoryName };

            A.CallTo(() => DocumentService.GetJobCategoriesAsync(A<string>.Ignored)).Returns(new List<JobCategoryViewModel> { jobCategory });
            A.CallTo(() => AzureSearchService.GetProfilesByCategoryAsync(CategoryName)).Returns(new List<JobProfileIndex> { jobProfileIndex });

            // Act
            var result = await controller.Body(CategoryName);

            // Assert
            var viewModel = result.Should().BeOfType<ViewResult>()
                .Which.ViewData.Model.Should().BeOfType<BodyViewModel>()
                .Which;

            viewModel.JobCategories.Should().BeEmpty(); // Other job categories.
            viewModel.JobProfiles.Should().NotBeNullOrEmpty()
                .And.HaveCount(1);
        }

        [Fact]
        public async Task BodyEmptyCategoryReturnsBadRequest()
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);

            // Act
            var result = await controller.Body(string.Empty);

            // Assert
            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task BodyUnknwonCategoryReturnsNotFound()
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);
            A.CallTo(() => DocumentService.GetJobCategoriesAsync($"/{CategoryName}")).Returns(new List<JobCategoryViewModel>());

            // Act
            var result = await controller.Body(CategoryName);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task DocumentReturnsHtml()
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);
            var jobCategory = new JobCategoryViewModel { Name = "Category name", CanonicalName = CategoryName };
            var jobProfileIndex = new JobProfileIndex { Title = jobCategory.Name, Overview = "some overview", UrlName = CategoryName };

            A.CallTo(() => DocumentService.GetJobCategoriesAsync(A<string>.Ignored)).Returns(new List<JobCategoryViewModel> { jobCategory });
            A.CallTo(() => AzureSearchService.GetProfilesByCategoryAsync(CategoryName)).Returns(new List<JobProfileIndex> { jobProfileIndex });

            // Act
            var result = await controller.Document(CategoryName);

            // Assert
            var viewModel = result.Should().BeOfType<ViewResult>()
                .Which.ViewData.Model.Should().BeOfType<DocumentViewModel>()
                .Which;

            viewModel.Body.Should().NotBeNull();
            viewModel.Body!.JobCategories.Should().BeEmpty(); // Other job categories.
            viewModel.Body.JobProfiles.Should().NotBeNullOrEmpty()
                .And.HaveCount(1);

            viewModel.Breadcrumb.Should().NotBeNull();
            viewModel.Breadcrumb!.Breadcrumbs
                .Should().NotBeNullOrEmpty()
                .And.HaveCount(3);

            viewModel.Head.Should().NotBeNull();
            viewModel.Head.Title.Should().Be("Category name | Explore careers");
            viewModel.Head.CanonicalUrl!.OriginalString.Should().Be("/job-categories");
        }

        [Fact]
        public async Task DocumentEmptyCategoryReturnsBadRequest()
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);

            // Act
            var result = await controller.Document(string.Empty);

            // Assert
            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task DocumentUnknwonCategoryReturnsNotFound()
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);
            A.CallTo(() => DocumentService.GetJobCategoriesAsync($"/{CategoryName}")).Returns(new List<JobCategoryViewModel>());

            // Act
            var result = await controller.Document(CategoryName);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        private JobCategoriesController BuildController(string mediaTypeName)
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers[HeaderNames.Accept] = mediaTypeName;

            var controller = new JobCategoriesController(Logger, Mapper, DocumentService, AzureSearchService)
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
