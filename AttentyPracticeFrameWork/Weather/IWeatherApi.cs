using AttentyPractice.Internals;
using AttentyPracticeFrameWork.Dto_s;

namespace AttentyPracticeFrameWork.Weather
{
    public interface IWeatherApi : IApplicationFactory, ITemperature<GetWeatherResponse>
    {
    }
}