using System.Linq;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.AzureSearch;
using DFC.App.ExploreCareers.Controllers;
using DFC.App.ExploreCareers.Models;

using FakeItEasy;

using FluentAssertions;

using Xunit;

namespace DFC.App.ExploreCareers.UnitTests.ControllerTests
{
    public class SearchAutocompleteControllerTests
    {
        private IAzureSearchService AzureSearchService { get; } = A.Fake<IAzureSearchService>();

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task GetEmptySearchTermReturnsNoResults(string? searchTerm)
        {
            // Arrange
            using var controller = new SearchAutocompleteController(AzureSearchService);

            // Act
            var result = await controller.Get(searchTerm);

            // Assert
            result.Should().BeOfType<AutoCompleteModel[]>()
                .And.BeEmpty();
        }

        [Fact]
        public async Task GetReturnsSuggestions()
        {
            // Arrange
            var searchTerm = "something";
            using var controller = new SearchAutocompleteController(AzureSearchService);

            var searchModel = new[]
            {
                new AutoCompleteModel{ Label = "test"}
            };
            A.CallTo(() => AzureSearchService.GetSuggestionsAsync(searchTerm, A<int>._, A<bool>._)).Returns(searchModel);

            // Act
            var result = await controller.Get(searchTerm);

            // Assert
            var results = result.Should().BeOfType<AutoCompleteModel[]>()
                .Which;
            results.Should().NotBeNullOrEmpty();
            results.Should().HaveCount(1);
            results.First().Label.Should().Be("test");
        }
    }
}
