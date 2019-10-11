using AttentyPractice.Internals;

namespace AttentyPracticeFrameWork.Converters
{
    public interface ICelsiusToFahrenheit : IApiFactory
    {
        ICelsiusToFahrenheit ClickOnTemperatureConvector();
        ICelsiusToFahrenheit ClickOnCelsius();
        ICelsiusToFahrenheit ClickOnCelsiusToFahrenheit();
        ICelsiusToFahrenheit TypeToCelsiusTextBox(decimal num);
        ICelsiusToFahrenheit ChangeFormatToDecimal();
        string GetConvertionValue();
    }
}
