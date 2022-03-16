using System;
using System.Globalization;
using System.IO;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

using DFC.App.ExploreCareers.UI.FunctionalTests.Model;
using DFC.TestAutomation.UI;
using DFC.TestAutomation.UI.Extension;
using DFC.TestAutomation.UI.Helper;
using DFC.TestAutomation.UI.Settings;
using DFC.TestAutomation.UI.Support;

using TechTalk.SpecFlow;

namespace DFC.App.ExploreCareers.UI.FunctionalTests.Hooks
{
    [Binding]
    public class BeforeScenario
    {
        /* extent reports*/
        private static AventStack.ExtentReports.ExtentReports extent;
        private static AventStack.ExtentReports.ExtentTest feature;
        private static string reportPath = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Result"
            + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("ddMMyyyy HHmmss", CultureInfo.InvariantCulture);

        private AventStack.ExtentReports.ExtentTest scenario;
        private AventStack.ExtentReports.ExtentTest step;

        public BeforeScenario(ScenarioContext context)
        {
            Context = context ?? throw new NullReferenceException($"The scenario context is null. The {nameof(BeforeScenario)} class cannot be initialised.");
        }

        private ScenarioContext Context { get; set; }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentHtmlReporter htmlReport = new ExtentHtmlReporter(reportPath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReport);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            feature = extent.CreateTest(context.FeatureInfo.Title);
        }

        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.TestError == null)
            {
                step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)
            {
                step.Log(Status.Fail, context.StepContext.StepInfo.Text);
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }

        /* extent reports*/

        [BeforeScenario(Order = 0)]
        public void SetObjectContext(ObjectContext objectContext, ScenarioContext context)
        {
            this.Context.SetObjectContext(objectContext);

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            //Extent report
            scenario = feature.CreateNode(context.ScenarioInfo.Title);
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