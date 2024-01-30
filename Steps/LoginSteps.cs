using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Helpers;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Configuration;

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
        private readonly By _searchBar = By.CssSelector(".search__input");
        private readonly By _searchicon = By.CssSelector(".search__icon");
        private readonly By _topSearchResult = By.CssSelector(".search__results>div:nth-of-type(1)");
        private readonly By _accountOverviewtextOnTCB = By.CssSelector("div[class$='acct-overview-box'] > h1>span:nth-of-type(1)");
        private readonly By _tafpageOnTCB = By.CssSelector(".friend-links-greyed-out");
        private readonly By _pageBtnMyAcc = By.CssSelector(".footer__item.footer__item__left");
        private readonly By _pageBtnTAF = By.CssSelector(".footer>div:nth-of-type(2)");


        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();

        }

        [When(@"I try to open the toolbar extesion")]
        public void WhenITryToOpenTheToolbarExtesionIn()
        {
            switch (ConfigurationManager.AppSettings["browser"])
            {
                case "Chrome":
                    _driver.Navigate().GoToUrl("chrome-extension://mpkbmnhnhfdmhnkblpjlaadamhajnmbo/popup.html");
                    break;

                case "Edge":
                    _driver.Navigate().GoToUrl("chrome-extension://mpkbmnhnhfdmhnkblpjlaadamhajnmbo/popup.html");
                    break;

                case "FireFox":
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
            _driver.SendKeys(_emailTextBox, ConfigurationManager.AppSettings["username"]);
            _driver.SendKeys(_passwordBox, ConfigurationManager.AppSettings["password"]);
            _driver.Click(_loginBtn);
            _driver.AssertElementDisplayed(_accountLabelOnTopRightHandOnTCB);
        }

        [Then(@"I should see the logged in toolbar")]
        public void ThenIShouldSeeTheLoggedInToolbar()
        {
            _driver.FocusFirstWindow();
            _driver.AssertElementDisplayed(_bestDealsText);
        }

        [When(@"I enter a merchant name '(.*)'")]
        public void WhenIEnterAMerchantName(string searchText)
        {
            _driver.Click(_searchBar);
            Thread.Sleep(1000);
            _driver.WaitForElementVisible(_searchicon);
            _driver.SendKeys(_searchBar, searchText);
            Actions actions = new Actions(_driver);
            actions.KeyDown(_driver.FindElement(_searchBar), Keys.Backspace).Build().Perform();
            _scenarioContext.Add("searchText", searchText);
        }

        [Then(@"I should see the suggested list")]
        public void ThenIShouldSeeTheSuggestedList()
        {
            string _searchText = _scenarioContext.Get<string>("searchText");
            _driver.AssertElementTextContains(_topSearchResult, _searchText);
        }

        [When(@"I click on '(.*)'")]
        public void WhenIClickOn(string page)
        {
            _scenarioContext.Add("pageName", page);
            switch (page)
            {
                case "My Account":
                    _driver.WaitForElementVisible(_pageBtnMyAcc);
                    _driver.Click(_pageBtnMyAcc);
                    break;
                case "Tell a friend":
                    _driver.WaitForElementVisible(_pageBtnTAF);
                    _driver.Click(_pageBtnTAF);
                    break;
            }
        }

        [Then(@"I should be redirected to correct page")]
        public void ThenIShouldBeRedirectedToCorrectPage()
        {
            _driver.FocusFirstWindow();
            string pageNameOnToolbar = _scenarioContext.Get<string>("pageName");
            _driver.AssertElementDisplayed(_accountLabelOnTopRightHandOnTCB);
            switch (pageNameOnToolbar)
            {
                case "My Account":
                    
                    _driver.AssertElementTextContains(_accountOverviewtextOnTCB, "Account Overview");
                    _scenarioContext.Remove("pageName");
                    break;

                case "Tell a friend":
                    _driver.AssertElementTextContains(_tafpageOnTCB, "Tell-a-Friend");
                    _scenarioContext.Remove("pageName");
                    break;

                default:
                    break;
            }
        }


    }
}
