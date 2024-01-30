using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
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
                    "start-maximixed"
                    );
                
                chromeOptions.AddExtensions("C:/Users/bibinabraham/Downloads/tcb_build_2023_06_15/tcb_build_2023_06_15/Chrome_V3/tcb-uk-3.6.0.0-QA-chrome.crx");
                return new ChromeDriver(chromeOptions);
            }

            if (browser == "firefox")
            {
                FirefoxProfile profile = new FirefoxProfile();
                profile.AddExtension("C:/Users/bibinabraham/Downloads/tcb_build_2023_06_15/tcb_build_2023_06_15/Chrome_V3/tcb-uk-3.6.0.0-QA-chrome.crx");
                FirefoxOptions options = new FirefoxOptions();
                options.Profile = profile;
                return new FirefoxDriver(options);
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
