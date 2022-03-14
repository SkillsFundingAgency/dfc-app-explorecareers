using System;
using System.Threading.Tasks;
using DFC.App.ExploreCareers.Model;
using DFC.TestAutomation.UI.Extension;

using OpenQA.Selenium.Remote;

using TechTalk.SpecFlow;

namespace DFC.App.ExploreCareers.UI.FunctionalTests.Hooks
{
    [Binding]
    public class AfterScenario
    {
        public AfterScenario(ScenarioContext context)
        {
            Context = context ?? throw new NullReferenceException($"The scenario context is null. The {nameof(AfterScenario)} class cannot be initialised.");
        }

        private ScenarioContext Context { get; set; }

        [AfterScenario(Order = 0)]
        public async Task UpdateBrowserStack()
        {
            var browserHelper = this.Context.GetHelperLibrary<AppSettings>().BrowserHelper;
            if (browserHelper.IsExecutingInBrowserStack())
            {
                var sessionId = (this.Context.GetWebDriver() as RemoteWebDriver).SessionId.ToString();
                var browserStackHelper = this.Context.GetHelperLibrary<AppSettings>().BrowserStackHelper;

                if (this.Context.TestError != null)
                {
                    var errorMessage = this.Context.TestError.InnerException.Message;
                    await browserStackHelper.SetTestToFailedWithReason(sessionId, errorMessage);
                }
                else
                {
                    await browserStackHelper.SetTestToPassed(sessionId);
                }
            }
        }

        [AfterScenario(Order = 1)]
        public void DisposeWebDriver()
        {
            var webDriver = this.Context.GetWebDriver();
            webDriver?.Quit();
            webDriver?.Dispose();
        }
    }
}
