using System;
using TechTalk.SpecFlow;
using ToolbarTests.Drivers;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace ToolbarTests.Hooks
{
    [Binding]
    public class HooksInitialisation
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;
        private DriverOptions capabilities;
        private readonly SeleniumDriver _seleniumDriver;

        public HooksInitialisation(ScenarioContext scenarioContext,
            SeleniumDriver seleniumDriver)
        {
            _scenarioContext = scenarioContext;
            _seleniumDriver = seleniumDriver;
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
           
            _driver = _seleniumDriver.Chrome(); // change browser 
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(100));
            Thread.Sleep(1000);


            var newWindowHandle = _driver.WindowHandles[1];
            if (_driver.WindowHandles.Count == 2)
            {
                _driver.SwitchTo().Window(newWindowHandle);
                //   _driver.Close();
            }
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);

            _scenarioContext.Set(_driver);

        }


        //[AfterScenario]
        // public void AfterScenario()
        // {
        //    _driver.Quit();
        //    Console.WriteLine("Browser was closed successfully");
        //}
    }
}
