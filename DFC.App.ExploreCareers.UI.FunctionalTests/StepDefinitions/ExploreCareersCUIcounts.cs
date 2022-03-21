using DFC.App.ExploreCareers.UI.FunctionalTests.Hooks;
using DFC.App.ExploreCareers.UI.FunctionalTests.Pages;
using DFC.App.ExploreCareers.UI.FunctionalTests.Support;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.App.ExploreCareers.UI.FunctionalTests.StepDefinitions
{
    [Binding]
    public sealed class ExploreCareersCUIcounts
    {
        private readonly ExploreCareersPage exploreCareersPage;
        private readonly SearchResultsPage searchResultsPage;
        private string theEnvironment;
        private string searchParameter;
        private string theJobCategory;
        private List<int> searchCount = new List<int>();

        public ExploreCareersCUIcounts(ScenarioContext scenarioContext)
        {
            exploreCareersPage = new ExploreCareersPage(scenarioContext);
            searchResultsPage = new SearchResultsPage(scenarioContext);
        }

        [Given(@"I search for the term (.*) of the (.*) Job category")]
        public void GivenISearchForTheTermOfTheJobCategory(string searchTerm, string jobCategory)
        {
            theJobCategory = jobCategory;
            searchParameter = searchTerm;
            searchResultsPage.SearchProfile(searchTerm);
        }

        [Given(@"I note the number of search results")]
        public void GivenINoteTheNumberOfSearchResults()
        {
            searchCount.Add(searchResultsPage.GetNumberOfSearchResults());
        }

        [Given(@"I surf to the ""(.*)"" environments ""(.*)"" page")]
        public void GivenISurfToTheEnvironmentsPage(string environment, string webPage = "search-results")
        {
            theEnvironment = environment;
            exploreCareersPage.NavigateToPage(environment, webPage);
        }

        [When(@"I compare the number of search results noted from both environments")]
        public void WhenICompareTheNumberOfSearchResultsNotedFromBothEnvironments()
        {
            searchResultsPage.CompareCounts(searchCount[0], searchCount[1]);
        }

        [Then(@"the number is the same")]
        public void ThenTheNumberIsTheSame()
        {
            string path = Directory.GetParent(@"../../../").FullName + Path.DirectorySeparatorChar + "Result" + "\\";
            string file = "jp_counts_log.txt";
            string textToWrite = theJobCategory + " category: count of '" + searchParameter + "' in " + theEnvironment + ", of " + searchCount[1] + " differs from " + ExploreCareersPage.Environment + "'s, of " + searchCount[0] + " by " + (searchCount[1] - searchCount[0] + ".");

            if (searchCount[1] != searchCount[0])
            {
                Devices.WriteToFile(path, file, textToWrite);
            }

            Assert.AreEqual(searchCount[1], searchCount[0], textToWrite);
        }
    }
}