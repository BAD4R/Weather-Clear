using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using WeatherAppLearning.Infrastructure.JsonConverters;

namespace WeatherAppLearning.Services;

internal partial class Settings : ObservableObject, ISettings
{
    public Settings()
    {
        _currentWeather = Deserialize(nameof(CurrentWeather), new CurrentWeatherPageModel());
        _fiveDayWeather = Deserialize(nameof(FiveDayWeather), Array.Empty<FiveDayWeatherModel>());
        _daytimeWeather = Deserialize(nameof(DaytimeWeather), Enumerable.Empty<DayTimeWeatherModel>());
    }

    private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions()
    {
        Converters = { new ColorJsonConverter() }
    };

    [ObservableProperty]
    private CurrentWeatherPageModel _currentWeather;

    [ObservableProperty]
    private IReadOnlyList<FiveDayWeatherModel> _fiveDayWeather;

    [ObservableProperty]
    private IEnumerable<DayTimeWeatherModel> _daytimeWeather;

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(CurrentWeather):
                SaveAsJson(CurrentWeather);
                break;
            case nameof(FiveDayWeather):
                SaveAsJson(FiveDayWeather);
                break;
            case nameof(DaytimeWeather):
                SaveAsJson(DaytimeWeather);
                break;
        }
    }

    private static T Deserialize<T>(string key, T defaultValue)
    {
        try
        {
            var jsonValue = Preferences.Get(key, string.Empty);

            if (string.IsNullOrEmpty(jsonValue))
                return defaultValue;

            return JsonSerializer.Deserialize<T>(jsonValue, SerializerOptions) ?? defaultValue;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return defaultValue;
        }
    }

    private static void SaveAsJson<T>(T value, [CallerArgumentExpression(nameof(value))] string? key = null)
    {
        if (key is null)
            return;

        var json = JsonSerializer.Serialize(value, SerializerOptions);
        Preferences.Set(key, json);
    }
}