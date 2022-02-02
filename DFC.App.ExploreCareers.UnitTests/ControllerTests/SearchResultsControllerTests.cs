using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

using AutoMapper;

using DFC.App.ExploreCareers.AutoMapperProfiles;
using DFC.App.ExploreCareers.AzureSearch;
using DFC.App.ExploreCareers.Controllers;
using DFC.App.ExploreCareers.Models;
using DFC.App.ExploreCareers.ViewModels;
using DFC.App.ExploreCareers.ViewModels.SearchResults;

using FakeItEasy;

using FluentAssertions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

using Xunit;

namespace DFC.App.ExploreCareers.UnitTests.ControllerTests
{
    public class SearchResultsControllerTests
    {
        private IMapper Mapper { get; } = new MapperConfiguration(cfg => cfg.AddProfile(new JobProfileContentItemModelProfile())).CreateMapper();

        private ILogger<SearchResultsController> Logger { get; } = A.Fake<ILogger<SearchResultsController>>();

        private IAzureSearchService AzureSearchService { get; } = A.Fake<IAzureSearchService>();

        //[Fact]
        [Theory]
        [InlineData("something", "something | Search | National Careers Service")]
        [InlineData(null, "Search | National Careers Service")]
        [InlineData("", "Search | National Careers Service")]
        public void HeadReturnsHtml(string? searchTerm, string expectedTitle)
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);

            // Act
            var result = controller.Head(searchTerm);

            // Assert
            var viewModel = result.Should().BeOfType<ViewResult>()
                .Which.ViewData.Model.Should().BeOfType<HeadViewModel>()
                .Which;

            viewModel.Title.Should().Be(expectedTitle);
            viewModel.CanonicalUrl!.OriginalString.Should().Be("/search-results");
        }

        [Fact]
        public void BreadcrumbReturnsHtml()
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);

            // Act
            var result = controller.Breadcrumb();

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
            viewModel.Breadcrumbs[2].Title.Should().Be("Search results");
            viewModel.Breadcrumbs[2].Route.Should().Be("#");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task BodyEmptySearchTermReturnsNoResults(string? searchTerm)
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);

            // Act
            var result = await controller.Body(searchTerm);

            // Assert
            var viewModel = result.Should().BeOfType<ViewResult>()
                .Which.ViewData.Model.Should().BeOfType<BodyViewModel>()
                .Which;

            viewModel.Should().NotBeNull();
            viewModel.SearchTerm.Should().Be(searchTerm);
        }

        [Fact]
        public async Task BodyReturnsHtmlWithResult()
        {
            // Arrange
            var searchTerm = "something";
            using var controller = BuildController(MediaTypeNames.Text.Html);

            var indexDocument = new JobProfileIndex();
            var searchModel = new AzureSearchJobProfileModel
            {
                TotalResults = 1,
                JobProfiles = new List<JobProfileIndex> { indexDocument }
            };
            A.CallTo(() => AzureSearchService.SearchAsync(searchTerm, A<int>.Ignored)).Returns(searchModel);

            // Act
            var result = await controller.Body(searchTerm);

            // Assert
            var viewModel = result.Should().BeOfType<ViewResult>()
                .Which.ViewData.Model.Should().BeOfType<BodyViewModel>()
                .Which;

            viewModel.TotalResultsMessage.Should().Be("1 result found");
            viewModel.JobProfiles.Should().NotBeNullOrEmpty()
                .And.HaveCount(1);
        }

        [Fact]
        public async Task BodyReturnsHtmlWithoutResult()
        {
            // Arrange
            var searchTerm = "something";
            using var controller = BuildController(MediaTypeNames.Text.Html);

            var searchModel = new AzureSearchJobProfileModel
            {
                TotalResults = 0,
                JobProfiles = Array.Empty<JobProfileIndex>()
            };
            A.CallTo(() => AzureSearchService.SearchAsync(searchTerm, A<int>.Ignored)).Returns(searchModel);

            // Act
            var result = await controller.Body(searchTerm);

            // Assert
            var viewModel = result.Should().BeOfType<ViewResult>()
                .Which.ViewData.Model.Should().BeOfType<BodyViewModel>()
                .Which;

            viewModel.TotalResultsMessage.Should().Be(SearchResultsController.NoResultsMessage);
            viewModel.JobProfiles.Should().BeEmpty();
        }

        [Fact]
        public async Task BodyReturnsHtmlWithPagingForFirstPage()
        {
            // Arrange
            var searchTerm = "something";
            using var controller = BuildController(MediaTypeNames.Text.Html);

            var indexDocument = new JobProfileIndex { };
            var searchModel = new AzureSearchJobProfileModel
            {
                TotalResults = 11,
                JobProfiles = new List<JobProfileIndex> { indexDocument }
            };
            A.CallTo(() => AzureSearchService.SearchAsync(searchTerm, A<int>.Ignored)).Returns(searchModel);

            // Act
            var result = await controller.Body(searchTerm);

            // Assert
            var viewModel = result.Should().BeOfType<ViewResult>()
                .Which.ViewData.Model.Should().BeOfType<BodyViewModel>()
                .Which;

            viewModel.TotalResultsMessage.Should().Be("11 results found");
            viewModel.JobProfiles.Should().NotBeNullOrEmpty();

            viewModel.TotalPages.Should().Be(2);

            viewModel.NextPageUrl.Should().NotBeNull()
                .And.Be($"/search-results?searchTerm={searchTerm}&page=2");
            viewModel.NextPageUrlText.Should().Be("2 of 2");

            viewModel.PreviousPageUrl.Should().BeNull();
            viewModel.PreviousPageUrlText.Should().BeNull();
        }

        [Fact]
        public async Task BodyReturnsHtmlWithPagingWithPreviousAndNextPage()
        {
            // Arrange
            var searchTerm = "something";
            using var controller = BuildController(MediaTypeNames.Text.Html);

            var indexDocument = new JobProfileIndex { };
            var searchModel = new AzureSearchJobProfileModel
            {
                TotalResults = 31,
                JobProfiles = new List<JobProfileIndex> { indexDocument }
            };
            A.CallTo(() => AzureSearchService.SearchAsync(searchTerm, A<int>.Ignored)).Returns(searchModel);

            // Act
            var result = await controller.Body(searchTerm, 3);

            // Assert
            var viewModel = result.Should().BeOfType<ViewResult>()
                .Which.ViewData.Model.Should().BeOfType<BodyViewModel>()
                .Which;

            viewModel.TotalResultsMessage.Should().Be("31 results found");
            viewModel.JobProfiles.Should().NotBeNullOrEmpty();

            viewModel.TotalPages.Should().Be(4);

            viewModel.PreviousPageUrl.Should().NotBeNull()
                .And.Be($"/search-results?searchTerm={searchTerm}&page=2");
            viewModel.PreviousPageUrlText.Should().Be("2 of 4");

            viewModel.NextPageUrl.Should().NotBeNull()
                .And.Be($"/search-results?searchTerm={searchTerm}&page=4");
            viewModel.NextPageUrlText.Should().Be("4 of 4");
        }

        [Fact]
        public async Task BodyReturnsHtmlWithPagingForLastPage()
        {
            // Arrange
            var searchTerm = "something";
            using var controller = BuildController(MediaTypeNames.Text.Html);

            var indexDocument = new JobProfileIndex { };
            var searchModel = new AzureSearchJobProfileModel
            {
                TotalResults = 11,
                JobProfiles = new List<JobProfileIndex> { indexDocument }
            };
            A.CallTo(() => AzureSearchService.SearchAsync(searchTerm, A<int>.Ignored)).Returns(searchModel);

            // Act
            var result = await controller.Body(searchTerm, 2);

            // Assert
            var viewModel = result.Should().BeOfType<ViewResult>()
                .Which.ViewData.Model.Should().BeOfType<BodyViewModel>()
                .Which;

            viewModel.TotalResultsMessage.Should().Be("11 results found");
            viewModel.JobProfiles.Should().NotBeNullOrEmpty();

            viewModel.TotalPages.Should().Be(2);

            viewModel.PreviousPageUrl.Should().NotBeNull()
                .And.Be($"/search-results?searchTerm={searchTerm}");
            viewModel.PreviousPageUrlText.Should().Be("1 of 2");

            viewModel.NextPageUrl.Should().BeNull();
            viewModel.NextPageUrlText.Should().BeNull();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task DocumentEmptySearchTermReturnsNoResults(string? searchTerm)
        {
            // Arrange
            using var controller = BuildController(MediaTypeNames.Text.Html);

            // Act
            var result = await controller.Document(searchTerm);

            // Assert
            var viewModel = result.Should().BeOfType<ViewResult>()
                .Which.ViewData.Model.Should().BeOfType<DocumentViewModel>()
                .Which;

            viewModel.Should().NotBeNull();
            viewModel.Body.SearchTerm.Should().Be(searchTerm);
        }

        private SearchResultsController BuildController(string mediaTypeName)
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers[HeaderNames.Accept] = mediaTypeName;

            var controller = new SearchResultsController(Logger, AzureSearchService, Mapper)
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
