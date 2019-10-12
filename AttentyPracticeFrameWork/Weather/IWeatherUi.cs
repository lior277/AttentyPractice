using AttentyPractice.Internals;
using AttentyPracticeFrameWork.Dto_s;

namespace AttentyPracticeFrameWork.Weather
{
    public interface IWeatherUi : IApplicationFactory, ITemperature<int>
    {
        IWeatherUi SearchLocation(string location);
        IWeatherUi ChooseLocation();
    }
}
