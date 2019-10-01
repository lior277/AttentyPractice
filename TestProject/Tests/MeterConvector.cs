using AttentyPracticeFrameWork.ContainerInitiate;
using AttentyPracticeFrameWork.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AttentyPracticeFrameWork.Extension.StringExtension;
using AttentyPracticeFrameWork.ConversionRaitesexpected;
using System;

namespace Tests
{
    [TestClass]
    public class MeterConvector : TestSuitBase
    {
        decimal numberToConvert = 15.2m;
        private IMetersToFeet Length;

        [TestInitialize]
        public void TestInitialize()
        {
            using (var container = ContainerInitialized.ContainerConfigure())
            {
                Length = container.GetInstance<IMetersToFeet>();
            }
        }

        [TestMethod]
        public void MeterToFeet()
        {
            var result = Length.InitiateWebDriver(WebDriver)
                 .NvigateToConvectorSite(convectorSiteUrl)
                 .ClickOnLengthConvector()
                 .ClickOnMeters()
                 .ClickOnMetersToFeet()
                 .TypeToMetersTextBox(numberToConvert)
                 .ChangeFormatToDecimal()
                 .GetConvertionValue();

            var actual = result.GetResaultNum();
            var num = ConversionRaitasCalcluation.MetersToFeet(numberToConvert);
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
