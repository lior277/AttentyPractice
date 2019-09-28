using System;
using AttentyPracticeFrameWork.WebDriverActions;
using OpenQA.Selenium;

namespace AttentyPracticeFrameWork.Weather
{
    public class WeatherUi : IWeatherUi
    {
        private IWebDriver driver;

        #region Locators
        private readonly By SearcTextBoxExp = By.XPath("//input[@aria-label='Location Search']");
        private readonly By SearchResultsExp = By.XPath("//div[contains(@class, '3moHD styles__menu__23Qmz')]//a");
        private readonly By TemperatureExp = By.XPath("//div[@class='today_nowcard-temp']");

        #endregion

        public IWeatherUi InitiateWebDriver(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Window.Maximize();
            return this;
        }
        public IWeatherUi NavigateToTemperatureSite(string url)
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }
        public IWeatherUi SearchLocation(string location)
        {
            driver.WaitForElementToBeEnable(SearcTextBoxExp);
            driver.GetElement(SearcTextBoxExp).Click();
            driver.GetElement(SearcTextBoxExp).SendKeys(location);
            return this;
        }
        public IWeatherUi ChooseLocation()
        {
            driver.GetElement(SearchResultsExp).Click();
            return this;
        }
        public string GetTemperatureValue()
        {
           return driver.GetElement(TemperatureExp).Text;
        }

       
    }
}
