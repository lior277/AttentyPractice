using AttentyPracticeFrameWork.ConversionRaitesexpected;
using AttentyPracticeFrameWork.Converters;
using AttentyPracticeFrameWork.Extension;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;

namespace Tests
{
    [TestFixture]
    public class WeightConvector : TestSuitBase
    {
        decimal numberToConvert = 15.2m;
        private IOuncesToGrams weight;


        [Test]
        public void CelsiusToFahrenheit()
        {
            var driver = new ChromeDriver();

            var result = weight.InitiateWebDriver(driver)
                 .NvigateToConvectorSite(convectorSiteUrl)
                 .ClickOnWeightConvector()
                 .ClickOnOunces()
                 .ClickOnOuncesToGrams()
                 .TypeToOuncesTextBox(numberToConvert)
                 .GetConvertionValue();

            var actual = result.GetResaultNum();
            var num = ConversionRaitasCalcluation.OunceToGram(numberToConvert);
            var expected = Math.Abs(actual - num);
            Assert.IsTrue(expected < 1);
        }

        [TearDown]
        public void TestCleanupAttribute()
        {
            //Dispose();
        }
    }
}
