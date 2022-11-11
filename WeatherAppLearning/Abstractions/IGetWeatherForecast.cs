using System.Text.Json;
using WeatherAppLearning.Models;
using WeatherAppLearning.Models.CurrentWearherModels;
using WeatherAppLearning.Models.FiveDayWeatherModels;

namespace WeatherAppLearning.Abstractions;

public interface IGetWeatherForecast
{
    public Task<CurrentWeatherForecastModel> GetCurrentWeatherForecast(string cityName);

    public Task<FiveDayWeatherForecastModel> GetFiveDayWeatherForecast(string cityName);
}

