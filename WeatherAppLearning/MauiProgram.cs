using CommunityToolkit.Maui;
using OpenWeatherMap.NetClient.Extensions;
using OpenWeatherMap.NetClient.Models;
using System.Globalization;
using WeatherAppLearning.Pages;
using WeatherAppLearning.ViewModels;

namespace WeatherAppLearning;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiCommunityToolkit()
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddOpenWeatherMap("b37699a0e5436032b4bf65856ddee855", new OpenWeatherMapOptions()
        {
            Culture = new CultureInfo("ru-RU"),
            CacheDuration = TimeSpan.FromMinutes(5),
        });

        builder.Services.AddSingleton<CurrentWeatherPage>();
		builder.Services.AddSingleton<OptionsPage>();

        builder.Services.AddSingleton<CurrentWeatherPageViewModel>();
        builder.Services.AddSingleton<OptionsPageViewModel>();

        return builder.Build();
	}
}
