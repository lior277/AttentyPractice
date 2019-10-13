using AttentyPractice.Internals;
using AttentyPracticeFrameWork.ConversionRaitesexpected;
using AttentyPracticeFrameWork.Converters;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;

namespace Tests
{
    [TestFixture]
    public class WeightConvector : TestSuitBase
    {
        decimal numberToConvert = 15.2m;

        [Test]
        public void OuncesToGrams()
        {
            var driver = GetDriver(Drivertype.Chrome);

            var resultFromUi = new ApplicationFactory(driver)
                 .ChangeContext<IOuncesToGrams>()
                 .ClickOnWeightConvector()
                 .ClickOnOunces()
                 .ClickOnOuncesToGrams()
                 .TypeToOuncesTextBox(numberToConvert)
                 .GetConvertionValue();

            var resultFromCalcuation = ConversionRaitasCalcluation.OunceToGram(numberToConvert);
            var expected = Math.Abs(resultFromUi - resultFromCalcuation);
            Assert.IsTrue(expected < 1);
        }

        [TearDown]
        public void TestCleanupAttribute()
        {
            //Dispose();
        }
    }
}
