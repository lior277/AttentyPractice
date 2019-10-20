using AttentyPracticeFrameWork.ConversionRaitesexpected;
using AttentyPracticeFrameWork.Converters;
using static AttentyPracticeFrameWork.Extension.StringExtension;
using System;
using AttentyPractice.Internals;
using NUnit.Framework;

namespace Tests
{
    [Parallelizable(ParallelScope.All)]
    [TestFixture]
    public class CelsiusConvector : TestSuitBase
    {            
        decimal numberToConvert = 12;

        [Test]
        public void CelsiusToFahrenheit()
        {
            var resultFromUi = apiFactory
                .ChangeContext<ICelsiusToFahrenheit>()
                .ClickOnTemperatureConvector()
                .ClickOnCelsius()
                .ClickOnCelsiusToFahrenheit()
                .TypeToCelsiusTextBox(numberToConvert)
                .ChangeFormatToDecimal()
                .GetConvertionValue();

            var resultFromCalcuation = ConversionRaitasCalcluation.CelsiusToFahrenheit(numberToConvert);
            var expected = Math.Abs(resultFromUi - resultFromCalcuation);
            Assert.IsTrue(expected < 1);

            driver.Quit();
            driver = null;
        }               
    }
}
