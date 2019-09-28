using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttentyPracticeFrameWork.Converters;
using AttentyPracticeFrameWork.Weather;
using SimpleInjector;

namespace AttentyPracticeFrameWork.ContainerInitiate
{
    public static class ContainerInitialized
    {
       private static Container container;

        public static Container ContainerConfigure()
        {
            container = new Container();

            container.Register<IMetersToFeet, MetersToFeet>();
            container.Register<ICelsiusToFahrenheit, CelsiusToFahrenheit>();
            container.Register<IOuncesToGrams, OuncesToGrams>();
            container.Register<IWeatherApi, WeatherApi>();
            container.Register<IWeatherUi, WeatherUi>();

            container.Verify();
            return container;
        }
    }
}
