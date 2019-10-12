using AttentyPractice.Internals;
using OpenQA.Selenium;

namespace AttentyPracticeFrameWork.Weather
{
    public interface ITemperature<T> 
    {
        T GetTodayTemperatureValue();
    }
}
