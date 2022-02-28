using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.AzureSearch;

using DFC.App.ExploreCareers.Models;

using FakeItEasy;

using FluentAssertions;

using Xunit;

namespace DFC.App.ExploreCareers.IntegrationTests.ControllerTests
{
    [Trait("Category", "SearchResults Controller Integration Tests")]
    public class SearchResultsRouteTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> factory;

        public SearchResultsRouteTests(CustomWebApplicationFactory<Startup> factory) =>
            this.factory = factory;

        [Fact]
        public async Task GetBodyEndpointReturnSuccessAndCorrectContentType()
        {
            // Arrange
            string term = "something";
            var uri = new Uri($"/search-results/body?searchTerm={term}", UriKind.Relative);
            var client = GetClient();

            var indexDocument = new JobProfileIndex { };
            var searchModel = new AzureSearchJobProfileModel
            {
                TotalResults = 11,
                JobProfiles = new List<JobProfileIndex> { indexDocument }
            };
            A.CallTo(() => factory.FakeAzureSearchService.SearchAsync(term, A<int>.Ignored)).Returns(searchModel);

            // Act
            var response = await client.GetAsync(uri);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be(MediaTypeNames.Text.Html);
        }

        [Fact]
        public async Task GetHeadEndpointReturnSuccessAndCorrectContentType()
        {
            // Arrange
            string term = "something";
            var uri = new Uri($"/search-results/head?searchTerm={term}", UriKind.Relative);
            var client = GetClient();

            // Act
            var response = await client.GetAsync(uri);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be(MediaTypeNames.Text.Html);
        }

        [Fact]
        public async Task GetBreadcrumbsEndpointReturnSuccessAndCorrectContentType()
        {
            // Arrange
            var uri = new Uri($"/search-results/breadcrumb", UriKind.Relative);
            var client = GetClient();

            // Act
            var response = await client.GetAsync(uri);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be(MediaTypeNames.Text.Html);
        }

        private HttpClient GetClient()
        {
            var client = factory.CreateClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(MediaTypeNames.Text.Html));
            return client;
        }
    }
}
