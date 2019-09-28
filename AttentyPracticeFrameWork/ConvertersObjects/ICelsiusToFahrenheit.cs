using OpenQA.Selenium;

namespace AttentyPracticeFrameWork.Converters
{
    public interface ICelsiusToFahrenheit
    {
        ICelsiusToFahrenheit InitiateWebDriver(IWebDriver driver);
        ICelsiusToFahrenheit NvigateToConvectorSite(string url);
        ICelsiusToFahrenheit ClickOnTemperatureConvector();
        ICelsiusToFahrenheit ClickOnCelsius();
        ICelsiusToFahrenheit ClickOnCelsiusToFahrenheit();
        ICelsiusToFahrenheit TypeToCelsiusTextBox(decimal num);
        ICelsiusToFahrenheit ChangeFormatToDecimal();
        string GetConvertionValue();
    }
}
