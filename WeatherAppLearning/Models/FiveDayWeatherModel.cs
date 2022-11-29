namespace WeatherAppLearning.Models;

public readonly struct FiveDayWeatherModel
{
    public FiveDayWeatherModel(double temperatureMaxLong, double temperatureMinLong, double precipitationProbabilityPercent, DateTime dateTime)
    {
        Date = dateTime.ToString("MM.dd");
        TemperatureMax = temperatureMaxLong.ToString("0°");
        TemperatureMin = temperatureMinLong.ToString("0°");
        PrecipitationProbability = (precipitationProbabilityPercent*100).ToString("0")+"%";
    }

    public string Date { get; init; }
    public string TemperatureMax { get; init; }
    public string TemperatureMin { get; init;  }
    public string PrecipitationProbability { get; init;  }
}
