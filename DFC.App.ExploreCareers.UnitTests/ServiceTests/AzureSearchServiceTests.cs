using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;

using DFC.App.ExploreCareers.AzureSearch;

using FakeItEasy;

using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DFC.App.ExploreCareers.UnitTests.ServiceTests
{
    public class AzureSearchServiceTests
    {
        private readonly SearchClient mockClient = A.Fake<SearchClient>();

        [Fact]
        public async Task GetSuggestionsFromSearchShouldReturnSuggestionsWithAlternativeTitles()
        {
            // Arrange
            SetupMockSearchResponse();
            var searchService = new AzureSearchService(mockClient);

            // Act
            var response = await searchService.GetSuggestionsFromSearchAsync("b");

            // Assert
            response.Should().NotBeNullOrEmpty();
            response.Should().HaveCount(2);
            response.First().Label.Should().Be("B (B Alt Title 1)");
            response.Skip(1).First().Label.Should().Be("A (A Alt Title 1,...)"); //ellipis there if there is more than one alternative title
        }

        [Fact]
        public async Task GetSuggestionsFromSearchShouldReturnExactMatchingAlternativeTitle()
        {
            // Arrange
            SetupMockSearchResponse();
            var searchService = new AzureSearchService(mockClient);

            // Act
            var response = await searchService.GetSuggestionsFromSearchAsync("a alt title 2");

            // Assert
            response.Should().NotBeNullOrEmpty();
            response.Should().NotHaveCount(1);
            response.First().Label.Should().Be("A (A Alt Title 2)");
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
            IEnumerable<string> alternativeTitlesB = new List<string>() { "B Alt Title 1" };
            IEnumerable<string> alternativeTitlesA = new List<string>() { "A Alt Title 1", "A Alt Title 2", "A Alt Title 3" };

            var mockResponse = A.Fake<Response>();
            var mockResults = SearchModelFactory.SearchResults(
                new[]
                {
                    SearchModelFactory.SearchResult(new JobProfileIndex { IdentityField = Guid.NewGuid().ToString(), Title = "B", AlternativeTitle = alternativeTitlesB }, 1.0, null),
                    SearchModelFactory.SearchResult(new JobProfileIndex { IdentityField = Guid.NewGuid().ToString(), Title = "A", AlternativeTitle = alternativeTitlesA }, 0.9, null),
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
