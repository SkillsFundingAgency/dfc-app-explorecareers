using DFC.App.ExploreCareers.UI.FunctionalTests.Model;
using DFC.App.ExploreCareers.UI.FunctionalTests.StepDefinitions;
using DFC.App.ExploreCareers.UI.FunctionalTests.Support;
using DFC.App.ExploreCareers.UI.FunctionalTests.Support.Poco;
using DFC.TestAutomation.UI.Extension;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.App.ExploreCareers.UI.FunctionalTests.Pages
{
    internal class ExploreCareersPage
    {
        private readonly ScenarioContext scenarioContext;

        public ExploreCareersPage(ScenarioContext context)
        {
            scenarioContext = context;
        }

        public static string Endpoint { get; set; }

        private IWebElement SearchField => scenarioContext.GetWebDriver().FindElement(By.Id("SearchTerm"));

        private IWebElement SearchButton => scenarioContext.GetWebDriver().FindElement(By.ClassName("submit"));

        private IWebElement PageHeading => scenarioContext.GetWebDriver().FindElement(By.Id("site-header"));

        public void ClickLinkJobCategory(string jobCategory)
        {
            scenarioContext.GetWebDriver().FindElement(By.XPath("//*[@class='govuk-link'][contains(text(),'" + jobCategory + "')]")).Click();
        }

        public void NavigateToPage(string resourceOne, string resourceTwo = null)
        {
            Endpoint = this.scenarioContext.GetSettingsLibrary<AppSettings>().AppSettings.AppBaseUrl.ToString().Replace("job-profiles/", string.Empty);

            switch (resourceOne)
            {
                case "Explore careers":
                    this.scenarioContext.GetWebDriver().Url = Endpoint + "explore-careers";
                    break;
                case "Job profiles":
                    this.scenarioContext.GetWebDriver().Url = Endpoint + "job-profiles/admin-assistant";
                    Devices.ScrollIntoView(this.scenarioContext.GetWebDriver(), scenarioContext.GetWebDriver().FindElement(By.Id("search-main")));
                    break;
                case "Search results":
                    this.scenarioContext.GetWebDriver().Url = Endpoint + "search-results";
                    break;
                case "Job categories":
                    this.scenarioContext.GetWebDriver().Url = Endpoint + "job-categories/" + ProcessResourceTwo(resourceTwo);
                    break;
            }
        }

        public string ProcessResourceTwo(string resourceTwo)
        {
            string secondResource = string.Empty;

            switch (resourceTwo)
            {
                case "Administration":
                    secondResource = "Administration";
                    break;
                case "Animal care":
                    secondResource = "animal-care";
                    break;
                case "Beauty and wellbeing":
                    secondResource = "beauty-and-wellbeing";
                    break;
                case "Business and finance":
                    secondResource = "business-and-finance";
                    break;
                case "Computing, technology and digital":
                    secondResource = "computing-technology-and-digital";
                    break;
                case "Construction and trades":
                    secondResource = "construction-and-trades";
                    break;
                case "Creative and media":
                    secondResource = "creative-and-media";
                    break;
                case "Delivery and storage":
                    secondResource = "delivery-and-storage";
                    break;
                case "Emergency and uniform services":
                    secondResource = "emergency-and-uniform-services";
                    break;
                case "Engineering and maintenance":
                    secondResource = "engineering-and-maintenance";
                    break;
                case "Environment and land":
                    secondResource = "environment-and-land";
                    break;
                case "Government services":
                    secondResource = "government-services";
                    break;
                case "Healthcare":
                    secondResource = "healthcare";
                    break;
                case "Home services":
                    secondResource = "home-services";
                    break;
                case "Hospitality and food":
                    secondResource = "hospitality-and-food";
                    break;
                case "Law and legal":
                    secondResource = "law-and-legal";
                    break;
                case "Managerial":
                    secondResource = "Managerial";
                    break;
                case "Manufacturing":
                    secondResource = "Manufacturing";
                    break;
                case "Retail and sales":
                    secondResource = "retail-and-sales";
                    break;
                case "Science and research":
                    secondResource = "science-and-research";
                    break;
                case "Social care":
                    secondResource = "social-care";
                    break;
                case "Sports and leisure":
                    secondResource = "sports-and-leisure";
                    break;
                case "Teaching and education":
                    secondResource = "teaching-and-education";
                    break;
                case "Transport":
                    secondResource = "Transport";
                    break;
                case "Travel and tourism":
                    secondResource = "travel-and-tourism";
                    break;
                default:
                    secondResource = string.Empty;
                    break;
            }

            return secondResource;
        }

        public void EnterSearchTerm(string searchTerm)
        {
            ClearSearchField();
            SearchField.SendKeys(searchTerm);
        }

        public void SelectFromAutosuggest(string autosuggested)
        {
           SearchField.Click();
           scenarioContext.GetWebDriver().FindElement(By.XPath("//div[@class='header-search-content']//following-sibling::ul/li/div[contains(text(), '" + autosuggested + "')]")).Click();
        }

        public string GetSelectedSearchTerm()
        {
            return SearchField.GetAttribute("value");
        }

        public void ClickSearchButton()
        {
            SearchButton.Click();
        }

        public void ClearSearchField()
        {
            SearchField.Clear();
        }

        public string GetUrl()
        {
            return scenarioContext.GetWebDriver().Url;
        }

        public void ClickEnterInSearchField()
        {
            SearchField.Click();
            SearchField.SendKeys(Keys.Enter);
        }

        public IList<IWebElement> GetJobCategoryList()
        {
            IList<IWebElement> allList = scenarioContext.GetWebDriver().FindElements(By.CssSelector(".govuk-list.homepage-jobcategories > li > a"));

            return allList;
        }

        public bool VerifyJobCategoryList(IEnumerable<JobCategories> expectedJobCategories)
        {
            bool a_and_b_checks = false;

            //A - Check.
            //Convert IEnumerable expected results to string
            string[] expected = expectedJobCategories.Select(p => p.JobCategory).ToArray();

            //Get actual list from the UI
            IList<IWebElement> actualJobCategoriesList = scenarioContext.GetWebDriver().FindElements(By.CssSelector(".govuk-list.homepage-jobcategories > li > a"));

            //translate IWebElements above into a collection of strings so they can be compared
            IEnumerable<string> actual = actualJobCategoriesList.Select(i => i.Text);

            //determines, as bool, if items in 1 and 2 are present in the other
            var optionsVerified = expected.All(d => actual.Contains(d));

            //B - Check.
            int noOfActualElements = actualJobCategoriesList.Count;
            bool optionsEqual = false;

            if (expected.Length == noOfActualElements)
            {
                optionsEqual = true;
            }

            if (optionsVerified == true && optionsEqual == true)
            {
                a_and_b_checks = true;
            }

            return a_and_b_checks;
        }

        public IList<IWebElement> GetList(string listToExamine)
        {
            IList<IWebElement> theList = null;

            switch (listToExamine)
            {
                case "Job categories":
                    theList = scenarioContext.GetWebDriver().FindElements(By.CssSelector(".govuk-list.homepage-jobcategories li a"));
                    break;
                case "Job profiles":
                    theList = scenarioContext.GetWebDriver().FindElements(By.CssSelector(".govuk-list.job-categories_items li h2 a"));
                    break;
                case "Other job categories":
                    theList = scenarioContext.GetWebDriver().FindElements(By.CssSelector(".govuk-list.font-xsmall > li > a"));
                    break;
            }

            return theList;
        }

        public bool VerifyOrdering()
        {
            var x = GetJobCategoryList().Select(item => item.Text.Replace(System.Environment.NewLine, string.Empty));
            var sorted = new List<string>();
            sorted.AddRange(x.OrderBy(o => o));

            return x.SequenceEqual(sorted);
        }

        public string GetPageHeading()
        {
            return PageHeading.Text;
        }
    }
}