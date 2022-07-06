using DFC.App.ExploreCareers.AzureSearch;

using FluentAssertions;

using Xunit;

namespace DFC.App.ExploreCareers.UnitTests
{
    public class SearchBuilderTests
    {
        [Theory]
        [InlineData("test", "/.*test.*/")]
        [InlineData("test1 test2", "/.*test1.*/ /.*test2.*/")]
        [InlineData("test1 test-2", "/.*test1.*/ test-2")]
        public void BuildContainPartialSearchTest(string cleanedSearchTerm, string expectation)
        {
            var result = SearchBuilder.BuildContainPartialSearch(cleanedSearchTerm);
            result.Should().Be(expectation);
        }

        [Theory]
        [InlineData("term~nurse", "termnurse")]
        [InlineData("term-nurse-vertinary", "term-nurse-vertinary")]
        [InlineData("term~", "term")]
        [InlineData("term^nurse", "termnurse")]
        [InlineData("+term +nurse", "term nurse")]
        [InlineData("term?nurse", "termnurse")]
        [InlineData("/[term]nurse/", "termnurse")]
        [InlineData("term !nurse", "term nurse")]
        [InlineData("term - nurse", "term nurse")]
        [InlineData("term + nurse", "term nurse")]
        [InlineData("term or nurse", "term or nurse")]
        [InlineData("term && nurse", "term nurse")]
        [InlineData("term & nurse", "term nurse")]
        [InlineData("term || nurse", "term nurse")]
        [InlineData("term and nurse", "term and nurse")]
        [InlineData("(term)", "term")]
        [InlineData("term Children's", "term Children's")]
        [InlineData("<term Children's>", "term Children's")]
        public void RemoveSpecialCharactersFromTheSearchTerm(string searchTerm, string expected)
        {
            var result = SearchBuilder.RemoveSpecialCharactersFromTheSearchTerm(searchTerm);
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("plumber", "plumb")] //er
        [InlineData("offenders", "offend")] //ers
        [InlineData("plumbing engineer", "plumb engine")] //ing
        [InlineData("Business development manager", "Business develop manag")] //"ment"
        [InlineData("installation and plumbing engineer", "install plumb engine")] //ation
        [InlineData("director or clock repairer", "direct clock repair")] //or
        [InlineData("pharmacology ecology", "pharmacolo ecolo")] //ology
        [InlineData("optometry", "opto")] //metry
        [InlineData("dietetics", "dietet")] //ics
        [InlineData("laundrette", "laundr")] //ette
        [InlineData("performance", "perform")] //ance
        [InlineData("fisheries", "fisher")] //ies
        [InlineData("diplomacy", "diplo")] //macy
        [InlineData("director and clock repairer", "direct clock repair")] //and
        [InlineData("Hydrotherapy", "Hydrothera")] //therapy
        public void TrimSuffixesTest(string searchTerm, string expected)
        {
            var searchTermResult = SearchBuilder.RemoveSpecialCharactersFromTheSearchTerm(searchTerm);
            var trimmedOutput = SearchBuilder.TrimCommonWordsAndSuffixes(searchTermResult);
            trimmedOutput.Should().Be(expected);
        }

        [Theory]
        [InlineData("term", "/.*term.*/")]
        [InlineData("term~nurse", "/.*termnurse.*/")]
        [InlineData("term - nurse", "/.*term.*/ /.*nurse.*/")]
        [InlineData("term-nurse-vertinary", "term-nurse-vertinary")]
        [InlineData("term nurs~ term-nurse-vertinary", "/.*term.*/ /.*nurs.*/ term-nurse-vertinary")]
        [InlineData("term~", "/.*term.*/")]
        [InlineData("term^nurse", "/.*termnurse.*/")]
        [InlineData("+term +nurse", "/.*term.*/ /.*nurse.*/")]
        [InlineData("term?nurse", "/.*termnurse.*/")]
        [InlineData("/[term]nurse/", "/.*termnurse.*/")]
        [InlineData("term !nurse", "/.*term.*/ /.*nurse.*/")]
        [InlineData("term + nurse", "/.*term.*/ /.*nurse.*/")]
        [InlineData("term && nurse", "/.*term.*/ /.*nurse.*/")]
        [InlineData("term & nurse", "/.*term.*/ /.*nurse.*/")]
        [InlineData("term || nurse", "/.*term.*/ /.*nurse.*/")]
        [InlineData("(term)", "/.*term.*/")]
        [InlineData("term Children's", "/.*term.*/ /.*Children's.*/")]
        [InlineData("<term Children's>", "/.*term.*/ /.*Children's.*/")]
        public void BuiBuildContainPartialSearchTest(string searchTerm, string expected)
        {
            var searchTermResult = SearchBuilder.RemoveSpecialCharactersFromTheSearchTerm(searchTerm);
            var trimmedOutput = SearchBuilder.TrimCommonWordsAndSuffixes(searchTermResult);
            var outputWithContainsWildCard = SearchBuilder.BuildContainPartialSearch(trimmedOutput);
            outputWithContainsWildCard.Should().Be(expected);
        }

        [Theory]
        [InlineData("*", "cleanSearch", "partialSearchTerm", "*")]
        [InlineData("test", "cleanSearch", "partialSearchTerm", "Title:(partialsearchterm) AlternativeTitle:(partialsearchterm) TitleAsKeyword:\"test\" AltTitleAsKeywords:\"test\" cleanSearch")]
        public void BuildSearchExpressionForRawTest(string searchTerm, string cleanedSearchTerm, string partialTermToSearch, string expectation)
        {
            var result = SearchBuilder.BuildSearchExpression(searchTerm, cleanedSearchTerm, partialTermToSearch);
            result.Should().Be(expectation);
        }

        [Theory]
        [InlineData("*", "*")]
        [InlineData("admin", "Title:(/.*admin.*/) AlternativeTitle:(/.*admin.*/) TitleAsKeyword:\"admin\" AltTitleAsKeywords:\"admin\" admin")]
        [InlineData("admin assistant", "Title:(/.*admin.*/ /.*assistant.*/) AlternativeTitle:(/.*admin.*/ /.*assistant.*/) TitleAsKeyword:\"admin assistant\" AltTitleAsKeywords:\"admin assistant\" admin assistant")]
        public void BuildSearchExpressionForFullTest(string searchTerm, string expectation)
        {
            var cleanedSearchTerm = SearchBuilder.RemoveSpecialCharactersFromTheSearchTerm(searchTerm);
            var trimmedSearchTerm = SearchBuilder.TrimCommonWordsAndSuffixes(cleanedSearchTerm);
            var partialTermToSearch = SearchBuilder.BuildContainPartialSearch(trimmedSearchTerm);
            var finalComputedSearchTerm = SearchBuilder.BuildSearchExpression(searchTerm, cleanedSearchTerm, partialTermToSearch);
            finalComputedSearchTerm.Should().Be(expectation);
        }
    }
}
