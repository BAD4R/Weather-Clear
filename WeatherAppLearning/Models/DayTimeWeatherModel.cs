namespace WeatherAppLearning.Models;

public class DayTimeWeatherModel
{
    public DayTimeWeatherModel(double temperatureLong, string imageSource, DateTime timeStamp, double precipitationProbabilityPercent)
    {
        TemperatureLong = temperatureLong;
        ImageSource = imageSource;
        TimeStamp = timeStamp;
        PrecipitationProbabilityPercent = precipitationProbabilityPercent;
    }
    public string Time
    {
        get { return TimeStamp.ToString("HH:mm"); }
    }

    public string Temperature
    {
        get { return TemperatureLong.ToString("0°"); }
    }
    public string PrecipitationProbability
    {
        get { return (PrecipitationProbabilityPercent*100).ToString("0")+"%"; }
    }

    public double TemperatureLong { get; }
    public string ImageSource{ get; }
    public DateTime TimeStamp { get; }
    public double PrecipitationProbabilityPercent { get; }
}
