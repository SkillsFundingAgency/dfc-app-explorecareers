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

        private IWebElement firstSearchResult => scenarioContext.GetWebDriver().FindElement(By.CssSelector(".results-list > li:nth-of-type(1) > h3 a:nth-of-type(1)"));

        public void SelectFromAutosuggest(string autosuggested)
        {
            SearchField.Click();
            scenarioContext.GetWebDriver().FindElement(By.XPath("//h1//following-sibling::ul/li/div[contains(text(), '" + autosuggested + "')]")).Click();
        }

        public string GetSelectedSearchTerm()
        {
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
            return SearchField.GetAttribute("value");
        }

        public void ClickSearchButton()
        {
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
            SearchButton.Click();
        }

        public string GetZeroResultsMsg()
        {
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
            return ResultsCount.Text.Trim();
        }

        public string GetDidYouMean()
        {
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
            return TextDidYouMean.Text.Trim();
        }

        public void ClearSearchField()
        {
            SearchField.Clear();
        }

        public string GetUrl()
        {
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
            return scenarioContext.GetWebDriver().Url;
        }

        public int GetNumberOfSearchResults()
        {
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
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
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
            decimal numberOfSeachResultPages = NumberOfSeachResultPages();

            while (numberOfSeachResultPages > 0)
            {
                NextPaginator.Click();
                Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
                numberOfSeachResultPages--;
            }
        }

        public bool NextVerifier()
        {
            Paginator();

            Devices.ScrollIntoView(scenarioContext.GetWebDriver(), Footer);
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));

            try
            {
                return scenarioContext.GetWebDriver().FindElement(By.ClassName("dfc-code-search-nextlink")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public string GetSearchResultsForText()
        {
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
            return SearchResultsForText.Text.Trim();
        }

        public string GetPlaceholderText()
        {
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
            return SearchField.GetAttribute("placeholder");
        }

        public string GetNumberOfProfilesListed()
        {
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
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
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
            return scenarioContext.GetWebDriver().FindElements(By.ClassName("dfc-code-search-jpTitle")).Count;
        }

        public void ClickDidYouMeanLink()
        {
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
            scenarioContext.GetWebDriver().FindElement(By.CssSelector(".search-dym > span a")).Click();
        }

        public bool UrlContainsSuggestion(string suggestedProfession)
        {
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
            string url = scenarioContext.GetWebDriver().Url;
            var result = url.Substring(url.LastIndexOf('=') + 1);

            return result == suggestedProfession;
        }

        public void SearchProfile(string searchTerm)
        {
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
            SearchField.SendKeys(searchTerm.Trim());
            SearchButton.Click();
        }

        public bool CompareCounts(int countInEnvironment, int countInProduction)
        {
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
            return countInEnvironment == countInProduction;
        }

        public void ClickFirstSearchResult()
        {
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
            firstSearchResult.Click();
        }
    }
}