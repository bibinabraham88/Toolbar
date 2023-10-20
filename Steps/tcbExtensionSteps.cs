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

            _driver.Navigate().GoToUrl("chrome-extension://mpkbmnhnhfdmhnkblpjlaadamhajnmbo/popup.html");
            // DE
            //  _driver.Navigate().GoToUrl("chrome-extension://iljjkgoaeinkkmleckfmjcfdhlbnjfmo/popup.html");
            //US
            //   _driver.Navigate().GoToUrl("chrome-extension://cbmmlcaooffjnkagiglmnebjpkekhnag/popup.html");            

            //  _driver.Navigate().GoToUrl("edge-extension://mpkbmnhnhfdmhnkblpjlaadamhajnmbo/popup.html");

            // UK firefox 
            //_driver.Navigate().GoToUrl("firefox-extension://mpkbmnhnhfdmhnkblpjlaadamhajnmbo/popup.html");
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
            // For new user 
            //  String userEmail = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "@topcashback.co.uk";
             // _driver.FindElement(By.Name("ctl00$GeckoOneColPrimary$JoinForm$emailInput")).SendKeys(usermail);
 

            _driver.FindElement(By.Name("ctl00$GeckoOneColPrimary$LoginV2$txtEmail")).SendKeys("tcbtestteam@topcashback.co.uk");

        }

        [When(@"I fills-in password field with ""(.*)""")]
        public void WhenIFills_InPasswordFieldWith(string password)
        {
            // For new user 
           // _driver.FindElement(By.Name("ctl00$GeckoOneColPrimary$JoinForm$passwordInput")).SendKeys("Yadda123!");

            
            _driver.FindElement(By.Name("ctl00$GeckoOneColPrimary$LoginV2$loginPasswordInput")).SendKeys("Yadda123!");
        }

        [When(@"I click on join free button")]
        public void WhenIClickOnJoinFreeButton()
        {
            // For new user
           // _driver.FindElement(By.Name("ctl00$GeckoOneColPrimary$JoinForm$btnJoin")).Click();

            _driver.FindElement(By.Name("ctl00$GeckoOneColPrimary$LoginV2$Loginbtn")).Click();
        }

        [Then(@"I should see sucssesfully install extension")]
        public void ThenIShouldSeeSucssesfullyInstallExtension()
        {
            System.Threading.Thread.Sleep(500);
            labelText = _driver.FindElement(By.ClassName("logo"));

            // _driver.FindElement(By.CssSelector("#ctl00_GeckoOneColPrimary_TitleLabel"));
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
            _driver.FindElement(By.XPath("//body/div[1]/div[3]/form/div[1]/div[1]/div[4]/center/input[1]")).Click();
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
            System.Threading.Thread.Sleep(500);
            labelText = _driver.FindElement(By.ClassName("logo"));
        }
        [Then(@"I should able to click on carousel image")]
        public void ThenIShouldAbleToClickOnCarouselImage()
        {
            System.Threading.Thread.Sleep(500);
            _driver.FindElement(By.ClassName("VueCarousel-inner")).Click();
        }




    }
}
