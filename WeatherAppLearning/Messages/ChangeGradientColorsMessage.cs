using CommunityToolkit.Mvvm.Messaging.Messages;
using OpenWeatherMap.NetClient.Models;

namespace WeatherAppLearning.Messages;

public class ChangeGradientColorsMessage : ValueChangedMessage<(Color, Color)>
{
    public ChangeGradientColorsMessage((Color, Color) tuple) : base(tuple)
    {
    }
}
