﻿using DFC.App.ExploreCareers.UI.FunctionalTests.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
        private List<int> searchCount = new List<int>();

        public ExploreCareersCUIcounts(ScenarioContext scenarioContext)
        {
            exploreCareersPage = new ExploreCareersPage(scenarioContext);
            searchResultsPage = new SearchResultsPage(scenarioContext);
        }

        [Given(@"I search for the term (.*)")]
        public void GivenISearchForTheTerm(string searchTerm)
        {
            searchParameter = searchTerm;
            searchResultsPage.SearchProfile(searchTerm);
        }

        [Given(@"I obtain the number of search results")]
        public void GivenIObtainTheNumberOfSearchResults()
        {
            searchCount.Add(searchResultsPage.GetNumberOfSearchResults());
        }

        [Given(@"I surf to the ""(.*)"" environments ""(.*)"" page")]
        public void GivenISurfToTheEnvironmentsPage(string environment, string webPage = "search-results")
        {
            theEnvironment = environment;
            exploreCareersPage.NavigateToPage(environment, webPage);
        }

        [When(@"I compare the number of search results from both environments")]
        public void WhenICompareTheNumberOfSearchResultsFromBothEnvironments()
        {
            searchResultsPage.CompareCounts(searchCount[0], searchCount[1]);
        }

        [Then(@"the number is the same")]
        public void ThenTheNumberIsTheSame()
        {
            Assert.AreEqual(searchCount[1], searchCount[0], "Count for '" + searchParameter + "' in " + theEnvironment + ", of " + searchCount[1] + " differs from this environment's, of " + searchCount[0] + " by " + (searchCount[1] - searchCount[0] + "."));
        }
    }
}