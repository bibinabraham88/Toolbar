using System;
using TechTalk.SpecFlow;
using ToolbarTests.Drivers;
using OpenQA.Selenium;

namespace ToolbarTests.Hooks
{
    [Binding]
    public class HooksInitialisation
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;
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
            _scenarioContext.Set(driver, "webDriver");
            _seleniumDriver.SetUp();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver = _scenarioContext.Get<IWebDriver>("webDriver");
            driver.Quit();
            Console.WriteLine("Browser was closed successfully");
        }
    }
}
