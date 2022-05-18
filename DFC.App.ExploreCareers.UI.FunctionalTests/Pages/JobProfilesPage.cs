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
    internal class JobProfilesPage
    {
        private ScenarioContext scenarioContext;

        public JobProfilesPage(ScenarioContext context)
        {
            scenarioContext = context;
        }

        private IWebElement SearchField => scenarioContext.GetWebDriver().FindElement(By.Id("search-main"));

        private IWebElement JobProlileHeading => scenarioContext.GetWebDriver().FindElement(By.CssSelector(".govuk-grid-column-two-thirds h1"));

        public void EnterSearchTerm(string searchTerm)
        {
            Devices.ScrollIntoView(this.scenarioContext.GetWebDriver(), scenarioContext.GetWebDriver().FindElement(By.Id("search-main")));
            SearchField.SendKeys(searchTerm);
        }

        public void SelectFromAutosuggest(string autosuggested)
        {
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
            SearchField.Click();
            scenarioContext.GetWebDriver().FindElement(By.XPath("//div[@class='job-profile-search-content']//following-sibling::ul/li/div[contains(text(), '" + autosuggested + "')]")).Click();
        }

        public string GetSelectedSearchTerm()
        {
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
            return SearchField.GetAttribute("value");
        }

        public void ClickEnterInSearchField()
        {
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
            SearchField.SendKeys(Keys.Enter);
        }

        public string GetJobProfileHeading()
        {
            Devices.WaitVisible(scenarioContext.GetWebDriver(), By.ClassName("govuk-footer"));
            var jobProfileHeadingText = JobProlileHeading.Text.Trim();

            return jobProfileHeadingText;
        }
    }
}