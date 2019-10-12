﻿using AttentyPractice.Internals;
using AttentyPracticeFrameWork.WebDriverActions;
using OpenQA.Selenium;

namespace AttentyPracticeFrameWork.Converters
{
    public class CelsiusToFahrenheit : ApplicationFactory, ICelsiusToFahrenheit
    {
        public IWebDriver Driver { get; set; }

        public CelsiusToFahrenheit(IWebDriver driver) : base(driver)
        {

        }

        #region Locators
        private readonly By TemperatureExp = By.CssSelector("[class='typeConv temperature bluebg']");
        private readonly By CelsiusExp = By.XPath("//a[contains(.,'Celsius')]");
        private readonly By CelsiusToFahrenheitExp = By.XPath("//a[contains(.,'Celsius to Fahrenheit')]");
        private readonly By FormatExp = By.XPath("//select[@id='format']");
        private readonly By ArgumentConvExp = By.CssSelector("#argumentConv");
        private readonly By ResultExp = By.CssSelector("#answer");

        #endregion
        public ICelsiusToFahrenheit ClickOnCelsius()
        {
            Driver.GetElement(CelsiusExp).Click();
            return this;
        }

        public ICelsiusToFahrenheit ClickOnCelsiusToFahrenheit()
        {
            Driver.GetElement(CelsiusToFahrenheitExp).Click();
            return this;
        }

        public ICelsiusToFahrenheit ClickOnTemperatureConvector()
        {
            Driver.GetElement(TemperatureExp).Click();
            return this;
        }

        public string GetConvertionValue()
        {
            return Driver.GetElement(ResultExp).Text;
        }
        
        public ICelsiusToFahrenheit TypeToCelsiusTextBox(decimal num)
        {
            Driver.GetElement(ArgumentConvExp).SendKeys(num.ToString());
            return this;
        }

        public ICelsiusToFahrenheit ChangeFormatToDecimal()
        {
            var element = Driver.FindElement(FormatExp);
            element.SendKeys("Decimal" + Keys.Enter);

            return this;
        }      
    }
}
