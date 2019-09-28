using AttentyPracticeFrameWork.ContainerInitiate;
using AttentyPracticeFrameWork.Weather;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AttentyPracticeFrameWork.Extension.StringExtension;
using System;

namespace Tests.Tests
{
    [TestClass]
    public class WeatherCom : TestSuitBase
    {
        private IWeatherUi weatherUi;
        private IWeatherApi WeatherApi;
        private string location = "20852";

        [TestInitialize]
        public void TestInitialize()
        {
            using (var container = ContainerInitialized.ContainerConfigure())
            {
                weatherUi = container.GetInstance<IWeatherUi>();
                WeatherApi = container.GetInstance<IWeatherApi>();
            }
        }

        [TestMethod]
        public void GetTemperature()
        {          
            var temperatureUI = weatherUi
                .InitiateWebDriver(WebDriver)
                .NavigateToTemperatureSite(weatherSiteUrl)
                .SearchLocation(location)
                .ChooseLocation()
                .GetTemperatureValue();
            var actual = temperatureUI.GetTeperature();

            var responce = WeatherApi.GetWeather();
            var temperature = responce.Vt1Observation.Temperature;
            Assert.IsTrue(Math.Abs(actual - temperature) <= 0.1);
        }

        [TestCleanup]
        public void TestCleanupAttribute()
        {
            Dispose();
        }

    }
}
