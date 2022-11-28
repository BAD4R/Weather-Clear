using OpenWeatherMap.NetClient.Models;
using WeatherAppLearning.Services;

namespace WeatherAppLearning.Models;

public struct CurrentWeatherPageModel
{
    public CurrentWeatherPageModel(CurrentWeather currentWeather)
    {
        var (imageSource, gradientColorOne, gradientColorTwo) =
            GetWeatherIconService.GetIconAndColors(currentWeather.WeatherConditionId, currentWeather.WeatherIcon);

        GradientColorOne = gradientColorOne;
        GradientColorTwo = gradientColorTwo;
        ImageLocation = imageSource;

        CityName = currentWeather.CityName;

        Temperature = currentWeather.Temperature.DegreesCelsius.ToString("#°");
        TemperatureMax = currentWeather.TemperatureMax.DegreesCelsius.ToString("#°");
        TemperatureMin = currentWeather.TemperatureMin.DegreesCelsius.ToString("#°");
        TemperatureFeelsLike = currentWeather.TemperatureFeelsLike.DegreesCelsius.ToString("#°");

        SunriseTime = currentWeather.Sunrise.ToLocalTime().ToString("HH:mm");
        SunsetTime = currentWeather.Sunset.ToLocalTime().ToString("HH:mm");
    }

    public Color GradientColorOne { get; }
    public Color GradientColorTwo { get; }
    public string ImageLocation { get;  }

    public string CityName { get; }
    public string Temperature { get; }
    public string TemperatureMax { get; }
    public string TemperatureMin { get; }
    public string TemperatureFeelsLike { get; }
    public string SunriseTime { get; }
    public string SunsetTime { get; }
}