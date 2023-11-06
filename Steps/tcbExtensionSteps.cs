using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ToolbarTests.Steps
{
    [Binding]
    public class tcbExtensionSteps
    {
       
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;
        private object labelText;
        private object driver;

        public tcbExtensionSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();          
        }

        [Given(@"I try to open the toolbar extesion")]
        public void WhenITryToOpenTheToolbarExtesion()
        {
            // UK 
            _driver.Navigate().GoToUrl("chrome-extension://mpkbmnhnhfdmhnkblpjlaadamhajnmbo/popup.html");

            // DE
            //  _driver.Navigate().GoToUrl("chrome-extension://iljjkgoaeinkkmleckfmjcfdhlbnjfmo/popup.html");

            //US
              // _driver.Navigate().GoToUrl("chrome-extension://cbmmlcaooffjnkagiglmnebjpkekhnag/popup.html");
           
            // edge    
             // _driver.Navigate().GoToUrl("edge-extension://cbmmlcaooffjnkagiglmnebjpkekhnag/popup.html");

            // UK firefox 
          //  _driver.Navigate().GoToUrl("firefox-extension://mpkbmnhnhfdmhnkblpjlaadamhajnmbo/popup.html");
        }

        [When(@"I click on join button")]
        public void ThenIShouldSeeTheToolbarPopUp()
        {
            System.Threading.Thread.Sleep(5000);
              _driver.FindElement(By.CssSelector(".cta.welcome__button")).Click();          
        }     

        [Then(@"I click on Accept cookies")]
         public void ThenIClickOnAcceptCookies()
        {
            System.Threading.Thread.Sleep(2000);
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            _driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
        }

        [When(@"I fills-in mailbox field with ""(.*)""")]
        public void WhenIFills_InMailboxFieldWith(string usermail)
        {          
            _driver.FindElement(By.Name("ctl00$GeckoOneColPrimary$LoginV2$txtEmail")).SendKeys("tcbtestteam@topcashback.co.uk");
        }

        [When(@"I fills-in password field with ""(.*)""")]
        public void WhenIFills_InPasswordFieldWith(string password)
        {
                     
            _driver.FindElement(By.Name("ctl00$GeckoOneColPrimary$LoginV2$loginPasswordInput")).SendKeys("Yadda123!");
        }

        [When(@"I fills-in password field with new user ""(.*)""")]
        public void WhenIFills_InPasswordFieldWithNewUser(string p0)
        {
            _driver.FindElement(By.Name("ctl00$GeckoOneColPrimary$JoinForm$passwordInput")).SendKeys("Yadda123!");
        }

        [When(@"I fills-in mailbox field with new user ""(.*)""")]
        public void WhenIFills_InMailboxFieldWithNewUser(string po)
        {
           // string userEmail = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "@topcashback.co.uk";
            _driver.FindElement(By.Id("emailInput")).SendKeys("tcbtestteam+3102@topcashback.co.uk");
        }

        [When(@"I click on join free button")]
        public void WhenIClickOnJoinFreeButton()
        {         

            _driver.FindElement(By.Name("ctl00$GeckoOneColPrimary$LoginV2$Loginbtn")).Click();
        }

        [When(@"I click on join free button new user")]
        public void WhenIClickOnJoinFreeButtonNewUser()
        {
            _driver.FindElement(By.Name("ctl00$GeckoOneColPrimary$JoinForm$btnJoin")).Click();
        }

        [Then(@"I should see sucssesfully install extension")]
        public void ThenIShouldSeeSucssesfullyInstallExtension()
        {
            System.Threading.Thread.Sleep(500);
            labelText = _driver.FindElement(By.ClassName("logo"));           
        }

        [Then(@"I click on My account")]
        public void ThenIClickOnMyAccount()
        {
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//body/div/div/div[2]/div[1]")).Click();
        }

        [Then(@"I click on Tell a friend")]
        public void ThenIClickOnTellAFriend()
        {
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//body/div/div/div[2]/div[2]")).Click();
        }

        [Then(@"I try to serach mearchant ""(.*)""")]
        public void ThenITryToSerachMearchant(string mearchant)
        {
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//body/div/div/div[1]/div[3]/div[1]/div/div[1]/input")).SendKeys("nike");
        }

        [Then(@"I should see search result")]
        public void ThenIShouldSeeSearchResult()
        {
            System.Threading.Thread.Sleep(500);
            labelText = _driver.FindElement(By.ClassName("search__result"));
        }

        [Given(@"I click on nike mearchnat")]
        public void GivenIClickOnNikeMearchnat()
        {
            _driver.FindElement(By.XPath("//body/div/div/div[1]/div[3]/div[1]/div/div[1]/div[2]/div[1]/span[1]/span")).Click();
        }

        [Then(@"I able to click on recently visited")]
        public void ThenIAbleToClickOnRecentlyVisited()
        {
             System.Threading.Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//body/div/div/div[1]/div[2]/div[2]")).Click();
        }

        [Given(@"I open chrome browser")]
        public void GivenIOpenChromeBrowser()
        {
            _driver.Navigate().GoToUrl("https://www.google.com/");
        }

        [Given(@"I click on Accepte all cookies button")]
        public void GivenIClickOnAccepteAllCookiesButton()
        {
            _driver.FindElement(By.Id("L2AGLb")).Click();
        }
        
        [When(@"I click on google search button")]
        public void WhenIClickOnGoogleSearchButton()
        {
            _driver.FindElement(By.Name("btnK")).Click();
        }

        [Then(@"I shuld see topcashback tax with %")]
        public void ThenIShuldSeeTopcashbackTaxWith()
        {
            System.Threading.Thread.Sleep(2000);
            labelText = _driver.FindElement(By.ClassName("topcashback-serp-uk-3bhGFz"));
        }

        [Given(@"I search mearchnt (.*)")]
        public void GivenISearchMearchnt(string SearchTerm)
            {
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(By.ClassName("search__input")).SendKeys(SearchTerm);           
        }

        [Given(@"I search on google mearchnt (.*)")]
        public void GivenISearchOnGoogleMearchnt(string SearchTerm)
        {
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(By.Id("APjFqb")).SendKeys(SearchTerm);
        }

        [When(@"I should able to click on suggestion merchant")]
        public void WhenIShouldAbleToClickOnSuggestionMerchant()
        {
            _driver.FindElement(By.Id("ctl00_GeckoOneColPrimary_ctl00_ctl00_SuggestedMerchantLogo")).Click();
        }

        [When(@"I should see sucssesfully install extension")]
        public void WhenIShouldSeeSucssesfullyInstallExtension()
        {
            System.Threading.Thread.Sleep(200);
            labelText = _driver.FindElement(By.ClassName("logo"));
        }

        [Then(@"I should able to click on carousel image")]
        public void ThenIShouldAbleToClickOnCarouselImage()
        {
            System.Threading.Thread.Sleep(500);
            _driver.FindElement(By.XPath("//body/div/div/div[1]/div[3]/div[1]/div/div[2]/div/div/div/div")).Click();
        }

        [Given(@"I should see sucssesfully install extension")]
        public void GivenIShouldSeeSucssesfullyInstallExtension()
        {
            System.Threading.Thread.Sleep(200);
            labelText = _driver.FindElement(By.ClassName("logo"));
        }

        [Then(@"I should able to click on FAQlink page")]
        public void ThenIShouldAbleToClickOnFAQlinkPage()
        {
            System.Threading.Thread.Sleep(500);
            _driver.FindElement(By.Id("ctl00_GeckoOneColPrimary_hypFAQ")).Click();
        }

        [Given(@"I should able to click on offer link")]
        public void GivenIShouldAbleToClickOnOfferLink()
        {
            _driver.FindElement(By.Id("ctl00_GeckoOneColPrimary_ctl00_SuggestedMerchantsLink")).Click();
        }

        [Then(@"I should able to see offer page")]
        public void ThenIShouldAbleToSeeOfferPage()
        {
            System.Threading.Thread.Sleep(500);
            labelText = _driver.FindElement(By.Id("ctl00_BodyMain_lblTitle"));
        }

        [Given(@"I click on account")]
        public void GivenIClickOnAccount()
        {
            _driver.FindElement(By.Id("accountIcon")).Click();
        }

        [Given(@"I click on sign out")]
        public void GivenIClickOnSignOut()
        {
            _driver.FindElement(By.Id("ctl00_ctl21_hypSignOut")).Click();
        }

        [Then(@"I should able to see logout page")]
        public void ThenIShouldAbleToSeeLogoutPage()
        {
            System.Threading.Thread.Sleep(500);
            labelText = _driver.FindElement(By.Id("ctl00_OneColPlaceHolder_lblLogoutHeader"));
        }

    }
}
