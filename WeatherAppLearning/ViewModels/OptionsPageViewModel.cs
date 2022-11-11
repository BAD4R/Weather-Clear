using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WeatherAppLearning.Messages;

namespace WeatherAppLearning.ViewModels;

public partial class OptionsPageViewModel : ObservableObject, IRecipient<ChangeGradientColorsMessage>
{
    public OptionsPageViewModel()
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
    [RelayCommand]
    async Task ChangeCityName(string args)
    {
        if(args != null)
            WeakReferenceMessenger.Default.Send(new ChangeCityNameMessage(args));
        if(args == null)
        {
            await Application.Current.MainPage.DisplayAlert("Пусто!", "Укажите название города", "OK");
        }
    }
}