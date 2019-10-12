using AttentyPractice.Internals;
using OpenQA.Selenium;

namespace AttentyPracticeFrameWork.Converters
{
    public interface IOuncesToGrams : IApplicationFactory
    {
        IOuncesToGrams InitiateWebDriver(IWebDriver driver);
        IOuncesToGrams NvigateToConvectorSite(string url);
        IOuncesToGrams ClickOnWeightConvector();
        IOuncesToGrams ClickOnOunces();
        IOuncesToGrams ClickOnOuncesToGrams();
        IOuncesToGrams TypeToOuncesTextBox(decimal num);
        string GetConvertionValue();
    }
}
