using System;
using AttentyPractice.Internals;
using AttentyPractice.Internals.WebDriverImplemention;
using AttentyPracticeFrameWork.ConversionRaitesexpected;
using AttentyPracticeFrameWork.Converters;
using AttentyPracticeFrameWork.Extension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace TestMS
{
    [TestClass]
    public class CelsiusConvector : TestSuitBase
    {
        decimal numberToConvert = 12;

        [TestMethod]
        public void CelsiusToFahrenheit()
        {
            var result = new ApiFactory()
                .ChangeContext<ICelsiusToFahrenheit>()
                .ClickOnTemperatureConvector()
                .ClickOnCelsius()
                .ClickOnCelsiusToFahrenheit()
                .TypeToCelsiusTextBox(numberToConvert)
                .ChangeFormatToDecimal()
                .GetConvertionValue();

            var actual = result.GetResaultNum();
            var num = ConversionRaitasCalcluation.CelsiusToFahrenheit(numberToConvert);
            var expected = Math.Abs(actual - num);
            Assert.IsTrue(expected < 1);

        }


        [TestMethod]
        public void CelsiusToFahrenheit1()
        {
            driver = ChromeDriverSingleton.GetInstance();
            var result = new ApiFactory()
                .ChangeContext<ICelsiusToFahrenheit>()
                .ClickOnTemperatureConvector()
                .ClickOnCelsius()
                .ClickOnCelsiusToFahrenheit()
                .TypeToCelsiusTextBox(numberToConvert)
                .ChangeFormatToDecimal()
                .GetConvertionValue();

            var actual = result.GetResaultNum();
            var num = ConversionRaitasCalcluation.CelsiusToFahrenheit(numberToConvert);
            var expected = Math.Abs(actual - num);
            Assert.IsTrue(expected < 1);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DisposeTest();
        }

      
    }
}
