using OpenWeatherMap.NetClient.Models;
using WeatherAppLearning.Extensions;

namespace WeatherAppLearning.Models;

public readonly struct DayTimeWeatherModel
{
    public DayTimeWeatherModel(Forecast5Days.Weather weather)
    {
        Time = weather.ForecastTimeStamp.ToString("HH:mm");
        Temperature = weather.Temperature.DegreesCelsius.ToString("0°");
        PrecipitationProbability = (weather.PrecipitationProbability.Value * 100).ToString("0") + "%";

        ImageSource = weather.GetIconAndColors().ImageSource;
    }

    public string Time { get; init;  }
    public string Temperature { get; init; }
    public string PrecipitationProbability { get; init;  }
    public string ImageSource { get; init;  }
}
