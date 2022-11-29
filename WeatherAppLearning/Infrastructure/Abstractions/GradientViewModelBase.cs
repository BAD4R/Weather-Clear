namespace WeatherAppLearning.Infrastructure.Abstractions;

public abstract partial class GradientViewModelBase : ObservableRecipient, IRecipient<ChangeGradientColorsMessage>
{
    protected GradientViewModelBase()
    {
        _gradientColorOne = Color.FromRgba("#8DA2DB");
        _gradientColorTwo = Color.FromRgba("#6378AE");
    }

    [ObservableProperty]
    private Color _gradientColorOne;

    [ObservableProperty]
    private Color _gradientColorTwo;

    public void Receive(ChangeGradientColorsMessage message)
    {
        GradientColorOne = message.Value.Item1;
        GradientColorTwo = message.Value.Item2;
    }
}