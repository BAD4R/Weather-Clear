using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppLearning.Models;

public class FiveDayWeatherModel
{
    public FiveDayWeatherModel(double temperatureMaxLong, double temperatureMinLong, double precipitationProbabilityPercent, DateTime dateTime)
    {
        TemperatureMaxLong = temperatureMaxLong;
        TemperatureMinLong = temperatureMinLong;
        PrecipitationProbabilityPercent = precipitationProbabilityPercent;
        DateTime = dateTime;
    }

    public string Date
    {
        get { return DateTime.ToString("MM.dd"); }
    }

    public string TemperatureMax
    {
        get { return TemperatureMaxLong.ToString("0°"); }
    }

    public string TemperatureMin
    {
        get { return TemperatureMinLong.ToString("0°"); }
    }

    public string PrecipitationProbability
    {
        get { return (PrecipitationProbabilityPercent*100).ToString("0")+"%"; }
    }

    public double TemperatureMaxLong { get; }
    public double TemperatureMinLong { get; }
    public double PrecipitationProbabilityPercent { get; }
    public DateTime DateTime { get; }
}
