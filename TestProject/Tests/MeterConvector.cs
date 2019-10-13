using AttentyPracticeFrameWork.Converters;
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
            var driver = GetDriver(Drivertype.Chrome);

            var resultFromUi = new ApplicationFactory(driver)
                 .ChangeContext<IMetersToFeet>()
                 .ClickOnLengthConvector()
                 .ClickOnMeters()
                 .ClickOnMetersToFeet()
                 .TypeToMetersTextBox(numberToConvert)
                 .ChangeFormatToDecimal()
                 .GetConvertionValue();

            // calcluationn with formula
            var resultFromCalcuation = ConversionRaitasCalcluation.MetersToFeet(numberToConvert);
            var expected = Math.Abs(resultFromUi - resultFromCalcuation);

            Assert.IsTrue(expected < 1);

            driver.Quit();
            driver = null;
        }

        [TearDown]
        public void TestCleanupAttribute()
        {
            //Dispose();
        }

    }
}
