using OpenWeatherMap.NetClient.Models;
using WeatherAppLearning.Extensions;

namespace WeatherAppLearning.Models;

public readonly struct CurrentWeatherPageModel
{
    public CurrentWeatherPageModel()
    {
        GradientColorOne = Color.FromRgba("#8DA2DB");
        GradientColorTwo = Color.FromRgba("#6378AE");
        ImageLocation = "clear_d.png";

        CityName = string.Empty;
        Temperature = string.Empty;
        TemperatureMax = string.Empty;
        TemperatureMin = string.Empty;
        TemperatureFeelsLike = string.Empty;
        SunriseTime = string.Empty;
        SunsetTime = string.Empty;
    }

    public CurrentWeatherPageModel(CurrentWeather currentWeather)
    {
        var (imageSource, gradientColorOne, gradientColorTwo) = currentWeather.GetIconAndColors();

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

    public Color GradientColorOne { get; init; }
    public Color GradientColorTwo { get; init; }
    public string ImageLocation { get; init; }

    public string CityName { get; init; }
    public string Temperature { get; init; }
    public string TemperatureMax { get; init; }
    public string TemperatureMin { get; init; }
    public string TemperatureFeelsLike { get; init; }
    public string SunriseTime { get; init; }
    public string SunsetTime { get; init; }
}