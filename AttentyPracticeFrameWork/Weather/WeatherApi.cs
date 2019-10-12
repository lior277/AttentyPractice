using AttentyPractice.Internals;
using AttentyPractice.Internals.DAL;
using AttentyPracticeFrameWork.ApiRoutes;
using AttentyPracticeFrameWork.Dto_s;
using System.Net.Http;

namespace AttentyPracticeFrameWork.Weather
{
    public class WeatherApi : ApplicationFactory, IWeatherApi
    {
        HttpClient _client;
        IApiAccess _apiAccess;
        IApiRouteAggregate _apiRouteAggregate;

        public WeatherApi(HttpClient client, IApiAccess apiAccess, IApiRouteAggregate apiRouteAggregate)
        {
            _client = client;
            _apiAccess = apiAccess;
            _apiRouteAggregate = apiRouteAggregate;
        }
    
        public GetWeatherResponse GetTodayTemperatureValue()
        {
            var route = _apiRouteAggregate.GetWeatherEntry();
            return _apiAccess.ExecuteGetEntry<GetWeatherResponse>(route);
        }
    }
}
