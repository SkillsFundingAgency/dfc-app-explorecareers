using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.App.ExploreCareers.UI.FunctionalTests.Support
{
    internal static class Devices
    {
        public static void ScrollIntoView(IWebDriver driver, IWebElement elementLocator)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", elementLocator);
        }

        public static void JavascriptClick(IWebDriver driver, By locator)
        {
            IJavaScriptExecutor jS = (IJavaScriptExecutor)driver;
            jS.ExecuteScript("arguments[0].click();", locator);
        }
    }
}
