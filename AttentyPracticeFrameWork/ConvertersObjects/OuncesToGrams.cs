using AttentyPractice.Internals;
using AttentyPractice.Internals.WebDriverImplemention;
using AttentyPracticeFrameWork.WebDriverActions;
using OpenQA.Selenium;

namespace AttentyPracticeFrameWork.Converters
{
    public class OuncesToGrams : ApiFactory, IOuncesToGrams
    {
        public IWebDriver driver { get; set; }
    
        #region Locators
        private readonly By WeightExp = By.CssSelector("[class='typeConv weight bluebg']");
        private readonly By OuncesExp = By.XPath("//a[contains(.,'Ounces')]");
        private readonly By OuncesToGramsExp = By.XPath("//a[contains(.,'Ounces to Grams')]");
        private readonly By ArgumentConvExp = By.CssSelector("#argumentConv");
        private readonly By ResultExp = By.CssSelector("#answer");
        #endregion

        public IOuncesToGrams ClickOnOunces()
        {
            driver.GetElement(OuncesExp).Click();
            return this;
        }

        public IOuncesToGrams ClickOnOuncesToGrams()
        {
            driver.GetElement(OuncesToGramsExp).Click();
            return this;
        }

        public IOuncesToGrams ClickOnWeightConvector()
        {
            driver.GetElement(WeightExp).Click();
            return this;
        }

        public string GetConvertionValue()
        {
            return driver.GetElement(ResultExp).Text;
        }

        public IOuncesToGrams InitiateWebDriver(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Window.Maximize();
            return this;
        }

        public IOuncesToGrams NvigateToConvectorSite(string url)
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        public IOuncesToGrams TypeToOuncesTextBox(decimal num)
        {
            driver.GetElement(ArgumentConvExp).SendKeys(num.ToString());
            return this;
        }  
    }
}
