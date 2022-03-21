using DFC.App.ExploreCareers.UI.FunctionalTests.Pages;
using DFC.App.ExploreCareers.UI.FunctionalTests.Support.Poco;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DFC.App.ExploreCareers.UI.FunctionalTests.StepDefinitions
{
    [Binding]
    public sealed class ExploreCareersCUI
    {
        private readonly ExploreCareersPage exploreCareersPage;
        private readonly JobCategoriesPage jobCategoriesPage;
        private readonly JobProfilesPage jobProfilesPage;
        private readonly SearchResultsPage searchResultsPage;
        private string webPage;
        private string jobCategory;
        private IEnumerable<JobCategories> jobCategories;
        private IList<IWebElement> jobProfiles;
        private IList<IWebElement> jobCategoryList;
        private bool jobCategoryPagePaginated;

        public ExploreCareersCUI(ScenarioContext scenarioContext)
        {
            exploreCareersPage = new ExploreCareersPage(scenarioContext);
            jobCategoriesPage = new JobCategoriesPage(scenarioContext);
            jobProfilesPage = new JobProfilesPage(scenarioContext);
            searchResultsPage = new SearchResultsPage(scenarioContext);
        }

        [Given(@"I am at the ""(.*)"" page")]
        public void GivenIAmAtThePage(string resource)
        {
            exploreCareersPage.NavigateToPage(resource, null);
        }

        [When(@"I click on the (.*) link")]
        public void WhenIClickOnTheAdministrationLink(string link)
        {
            exploreCareersPage.ClickLinkJobCategory(link);
        }

        [Then(@"I am taken to the (.*) page")]
        public void ThenIAmTakenToThePage(string page)
        {
            Assert.AreEqual(page, jobCategoriesPage.GetHeadingText(), "This is not the " + page + "page.");
        }

        [Given(@"I navigate to the web page ""(.*)""")]
        [Given(@"I navigate to the (.*) page")]
        public void GivenINavigateToThePage(string page)
        {
            webPage = page;
            exploreCareersPage.NavigateToPage(page, null);
        }

        [When(@"I enter the search term (.*) in the search field")]
        public void GivenIEnterTheSearchTermInTheSearchField(string searchTerm)
        {
            switch (webPage)
            {
                case "Explore careers":
                    exploreCareersPage.EnterSearchTerm(searchTerm);
                    break;
                case "Job profiles":
                    jobProfilesPage.EnterSearchTerm(searchTerm);
                    break;
                case "Search results":
                    jobProfilesPage.EnterSearchTerm(searchTerm);
                    break;
            }
        }

        [When(@"I enter the non existent search term (.*) in the search field")]
        public void WhenIEnterTheNonExistentSearchTermInTheSearchField(string nonExistentSearchTerm)
        {
            switch (webPage)
            {
                case "Explore careers":
                    exploreCareersPage.EnterSearchTerm(nonExistentSearchTerm);
                    break;
                case "Job profiles":
                    jobProfilesPage.EnterSearchTerm(nonExistentSearchTerm);
                    break;
                case "Search results":
                    jobProfilesPage.EnterSearchTerm(nonExistentSearchTerm);
                    break;
            }
        }

        [Then(@"I am able to select (.*) from the resultant auto suggest")]
        public void ThenIAmAbleToSelectFromTheResultantAutoSuggest(string option)
        {
            switch (webPage)
            {
                case "Explore careers":
                    exploreCareersPage.SelectFromAutosuggest(option);
                    break;
                case "Job profiles":
                    jobProfilesPage.SelectFromAutosuggest(option);
                    break;
                case "Search results":
                    searchResultsPage.SelectFromAutosuggest(option);
                    break;
            }
        }

        [Then(@"(.*) is populated in the search field")]
        public void IsPopulatedInTheSearchField(string autosuggestedOption)
        {
            switch (webPage)
            {
                case "Explore careers":
                    Assert.AreEqual(autosuggestedOption, exploreCareersPage.GetSelectedSearchTerm(), "Selected option is not " + autosuggestedOption + ".");
                    break;
                case "Job profiles":
                    Assert.AreEqual(autosuggestedOption, jobProfilesPage.GetSelectedSearchTerm(), "Selected option is not " + autosuggestedOption + ".");
                    break;
                case "Search results":
                    Assert.AreEqual(autosuggestedOption, searchResultsPage.GetSelectedSearchTerm(), "Selected option is not " + autosuggestedOption + ".");
                    break;
            }
        }

        [Given(@"I enter the search term (.*) in the search field")]
        public void GivenIEnterTheSearchTermNurInTheSearchField(string searchTerm)
        {
            switch (webPage)
            {
                case "Explore careers":
                    exploreCareersPage.EnterSearchTerm(searchTerm);
                    break;
                case "Job profiles":
                    jobProfilesPage.EnterSearchTerm(searchTerm);
                    break;
                case "Search results":
                    jobProfilesPage.EnterSearchTerm(searchTerm);
                    break;
            }
        }

        [Given(@"I click the search button")]
        public void GivenIClickTheSearchButton()
        {
            switch (webPage)
            {
                case "Explore careers":
                    exploreCareersPage.ClickSearchButton();
                    break;
                case "Job profiles":
                    exploreCareersPage.ClickSearchButton();
                    break;
                case "Search results":
                    searchResultsPage.ClickSearchButton();
                    break;
            }
        }

        [Given(@"I retrieve the number of search results")]
        public void GivenIRetrieveTheNumberOfSearchResults()
        {
            searchResultsPage.GetNumberOfSearchResults();
        }

        [When(@"I work out the number of result pages from the number of search results returned")]
        public void WhenIWorkOutTheNumberOfResultPagesFromTheNumberOfSearchResultsReturned()
        {
            searchResultsPage.NumberOfSeachResultPages();
        }

        [Given(@"the search field is empty")]
        public void GivenTheSearchFieldIsEmpty()
        {
            switch (webPage)
            {
                case "Explore careers":
                    exploreCareersPage.ClearSearchField();
                    break;
                case "Job profiles":
                    exploreCareersPage.ClearSearchField();
                    break;
                case "Search results":
                    searchResultsPage.ClearSearchField();
                    break;
            }
        }

        [When(@"I click the search button")]
        public void WhenIClickTheSearchButton()
        {
            switch (webPage)
            {
                case "Explore careers":
                    exploreCareersPage.ClickSearchButton();
                    break;
                case "Job profiles":
                    exploreCareersPage.ClickSearchButton();
                    break;
                case "Search results":
                    searchResultsPage.ClickSearchButton();
                    break;
            }
        }

        [Then(@"the page does not advance")]
        public void ThenThePageDoesNotAdvance()
        {
            switch (webPage)
            {
                case "Explore careers":
                    Assert.IsTrue(exploreCareersPage.GetUrl().Contains("/explore-careers"), "The page advanced unexpectedly");
                    break;
                case "Search results":
                    Assert.IsTrue(searchResultsPage.GetUrl().Contains("/search-results/Search/"), "The page advanced unexpectedly");
                    break;
            }
        }

        [Then(@"I get the message ""(.*)"" in the search results page")]
        public void ThenIGetTheMessageInTheSearchResultsPage(string zeroResultsMsg)
        {
            Assert.AreEqual(zeroResultsMsg, searchResultsPage.GetZeroResultsMsg(), "The search unexpectedly returned results");
        }

        [Given(@"I am taken to the search results page with the message Did you mean (.*) displayed")]
        [Then(@"I am taken to the search results page with the message Did you mean (.*) displayed")]
        public void ThenIAmTakenToTheSearchResultsPageWithTheMessageDidYouMeanDisplayed(string autoSuggestedSearchTerm)
        {
            Assert.AreEqual("Did you mean " + autoSuggestedSearchTerm, searchResultsPage.GetDidYouMean(), "Unexpected auto suggesteed search term displayed");
        }

        [Then(@"the message ""(.*)"" displayed below it")]
        public void ThenTheMessageDisplayedBelowIt(string zeroResultsMsg)
        {
            Assert.AreEqual(zeroResultsMsg, searchResultsPage.GetZeroResultsMsg(), "The search unexpectedly returned results");
        }

        [Then(@"the number of search results returned is commensurate with the number of search result pages")]
        public void ThenTheNumberOfSearchResultsReturnedIsCommensurateWithTheNumberOfSearchResultPages()
        {
            Assert.False(searchResultsPage.NextVerifier(), "Next paginator is still unexpectedly displayed.");
        }

        [Then(@"the Next button is no longer present on the final page")]
        public void ThenTheNextButtonIsNoLongerPresentOnTheFinalPage()
        {
            /* This step is inserted for readability. The verification of the presence of the
            Next button on the final page was done as part of the assertion in the last step */
        }

        [When(@"I press the Enter button instead of clicking search")]
        public void WhenIPressTheEnterButtonInsteadOfClickingSearch()
        {
            switch (webPage)
            {
                case "Explore careers":
                    exploreCareersPage.ClickEnterInSearchField();
                    break;
                case "Job profiles":
                    jobProfilesPage.ClickEnterInSearchField();
                    break;
                case "Search results":
                    searchResultsPage.ClickSearchButton();
                    break;
            }
        }

        [Then(@"the search results screen is displayed.")]
        public void ThenTheSearchResultsScreenIsDisplayed()
        {
            switch (webPage)
            {
                case "Search results":
                    Assert.IsTrue(searchResultsPage.GetZeroResultsMsg().Contains("results found"), "Pressing the enter key did not produce search results");
                    break;
            }

            Assert.AreEqual("Search results for", searchResultsPage.GetSearchResultsForText(), "Pressing Enter did not advance to the search results page");
        }

        [Given(@"I am at the ""(.*)"" page for (.*)")]
        public void GivenIAmAtThePageFor(string resourceOne, string resourceTwo)
        {
            exploreCareersPage.NavigateToPage(resourceOne, resourceTwo);
        }

        [Given(@"I am at the ""(.*)"" Administration web page")]
        public void GivenIAmAtTheAdministrationWebPage(string resource)
        {
            exploreCareersPage.NavigateToPage(resource, "Administration");
        }

        [Given(@"I am at the ""(.*)"" web page for (.*)")]
        public void GivenIAmAtTheWebPageFor(string resource, string resourceTwo)
        {
            jobCategory = resourceTwo;
            exploreCareersPage.NavigateToPage(resource, resourceTwo);
        }

        [Given(@"I navigate to the (.*) page for (.*)")]
        public void GivenINavigateToThePageFor(string resource, string resourceTwo)
        {
            jobCategory = resourceTwo;
            exploreCareersPage.NavigateToPage(resource, resourceTwo);
        }

        [Then(@"the (.*) link is not present amongst the links beneath the Other job categories side section")]
        public void ThenTheLinkIsNotPresentAmongstTheLinksBeneathTheOtherJobCategoriesSideSection(string jobCategory)
        {
            Assert.True(jobCategoriesPage.GetJobCategorySideLinks(jobCategory), "The " + jobCategory + " link is present, unexpectedly.");
        }

        [Given(@"I check the list displayed below against the list of Job categories displayed on that page")]
        public void GivenICheckTheListDisplayedBelowAgainstTheListOfJobCategoriesDisplayedOnThatPage(Table table)
        {
            jobCategories = table.CreateSet<JobCategories>().ToList();
        }

        [Then(@"both lists are the same")]
        public void ThenBothListsAreTheSame()
        {
            Assert.IsTrue(exploreCareersPage.VerifyJobCategoryList(jobCategories), "Expected and actual Job categories are not the same");
        }

        [When(@"I check the job profiles list")]
        public void WhenICheckTheJobProfilesList()
        {
            jobProfiles = jobCategoriesPage.GetJobProfiles();
        }

        [Then(@"none of the job profiles occur more than once")]
        public void ThenNoneOfTheJobProfilesOccurMoreThanOnce()
        {
            Assert.AreEqual(0, jobCategoriesPage.VerifyJobProfileCount(jobProfiles), "There are multiple occurrences in the Job profiles for " + jobCategory + ".");
        }

        [When(@"I click the link for the (.*) Job profile under that Job category")]
        public void WhenIClickTheLinkForTheJobProfileUnderThatJobCategory(string linkPosition)
        {
            jobCategoriesPage.ClickLinkInPosition(linkPosition);
        }

        [Then(@"I am taken profile details page for that Job profile")]
        public void ThenIAmTakenProfileDetailsPageForThatJobProfile()
        {
            Assert.AreEqual(jobCategoriesPage.JobProfileHeading, jobProfilesPage.GetJobProfileHeading(), "Clicking the " + jobCategoriesPage.JobProfileHeading + " link failed");
        }

        [When(@"I examine the ""(.*)"" list")]
        public void WhenIExamineTheList(string listToExamine)
        {
            jobCategoryList = exploreCareersPage.GetList(listToExamine);
        }

        [When(@"I examine the (.*) list")]
        public void WhenIExamineTheJobCategoriesList(string listToExamine)
        {
            switch (listToExamine)
            {
                case "Job categories":
                    jobCategoryList = exploreCareersPage.GetList(listToExamine);
                    break;
                case "Job profiles":
                    jobCategoryList = exploreCareersPage.GetList(listToExamine);
                    break;
                case "Other job categories":
                    jobCategoryList = exploreCareersPage.GetList(listToExamine);
                    break;
            }
        }

        [Then(@"the list is in alphabetical order")]
        public void ThenTheListIsInAlphabeticalOrder()
        {
            Assert.True(exploreCareersPage.VerifyOrdering(), jobCategoryList + " is not in alphabetical order");
        }

        [When(@"I examine the page")]
        public void WhenIExamineThePage()
        {
            jobCategoryPagePaginated = jobCategoriesPage.IsPagePaginated();
        }

        [Then(@"the page contains no pagination")]
        public void ThenThePageContainsNoPagination()
        {
            Assert.IsFalse(jobCategoryPagePaginated, "The job categories > Administration page is, unexpectedly, paginated");
        }

        [Then(@"the search results field placeholder text is ""(.*)""")]
        public void ThenTheSearchResultsFieldPlaceholderTextIsEnterAJobTitle(string placeholderText)
        {
            Assert.AreEqual(placeholderText, searchResultsPage.GetPlaceholderText(), "Placeholder text incorrect.");
        }

        [Then(@"the number of results stated as found is the equal to the actual number of Job profiles listed thereunder")]
        public void ThenTheNumberOfResultsStatedAsFoundIsTheEqualToTheActualNumberOfJobProfilesListedThereunder()
        {
            searchResultsPage.ProfilesCounter();

            Assert.AreEqual(searchResultsPage.GetNumberOfSearchResults(), searchResultsPage.ProfilesCount, "Search result figure not equal to number of job profiles found");
        }

        [When(@"I click the link in the message")]
        public void WhenIClickTheLinkInTheMessage()
        {
            searchResultsPage.ClickDidYouMeanLink();
        }

        [Then(@"the url bears the suggested search term (.*) as its parameter")]
        public void ThenTheUrlBearsTheSuggestedSearchTermNurseAsItsParameter(string suggestedProfession)
        {
            searchResultsPage.UrlContainsSuggestion(suggestedProfession);
        }

        [When(@"I click the Explore careers breadcrumb")]
        public void WhenIClickTheExploreCareersBreadcrumb()
        {
            jobCategoriesPage.ClickExploreCareersBreadcrumb();
        }

        [Then(@"I am on the ""(.*)"" page")]
        public void ThenIAmOnThePage(string page)
        {
            Assert.AreEqual(page, exploreCareersPage.GetPageHeading(), "Breacrumb did not land on the " + page + " page.");
        }

        [Then(@"the page displayed as a result bears the breadcrumb (.*)")]
        public void ThenThePageDisplayedAsAResultBearsTheBreadcrumb(string breadCrumb)
        {
            if (breadCrumb == null)
            {
                throw new ArgumentNullException(nameof(breadCrumb));
            }

            Assert.IsEmpty(jobCategoriesPage.GetBreadcrumbVerifier(breadCrumb), "Breadcrumb for page " + jobCategoriesPage.GetBreadcrumbVerifier(breadCrumb) + " is incorrect.");
        }

        [Then(@"the breadcrumb for that specific Job profile is displayed")]
        public void ThenTheBreadcrumbForThatSpecificJobProfileIsDisplayed()
        {
            Assert.AreEqual("Test passed", jobCategoriesPage.ClickJobProfiles(jobCategory), "Breadcrumb wrong/not displayed");
        }
    }
}