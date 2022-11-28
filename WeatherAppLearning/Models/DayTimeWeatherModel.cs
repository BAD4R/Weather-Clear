using OpenWeatherMap.NetClient.Models;
using WeatherAppLearning.Services;

namespace WeatherAppLearning.Models;

public struct DayTimeWeatherModel
{
    public DayTimeWeatherModel(Forecast5Days.Weather weather)
    {
        Time = weather.ForecastTimeStamp.ToString("HH:mm");
        Temperature = weather.Temperature.DegreesCelsius.ToString("0°");
        PrecipitationProbability = (weather.PrecipitationProbability.Value * 100).ToString("0") + "%";

        ImageSource = GetWeatherIconService.GetIconAndColors(weather.WeatherConditionId, weather.WeatherIcon).imageSource;
    }

    public string Time { get; }
    public string Temperature { get; }
    public string PrecipitationProbability { get; }
    public string ImageSource { get; }
}
