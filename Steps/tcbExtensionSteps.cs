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
            //DE
            // _driver.Navigate().GoToUrl("chrome-extension://iljjkgoaeinkkmleckfmjcfdhlbnjfmo/popup.html");
            //US
             //  _driver.Navigate().GoToUrl("chrome-extension://cbmmlcaooffjnkagiglmnebjpkekhnag/popup.html");            

            // _driver.Navigate().GoToUrl("edge-extension://iljjkgoaeinkkmleckfmjcfdhlbnjfmo/popup.html");
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
            System.Threading.Thread.Sleep(5000);
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            _driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
        }

        [When(@"I fills-in mailbox field with ""(.*)""")]
        public void WhenIFills_InMailboxFieldWith(string usermail)
        {
            String userEmail = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "@topcashback.co.uk";
            _driver.FindElement(By.Name("ctl00$GeckoOneColPrimary$JoinForm$emailInput")).SendKeys(userEmail);
            
        }
        [When(@"I fills-in password field with ""(.*)""")]
        public void WhenIFills_InPasswordFieldWith(string password)
        {
            _driver.FindElement(By.Name("ctl00$GeckoOneColPrimary$JoinForm$passwordInput")).SendKeys("Yadda123!");
        }
        [When(@"I click on join free button")]
        public void WhenIClickOnJoinFreeButton()
        {
            _driver.FindElement(By.Name("ctl00$GeckoOneColPrimary$JoinForm$btnJoin")).Click();
        }
        [Then(@"I should see sucssesfully install extension")]
        public void ThenIShouldSeeSucssesfullyInstallExtension()
        {
            System.Threading.Thread.Sleep(5000);
            labelText = _driver.FindElement(By.ClassName("logo"));

            // _driver.FindElement(By.CssSelector("#ctl00_GeckoOneColPrimary_TitleLabel"));

        }
        [Then(@"I try to open again toolbar extesion")]
        public void ThenITryToOpenAgainToolbarExtesion()
        {
            _driver.Navigate().GoToUrl("chrome-extension://mpkbmnhnhfdmhnkblpjlaadamhajnmbo/popup.html");
            _driver.Navigate().Refresh();
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

       
        [Given(@"I try to open again toolbar extesion")]
        public void GivenITryToOpenAgainToolbarExtesion()
        {
            _driver.Navigate().GoToUrl("chrome-extension://iljjkgoaeinkkmleckfmjcfdhlbnjfmo/popup.html");
             _driver.Navigate().Refresh();
        }
        
        [Then(@"I try to serach mearchant ""(.*)""")]
        public void ThenITryToSerachMearchant(string mearchant)
        {
            System.Threading.Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//body/div/div/div[1]/div[3]/div[1]/div/div[1]/input")).SendKeys("nike");
        }
        [Then(@"I click on nike mearchnat")]
        public void ThenIClickOnNikeMearchnat()
        {
            _driver.FindElement(By.XPath("//body/div/div/div[1]/div[3]/div[1]/div/div[1]/div[2]/div[1]/span[1]/span")).Click();
        }
        [Then(@"I able to click on recently visited")]
        public void ThenIAbleToClickOnRecentlyVisited()
        {
             System.Threading.Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//body/div/div/div[1]/div[2]/div[2]")).Click();
        }


    }
}
