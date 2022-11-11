using OpenWeatherMap.NetClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAppLearning.Models;

namespace WeatherAppLearning.Services;

public class FiveDayForecastByDaysService
{
    public ObservableCollection<FiveDayWeatherModel> GetSortedFiveDayForecast(Forecast5Days fiveDayWeather)
    {
        ObservableCollection<FiveDayWeatherModel> collection = new ObservableCollection<FiveDayWeatherModel>();

        collection.Clear();
        List<double> temperatureMaxList = new List<double>();
        List<double> temperatureMinList = new List<double>();
        List<double> precipitationList = new List<double>();

        var date = DateTime.Now.Date.ToLocalTime();
        foreach (Forecast5Days.Weather item in fiveDayWeather.Forecast)
        {
            if (item.ForecastTimeStamp.Day == date.Day)
            {
                temperatureMaxList.Add(item.TemperatureMax.DegreesCelsius);
                temperatureMinList.Add(item.TemperatureMin.DegreesCelsius);
                precipitationList.Add(item.PrecipitationProbability.Value);
            }
            if (item.ForecastTimeStamp.Day != date.Day)
            {
                date = date.AddDays(1);

                collection.Add(new FiveDayWeatherModel(
                    temperatureMaxList.Max(),
                    temperatureMinList.Min(),
                    precipitationList.Max(),
                    date));

                temperatureMaxList.Clear();
                temperatureMinList.Clear();
                precipitationList.Clear();
            }
        }

        return collection;
    }
}
