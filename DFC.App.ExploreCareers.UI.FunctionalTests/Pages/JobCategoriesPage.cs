using DFC.App.ExploreCareers.UI.FunctionalTests.Support;
using DFC.TestAutomation.UI.Extension;
using NUnit.Framework;
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

        public List<string> JobProfileDiffs { get; set; }

        //IWebElement heading => _scenarioContext.GetWebDriver().FindElement(By.ClassName("heading-xlarge")); //PreProd
        private IWebElement Heading => scenarioContext.GetWebDriver().FindElement(By.ClassName("govuk-heading-xl")); //SIT

        private IWebElement ExploreCareersBreadcrumb => scenarioContext.GetWebDriver().FindElement(By.CssSelector(".govuk-breadcrumbs li:nth-of-type(2) a"));

        private IWebElement BreadcrumbOne => scenarioContext.GetWebDriver().FindElement(By.CssSelector(".govuk-breadcrumbs__list li:nth-of-type(1)"));

        private IWebElement BreadcrumbTwo => scenarioContext.GetWebDriver().FindElement(By.CssSelector(".govuk-breadcrumbs__list li:nth-of-type(2)"));

        private IWebElement BreadcrumbThree => scenarioContext.GetWebDriver().FindElement(By.CssSelector(".govuk-breadcrumbs__list li:nth-of-type(3)"));

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

        public string GetBreadcrumbVerifier(string expectedBreadCrumb)
        {
            string jobCategory = string.Empty;
            string[] expectedBreadcrumbSingles = expectedBreadCrumb.Split(">");
            string[] actualBreadcrumbSingles = { BreadcrumbOne.Text, BreadcrumbTwo.Text, BreadcrumbThree.Text };

            for (int i = 0; i < expectedBreadcrumbSingles.Length; i++)
            {
                if (expectedBreadcrumbSingles[i].Trim() != actualBreadcrumbSingles[i].Trim())
                {
                    jobCategory = expectedBreadcrumbSingles[2].Trim();
                }
                else
                {
                    jobCategory = string.Empty;
                }
            }

            return jobCategory;
        }

        public string ClickJobProfiles(string jobCategory)
        {
            scenarioContext.GetWebDriver().FindElement(By.Id("accept-all-cookies")).Click();
            string selector = ".job-categories_item h2 a";
            IList<IWebElement> jobProfileLinks = scenarioContext.GetWebDriver().FindElements(By.CssSelector(selector));

            for (int i = 0; i < jobProfileLinks.Count; i++)
            {
                jobProfileLinks = scenarioContext.GetWebDriver().FindElements(By.CssSelector(selector)); //prevents staleness of element
                string jobProfileLinkText = jobProfileLinks[i].Text;
                Devices.ScrollIntoView(scenarioContext.GetWebDriver(), jobProfileLinks[i]);
                jobProfileLinks[i].Click();

                try
                {
                    scenarioContext.GetWebDriver().FindElement(By.CssSelector(".govuk-grid-column-two-thirds > h1"));
                }
                catch (NoSuchElementException)
                {
                    /* Assertion for Job profiles link text on Job categories page against Job profiles page header text */
                    Assert.AreEqual(jobProfileLinkText, string.Empty, "From the " + jobCategory + " Job category page, the " + jobProfileLinkText + " link did not navigate to its Job profile details page.");
                }

                /* Assertion for Job profiles page breadcrumb */
                Assert.AreEqual("Home: Explore careers" + " " + jobProfileLinkText, scenarioContext.GetWebDriver().FindElement(By.CssSelector(".govuk-breadcrumbs__list-item:nth-of-type(1)")).Text + " " + scenarioContext.GetWebDriver().FindElement(By.CssSelector(".govuk-breadcrumbs__list-item:nth-of-type(2)")).Text, jobProfileLinkText + "breadcrumb is incorrect.");
                scenarioContext.GetWebDriver().Navigate().Back();
            }

            return "Test passed"; //if test fails assertion message is displayed
        }

        public IList<string> GetJobProfilesIEnum()
        {
            IList<string> jobProfiles = GetJobProfiles().Select(i => i.Text).ToArray();
            return jobProfiles;
        }

        public bool CompareLists(IList<string> listA, IList<string> listB)
        {
            bool listEqual = listA.Count == listB.Count && listA.Intersect(listB).Count() == listB.Count;
            JobProfileDiffs = listA.Except(listB).ToList();
            return listEqual;
        }
    }
}