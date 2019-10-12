using AttentyPractice.Internals;

namespace AttentyPracticeFrameWork.Converters
{
    public interface ICelsiusToFahrenheit : IApplicationFactory
    {
        ICelsiusToFahrenheit ClickOnTemperatureConvector();
        ICelsiusToFahrenheit ClickOnCelsius();
        ICelsiusToFahrenheit ClickOnCelsiusToFahrenheit();
        ICelsiusToFahrenheit TypeToCelsiusTextBox(decimal num);
        ICelsiusToFahrenheit ChangeFormatToDecimal();
        string GetConvertionValue();
    }
}
