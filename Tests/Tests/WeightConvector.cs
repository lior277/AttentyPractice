using AttentyPracticeFrameWork.ContainerInitiate;
using AttentyPracticeFrameWork.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AttentyPracticeFrameWork.Extension.StringExtension;
using AttentyPracticeFrameWork.ConversionRaitesexpected;
using System;

namespace Tests
{
    [TestClass]
    public class WeightConvector : TestSuitBase
    {
        decimal numberToConvert = 15.2m;
        private IOuncesToGrams weight;

        [TestInitialize]
        public void TestInitialize()
        {
            using (var container = ContainerInitialized.ContainerConfigure())
            {
                weight = container.GetInstance<IOuncesToGrams>();
            }
        }
        [TestMethod]
        public void CelsiusToFahrenheit()
        {
           var result = weight.InitiateWebDriver(WebDriver)
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

        [TestCleanup]
        public void TestCleanupAttribute()
        {
            Dispose();
        }
    }
}
