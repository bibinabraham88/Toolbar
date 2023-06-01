using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ToolbarTests.Steps
{
    [Binding]
    public class tcbExtensionSteps
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;

        public tcbExtensionSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I open the chrome browser")]
        public void GivenIOpenTheChromeBrowser()
        {
            driver = _scenarioContext.Get<IWebDriver>("webDriver");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.postMessage('clicked_browser_action', '*')");
            driver.Navigate().GoToUrl("https://www.google.com");
        }

        [When(@"I try to open the toolbar extesion")]
        public void WhenITryToOpenTheToolbarExtesion()
        {
            
        }

        [Then(@"I should see the toolbar pop up")]
        public void ThenIShouldSeeTheToolbarPopUp()
        {
            
        }

    }
}
