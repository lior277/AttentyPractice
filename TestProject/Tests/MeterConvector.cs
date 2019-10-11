using AttentyPracticeFrameWork.Converters;
using static AttentyPracticeFrameWork.Extension.StringExtension;
using AttentyPracticeFrameWork.ConversionRaitesexpected;
using System;
using AttentyPractice.Internals;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    [TestFixture]
    public class MeterConvector : TestSuitBase
    {
        decimal numberToConvert = 15.2m;

        [Test]
        public void MeterToFeet()
        {
            var driver = new ChromeDriver();

            var result = new ApiFactory(driver)
                 .ChangeContext<IMetersToFeet>()
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

        [TearDown]
        public void TestCleanupAttribute()
        {
            //Dispose();
        }

    }
}
