using AttentyPractice.Internals;
using AttentyPracticeFrameWork.WebDriverActions;
using OpenQA.Selenium;

namespace AttentyPracticeFrameWork.Converters
{
    public class CelsiusToFahrenheit : ApiFactory, ICelsiusToFahrenheit
    {
        public IWebDriver driver { get; set; }

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
