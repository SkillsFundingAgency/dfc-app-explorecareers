using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;

using DFC.App.ExploreCareers.AzureSearch;

using FakeItEasy;

using FluentAssertions;

using Xunit;

namespace DFC.App.ExploreCareers.UnitTests.ServiceTests
{
    public class AzureSearchServiceTests
    {
        private readonly SearchClient mockClient = A.Fake<SearchClient>();

        [Fact]
        public async Task GetSuggestionsShouldReturnSuggestions()
        {
            // Arrange
            SetupMockSuggestionResponse();
            var searchService = new AzureSearchService(mockClient);

            // Act
            var response = await searchService.GetSuggestionsAsync("a");

            // Assert
            response.Should().NotBeNullOrEmpty();
            response.Should().HaveCount(2);
            response.First().Label.Should().Be("B");
            response.Skip(1).First().Label.Should().Be("A");
        }

        [Fact]
        public async Task GetProfilesByCategoryShouldReturnsResultsOrderedByTitle()
        {
            // Arrange
            SetupMockSearchResponse();
            var searchService = new AzureSearchService(mockClient);

            // Act
            var response = await searchService.GetProfilesByCategoryAsync("category");

            // Assert
            response.Count.Should().Be(2);
            response[0].Title.Should().Be("A");
            response[1].Title.Should().Be("B");
        }

        [Fact]
        public async Task SearchAsyncShouldUseCorrectSearchOptions()
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

            SearchOptions? searchOptionsUsedForClient = null;
            A.CallTo(() => mockClient.SearchAsync<JobProfileIndex>(A<string>.Ignored, A<SearchOptions>.Ignored, A<CancellationToken>.Ignored))
                .Invokes((string term, SearchOptions options, CancellationToken token) => searchOptionsUsedForClient = options)
                .Returns(Response.FromValue(mockResults, mockResponse));

            var searchService = new AzureSearchService(mockClient);

            // Act
            await searchService.SearchAsync("something");

            // Assert
            searchOptionsUsedForClient.Should().NotBeNull();
            searchOptionsUsedForClient!.QueryType.Should().Be(SearchQueryType.Full);
            searchOptionsUsedForClient.ScoringProfile.Should().Be("jp");
            searchOptionsUsedForClient.IncludeTotalCount.Should().BeTrue();
            searchOptionsUsedForClient.Size.Should().Be(10);
            searchOptionsUsedForClient.Skip.Should().Be(0);
            searchOptionsUsedForClient.Select.Should().Contain(nameof(JobProfileIndex.Title));
            searchOptionsUsedForClient.Select.Should().Contain(nameof(JobProfileIndex.AlternativeTitle));
            searchOptionsUsedForClient.Select.Should().Contain(nameof(JobProfileIndex.UrlName));
            searchOptionsUsedForClient.Select.Should().Contain(nameof(JobProfileIndex.Overview));
            searchOptionsUsedForClient.Select.Should().Contain(nameof(JobProfileIndex.SalaryStarter));
            searchOptionsUsedForClient.Select.Should().Contain(nameof(JobProfileIndex.SalaryExperienced));
            searchOptionsUsedForClient.Select.Should().Contain(nameof(JobProfileIndex.JobProfileCategoriesWithUrl));
        }

        [Fact]
        public async Task SearchAsyncShouldReturnSearchedResultAtTheTop()
        {
            // Arrange
            SetupMockSearchResponse();
            var searchService = new AzureSearchService(mockClient);

            // Act
            var response = await searchService.SearchAsync("a");

            // Assert
            response.Should().NotBeNull();
            response.JobProfiles.Should().NotBeEmpty();
            response.TotalResults.Should().Be(2);
            JobProfileIndex firstJobProfile = response.JobProfiles.First();
            firstJobProfile.Rank.Should().Be(0);
            firstJobProfile.Title.Should().Be("A");

            JobProfileIndex otherJobProfile = response.JobProfiles.Last();
            otherJobProfile.Rank.Should().Be(1);
            otherJobProfile.Title.Should().Be("B");
        }

        [Fact]
        public async Task SearchAsyncShouldReturnSearchResultsWithoutOrdering()
        {
            // Arrange
            SetupMockSearchResponse();
            var searchService = new AzureSearchService(mockClient);

            // Act
            var response = await searchService.SearchAsync("a", 2);

            // Assert
            response.Should().NotBeNull();
            response.JobProfiles.Should().NotBeEmpty();
            response.TotalResults.Should().Be(2);

            JobProfileIndex firstJobProfile = response.JobProfiles.First();
            firstJobProfile.Rank.Should().Be(1);
            firstJobProfile.Title.Should().Be("B");

            JobProfileIndex otherJobProfile = response.JobProfiles.Last();
            otherJobProfile.Rank.Should().Be(2);
            otherJobProfile.Title.Should().Be("A");
        }

        private void SetupMockSuggestionResponse()
        {
            var mockResponse = A.Fake<Response>();
            var mockResults = SearchModelFactory.SuggestResults(
                new[]
                {
                  SearchModelFactory.SearchSuggestion(new JobProfileIndex { IdentityField = Guid.NewGuid().ToString(), Title = "B" }, "B"),
                  SearchModelFactory.SearchSuggestion(new JobProfileIndex { IdentityField = Guid.NewGuid().ToString(), Title = "A" }, "A")
                }, null);

            A.CallTo(() => mockClient.SuggestAsync<JobProfileIndex>(A<string>._, A<string>._, A<SuggestOptions>._, A<CancellationToken>.Ignored))
                .Returns(Response.FromValue(mockResults, mockResponse));
        }

        private void SetupMockSearchResponse()
        {
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

            A.CallTo(() => mockClient.SearchAsync<JobProfileIndex>(A<string>.Ignored, A<SearchOptions>.Ignored, A<CancellationToken>.Ignored))
                .Returns(Response.FromValue(mockResults, mockResponse));
        }
    }
}
