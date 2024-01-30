using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Helpers
{
    /// <summary>
    ///     Web Driver Extensions which assist with creating Automated Tests
    /// </summary>
    /// <dependency nuget-package-name="Selenium.WebDriver"></dependency>
    /// <dependency nuget-package-name="Selenium.Support"></dependency>
    /// <dependency nuget-package-name="DotNetSeleniumExtras.WaitHelpers"></dependency>
    public static class WebDriverExtensions
    {
        private static void WaitForElementToBeClickable(IWebDriver driver, By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        private static void WaitUntilElementExists(IWebDriver driver, By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementExists(by));
            }

            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static bool IsNotClickable(this IWebDriver driver, By by)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = by ?? throw new ArgumentNullException(nameof(by));

            try
            {
                IWebElement element = driver.FindElement(by);

                if (element.GetAttribute("disabled") == "")
                {
                    return false;
                }

                if (element.GetAttribute("disabled") == null)
                {
                    return false;
                }

                else
                {
                    return true;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void AssertElementDisplayed(this IWebDriver driver, By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void AssertElementDisplayed(this IWebDriver driver, ScenarioContext scenarioContext, By by)
        {
            try
            {
                if (scenarioContext == null) throw new ArgumentNullException(nameof(scenarioContext));
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void WaitForElementNotVisible(this IWebDriver driver, By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void WaitForElementVisible(this IWebDriver driver, By by)
        {
            try
            {
                WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                waitForElement.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to wait for the following to not be visible {by} | Error: {e}");
                throw;
            }
        }

        public static void WaitForElementVisible(this IWebDriver driver, ScenarioContext scenarioContext, By by)
        {
            try
            {
                WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                if (scenarioContext == null) throw new ArgumentNullException(nameof(scenarioContext));
                waitForElement.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to wait for the elemnt to be visible | Error: {e}");
                throw;
            }
        }

        public static IWebElement FindElementForDesktopAndMobile(this IWebDriver driver, By by, ScenarioContext scenarioContext)
        {
            try
            {
                _ = driver ?? throw new ArgumentNullException(nameof(driver));
                if (scenarioContext == null) throw new ArgumentNullException(nameof(scenarioContext));
                return driver.FindElement(by);

            }

            catch (Exception e)
            {
                Console.WriteLine($"Unable to find element | Error :{e}");
                throw;
            }


        }

        public static void WaitForElementNotVisible(this IWebDriver driver, By by, ScenarioContext scenarioContext)
        {
            try
            {
                if (scenarioContext == null) throw new ArgumentNullException(nameof(scenarioContext));
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void Click(this IWebDriver driver, By by)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = by ?? throw new ArgumentNullException(nameof(by));

            try
            {
                AssertElementDisplayed(driver, by);
                IWebElement element = driver.FindElement(by);

                try
                {
                    driver.ExecuteJavaScript("arguments[0].click();", element);
                }
                catch (StaleElementReferenceException)
                {
                    //Fix "stale element reference: element is not attached to the page document" error
                    IWebElement newElement = driver.FindElement(by);
                    newElement.Click();
                }
                catch (ElementNotInteractableException)
                {
                    //Fix "element not interactable" error
                    IWebElement newElement = driver.FindElement(by);
                    newElement.Click();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void Click(this IWebDriver driver, IWebElement element)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = element ?? throw new ArgumentNullException(nameof(element));

            try
            {
                try
                {
                    driver.ExecuteJavaScript("arguments[0].click();", element);
                }
                catch (StaleElementReferenceException)
                {
                    //Fix "stale element reference: element is not attached to the page document" error
                    element.Click();
                }
                catch (ElementNotInteractableException)
                {
                    //Fix "element not interactable" error
                    element.Click();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void Click(this IWebDriver driver, By by, ScenarioContext scenarioContext)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));

            try
            {
                AssertElementDisplayed(driver, by);
                IWebElement element = driver.FindElement(by);

                try
                {
                    driver.ExecuteJavaScript("arguments[0].click();", element);
                }
                catch (StaleElementReferenceException)
                {
                    //Fix "stale element reference: element is not attached to the page document" error
                    IWebElement newElement = driver.FindElement(by);
                    newElement.Click();
                }
                catch (ElementNotInteractableException)
                {
                    //Fix "element not interactable" error
                    IWebElement newElement = driver.FindElement(by);
                    newElement.Click();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void Click(this IWebDriver driver, IWebElement element, ScenarioContext scenarioContext)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));

            try
            {
                try
                {
                    driver.ExecuteJavaScript("arguments[0].click();", element);
                }
                catch (StaleElementReferenceException)
                {
                    //Fix "stale element reference: element is not attached to the page document" error
                    element.Click();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void ClickUsingWebElement(this IWebDriver driver, By by)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));

            try
            {
                AssertElementDisplayed(driver, by);
                IWebElement element = driver.FindElement(by);
                element.Click();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void ClickUsingWebElement(this IWebDriver driver, By by, ScenarioContext scenarioContext)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));

            try
            {
                AssertElementDisplayed(driver, by);
                IWebElement element = driver.FindElement(by);
                element.Click();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void DoubleClick(this IWebDriver driver, By by)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));

            try
            {
                WaitForElementToBeClickable(driver, by);
                IWebElement element = driver.FindElement(by);

                Actions action = new Actions(driver);
                action.MoveToElement(element).Build().Perform();
                action.DoubleClick(element).Build().Perform();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void DoubleClick(this IWebDriver driver, By by, ScenarioContext scenarioContext)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));

            try
            {
                Actions action = new Actions(driver);
                WaitForElementToBeClickable(driver, by);
                IWebElement element = driver.FindElement(by);
                action.MoveToElement(element).Build().Perform();
                action.DoubleClick(element).Build().Perform();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static bool IsClickable(this IWebDriver driver, By by)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = by ?? throw new ArgumentNullException(nameof(by));

            try
            {
                IWebElement element = driver.FindElement(by);

                if (element.GetAttribute("disabled") == "")
                {
                    return true;
                }

                if (element.GetAttribute("disabled") == null)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void SendKeys(this IWebDriver driver, By by, string value)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = value ?? throw new ArgumentNullException(nameof(value));

            try
            {
                AssertElementDisplayed(driver, by);
                IWebElement element = driver.FindElement(by);

                if (value.Length > 0)
                {
                    if (element.Text.Length > 0)
                    {
                        driver.ExecuteJavaScript($"arguments[0].value='{Keys.Clear}';", element);
                    }

                    driver.ExecuteJavaScript($"arguments[0].value='{value}';", element);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void SendKeys(this IWebDriver driver, By by, string value, ScenarioContext scenarioContext)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
            _ = value ?? throw new ArgumentNullException(nameof(value));

            try
            {
                AssertElementDisplayed(driver, by);
                IWebElement element = driver.FindElement(by);

                if (value.Length > 0)
                {
                    if (element.Text.Length > 0)
                    {
                        driver.ExecuteJavaScript($"arguments[0].value='{Keys.Clear}';", element);
                    }

                    driver.ExecuteJavaScript($"arguments[0].value='{value}';", element);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void SendKeysUsingWebElement(this IWebDriver driver, By by, string value)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));

            try
            {
                AssertElementDisplayed(driver, by);
                IWebElement element = driver.FindElement(by);
                element.SendKeys(value);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void SendKeysUsingWebElement(this IWebDriver driver, By by, string value, ScenarioContext scenarioContext)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));

            try
            {
                AssertElementDisplayed(driver, by);
                IWebElement element = driver.FindElement(by);
                element.SendKeys(value);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void WaitUntilurlContains(this IWebDriver driver, string expectedUrl)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.UrlContains(expectedUrl));
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        /// <summary>
        ///     To be used to check if an element is displayed, if it is, return true, if not; return false
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        public static bool IsElementDisplayed(this IWebDriver driver, By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsElementDisplayed(this IWebDriver driver, By by, ScenarioContext scenarioContext)
        {
            try
            {
                if (scenarioContext == null) throw new ArgumentNullException(nameof(scenarioContext));
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void SelectFromDropdownByIndex(this IWebDriver driver, By by, int index)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));

            try
            {
                WaitForElementToBeClickable(driver, by);
                IWebElement element = driver.FindElement(by).FindElement(By.XPath($".//option[{index + 1}]"));
                element.Click();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void SelectFromDropdownByIndex(this IWebDriver driver, By by, int index, ScenarioContext scenarioContext)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));

            try
            {
                WaitForElementToBeClickable(driver, by);
                IWebElement element = driver.FindElement(by).FindElement(By.XPath($".//option[{index + 1}]"));
                element.Click();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void SelectFromDropdownByText(this IWebDriver driver, By by, string text)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));

            try
            {
                WaitForElementToBeClickable(driver, by);
                IWebElement element = driver.FindElement(by).FindElement(By.XPath($".//option[contains(text(), '{text}')]"));
                element.Click();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void SelectFromDropdownByText(this IWebDriver driver, By by, string text, ScenarioContext scenarioContext)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));

            try
            {
                WaitForElementToBeClickable(driver, by);
                IWebElement element = driver.FindElement(by).FindElement(By.XPath($".//option[contains(text(), '{text}')]"));
                element.Click();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void ClickRandomItemFromCollection(this IWebDriver driver, By by)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));

            try
            {
                Random r = new Random();

                WaitForElementToBeClickable(driver, by);
                ReadOnlyCollection<IWebElement> collection = driver.FindElements(by);
                int rInt = r.Next(0, collection.Count - 1);
                IWebElement element = collection.ElementAt(rInt);
                Console.WriteLine($"The following element will be clicked {element.GetAttribute("href")}");
                driver.ExecuteJavaScript("arguments[0].click();", element);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void ClickRandomItemFromCollection(this IWebDriver driver, By by, ScenarioContext scenarioContext)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));

            try
            {
                Random r = new Random();
                WaitForElementToBeClickable(driver, by);
                ReadOnlyCollection<IWebElement> collection = driver.FindElements(by);
                int rInt = r.Next(0, collection.Count - 1);
                IWebElement element = collection.ElementAt(rInt);
                Console.WriteLine($"The following element will be clicked {element.GetAttribute("href")}");
                driver.ExecuteJavaScript("arguments[0].click();", element);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static IWebElement GetRandomItemFromCollection(this IWebDriver driver, By by)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));

            try
            {
                Random r = new Random();

                WaitUntilElementExists(driver, by);
                ReadOnlyCollection<IWebElement> collection = driver.FindElements(by);
                int rInt = r.Next(0, collection.Count - 1);
                IWebElement element = collection.ElementAt(rInt);

                return element;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static IWebElement GetRandomItemFromCollection(this IWebDriver driver, By by, ScenarioContext scenarioContext)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));

            try
            {
                Random r = new Random();
                WaitUntilElementExists(driver, by);
                ReadOnlyCollection<IWebElement> collection = driver.FindElements(by);
                int rInt = r.Next(0, collection.Count - 1);
                IWebElement element = collection.ElementAt(rInt);

                return element;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static ReadOnlyCollection<IWebElement> GetAllItemsFromCollection(this IWebDriver driver, By by)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));

            WaitUntilElementExists(driver, by);

            ReadOnlyCollection<IWebElement> collection = driver.FindElements(by);

            return collection;
        }

        public static ReadOnlyCollection<IWebElement> GetAllItemsFromCollection(this IWebDriver driver, By by, ScenarioContext scenarioContext)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
            WaitUntilElementExists(driver, by);
            ReadOnlyCollection<IWebElement> collection = driver.FindElements(by);
            return collection;
        }

        public static void ScrollToElement(this IWebDriver driver, IWebElement element)
        {
            try
            {
                driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", element);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void HoverOverElement(this IWebDriver driver, By by)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));

            try
            {
                Actions action = new Actions(driver);
                AssertElementDisplayed(driver, by);
                IWebElement element = driver.FindElement(by);
                action.MoveToElement(element).Build().Perform();
                action.MoveToElement(element).Build().Perform();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void HoverOverElement(this IWebDriver driver, By by, ScenarioContext scenarioContext)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));

            try
            {
                Actions action = new Actions(driver);
                AssertElementDisplayed(driver, by);
                IWebElement element = driver.FindElement(by);
                action.MoveToElement(element).Build().Perform();
                action.MoveToElement(element).Build().Perform();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static string GetElementText(this IWebDriver driver, By by)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));

            try
            {
                AssertElementDisplayed(driver, by);
                return driver.FindElement(by).Text;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static string GetElementText(this IWebDriver driver, By by , ScenarioContext scenarioContext)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));

            try
            {
                if (scenarioContext == null) throw new ArgumentNullException(nameof(scenarioContext));
                AssertElementDisplayed(driver, by);
                return driver.FindElement(by).Text;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static IWebElement GetElement(this IWebDriver driver, By by)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));

            try
            {
                WaitUntilElementExists(driver, by);
                return driver.FindElement(by);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static IWebElement GetElement(this IWebDriver driver, By by, ScenarioContext scenarioContext)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));

            try
            {
                WaitUntilElementExists(driver, by);
                return driver.FindElement(by);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }


        public static void AssertUrlEquals(this IWebDriver driver, string expectedUrl)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = expectedUrl ?? throw new ArgumentNullException(nameof(expectedUrl));

            try
            {
                string currentUrl = driver.Url.ToLower();
                string expectedUrlToLower = expectedUrl.ToLower();

                currentUrl.Should().Be(expectedUrlToLower, $"The current URL '{currentUrl} should be equal to '{expectedUrlToLower}'");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void AssertUrlContains(this IWebDriver driver, string partialUrl)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = partialUrl ?? throw new ArgumentNullException(nameof(partialUrl));

            try
            {
                string currentUrl = driver.Url.ToLower();
                string partialUrlToLower = partialUrl.ToLower();

                currentUrl.Should().Contain(partialUrlToLower, $"The current URL: '{currentUrl}' should contain '{partialUrlToLower}'");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void AssertElementTextContains(this IWebDriver driver, By actualTextLocator, string expectedText)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = expectedText ?? throw new ArgumentNullException(nameof(expectedText));

            try
            {
                AssertElementDisplayed(driver, actualTextLocator);

                string actualText = RemoveSpecialCharacters(driver.FindElement(actualTextLocator).Text.ToLower());
                string expectedTextToLower = RemoveSpecialCharacters(expectedText.ToLower());

                actualText.Should().Contain(expectedTextToLower, $"The actual text of the element '{actualText}' should contain '{expectedTextToLower}'");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static void AssertElementTextContains(this IWebDriver driver, By actualTextLocator, string expectedText, ScenarioContext scenarioContext)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = expectedText ?? throw new ArgumentNullException(nameof(expectedText));
            _ = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));

            try
            {
                string actualText;
                AssertElementDisplayed(driver, actualTextLocator);
                actualText = RemoveSpecialCharacters(driver.FindElement(actualTextLocator).Text.ToLower());
                
                string expectedTextToLower = RemoveSpecialCharacters(expectedText.ToLower());
                actualText.Should().Contain(expectedTextToLower, $"The actual text of the element '{actualText}' should contain '{expectedTextToLower}'");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown in AssertElementTextContains: {exception.Message}");
                throw;
            }
        }


        public static IWebDriver FocusFirstWindow(this IWebDriver driver)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));

            try
            {
                return driver.SwitchTo().Window(driver.WindowHandles.First());
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static IWebDriver FocusLastWindow(this IWebDriver driver)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));

            try
            {
                return driver.SwitchTo().Window(driver.WindowHandles.Last());
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        /// <summary>
        ///     Get all windows apart from Original Handle, and close them
        ///     return to Original Window Handle
        /// </summary>
        /// <param name="driver"></param>
        public static void CloseAdditionalWindowsAndFocusOnFirstWindow(this IWebDriver driver)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            Thread.Sleep(TimeSpan.FromSeconds(30));

            try
            {
                if (driver.WindowHandles.Count > 1)
                {
                    string mainWindow = driver.WindowHandles[0];

                    driver.WindowHandles.Where(w => w != mainWindow).ToList()
                        .ForEach(w =>
                        {
                            driver.SwitchTo().Window(w);
                            driver.Close();
                        });

                    driver.FocusFirstWindow();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }

        public static string ExtractNumbersFromElementText(this IWebDriver driver, By actualTextLocator)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));

            AssertElementDisplayed(driver, actualTextLocator);
            string actualText = driver.FindElement(actualTextLocator).Text.ToLower();
            string input = actualText.Replace(",", string.Empty);
            IEnumerable<string> doubleArray = Regex.Split(input, @"[^0-9\.]+")
                .Where(c => c != "." && c.Trim() != "");

            return doubleArray.FirstOrDefault();
        }

        public static string ExtractNumbersFromString(this IWebDriver driver, string input)
        {
            IEnumerable<string> doubleArray = Regex.Split(input, @"[^0-9\.]+")
                .Where(c => c != "." && c.Trim() != "");

            return doubleArray.FirstOrDefault();
        }

        public static string RemoveSpecialCharacters(this string str)
        {
            _ = str ?? throw new ArgumentNullException(nameof(str));

            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static bool IsCookiePresent(this IWebDriver driver, string cookieName)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));

            try
            {
                return driver.Manage().Cookies.GetCookieNamed(cookieName) != null;
            }
            catch
            {
                return false;
            }
        }

        public static string CapitaliseFirstCharacter(this IWebDriver driver, string elementLocator)
        {
            switch (elementLocator)
            {
                case null: throw new ArgumentNullException(nameof(elementLocator));
                case "": throw new ArgumentException($"{nameof(elementLocator)} cannot be empty", nameof(elementLocator));
                default: return elementLocator.First().ToString(CultureInfo.InvariantCulture).ToUpper() + elementLocator.Substring(1);
            }
        }

        /// <summary>
        ///     Trims the "Up to" text for a locator, typically used for a Merchants Cashback rate so that it can be asserted correctly
        /// </summary>
        /// <param name="textToTrim"></param>
        public static string TrimUpToText(this IWebDriver driver, string textToTrim)
        {
            const string upToText = "Up to";
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = textToTrim ?? throw new ArgumentNullException(nameof(textToTrim));

            if (textToTrim.Contains(upToText))
            {
                return textToTrim.Trim(upToText.ToCharArray());
            }

            return textToTrim;
        }

        public static string TrimWebsiteUrl(this IWebDriver driver, string textToTrim, ScenarioContext scenarioContext)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));

            string websiteUrl = $"{scenarioContext.Get<string>("WebsiteUrl")}/";

            _ = websiteUrl ?? throw new ArgumentNullException(nameof(textToTrim));

            if (textToTrim.Contains(websiteUrl))
            {
                return textToTrim.Replace(websiteUrl, "");
            }

            return textToTrim;
        }

        public static string RemoveTextAfterSpace(this IWebDriver driver, string textToTrim)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = textToTrim ?? throw new ArgumentNullException(nameof(textToTrim));

            if (textToTrim.Contains(" "))
            {
                int index = textToTrim.IndexOf(' ');
                return textToTrim.Substring(0, index);
            }

            return textToTrim;
        }

        public static string TrimUkDomain(this IWebDriver driver, string textToTrim)
        {
            const string ukDomain = ".co.uk";
            _ = driver ?? throw new ArgumentNullException(nameof(driver));
            _ = textToTrim ?? throw new ArgumentNullException(nameof(textToTrim));

            if (textToTrim.Contains(ukDomain))
            {
                return textToTrim.Replace(ukDomain, "");
            }

            return textToTrim;
        }

        public static void PrintToConsole(string message)
        {
            Console.WriteLine($"Test failed due to: {message}");
        }

        public static void TakeScreenShot(this IWebDriver driver, ScenarioContext scenarioContext)
        {
            try
            {
                if (scenarioContext == null) throw new ArgumentNullException(nameof(scenarioContext));

                Screenshot screenShot = driver.TakeScreenshot();
                string artifactDirectory = Path.Combine(Directory.GetCurrentDirectory(), "screenshots");
                string fileNameBase =
                    $"{scenarioContext.Get<string>("FeatureTitle")}_{scenarioContext.Get<string>("DeviceType")}_{DateTime.Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture)}.png".Replace(' ', '_');
                string screenShotFilePath = Path.Combine(artifactDirectory, fileNameBase);

                Directory.CreateDirectory(artifactDirectory);

                screenShot.SaveAsFile(screenShotFilePath, ScreenshotImageFormat.Png);
                Console.WriteLine($"Screenshot Location: {screenShotFilePath}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Unable to take Screenshot due to: {exception.Message}");
            }
        }

        public static void PrintOutSessionId(this IWebDriver driver)
        {
            _ = driver ?? throw new ArgumentNullException(nameof(driver));

            if (driver.IsCookiePresent("TCB_SessionID8"))
            {
                Cookie tcbSessionCookie = driver.Manage().Cookies.GetCookieNamed("TCB_SessionID8");
                string trim = tcbSessionCookie.ToString().Trim("TCB_SessionID8=".ToCharArray());
                int index = trim.IndexOf(';');
                string tcbSessionId = trim.Substring(0, index);

                Console.WriteLine($"Session Id: {tcbSessionId}");
            }
        }
    }
}
