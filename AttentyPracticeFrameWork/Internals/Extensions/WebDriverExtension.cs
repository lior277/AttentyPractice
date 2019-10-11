using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AttentyPracticeFrameWork.WebDriverActions
{
    public static class WebDriverExtension
    {           
        public static IWebElement GetElement(this IWebDriver driver, By by, int fromSeconds = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(fromSeconds));

            var element = wait.Until(d =>
            {
                try
                {
                    for (int i = 0; i < fromSeconds; i++)
                    {
                        var elementToBeDisplayed = driver.FindElement(by);
                        for (int j = 0; i < 4; i++)
                        {
                            elementToBeDisplayed.ForceClick(driver);
                        }
                        
                        if (elementToBeDisplayed.Displayed)
                        {
                            return elementToBeDisplayed;
                        }
                    }
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    Thread.Sleep(400);
                    return driver.FindElement(by);
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (ElementNotVisibleException)
                {
                    return null;
                }
                catch (ElementNotInteractableException)
                {
                    return null;
                }
            });
            return element;
        }
         
        public static void WaitForElementToBeEnable(this IWebDriver driver, By by, int fromSeconds = 50)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(fromSeconds));

            wait.Until(d =>
            {
                try
                {
                    var elementEnabled = driver.FindElement(by);
                    if (elementEnabled.Enabled)
                    {
                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            });
        }

        public static void ForceClick(this IWebElement webElement, IWebDriver driver, int fromSeconds = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(fromSeconds));

            wait.Until(d =>
            {
                try
                {
                    IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;

                    jse.ExecuteScript("scroll(250, 0)");
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            });
        }           
    }
}
