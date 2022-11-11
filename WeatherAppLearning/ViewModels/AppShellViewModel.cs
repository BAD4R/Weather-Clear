using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WeatherAppLearning.Messages;

namespace WeatherAppLearning.ViewModels;

public partial class AppShellViewModel : ObservableObject, IRecipient<ChangeGradientColorsMessage>
{
    public AppShellViewModel()
    {
        WeakReferenceMessenger.Default.Register(this);
    }

    [ObservableProperty]
    Color gradientColorOne = Color.FromRgba("#8DA2DB");

    [ObservableProperty]
    Color gradientColorTwo = Color.FromRgba("#6378AE");

    public void Receive(ChangeGradientColorsMessage message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            GradientColorOne = message.Value.Item1;
            GradientColorTwo = message.Value.Item2;
        });
    }
}