using CommunityToolkit.Mvvm.Messaging.Messages;

namespace WeatherAppLearning.Infrastructure.Messages;

public class ChangeCityNameMessage : ValueChangedMessage<string>
{
    public ChangeCityNameMessage(string value) : base(value)
    {
    }
}
