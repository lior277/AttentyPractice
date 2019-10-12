using AttentyPractice.Internals;
using AttentyPracticeFrameWork.Weather;
using NUnit.Framework;
using System;

namespace Tests.Tests
{
    [TestFixture]
    public class WeatherCom : TestSuitBase
    {
        private string location = "20852";
    
        [Test]
        public void GetTemperature()
        {
            var driver = GetDriver(Drivertype.Chrome);

            var temperatureUi = new ApplicationFactory(driver)
                .ChangeContext<IWeatherUi>(weatherSiteUrl)
                .SearchLocation(location)
                .ChooseLocation()
                .GetTodayTemperatureValue();

            var responce = new ApplicationFactory()
                .ChangeContext<IWeatherApi>()
                .GetTodayTemperatureValue();

            var temperatureApi = responce.Vt1Observation.Temperature;
            Assert.IsTrue(Math.Abs(temperatureUi - temperatureApi) <= 0.1);

            driver.Quit();
            driver = null;
        }
    }
}
