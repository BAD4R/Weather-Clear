using WeatherAppLearning.ViewModels;

namespace WeatherAppLearning.Pages;

public partial class CurrentWeatherPage : ContentPage
{
	public CurrentWeatherPage(CurrentWeatherPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
		StatusBar.BindingContext = viewModel;
	}
}