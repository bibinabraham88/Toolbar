using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Helpers;


namespace ToolbarTests.Steps
{
    [Binding]
    public class LoginSteps
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;
        private readonly By _acceptCookies = By.Id("onetrust-accept-btn-handler");
        private readonly By _emailTextBox = By.Id("txtEmail");
        private readonly By _passwordBox = By.Id("loginPasswordInput");
        private readonly By _accountLabelOnTopRightHandOnTCB = By.CssSelector("[id$='_lblAccount']");
        private readonly By _joinButtonOnToolbar = By.CssSelector(".cta.welcome__button");
        private readonly By _loginBtn = By.Id("Loginbtn");
        private readonly By _bestDealsText = By.CssSelector(".tab__title");

        public LoginSteps(ScenarioContext scenarioContext )
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();

        }

        [When(@"I try to open the toolbar extesion in '(.*)'")]
        public void WhenITryToOpenTheToolbarExtesionIn(string browser)
        {
            switch (browser)
            {
                case "Chrome":
                    _driver.Navigate().GoToUrl("chrome-extension://mpkbmnhnhfdmhnkblpjlaadamhajnmbo/popup.html");
                    break;

                case "Edge":
                    _driver.Navigate().GoToUrl("chrome-extension://mpkbmnhnhfdmhnkblpjlaadamhajnmbo/popup.html");
                    break;

                case "Firefox":
                    _driver.Navigate().GoToUrl("chrome-extension://mpkbmnhnhfdmhnkblpjlaadamhajnmbo/popup.html");
                    break;
            }
        }


        [When(@"I click on join button")]
        public void ThenIShouldSeeTheToolbarPopUp()
        {
            _driver.FocusFirstWindow();
            _driver.WaitForElementVisible(_joinButtonOnToolbar);
            _driver.FindElement(_joinButtonOnToolbar).Click();
        }

        [When(@"I login to the TCB Website")]
        public void WhenILoginToTheTCBWebsite()
        {
            _driver.FocusFirstWindow();
            _driver.WaitForElementVisible(_acceptCookies);
            _driver.Click(_acceptCookies);
            _driver.WaitForElementNotVisible(_acceptCookies);
            _driver.SendKeys(_emailTextBox, "tcbtestteam@topcashback.co.uk");
            _driver.SendKeys(_passwordBox, "Yadda123!");
            _driver.Click(_loginBtn);
            _driver.AssertElementDisplayed(_accountLabelOnTopRightHandOnTCB);
        }

        [Then(@"I should see the logged in toolbar")]
        public void ThenIShouldSeeTheLoggedInToolbar()
        {
            _driver.FocusFirstWindow();
            _driver.AssertElementDisplayed(_bestDealsText);
        }

    }
}
