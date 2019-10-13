using AttentyPractice.Internals;
using AttentyPracticeFrameWork.WebDriverActions;
using static AttentyPracticeFrameWork.Extension.StringExtension;
using OpenQA.Selenium;

namespace AttentyPracticeFrameWork.Converters
{
    public class OuncesToGrams : ApplicationFactory, IOuncesToGrams
    {
        public IWebDriver Driver { get; set; }

        public OuncesToGrams(IWebDriver driver) : base(driver)
        {

        }

        #region Locators
        private readonly By WeightExp = By.CssSelector("[class='typeConv weight bluebg']");
        private readonly By OuncesExp = By.XPath("//a[contains(.,'Ounces')]");
        private readonly By OuncesToGramsExp = By.XPath("//a[contains(.,'Ounces to Grams')]");
        private readonly By ArgumentConvExp = By.CssSelector("#argumentConv");
        private readonly By ResultExp = By.CssSelector("#answer");
        #endregion

        public IOuncesToGrams ClickOnOunces()
        {
            Driver.GetElement(OuncesExp).Click();
            return this;
        }

        public IOuncesToGrams ClickOnOuncesToGrams()
        {
            Driver.GetElement(OuncesToGramsExp).Click();
            return this;
        }

        public IOuncesToGrams ClickOnWeightConvector()
        {
            Driver.GetElement(WeightExp).Click();
            return this;
        }

        public decimal GetConvertionValue()
        {
            var result = Driver.GetElement(ResultExp).Text;
            return result.GetNumberFromResault();
        }

        public IOuncesToGrams InitiateWebDriver(IWebDriver driver)
        {
            this.Driver = driver;
            driver.Manage().Window.Maximize();
            return this;
        }

        public IOuncesToGrams NvigateToConvectorSite(string url)
        {
            Driver.Navigate().GoToUrl(url);
            return this;
        }

        public IOuncesToGrams TypeToOuncesTextBox(decimal num)
        {
            Driver.GetElement(ArgumentConvExp).SendKeys(num.ToString());
            return this;
        }  
    }
}
