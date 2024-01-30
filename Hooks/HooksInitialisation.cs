using System;
using TechTalk.SpecFlow;
using ToolbarTests.Drivers;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using FluentAssertions;
using Helpers;

namespace ToolbarTests.Hooks
{
    [Binding]
    public class HooksInitialisation
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;
        private readonly SeleniumDriver _seleniumDriver;

        public HooksInitialisation(ScenarioContext scenarioContext,
            SeleniumDriver seleniumDriver)
        {
            _scenarioContext = scenarioContext;
            _seleniumDriver = seleniumDriver;

        }

        [Given(@"I try to open the '(.*)' browser")]
        public void GivenITryToOpenTheBrowser(string browser)
        {
            _driver = _seleniumDriver.SetUp(browser);
            _driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            Thread.Sleep(1000);
            var newWindowHandle = _driver.WindowHandles[1];
            if (_driver.WindowHandles.Count == 2)
            {
                _driver.SwitchTo().Window(newWindowHandle);
                _driver.Close();
            }
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            _scenarioContext.Set(_driver);
        }


        [AfterStep]

        public void AfterStep()
        {
            _driver.FocusFirstWindow();
            if((_driver.Url.Contains("error"))||(_driver.Url.Contains("Error")))
            {
                By errorCodeText = By.Id("ctl00_GeckoContent_lblErrorNumber");
                Console.WriteLine($"Dogpage was displayed at this point with Error Code: {_driver.FindElement(errorCodeText).Text}. Please check Graylog for the error code");
            }
            _driver.Url.Should().NotContainAny("error", "Error");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //_driver.Quit();
            //Console.WriteLine("Browser was closed successfully");
        }
    }
}
