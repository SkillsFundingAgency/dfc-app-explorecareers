using DFC.TestAutomation.UI.Extension;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.App.ExploreCareers.UI.FunctionalTests.Pages
{
    internal class JobCategoriesPage
    {
        private ScenarioContext scenarioContext;

        public JobCategoriesPage(ScenarioContext context)
        {
            scenarioContext = context;
        }

        public string JobProfileHeading { get; set; }

        //IWebElement heading => _scenarioContext.GetWebDriver().FindElement(By.ClassName("heading-xlarge")); //PreProd
        private IWebElement Heading => scenarioContext.GetWebDriver().FindElement(By.ClassName("govuk-heading-xl")); //SIT

        private IWebElement ExploreCareersBreadcrumb => scenarioContext.GetWebDriver().FindElement(By.CssSelector(".govuk-breadcrumbs li:nth-of-type(2) a"));

        public string GetHeadingText()
        {
            return Heading.Text;
        }

        public bool GetJobCategorySideLinks(string jobCategory)
        {
            IList<IWebElement> allLinks = scenarioContext.GetWebDriver().FindElements(By.CssSelector(".govuk-list.font-xsmall > li > a"));

            for (int i = 0; i < allLinks.Count; i++)
            {
                if (allLinks[i].Text == jobCategory)
                {
                    return false;
                }
            }

            return true;
        }

        public IList<IWebElement> GetJobProfiles()
        {
            IList<IWebElement> jobProfiles = scenarioContext.GetWebDriver().FindElements(By.CssSelector(".dfc-code-search-jpTitle.govuk-link"));

            return jobProfiles;
        }

        public int VerifyJobProfileCount(IList<IWebElement> jobProfileElements)
        {
            IEnumerable<string> jobProfileElementsString = jobProfileElements.Select(i => i.Text);

            int multipleOccurences = jobProfileElementsString.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key).ToList().Count;

            return multipleOccurences;
        }

        public void ClickLinkInPosition(string linkPosition)
        {
            switch (linkPosition)
            {
                case "first":
                    JobProfileHeading = scenarioContext.GetWebDriver().FindElement(By.CssSelector(".govuk-list.job-categories_items li:nth-of-type(1) h2 a")).Text;
                    scenarioContext.GetWebDriver().FindElement(By.CssSelector(".govuk-list.job-categories_items li:nth-of-type(1) h2 a")).Click();
                    break;
                case "second":
                    JobProfileHeading = scenarioContext.GetWebDriver().FindElement(By.CssSelector(".govuk-list.job-categories_items li:nth-of-type(2) h2 a")).Text;
                    scenarioContext.GetWebDriver().FindElement(By.CssSelector(".govuk-list.job-categories_items li:nth-of-type(2) h2 a")).Click();
                    break;
                case "third":
                    JobProfileHeading = scenarioContext.GetWebDriver().FindElement(By.CssSelector(".govuk-list.job-categories_items li:nth-of-type(3) h2 a")).Text;
                    scenarioContext.GetWebDriver().FindElement(By.CssSelector(".govuk-list.job-categories_items li:nth-of-type(3) h2 a")).Click();
                    break;
                case "fourth":
                    JobProfileHeading = scenarioContext.GetWebDriver().FindElement(By.CssSelector(".govuk-list.job-categories_items li:nth-of-type(4) h2 a")).Text;
                    scenarioContext.GetWebDriver().FindElement(By.CssSelector(".govuk-list.job-categories_items li:nth-of-type(4) h2 a")).Click();
                    break;
                case "fifth":
                    JobProfileHeading = scenarioContext.GetWebDriver().FindElement(By.CssSelector(".govuk-list.job-categories_items li:nth-of-type(5) h2 a")).Text;
                    scenarioContext.GetWebDriver().FindElement(By.CssSelector(".govuk-list.job-categories_items li:nth-of-type(5) h2 a")).Click();
                    break;
            }
        }

        public bool IsPagePaginated()
        {
            try
            {
                scenarioContext.GetWebDriver().FindElement(By.ClassName("pagination-label"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ClickExploreCareersBreadcrumb()
        {
            ExploreCareersBreadcrumb.Click();
        }
    }
}