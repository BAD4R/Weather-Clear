using OpenWeatherMap.NetClient.Models;

namespace WeatherAppLearning.Infrastructure.Extensions;

internal static class WeatherExtensions
{
    public static IconAndColorsForWeather GetIconAndColors(this CurrentWeather currentWeather) => GetIconAndColors(currentWeather.WeatherConditionId, currentWeather.WeatherIcon);
    public static IconAndColorsForWeather GetIconAndColors(this Forecast5Days.Weather weather) => GetIconAndColors(weather.WeatherConditionId, weather.WeatherIcon);

    private static IconAndColorsForWeather GetIconAndColors(int id, string? icon)
    {
        icon ??= "d";

        Application.Current!.Resources.TryGetValue("GradientOneGrayDayNight", out var gradientOneGrayDayNight);
        Application.Current!.Resources.TryGetValue("GradientTwoGrayDayNight", out var gradientTwoGrayDayNight);
        Application.Current!.Resources.TryGetValue("GradientOneDarkGrayDNight", out var gradientOneDarkGrayDNight);
        Application.Current!.Resources.TryGetValue("GradientTwoDarkGrayDNight", out var gradientTwoDarkGrayDNight);
        Application.Current!.Resources.TryGetValue("GradientOneDarkBlueNight", out var gradientOneDarkBlueNight);
        Application.Current!.Resources.TryGetValue("GradientTwoDarkBlueNight", out var gradientTwoDarkBlueNight);
        Application.Current!.Resources.TryGetValue("GradientOneAquaDay", out var gradientOneAquaDay);
        Application.Current!.Resources.TryGetValue("GradientTwoAquaDay", out var gradientTwoAquaDay);
        Application.Current!.Resources.TryGetValue("GradientOneBlueDay", out var gradientOneBlueDay);
        Application.Current!.Resources.TryGetValue("GradientTwoBlueDay", out var gradientTwoBlueDay);

        var weather = "clear";
        var gradientColorOne = (Color)gradientOneBlueDay;
        var gradientColorTwo = (Color)gradientTwoBlueDay;

        switch (id)
        {
            case >= 200 and <= 232:
                weather = "thunderstorm";
                if (icon[^1] == 'd')
                {
                    gradientColorOne = (Color)gradientOneGrayDayNight;
                    gradientColorTwo = (Color)gradientTwoGrayDayNight;
                }
                if (icon[^1] == 'n')
                {
                    gradientColorOne = (Color)gradientOneDarkGrayDNight;
                    gradientColorTwo = (Color)gradientTwoDarkGrayDNight;
                }
                break;
            case >= 300 and <= 321:
                weather = "shower_rain";
                if (icon[^1] == 'd')
                {
                    gradientColorOne = (Color)gradientOneGrayDayNight;
                    gradientColorTwo = (Color)gradientTwoGrayDayNight;
                }
                if (icon[^1] == 'n')
                {
                    gradientColorOne = (Color)gradientOneDarkGrayDNight;
                    gradientColorTwo = (Color)gradientTwoDarkGrayDNight;
                }
                break;
            case >= 500 and <= 504:
                weather = "rain";
                if (icon[^1] == 'd')
                {
                    gradientColorOne = (Color)gradientOneAquaDay;
                    gradientColorTwo = (Color)gradientTwoAquaDay;
                }
                if (icon[^1] == 'n')
                {
                    gradientColorOne = (Color)gradientOneDarkGrayDNight;
                    gradientColorTwo = (Color)gradientTwoDarkGrayDNight;
                }
                break;
            case 511:
                weather = "snow";
                if (icon[^1] == 'd')
                {
                    gradientColorOne = (Color)gradientOneAquaDay;
                    gradientColorTwo = (Color)gradientTwoAquaDay;
                }
                if (icon[^1] == 'n')
                {
                    gradientColorOne = (Color)gradientOneDarkGrayDNight;
                    gradientColorTwo = (Color)gradientTwoDarkGrayDNight;
                }
                break;
            case >= 520 and <= 531:
                weather = "shower_rain";
                if (icon[^1] == 'd')
                {
                    gradientColorOne = (Color)gradientOneGrayDayNight;
                    gradientColorTwo = (Color)gradientTwoGrayDayNight;
                }
                if (icon[^1] == 'n')
                {
                    gradientColorOne = (Color)gradientOneDarkGrayDNight;
                    gradientColorTwo = (Color)gradientTwoDarkGrayDNight;
                }
                break;
            case >= 600 and <= 622:
                weather = "snow";
                if (icon[^1] == 'd')
                {
                    gradientColorOne = (Color)gradientOneAquaDay;
                    gradientColorTwo = (Color)gradientTwoAquaDay;
                }
                if (icon[^1] == 'n')
                {
                    gradientColorOne = (Color)gradientOneDarkGrayDNight;
                    gradientColorTwo = (Color)gradientTwoDarkGrayDNight;
                }
                break;
            case >= 701 and <= 781:
                weather = "mist";
                if (icon[^1] == 'd')
                {
                    gradientColorOne = (Color)gradientOneGrayDayNight;
                    gradientColorTwo = (Color)gradientTwoGrayDayNight;
                }
                if (icon[^1] == 'n')
                {
                    gradientColorOne = (Color)gradientOneDarkGrayDNight;
                    gradientColorTwo = (Color)gradientTwoDarkGrayDNight;
                }
                break;
            case 800:
                weather = "clear";
                if (icon[^1] == 'd')
                {
                    gradientColorOne = (Color)gradientOneBlueDay;
                    gradientColorTwo = (Color)gradientTwoBlueDay;
                }
                if (icon[^1] == 'n')
                {
                    gradientColorOne = (Color)gradientOneDarkBlueNight;
                    gradientColorTwo = (Color)gradientTwoDarkBlueNight;
                }
                break;
            case 801:
                weather = "few_clouds";
                if (icon[^1] == 'd')
                {
                    gradientColorOne = (Color)gradientOneGrayDayNight;
                    gradientColorTwo = (Color)gradientTwoGrayDayNight;
                }
                if (icon[^1] == 'n')
                {
                    gradientColorOne = (Color)gradientOneDarkGrayDNight;
                    gradientColorTwo = (Color)gradientTwoDarkGrayDNight;
                }
                break;
            case 802:
                weather = "scattered_clouds";
                if (icon[^1] == 'd')
                {
                    gradientColorOne = (Color)gradientOneGrayDayNight;
                    gradientColorTwo = (Color)gradientTwoGrayDayNight;
                }
                if (icon[^1] == 'n')
                {
                    gradientColorOne = (Color)gradientOneDarkGrayDNight;
                    gradientColorTwo = (Color)gradientTwoDarkGrayDNight;
                }
                break;
            case 803:
                weather = "broken_clouds";
                if (icon[^1] == 'd')
                {
                    gradientColorOne = (Color)gradientOneGrayDayNight;
                    gradientColorTwo = (Color)gradientTwoGrayDayNight;
                }
                if (icon[^1] == 'n')
                {
                    gradientColorOne = (Color)gradientOneDarkGrayDNight;
                    gradientColorTwo = (Color)gradientTwoDarkGrayDNight;
                }
                break;
            case 804:
                weather = "broken_clouds";
                if (icon[^1] == 'd')
                {
                    gradientColorOne = (Color)gradientOneGrayDayNight;
                    gradientColorTwo = (Color)gradientTwoGrayDayNight;
                }
                if (icon[^1] == 'n')
                {
                    gradientColorOne = (Color)gradientOneDarkGrayDNight;
                    gradientColorTwo = (Color)gradientTwoDarkGrayDNight;
                }
                break;
        }

        return new IconAndColorsForWeather($"{weather}_{icon[^1]}.png", gradientColorOne, gradientColorTwo);
    }
}