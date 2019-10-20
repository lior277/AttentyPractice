using AttentyPracticeFrameWork.Converters;
using AttentyPracticeFrameWork.ConversionRaitesexpected;
using System;
using AttentyPractice.Internals;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class MeterConvector : TestSuitBase
    {
        decimal numberToConvert = 15.2m;

        [Test]
        public void MeterToFeet()
        {
            var resultFromUi = apiFactory
                 .ChangeContext<IMetersToFeet>()
                 .ClickOnLengthConvector()
                 .ClickOnMeters()
                 .ClickOnMetersToFeet()
                 .TypeToMetersTextBox(numberToConvert)
                 .ChangeFormatToDecimal()
                 .GetConvertionValue();

            // calcluationn with formula
            var resultFromCalcuation = ConversionRaitasCalcluation.MetersToFeet(numberToConvert);
            var expected = Math.Abs(resultFromUi - resultFromCalcuation) < 1;

            Assert.IsTrue(false);
        }     
    }
}
