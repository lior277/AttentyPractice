namespace AttentyPracticeFrameWork.ApiRoutes
{
    public class ApiRouteAggregate : IApiRouteAggregate
    {
        public string GetWeatherEntry()
        {
            return "/v2/turbo/vt1observation?apiKey=d522aa97197fd864d36b418f39ebb323&format=json&geocode=39.06%2C-77.12&language=en-US&units=e";
        }
    }
}
