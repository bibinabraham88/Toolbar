using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace ToolbarTests.Drivers
{
    public class SeleniumDriver
    {

        public static IWebDriver driver = new ChromeDriver();
        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;
        
        public IWebDriver SetUp()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(
                "enable-automation",
                "enable-extensions",
                "no-sandbox",
                "start-maximixed"
                );
            chromeOptions.AddExtensions("C:/Users/bibinabraham/Downloads/tcb-de-1.1.0.1-chrome.crx");
            chromeOptions.AddAdditionalChromeOption("useAutomationExtension", false);
            _scenarioContext.Set(driver, "webDriver");
            //driver.Manage().Window.Maximize();
            return new ChromeDriver(chromeOptions);

        }
    }
}
