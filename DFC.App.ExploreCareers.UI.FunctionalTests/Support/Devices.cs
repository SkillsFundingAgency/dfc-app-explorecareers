using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
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

        public static string Between(string str, string firstString, string lastString)
        {
            string finalString;
            int pos1 = str.IndexOf(firstString, StringComparison.Ordinal) + firstString.Length;
            int pos2 = str.IndexOf(lastString, StringComparison.Ordinal);
            finalString = str.Substring(pos1, pos2 - pos1);
            return finalString;
        }

        public static string RandomString()
        {
            int randomStringLength = 4;

            using (var crypto = new RNGCryptoServiceProvider())
            {
                var bits = randomStringLength * 6;
                var byte_size = (bits + 7) / 8;
                var bytesarray = new byte[byte_size];
                crypto.GetBytes(bytesarray);

                return Convert.ToBase64String(bytesarray);
            }
        }
    }
}