using AttentyPractice.Internals;
using AttentyPracticeFrameWork.WebDriverActions;
using OpenQA.Selenium;

namespace AttentyPracticeFrameWork.Converters
{
    public class MetersToFeet : ApplicationFactory, IMetersToFeet
    {
        public IWebDriver Driver { get; set; }

        public MetersToFeet(IWebDriver driver) : base(driver)
        {

        }

        #region Locators
        private readonly By LengthExp = By.CssSelector("[class='typeConv length bluebg']");
        private readonly By MetersExp = By.XPath("//a[contains(.,'Meters')]");
        private readonly By MetersToFeetExp = By.XPath("//a[contains(.,'Meters to Feet')]");
        private readonly By FormatExp = By.XPath("//select[@id='format']");
        private readonly By ArgumentConvExp = By.CssSelector("#argumentConv");
        private readonly By ResultExp = By.CssSelector("#answer");
        #endregion

        // Celsius to Fahrenheit pipe       
        public IMetersToFeet ClickOnLengthConvector()
        {
            Driver.GetElement(LengthExp).Click();
            return this;
        }

        public IMetersToFeet ClickOnMeters()
        {
            Driver.GetElement(MetersExp).Click();
            return this;
        }

        public IMetersToFeet ClickOnMetersToFeet()
        {
            Driver.GetElement(MetersToFeetExp).Click();
            return this;
        }

        public IMetersToFeet TypeToMetersTextBox(decimal num)
        {
            Driver.GetElement(ArgumentConvExp).SendKeys(num.ToString());
            return this;
        }

        public IMetersToFeet ChangeFormatToDecimal()
        {
            var element = Driver.GetElement(FormatExp);
            element.SendKeys("Decimal" + Keys.Enter);

            return this;
        }

        public string GetConvertionValue()
        {
            return Driver.GetElement(ResultExp).Text;
        }      
    }
}
