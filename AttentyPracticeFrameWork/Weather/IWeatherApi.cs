using AttentyPractice.Internals;
using AttentyPracticeFrameWork.Dto_s;
using System.Threading.Tasks;

namespace AttentyPracticeFrameWork.Weather
{
    public interface IWeatherApi : IApplicationFactory, ITemperature<GetWeatherResponse>
    {
    }
}