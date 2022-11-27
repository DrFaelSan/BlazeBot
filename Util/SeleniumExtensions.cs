using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BlazeBot.Util;

public static class SeleniumExtensions
{

    public static IWebElement WaitUntilElementExists(IWebDriver _driver, By elementLocator, int timeout = 10)
    {
        try
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementExists(elementLocator));
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
            throw;
        }
    }

    public static IWebElement WaitUntilElementVisible(IWebDriver _driver, By elementLocator, int timeout = 10)
    {
        try
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Element with locator: '" + elementLocator + "' was not found.");
            throw;
        }
    }

    public static IWebElement WaitUntilElementClickable(IWebDriver _driver, By elementLocator, int timeout = 10)
    {
        try
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
            throw;
        }
    }

    public static void ClickAndWaitForPageToLoad(IWebDriver _driver, By elementLocator, int timeout = 10)
    {
        try
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
            var element = _driver.FindElement(elementLocator);
            element.Click();
            wait.Until(ExpectedConditions.StalenessOf(element));
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
            throw;
        }
    }
}
