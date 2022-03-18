using DFC.App.ExploreCareers.UI.FunctionalTests.Support;
using DFC.TestAutomation.UI.Extension;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.App.ExploreCareers.UI.FunctionalTests.Pages
{
    internal class SearchResultsPage
    {
        private ScenarioContext scenarioContext;

        public SearchResultsPage(ScenarioContext context)
        {
            scenarioContext = context;
        }

        public int ProfilesCount { get; set; }

        private IWebElement SearchField => scenarioContext.GetWebDriver().FindElement(By.Id("search-main"));

        private IWebElement SearchButton => scenarioContext.GetWebDriver().FindElement(By.ClassName("button"));

        private IWebElement ResultsCount => scenarioContext.GetWebDriver().FindElement(By.Id("result-count"));

        private IWebElement TextDidYouMean => scenarioContext.GetWebDriver().FindElement(By.CssSelector(".search-dym > span"));

        private IWebElement NextPaginator => scenarioContext.GetWebDriver().FindElement(By.ClassName("dfc-code-search-nextlink"));

        private IWebElement SearchResultsForText => scenarioContext.GetWebDriver().FindElement(By.CssSelector(".search-input.ui-front > h1"));

        private IWebElement Footer => scenarioContext.GetWebDriver().FindElement(By.ClassName("govuk-footer"));

        public void SelectFromAutosuggest(string autosuggested)
        {
            SearchField.Click();
            scenarioContext.GetWebDriver().FindElement(By.XPath("//h1//following-sibling::ul/li/div[contains(text(), '" + autosuggested + "')]")).Click();
        }

        public string GetSelectedSearchTerm()
        {
            return SearchField.GetAttribute("value");
        }

        public void ClickSearchButton()
        {
            SearchButton.Click();
        }

        public string GetZeroResultsMsg()
        {
            return ResultsCount.Text.Trim();
        }

        public string GetDidYouMean()
        {
            return TextDidYouMean.Text.Trim();
        }

        public void ClearSearchField()
        {
            SearchField.Clear();
        }

        public string GetUrl()
        {
            return scenarioContext.GetWebDriver().Url;
        }

        public int GetNumberOfSearchResults()
        {
            if (ResultsCount.Text.Trim() == "1 result found")
            {
                return int.Parse(ResultsCount.Text.Replace("result found", string.Empty).Trim(), new CultureInfo("en-au"));
            }
            else
            {
                return int.Parse(ResultsCount.Text.Replace("results found", string.Empty).Trim(), new CultureInfo("en-au"));
            }
        }

        public decimal NumberOfSeachResultPages()
        {
            decimal ofSearchCount = GetNumberOfSearchResults();
            decimal searchCountGroups = ofSearchCount / 10;
            decimal ofSearchCountGroups = Math.Ceiling(searchCountGroups) - 1;

            return ofSearchCountGroups;
        }

        public void Paginator()
        {
            decimal numberOfSeachResultPages = NumberOfSeachResultPages();

            while (numberOfSeachResultPages > 0)
            {
                NextPaginator.Click();
                numberOfSeachResultPages--;
            }
        }

        public bool NextVerifier()
        {
            Paginator();

            Devices.ScrollIntoView(scenarioContext.GetWebDriver(), Footer);

            try
            {
                scenarioContext.GetWebDriver().FindElement(By.ClassName("dfc-code-search-nextlink"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public string GetSearchResultsForText()
        {
            return SearchResultsForText.Text.Trim();
        }

        public string GetPlaceholderText()
        {
            return SearchField.GetAttribute("placeholder");
        }

        public string GetNumberOfProfilesListed()
        {
            return SearchField.GetAttribute("placeholder");
        }

        public void ProfilesCounter()
        {
            if (GetNumberOfSearchResults() <= 10)
            {
                ProfilesCount = GetProfilesList();
            }
            else
            {
                decimal numberOfSeachResultPages = NumberOfSeachResultPages();

                while (numberOfSeachResultPages > 0)
                {
                    ProfilesCount = ProfilesCount + GetProfilesList();
                    NextPaginator.Click();
                    numberOfSeachResultPages--;
                }

                ProfilesCount = ProfilesCount + GetProfilesList();
            }
        }

        public int GetProfilesList()
        {
            return scenarioContext.GetWebDriver().FindElements(By.ClassName("dfc-code-search-jpTitle")).Count;
        }

        public void ClickDidYouMeanLink()
        {
            scenarioContext.GetWebDriver().FindElement(By.CssSelector(".search-dym > span a")).Click();
        }

        public bool UrlContainsSuggestion(string suggestedProfession)
        {
            string url = scenarioContext.GetWebDriver().Url;
            var result = url.Substring(url.LastIndexOf('=') + 1);

            return result == suggestedProfession;
        }

        public void SearchProfile(string searchTerm)
        {
            SearchField.SendKeys(searchTerm);
            SearchButton.Click();
        }

        public bool CompareCounts(int countInEnvironment, int countInProduction)
        {
            return countInEnvironment == countInProduction;
        }
    }
}