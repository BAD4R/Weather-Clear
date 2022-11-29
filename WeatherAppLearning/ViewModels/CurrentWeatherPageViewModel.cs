using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using WeatherAppLearning.Messages;
using OpenWeatherMap.NetClient;
using CommunityToolkit.Mvvm.Input;
using WeatherAppLearning.Services;
using WeatherAppLearning.Models;
using System.Collections.ObjectModel;
using WeatherAppLearning.Abstractions;
using WeatherAppLearning.Extensions;

namespace WeatherAppLearning.ViewModels;

public partial class CurrentWeatherPageViewModel : ObservableRecipient, IRecipient<ChangeCityNameMessage>
{
    public CurrentWeatherPageViewModel(IOpenWeatherMap openWeatherMap, ISettings settings)
    {
        _openWeatherMap = openWeatherMap;
        _settings = settings;
    }
    private readonly IOpenWeatherMap _openWeatherMap;
    private readonly ISettings _settings;

    [ObservableProperty]
    private CurrentWeatherPageModel _currentWeatherModel = new();

    [ObservableProperty]
    private IReadOnlyList<FiveDayWeatherModel> _fiveDayWeather = Array.Empty<FiveDayWeatherModel>();

    public ObservableCollection<DayTimeWeatherModel> DaytimeWeather { get; } = new();

    [RelayCommand]
    private async Task CurrentWeatherPageLoaded()
    {
        var cityName = _settings.CityName;

        try
        {
            if (_settings.IsDefault(nameof(Settings.CityName)))
            {
                var location = await Geolocation.Default.GetLastKnownLocationAsync() ??
                               await Geolocation.Default.GetLocationAsync();

                var weatherForecastByCoordinatesAsync =
                    await _openWeatherMap.CurrentWeather.GetByCoordinatesAsync(location!.Latitude, location.Longitude);

                cityName = weatherForecastByCoordinatesAsync is null
                    ? cityName
                    : weatherForecastByCoordinatesAsync.CityName;
            }

            var weatherForecast = await _openWeatherMap.CurrentWeather.QueryAsync(cityName);
            CurrentWeatherModel = new CurrentWeatherPageModel(weatherForecast);

            await InitializeFiveDayWeather(cityName);
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
        _settings.CityName = message.Value;

        try
        {
            var weather = await _openWeatherMap.CurrentWeather.QueryAsync(_settings.CityName);
            CurrentWeatherModel = new CurrentWeatherPageModel(weather);
            WeakReferenceMessenger.Default.Send(new ChangeGradientColorsMessage((CurrentWeatherModel.GradientColorOne, CurrentWeatherModel.GradientColorTwo)));

            await InitializeFiveDayWeather(message.Value);

            await Shell.Current.GoToAsync("//currentWeatherPage");
            await Application.Current!.MainPage!.DisplayAlert("Настройки применены", "Город изменен", "OK");
        }
        catch
        {
            await Application.Current!.MainPage!.DisplayAlert("Не найдено", "Указанный город не найден", "OK");
        }
    }

    private async ValueTask InitializeFiveDayWeather(string cityName)
    {
        DaytimeWeather.Clear();
        var fiveDayWeather = await _openWeatherMap.Forecast5Days.QueryAsync(cityName);

        foreach (var weather in fiveDayWeather!.Forecast)
        {
            DaytimeWeather.Add(new DayTimeWeatherModel(weather));
        }

        FiveDayWeather = fiveDayWeather.GetSortedFiveDayForecast();
    }
}