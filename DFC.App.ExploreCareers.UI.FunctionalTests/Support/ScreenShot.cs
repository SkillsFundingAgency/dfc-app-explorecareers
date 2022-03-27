using DFC.TestAutomation.UI.Extension;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.App.ExploreCareers.UI.FunctionalTests.Support
{
    public class ScreenShot
    {
        private readonly ScenarioContext scenarioContext;

        public ScreenShot(ScenarioContext context)
        {
            scenarioContext = context;
        }

        public void TakeScreenShot(IWebDriver driver, string filePath)
        {
            filePath = filePath + "ScreenShots\\";
            string name = filePath + scenarioContext.ScenarioInfo.Title.Replace(" ", string.Empty) + Devices.RandomString() + ".jpeg";

            if (driver != null)
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(name);
            }
        }
    }
}