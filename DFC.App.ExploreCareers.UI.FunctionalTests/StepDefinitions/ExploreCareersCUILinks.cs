using DFC.App.ExploreCareers.UI.FunctionalTests.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.App.ExploreCareers.UI.FunctionalTests.StepDefinitions
{
    [Binding]
    public sealed class ExploreCareersCUILinks
    {
        private readonly JobCategoriesPage jobCategoriesPage;

        public ExploreCareersCUILinks(ScenarioContext scenarioContext)
        {
            jobCategoriesPage = new JobCategoriesPage(scenarioContext);
        }

        [When(@"I click the link for each of the Job profiles listed thereunder in turn")]
        public void WhenIClickTheLinkForEachOfTheJobProfilesListedThereunderInTurn()
        {
            /* This step is inserted for readability. The action herein is performed in the Then step */
        }

        [Then(@"I am navigated to the Job profiles page for the Job profile clicked")]
        public void ThenIAmNavigatedToTheJobProfilesPageForTheJobProfileClicked()
        {
            /* This step is inserted for readability. The action herein is performed in the Then step */
        }
    }
}