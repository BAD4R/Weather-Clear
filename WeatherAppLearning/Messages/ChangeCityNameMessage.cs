using CommunityToolkit.Mvvm.Messaging.Messages;
using OpenWeatherMap.NetClient.Models;

namespace WeatherAppLearning.Messages;

public class ChangeCityNameMessage : ValueChangedMessage<string>
{
    public ChangeCityNameMessage(string value) : base(value)
    {
    }
}
