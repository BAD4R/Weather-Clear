namespace WeatherAppLearning.Abstractions;

public interface ISettings
{
    public string CityName { get; set; }

    public bool IsDefault(string propertyName);
}