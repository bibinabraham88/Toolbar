using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.IO;
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
        
        public IWebDriver SetUp(string browser)
        {

            if(browser == "Chrome")
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments(
                    "enable-automation",
                    "enable-extensions",
                    "no-sandbox",
                    "start-maximized"
                    );
                
                chromeOptions.AddExtensions("C:/Users/bibinabraham/Downloads/tcb_build_2023_06_15/tcb_build_2023_06_15/Chrome_V3/tcb-uk-3.6.0.0-QA-chrome.crx");
                return new ChromeDriver(chromeOptions);
            }

            if (browser == "FireFox")
            {
                //FirefoxProfile profile = new FirefoxProfile();
                //profile.AddExtension("C:/Users/bibinabraham/Toolbar-crx-files/tcb-uk-4.0.3.0-QA-firefox.zip");
                //FirefoxOptions options = new FirefoxOptions();
                //options.Profile = profile;
                //return new FirefoxDriver(options);

                FirefoxDriver _driver = new FirefoxDriver();
                _driver.InstallAddOnFromFile("C:/Users/bibinabraham/Downloads/tcb_build_2023_06_15/tcb_build_2023_06_15/Firefox_V2/tcb-uk-3.6.0.0-QA-firefox.xpi");
                return _driver;

            }

            if (browser == "Edge")
            {
                var edgeoptions = new EdgeOptions();
                edgeoptions.AddExtensions("C:/Users/bibinabraham/Downloads/tcb_build_2023_06_15/tcb_build_2023_06_15/Chrome_V3/tcb-uk-3.6.0.0-QA-chrome.crx");
                return new EdgeDriver(edgeoptions);
            }

            else return null;
        }
    }
}
