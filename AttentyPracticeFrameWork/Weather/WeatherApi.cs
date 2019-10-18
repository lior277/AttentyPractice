using AttentyPractice.Internals;
using AttentyPractice.Internals.DAL;
using AttentyPracticeFrameWork.ApiRoutes;
using AttentyPracticeFrameWork.Dto_s;

namespace AttentyPracticeFrameWork.Weather
{
    public class WeatherApi : ApplicationFactory, IWeatherApi
    {       
        IApiAccess _apiAccess;
        IApiRouteAggregate _apiRouteAggregate;
        public WeatherApi(IApiAccess apiAccess, IApiRouteAggregate apiRouteAggregate)
        {
            _apiAccess = apiAccess;
            _apiRouteAggregate = apiRouteAggregate;
        }
    
        public GetWeatherResponse GetTodayTemperatureValue()
        {
            var route = _apiRouteAggregate.GetWeatherEntry();
            return _apiAccess.ExecuteGetEntry<GetWeatherResponse>(route).Result;
        }
    }
}
