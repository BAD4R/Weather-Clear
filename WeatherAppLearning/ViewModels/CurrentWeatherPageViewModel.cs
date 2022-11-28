using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using WeatherAppLearning.Messages;
using OpenWeatherMap.NetClient;
using CommunityToolkit.Mvvm.Input;
using WeatherAppLearning.Services;
using WeatherAppLearning.Models;
using System.Collections.ObjectModel;

namespace WeatherAppLearning.ViewModels;

public partial class CurrentWeatherPageViewModel : ObservableObject, IRecipient<ChangeCityNameMessage>
{
    public CurrentWeatherPageViewModel(IOpenWeatherMap openWeatherMap)
    {
        _openWeatherMap = openWeatherMap;

        WeakReferenceMessenger.Default.Register(this);
    }
    private readonly IOpenWeatherMap _openWeatherMap;
    private readonly GetIconAndColorsService _getIconAndColorsService = new();
    private readonly FiveDayForecastByDaysService _fiveDayForecastByDaysService = new();

    [ObservableProperty]
    Color _gradientColorOne = Color.FromRgba("#8DA2DB");

    [ObservableProperty]
    Color _gradientColorTwo = Color.FromRgba("#6378AE");

    [ObservableProperty]
    string _imageLocation = "clear_d.png";

    [ObservableProperty]
    string _cityName;

    [ObservableProperty]
    string _precipitationProbability;

    [ObservableProperty]
    string _temperature;

    [ObservableProperty]
    string _temperatureMax;

    [ObservableProperty]
    string _temperatureMin;

    [ObservableProperty]
    string _temperatureFeelsLike;

    [ObservableProperty]
    string _sunriseTime;

    [ObservableProperty]
    string _sunsetTime;

    [ObservableProperty]
    private ObservableCollection<FiveDayWeatherModel> _fiveDayWeather;

    public ObservableCollection<DayTimeWeatherModel> DaytimeWeather { get; } = new();

    [RelayCommand]
    async Task CurrentWeatherPageLoaded()
    {
        if (Preferences.Default.ContainsKey("city_name"))
        {
            CityName = Preferences.Default.Get("city_name","New York");
        }

        try
        {
            if (!Preferences.Default.ContainsKey("city_name"))
            {
                var location = await Geolocation.Default.GetLastKnownLocationAsync() ??
                               await Geolocation.Default.GetLocationAsync();

                var weatherForecastByCoordinatesAsync =
                    await _openWeatherMap.CurrentWeather.GetByCoordinatesAsync(location!.Latitude, location.Longitude);

                CityName = weatherForecastByCoordinatesAsync is null
                    ? "New York"
                    : weatherForecastByCoordinatesAsync.CityName;
            }

            var weatherForecast = await _openWeatherMap.CurrentWeather.QueryAsync(CityName);

            Temperature = weatherForecast.Temperature.DegreesCelsius.ToString("#°");
            TemperatureMax = weatherForecast.TemperatureMax.DegreesCelsius.ToString("#°");
            TemperatureMin = weatherForecast.TemperatureMin.DegreesCelsius.ToString("#°");
            TemperatureFeelsLike = weatherForecast.TemperatureFeelsLike.DegreesCelsius.ToString("#°");

            SunriseTime = weatherForecast.Sunrise.ToLocalTime().ToString("HH:mm");
            SunsetTime = weatherForecast.Sunset.ToLocalTime().ToString("HH:mm");

            var fiveDayWeather = await _openWeatherMap.Forecast5Days.QueryAsync(CityName);

            DaytimeWeather.Clear();
            for (int i = 0; i < 9; i++)
            {
                var forecast = fiveDayWeather.Forecast.ElementAt(i);
                DaytimeWeather.Add(new DayTimeWeatherModel(
                    forecast.Temperature.DegreesCelsius,
                    _getIconAndColorsService.GetIconAndColors(forecast.WeatherConditionId, forecast.WeatherIcon).imageSourse,
                    forecast.ForecastTimeStamp,
                    forecast.PrecipitationProbability.Value));
            }

            FiveDayWeather = _fiveDayForecastByDaysService.GetSortedFiveDayForecast(fiveDayWeather);
        }
        catch (FeatureNotSupportedException)
        {
            await Application.Current!.MainPage!.DisplayAlert("Не поддерживается", "На вашем устройстве нет функции геолокации. Выберите город в настройках", "OK");
        }
        catch (FeatureNotEnabledException)
        {
            await Application.Current!.MainPage!.DisplayAlert("Геопозиция выключена", "Определение геопозиции отключено. Выберите город в настройках", "OK");
        }
        catch (PermissionException)
        {
            await Application.Current!.MainPage!.DisplayAlert("Разрешение отклонено", "Выберите город в настройках", "OK");
        }
        catch (Exception)
        {
            await Application.Current!.MainPage!.DisplayAlert("Ошибка геолокации", "Не удалось найти город по геолокации. Выберите город в настройках", "OK");
        }
    }

    public async void Receive(ChangeCityNameMessage message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            CityName = message.Value;
            Preferences.Default.Set("city_name", message.Value);
        });

        try
        {
            var weather = await _openWeatherMap.CurrentWeather.QueryAsync(CityName);
            Temperature = weather.Temperature.DegreesCelsius.ToString("#°");

            var id = weather.WeatherConditionId;
            var icon = weather.WeatherIcon;


            var imageAndColors = _getIconAndColorsService.GetIconAndColors(id, icon);

            ImageLocation = imageAndColors.imageSourse;
            GradientColorOne = imageAndColors.gradientColorOne;
            GradientColorTwo = imageAndColors.gradientColorTwo;

            WeakReferenceMessenger.Default.Send(new ChangeGradientColorsMessage((GradientColorOne, GradientColorTwo)));

            var fiveDayWeather = await _openWeatherMap.Forecast5Days.QueryAsync(CityName);
            var weatherForecast = await _openWeatherMap.CurrentWeather.QueryAsync(CityName);

            DaytimeWeather.Clear();
            for (int i = 0; i < 9; i++)
            {
                var forecast = fiveDayWeather.Forecast.ElementAt(i);
                DaytimeWeather.Add(new DayTimeWeatherModel(
                    forecast.Temperature.DegreesCelsius,
                    _getIconAndColorsService.GetIconAndColors(forecast.WeatherConditionId, forecast.WeatherIcon).imageSourse,
                    forecast.ForecastTimeStamp,
                    forecast.PrecipitationProbability.Value));
            }

            FiveDayWeather = _fiveDayForecastByDaysService.GetSortedFiveDayForecast(fiveDayWeather);

            TemperatureMax = weatherForecast.TemperatureMax.DegreesCelsius.ToString("#°");
            TemperatureMin = weatherForecast.TemperatureMin.DegreesCelsius.ToString("#°");
            TemperatureFeelsLike = weatherForecast.TemperatureFeelsLike.DegreesCelsius.ToString("#°");

            SunriseTime = weatherForecast.Sunrise.ToLocalTime().ToString("HH:mm");
            SunsetTime = weatherForecast.Sunset.ToLocalTime().ToString("HH:mm");

            await Shell.Current.GoToAsync("//currentWeatherPage");
            await Application.Current!.MainPage!.DisplayAlert("Настройки применены", "Город изменен", "OK");
        }
        catch
        {
            await Application.Current!.MainPage!.DisplayAlert("Не найдено", "Указанный город не найден", "OK");
        }

    }
}
