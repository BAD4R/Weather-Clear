﻿using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WeatherAppLearning.Abstractions;
using WeatherAppLearning.Messages;

namespace WeatherAppLearning.ViewModels;

public partial class OptionsPageViewModel : GradientViewModelBase
{
    [RelayCommand]
    private async Task ChangeCityName(string args)
    {
        if(string.IsNullOrEmpty(args))
        {
            await Application.Current!.MainPage!.DisplayAlert("Пусто!", "Укажите название города", "OK");
            return;
        }

        WeakReferenceMessenger.Default.Send(new ChangeCityNameMessage(args));
    }
}