using AttentyPracticeFrameWork.ContainerInitiate;
using AttentyPracticeFrameWork.ConversionRaitesexpected;
using AttentyPracticeFrameWork.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AttentyPracticeFrameWork.Extension.StringExtension;

using System;

namespace Tests
{
    [TestClass]
    public class CelsiusConvector : TestSuitBase
    {
        decimal numberToConvert = 12;
        private ICelsiusToFahrenheit temperature;

        [TestInitialize]
        public void TestInitialize()
        {
            using (var container = ContainerInitialized.ContainerConfigure())
            {
                temperature = container.GetInstance<ICelsiusToFahrenheit>();
            }
        }
        [TestMethod]
        public void CelsiusToFahrenheit()
        {
           var result = temperature.InitiateWebDriver(WebDriver)
                .NvigateToConvectorSite(convectorSiteUrl)
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
        public void TestCleanupAttribute()
        {
            Dispose();
        }
    }
}
