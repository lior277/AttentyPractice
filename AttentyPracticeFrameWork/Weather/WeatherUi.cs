using System;
using AttentyPractice.Internals;
using AttentyPracticeFrameWork.Dto_s;
using AttentyPracticeFrameWork.Extension;
using AttentyPracticeFrameWork.WebDriverActions;
using OpenQA.Selenium;

namespace AttentyPracticeFrameWork.Weather
{
    public class WeatherUi : ApplicationFactory, IWeatherUi
    {
        public IWebDriver Driver { get; set; }

        #region Locators
        private readonly By SearcTextBoxExp = By.XPath("//input[@aria-label='Location Search']");
        private readonly By SearchResultsExp = By.XPath("//div[contains(@class, '3moHD styles__menu__23Qmz')]//a");
        private readonly By TemperatureExp = By.XPath("//div[@class='today_nowcard-temp']");

        #endregion

        public IWeatherUi NavigateToTemperatureSite(string url)
        {
            Driver.Navigate().GoToUrl(url);
            return this;
        }
        public IWeatherUi SearchLocation(string location)
        {
            Driver.WaitForElementToBeEnable(SearcTextBoxExp);
            Driver.GetElement(SearcTextBoxExp).Click();
            Driver.GetElement(SearcTextBoxExp).SendKeys(location);
            return this;
        }
        public IWeatherUi ChooseLocation()
        {
            Driver.GetElement(SearchResultsExp).Click();
            return this;
        }

        public int GetTodayTemperatureValue()
        {
            var text = Driver.GetElement(TemperatureExp).Text;
            return Convert.ToInt32(text.GetTemperature());

        }
    }
}
