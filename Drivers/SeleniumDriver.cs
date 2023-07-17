using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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


        public IWebDriver Chrome()

        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(
                 "enable-automation",
                 "enable-extensions",
                  "no-sandbox",
                 "start-maximixed"
                 );
             chromeOptions.AddExtensions("C:/Users/divyeshsavaliya/Downloads/tcb-uk-3.6.0.0-QA-chrome.crx");
           // chromeOptions.AddExtensions("C:/Users/divyeshsavaliya/Downloads/tcb-de-1.2.0.0-QA-chrome.crx");
            // chromeOptions.AddExtensions("C:/Users/divyeshsavaliya/Downloads/tcb-us-3.3.0.0-QA-chrome.crx");

            return new ChromeDriver(chromeOptions);

        }
        //public IWebDriver Firefox()
        //{
        //    FirefoxOptions firefoxOptions = new FirefoxOptions();
        //    firefoxOptions.AddArguments(
        //        "enable-automation",
        //        "enable-extensions",
        //        "no-sandbox",
        //        "start-maximixed"
        //        );
        //    firefoxOptions.AddExtensions("C:/Users/divyeshsavaliya/Downloads/tcb-de-1.2.0.0-QA-chrome.crx");
        //    return new FirefoxDriver(firefoxOptions);
        //}
        public IWebDriver Edge()
        {
            EdgeOptions edgeOptions = new EdgeOptions();
            edgeOptions.AddArguments(
                "enable-automation",
                "enable-extensions",
                "no-sandbox",
                "start-maximixed"
                );
            edgeOptions.AddExtensions("C:/Users/divyeshsavaliya/Downloads/tcb-us-3.3.0.0-QA-chrome.crx");
            return new EdgeDriver(edgeOptions);
        }
    }


}

