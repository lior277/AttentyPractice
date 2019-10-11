using AttentyPracticeFrameWork.ConversionRaitesexpected;
using AttentyPracticeFrameWork.Converters;
using static AttentyPracticeFrameWork.Extension.StringExtension;
using System;
using AttentyPractice.Internals;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

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
           var driver = GetDriver(Drivertype.Chrome);

            var result = new ApiFactory(driver)
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

            driver.Quit();
            driver = null;
        }
       

        [Test]
        public void CelsiusToFahrenheit1()
        {
            var driver = new ChromeDriver();

            var result = new ApiFactory(driver)
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

            driver.Quit();
            driver = null;
        }

        [TearDown]
        public void TestCleanup()
        {
           // DisposeTest();
        }

       
    }
}
