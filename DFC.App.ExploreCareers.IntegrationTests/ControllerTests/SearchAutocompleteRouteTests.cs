using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.Models;

using FakeItEasy;

using FluentAssertions;

using Microsoft.AspNetCore.Http;

using Xunit;

namespace DFC.App.ExploreCareers.IntegrationTests.ControllerTests
{
    [Trait("Category", "SearchAutocomplete Controller Integration Tests")]
    public class SearchAutocompleteRouteTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> factory;

        public SearchAutocompleteRouteTests(CustomWebApplicationFactory<Startup> factory) =>
            this.factory = factory;

        [Fact]
        public async Task GetHeadEndpointReturnsNoContent()
        {
            // Arrange
            var uri = new Uri("/searchautocomplete/head", UriKind.Relative);
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync(uri);

            // Assert
            response.StatusCode.Should().Be((System.Net.HttpStatusCode?)StatusCodes.Status204NoContent);
        }

        [Fact]
        public async Task GetEndpointReturnsSuccessAndCorrectContent()
        {
            // Arrange
            var uri = new Uri("/searchautocomplete?term=something", UriKind.Relative);
            var client = factory.CreateClient();
            var expectedResults = new List<AutoCompleteModel>
            {
                new AutoCompleteModel{ Label = "A", Category = "A"},
                new AutoCompleteModel{ Label = "B", Category = "B"},
            };
            A.CallTo(() => factory.FakeAzureSearchService.GetSuggestionsFromSearchAsync(A<string>._, A<int>._)).Returns(expectedResults);

            // Act
            var response = await client.GetAsync(uri);

            // Assert
            response.StatusCode.Should().Be((System.Net.HttpStatusCode?)StatusCodes.Status200OK);
            var result = await response.Content.ReadAsAsync<List<AutoCompleteModel>>();
            result.Should().BeEquivalentTo(expectedResults);
        }
    }
}
