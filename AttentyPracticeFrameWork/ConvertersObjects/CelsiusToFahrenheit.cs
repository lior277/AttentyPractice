using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttentyPracticeFrameWork.WebDriverActions;
using OpenQA.Selenium;

namespace AttentyPracticeFrameWork.Converters
{
    public class CelsiusToFahrenheit : ICelsiusToFahrenheit
    {
        private IWebDriver driver;

        #region Locators
        private readonly By TemperatureExp = By.CssSelector("[class='typeConv temperature bluebg']");
        private readonly By CelsiusExp = By.XPath("//a[contains(.,'Celsius')]");
        private readonly By CelsiusToFahrenheitExp = By.XPath("//a[contains(.,'Celsius to Fahrenheit')]");
        private readonly By FormatExp = By.XPath("//select[@id='format']");
        private readonly By ArgumentConvExp = By.CssSelector("#argumentConv");
        private readonly By ResultExp = By.CssSelector("#answer");
        #endregion

        public ICelsiusToFahrenheit InitiateWebDriver(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Window.Maximize();
            return this;
        }
      
        public ICelsiusToFahrenheit ClickOnCelsius()
        {
            driver.GetElement(CelsiusExp).Click();
            return this;
        }

        public ICelsiusToFahrenheit ClickOnCelsiusToFahrenheit()
        {
            driver.GetElement(CelsiusToFahrenheitExp).Click();
            return this;
        }

        public ICelsiusToFahrenheit ClickOnTemperatureConvector()
        {
            driver.GetElement(TemperatureExp).Click();
            return this;
        }

        public string GetConvertionValue()
        {
            return driver.GetElement(ResultExp).Text;
        }
    
        public ICelsiusToFahrenheit NvigateToConvectorSite(string url)
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        public ICelsiusToFahrenheit TypeToCelsiusTextBox(decimal num)
        {
            driver.GetElement(ArgumentConvExp).SendKeys(num.ToString());
            return this;
        }

        public ICelsiusToFahrenheit ChangeFormatToDecimal()
        {
            var element = driver.FindElement(FormatExp);
            element.SendKeys("Decimal" + Keys.Enter);

            return this;
        }
    }
}
