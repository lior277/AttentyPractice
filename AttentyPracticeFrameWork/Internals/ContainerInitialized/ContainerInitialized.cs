using AttentyPracticeFrameWork.Converters;
using AttentyPracticeFrameWork.Weather;
using Autofac;
using OpenQA.Selenium;

namespace AttentyPracticeFrameWork.ContainerInitiate
{
    public class ContainerInitialized 
    {
        public IContainer ContainerConfigure(IWebDriver driver)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MetersToFeet>().OnActivating(e => e.Instance.driver = driver).As<IMetersToFeet>();
            builder.RegisterType<OuncesToGrams>().OnActivating(e => e.Instance.driver = driver).As<IOuncesToGrams>(); ;
            builder.RegisterType<WeatherUi>().OnActivating(e => e.Instance.driver = driver).As<IWeatherUi>(); ;
            builder.RegisterType<WeatherApi>().OnActivating(e => e.Instance.driver = driver).As<IWeatherApi>(); ;
            builder.RegisterType<CelsiusToFahrenheit>().OnActivating(e => e.Instance.driver = driver).As<ICelsiusToFahrenheit>(); ;

            var container = builder.Build();

            return container;
        }
    }
}
