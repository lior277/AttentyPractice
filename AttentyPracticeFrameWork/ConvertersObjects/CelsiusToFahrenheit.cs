using AttentyPractice.Internals;
using AttentyPracticeFrameWork.WebDriverActions;
using static AttentyPracticeFrameWork.Extension.StringExtension;
using OpenQA.Selenium;

namespace AttentyPracticeFrameWork.Converters
{
    public class CelsiusToFahrenheit : ApplicationFactory, ICelsiusToFahrenheit
    {
        public IWebDriver Driver { get; set; }

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

        public decimal GetConvertionValue()
        {
            var result = Driver.GetElement(ResultExp).Text;
            return result.GetNumberFromResault();
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
