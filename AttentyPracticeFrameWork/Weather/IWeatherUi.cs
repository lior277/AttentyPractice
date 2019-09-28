using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttentyPracticeFrameWork.Weather
{
   public interface IWeatherUi
    {
        IWeatherUi InitiateWebDriver(IWebDriver driver);
        IWeatherUi NavigateToTemperatureSite(string url);
        IWeatherUi SearchLocation(string location);
        IWeatherUi ChooseLocation();
        string GetTemperatureValue();
    }
}
