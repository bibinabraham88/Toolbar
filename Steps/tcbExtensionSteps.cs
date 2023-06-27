using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ToolbarTests.Steps
{
    [Binding]
    public class tcbExtensionSteps
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;

        public tcbExtensionSteps(ScenarioContext scenarioContext )
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();

        }

        [Given(@"I try to open the toolbar extesion")]
        public void WhenITryToOpenTheToolbarExtesion()
        {
            _driver.Navigate().GoToUrl("chrome-extension://ekeeeebmbhkkjcaoicinbdjmklipppkj/popup.html");
            
        }

        [When(@"I click on join button")]
        public void ThenIShouldSeeTheToolbarPopUp()
        {

            _driver.FindElement(By.CssSelector(".cta.welcome__button")).Click();
        }

    }
}
