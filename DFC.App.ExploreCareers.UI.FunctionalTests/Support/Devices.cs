﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

        public static void WriteToFile(string path, string file, string textToWrite)
        {
            File.AppendAllText(path + file, textToWrite + Environment.NewLine);
        }

        public static int TotalLines(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                int i = 0;
                while (r.ReadLine() != null)
                {
                    i++;
                }

                return i;
            }
        }
    }
}
