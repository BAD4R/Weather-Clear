using OpenWeatherMap.NetClient.Models;
using WeatherAppLearning.Models;

namespace WeatherAppLearning.Extensions;

internal static class Forecast5DaysExtensions
{
    public static IReadOnlyList<FiveDayWeatherModel> GetSortedFiveDayForecast(this Forecast5Days fiveDayWeather)
    {
        var collection = new List<FiveDayWeatherModel>();

        var temperatureMaxList = new List<double>();
        var temperatureMinList = new List<double>();
        var precipitationList = new List<double>();

        var date = DateTime.Now.Date.ToLocalTime();

        foreach (var item in fiveDayWeather.Forecast)
        {
            if (item.ForecastTimeStamp.Day == date.Day)
            {
                temperatureMaxList.Add(item.TemperatureMax.DegreesCelsius);
                temperatureMinList.Add(item.TemperatureMin.DegreesCelsius);
                precipitationList.Add(item.PrecipitationProbability.Value);
            }

            if (item.ForecastTimeStamp.Day == date.Day)
                continue;

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

        return collection;
    }
}