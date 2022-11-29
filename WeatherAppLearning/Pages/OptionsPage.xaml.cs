namespace WeatherAppLearning.Pages;

public partial class OptionsPage
{
    public OptionsPage(OptionsPageViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();

        StatusBar.BindingContext = viewModel;
    }
}