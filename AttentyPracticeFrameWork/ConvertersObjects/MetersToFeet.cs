using AttentyPracticeFrameWork.WebDriverActions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AttentyPracticeFrameWork.Converters
{
    public class MetersToFeet : IMetersToFeet
    {
       private IWebDriver driver;

        #region Locators
        private readonly By LengthExp = By.CssSelector("[class='typeConv length bluebg']");
        private readonly By MetersExp = By.XPath("//a[contains(.,'Meters')]");
        private readonly By MetersToFeetExp = By.XPath("//a[contains(.,'Meters to Feet')]");
        private readonly By FormatExp = By.XPath("//select[@id='format']");
        private readonly By ArgumentConvExp = By.CssSelector("#argumentConv");
        private readonly By ResultExp = By.CssSelector("#answer");
        #endregion

        public IMetersToFeet InitiateWebDriver(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Window.Maximize();
            return this;
        }

        // Celsius to Fahrenheit pipe

        public IMetersToFeet NvigateToConvectorSite(string url)
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }
        public IMetersToFeet ClickOnLengthConvector()
        {
            driver.GetElement(LengthExp).Click();
            return this;
        }

        public IMetersToFeet ClickOnMeters()
        {
            driver.GetElement(MetersExp).Click();
            return this;
        }

        public IMetersToFeet ClickOnMetersToFeet()
        {
            driver.GetElement(MetersToFeetExp).Click();
            return this;
        }

        public IMetersToFeet TypeToMetersTextBox(decimal num)
        {
            driver.GetElement(ArgumentConvExp).SendKeys(num.ToString());
            return this;
        }

        public IMetersToFeet ChangeFormatToDecimal()
        {
            var element = driver.GetElement(FormatExp);
            element.SendKeys("Decimal"+Keys.Enter);

            return this;
        }

        public string GetConvertionValue()
        {
            return driver.GetElement(ResultExp).Text;
        }

        
    }
}
