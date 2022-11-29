using WeatherAppLearning.Models;

namespace WeatherAppLearning.Abstractions;

public interface ISettings
{
    public CurrentWeatherPageModel CurrentWeather { get; set; }
    public IReadOnlyList<FiveDayWeatherModel> FiveDayWeather { get; set; }
    public IEnumerable<DayTimeWeatherModel> DaytimeWeather { get; set; }
}