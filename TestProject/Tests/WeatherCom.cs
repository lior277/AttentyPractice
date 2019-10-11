using AttentyPracticeFrameWork.Extension;
using AttentyPracticeFrameWork.Weather;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;

namespace Tests.Tests
{
    [TestFixture]
    public class WeatherCom : TestSuitBase
    {
        private IWeatherUi weatherUi;
        private IWeatherApi WeatherApi;
        private string location = "20852";
    
        [Test]
        public void GetTemperature()
        {
            var driver = new ChromeDriver();

            var temperatureUI = weatherUi
                .InitiateWebDriver(driver)
                .NavigateToTemperatureSite(weatherSiteUrl)
                .SearchLocation(location)
                .ChooseLocation()
                .GetTemperatureValue();
            var actual = temperatureUI.GetTeperature();

            var responce = WeatherApi.GetWeather();
            var temperature = responce.Vt1Observation.Temperature;
            Assert.IsTrue(Math.Abs(actual - temperature) <= 0.1);
        }

        [TearDown]
        public void TestCleanupAttribute()
        {
            //Dispose();
        }

    }
}
