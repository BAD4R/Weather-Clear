namespace WeatherAppLearning.Pages;

public partial class CurrentWeatherPage
{
    public CurrentWeatherPage(CurrentWeatherPageViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();

        StatusBar.BindingContext = viewModel;
    }
}