using System;
using System.Globalization;
using System.IO;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;

using DFC.App.ExploreCareers.UI.FunctionalTests.Model;
using DFC.App.ExploreCareers.UI.FunctionalTests.Support;
using DFC.TestAutomation.UI;
using DFC.TestAutomation.UI.Extension;
using DFC.TestAutomation.UI.Helper;
using DFC.TestAutomation.UI.Settings;
using DFC.TestAutomation.UI.Support;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DFC.App.ExploreCareers.UI.FunctionalTests.Hooks
{
    [Binding]
    public class BeforeScenario
    {
        private static string filePath = Directory.GetParent(@"../../../").FullName + Path.DirectorySeparatorChar + "Result" + "\\";
        private static string logFile = "jp_counts_log.txt";
        private static string logDiffs = "jp_differences_log.txt";

        /* extent reports*/
        private static AventStack.ExtentReports.ExtentReports extentReports;
        private static ExtentHtmlReporter extentHtmlReporter;
        private static ExtentTest feature;
        private static ExtentTest scenario;
        private readonly ScreenShot screenShot;

        public BeforeScenario(ScenarioContext context)
        {
            Context = context ?? throw new NullReferenceException($"The scenario context is null. The {nameof(BeforeScenario)} class cannot be initialised.");
            screenShot = new ScreenShot(context);
        }

        private ScenarioContext Context { get; set; }

        [BeforeTestRun(Order = 0)]
        public static void BeforeTestRun()
        {
            extentHtmlReporter = new ExtentHtmlReporter(filePath);
            extentHtmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extentReports = new AventStack.ExtentReports.ExtentReports();
            extentReports.AttachReporter(extentHtmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context != null)
            {
                feature = extentReports.CreateTest<Feature>(context.FeatureInfo.Title, context.FeatureInfo.Description);
            }

            File.WriteAllText(filePath + logFile, string.Empty);
            File.WriteAllText(filePath + logDiffs, string.Empty);

            DirectoryInfo di = new DirectoryInfo(filePath + "ScreenShots\\");
            foreach (FileInfo file in di.EnumerateFiles())
            {
                file.Delete();
            }

            Devices.WriteToFile(filePath, logFile, "--begin-- " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture));
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException(nameof(scenarioContext));
            }

            ScenarioBlock scenarioBlock = scenarioContext.CurrentScenarioBlock;

            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    ReportExecution(scenarioContext);
                    break;
                case ScenarioBlock.When:
                    ReportExecution(scenarioContext);
                    break;
                case ScenarioBlock.Then:
                    ReportExecution(scenarioContext);
                    break;
                default:
                    ReportExecution(scenarioContext);
                    break;
            }
        }

        public void ReportExecution(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException(nameof(scenarioContext));
            }

            if (scenarioContext.TestError != null)
            {
                screenShot.TakeScreenShot(scenarioContext.GetWebDriver(), filePath);

                scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
            }
            else
            {
                scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text).Pass(string.Empty);
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extentReports.Flush();

            Devices.WriteToFile(filePath, logFile, "--end-- " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture));
            Devices.WriteToFile(filePath, logFile, (Devices.TotalLines(filePath + logFile) - 2).ToString(CultureInfo.InvariantCulture) + " Job profiles affected");
        }

        /* extent reports*/

        [BeforeScenario]
        public static void BeforeScenarioStart(ScenarioContext scenarioContext)
        {
            if (scenarioContext != null)
            {
                scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title, scenarioContext.ScenarioInfo.Description);
            }
        }

        [BeforeScenario(Order = 0)]
        public void SetObjectContext(ObjectContext objectContext, ScenarioContext context)
        {
            this.Context.SetObjectContext(objectContext);

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
        }

        [BeforeScenario(Order = 1)]
        public void SetSettingsLibrary()
        {
            this.Context.SetSettingsLibrary(new SettingsLibrary<AppSettings>());
        }

        [BeforeScenario(Order = 2)]
        public void SetApplicationUrl()
        {
            string appBaseUrl = this.Context.GetSettingsLibrary<AppSettings>().AppSettings.AppBaseUrl.ToString();
            this.Context.GetSettingsLibrary<AppSettings>().AppSettings.AppBaseUrl = new Uri($"{appBaseUrl}job-profiles/");
        }

        [BeforeScenario(Order = 3)]
        public void ConfigureBrowserStack()
        {
            this.Context.GetSettingsLibrary<AppSettings>().BrowserStackSettings.Name = this.Context.ScenarioInfo.Title;
            this.Context.GetSettingsLibrary<AppSettings>().BrowserStackSettings.Build = "Job profiles";
        }

        [BeforeScenario(Order = 4)]
        public void SetupWebDriver()
        {
            var settingsLibrary = this.Context.GetSettingsLibrary<AppSettings>();
            var webDriver = new WebDriverSupport<AppSettings>(settingsLibrary).Create();
            webDriver.Manage().Window.Maximize();

            //webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(settingsLibrary.TestExecutionSettings.TimeoutSettings.PageNavigation);
            webDriver.SwitchTo().Window(webDriver.CurrentWindowHandle);
            this.Context.SetWebDriver(webDriver);
        }

        [BeforeScenario(Order = 5)]
        public void SetUpHelpers()
        {
            var helperLibrary = new HelperLibrary<AppSettings>(this.Context.GetWebDriver(), this.Context.GetSettingsLibrary<AppSettings>());
            this.Context.SetHelperLibrary(helperLibrary);
        }
    }
}