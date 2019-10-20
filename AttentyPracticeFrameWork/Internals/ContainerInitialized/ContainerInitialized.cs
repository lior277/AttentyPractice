using AttentyPractice.Internals.DAL;
using AttentyPracticeFrameWork.ApiRoutes;
using AttentyPracticeFrameWork.Converters;
using AttentyPracticeFrameWork.Weather;
using Autofac;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System.Net.Http;

namespace AttentyPracticeFrameWork.ContainerInitiate
{
    public class ContainerInitialized 
    {
        public IContainer ContainerConfigure(IWebDriver driver)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MetersToFeet>().OnActivating(e => e.Instance.Driver = driver).As<IMetersToFeet>();
            builder.RegisterType<OuncesToGrams>().OnActivating(e => e.Instance.Driver = driver).As<IOuncesToGrams>();
            builder.RegisterType<WeatherUi>().OnActivating(e => e.Instance.Driver = driver).As<IWeatherUi>();
            builder.RegisterType<WeatherApi>().As<IWeatherApi>();
            builder.RegisterType<ApiAccess>().As<IApiAccess>();
            builder.RegisterType<ApiRouteAggregate>().As<IApiRouteAggregate>();
            builder.RegisterType<CelsiusToFahrenheit>().OnActivating(e => e.Instance.Driver = driver).As<ICelsiusToFahrenheit>();
            builder.RegisterType<HttpClient>().AsSelf().SingleInstance();
            builder.RegisterType<ExtentTest>().AsSelf();
            
            var container = builder.Build();

            return container;
        }
    }
}
