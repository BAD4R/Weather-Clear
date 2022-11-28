namespace WeatherAppLearning.Models;

public struct FiveDayWeatherModel
{
    public FiveDayWeatherModel(double temperatureMaxLong, double temperatureMinLong, double precipitationProbabilityPercent, DateTime dateTime)
    {
        Date = dateTime.ToString("MM.dd");
        TemperatureMax = temperatureMaxLong.ToString("0°");
        TemperatureMin = temperatureMinLong.ToString("0°");
        PrecipitationProbability = (precipitationProbabilityPercent*100).ToString("0")+"%";
    }

    public string Date { get; }
    public string TemperatureMax { get; }
    public string TemperatureMin { get; }
    public string PrecipitationProbability { get; }
}
