using CommunityToolkit.Mvvm.Messaging.Messages;

namespace WeatherAppLearning.Infrastructure.Messages;

public class ChangeGradientColorsMessage : ValueChangedMessage<(Color, Color)>
{
    public ChangeGradientColorsMessage((Color, Color) tuple) : base(tuple)
    {
    }
}
