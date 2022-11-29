namespace WeatherAppLearning.Infrastructure.Abstractions;

public abstract class BasePage<TViewModel> : ContentPage where TViewModel : ObservableRecipient
{
    protected BasePage(TViewModel viewModel)
    {
        Loaded += OnLoaded;
        Unloaded += OnUnloaded;

        BindingContext = viewModel;
        ViewModel = viewModel;
    }

    public TViewModel ViewModel { get; }

    private void OnLoaded(object sender, EventArgs e)
    {
        ViewModel.IsActive = true;
    }

    private void OnUnloaded(object sender, EventArgs e)
    {
        Loaded -= OnLoaded;
        Unloaded -= OnUnloaded;

        ViewModel.IsActive = false;
    }
}