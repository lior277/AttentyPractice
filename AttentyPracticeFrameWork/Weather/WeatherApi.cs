using AttentyPracticeFrameWork.ApiRouteAggregate;
using AttentyPracticeFrameWork.Dto_s;
using AttentyPracticeFrameWork.Weather;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AttentyPracticeFrameWork.Weather
{
    public class WeatherApi : IWeatherApi
    {
        public IWebDriver driver { get; set; }
        static HttpClient client = new HttpClient();

        public WeatherApi()
        {
            var baseApiUrl = @"https://api.weather.com";

            client.BaseAddress = new Uri(baseApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public GetWeatherResponse GetWeather()
        {

            var route = ApiRouteAggregate.ApiRouteAggregate.GetWeatherEntry();
            return ExecuteGetEntry<GetWeatherResponse>(route);
        }

        private TResponseDto ExecuteGetEntry<TResponseDto>(string apiRoute)
        {
            var response = client.GetAsync(apiRoute);
            var json = response.Result.Content.ReadAsStringAsync().Result;

            var Obj = JsonConvert.DeserializeObject<TResponseDto>(json);

            return Obj;
        }
    }
}
