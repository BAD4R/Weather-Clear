using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using WeatherAppLearning.Abstractions;

namespace WeatherAppLearning.Services;

internal partial class Settings : ObservableObject, ISettings
{
    public Settings()
    {
        CityName = Preferences.Default.Get(nameof(CityName), "New York");
    }

    [ObservableProperty]
    private string _cityName;

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(CityName):
                Preferences.Default.Set(nameof(CityName), CityName);
                break;
        }
    }
}