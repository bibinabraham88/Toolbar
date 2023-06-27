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
        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        } 
        
        public IWebDriver SetUp()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(
                "enable-automation",
                "enable-extensions",
                "no-sandbox",
                "start-maximixed"
                );
            chromeOptions.AddExtensions("C:/Users/bibin/Downloads/extension_3_5_0_1.crx");
            return new ChromeDriver(chromeOptions);
        }
    }
}
