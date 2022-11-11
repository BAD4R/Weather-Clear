using WeatherAppLearning.ViewModels;

namespace WeatherAppLearning.Pages;

public partial class OptionsPage : ContentPage
{
	public OptionsPage(OptionsPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
		StatusBar.BindingContext = viewModel;
    }
}