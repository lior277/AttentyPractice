using OpenQA.Selenium;
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
        public static IWebElement GetElement(this IWebDriver driver, By by, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            var element = wait.Until(d =>
            {
                try
                {
                    for (int i = 0; i < timeoutInSeconds; i++)
                    {
                        var elementToBeDisplayed = driver.FindElement(by);
                        //elementToBeDisplayed.SendKeys(" ");
                        if (elementToBeDisplayed.Displayed)
                        {
                            return elementToBeDisplayed;
                        }
                    }
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    Thread.Sleep(200);
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

        public static void WaitForElementToBeEnable(this IWebDriver driver, By by, int FromSeconds = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(FromSeconds));
            var element = wait.Until(d =>
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
    }
}
