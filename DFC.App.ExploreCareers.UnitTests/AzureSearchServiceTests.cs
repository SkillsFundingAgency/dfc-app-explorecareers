using System;
using System.Threading;
using System.Threading.Tasks;

using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;

using DFC.App.ExploreCareers.AzureSearch;

using FakeItEasy;

using FluentAssertions;

using Xunit;

namespace DFC.App.ExploreCareers.UnitTests
{
    public class AzureSearchServiceTests
    {
        [Fact]
        public async Task GetProfilesByCategoryShouldReturnsResultsOrderedByTitle()
        {
            // Arrange
            var mockResponse = A.Fake<Response>();
            var mockResults = SearchModelFactory.SearchResults(
                new[]
                {
                    SearchModelFactory.SearchResult(new JobProfileIndex { IdentityField = Guid.NewGuid().ToString(), Title = "B" }, 1.0, null),
                    SearchModelFactory.SearchResult(new JobProfileIndex { IdentityField = Guid.NewGuid().ToString(), Title = "A" }, 0.9, null),
                },
                2,
                null,
                0,
                mockResponse);

            var mockClient = A.Fake<SearchClient>();
            A.CallTo(() => mockClient.SearchAsync<JobProfileIndex>(A<string>.Ignored, A<SearchOptions>.Ignored, A<CancellationToken>.Ignored))
              .Returns(Response.FromValue(mockResults, mockResponse));

            var searchService = new AzureSearchService(mockClient);

            // Act
            var response = await searchService.GetProfilesByCategoryAsync("category");

            // Assert
            response.Count.Should().Be(2);
            response[0].Title.Should().Be("A");
            response[1].Title.Should().Be("B");
        }
    }
}
