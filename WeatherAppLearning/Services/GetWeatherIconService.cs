namespace WeatherAppLearning.Services;

public static class GetWeatherIconService
{
    private static bool _isInitialized;

    private static Color _gradientOneGrayDayNight;
    private static Color _gradientTwoGrayDayNight;

    private static Color _gradientOneDarkGrayDNight;
    private static Color _gradientTwoDarkGrayDNight;

    private static Color _gradientOneDarkBlueNight;
    private static Color _gradientTwoDarkBlueNight;

    private static Color _gradientOneAquaDay;
    private static Color _gradientTwoAquaDay;

    private static Color _gradientOneBlueDay;
    private static Color _gradientTwoBlueDay;

    public static (string imageSource, Color gradientColorOne, Color gradientColorTwo) GetIconAndColors(int id, string icon)
    {
        InitializeColors();

        string weather = "clear";

        var gradientColorOne = _gradientOneBlueDay;
        var gradientColorTwo = _gradientTwoBlueDay;

        switch (id)
        {
            case >= 200 and <= 232:
                weather = "thunderstorm";
                if (icon[^1] == 'd')
                {
                    gradientColorOne = _gradientOneGrayDayNight;
                    gradientColorTwo = _gradientTwoGrayDayNight;
                }                      
                if (icon[^1] == 'n')   
                {                      
                    gradientColorOne = _gradientOneDarkGrayDNight;
                    gradientColorTwo = _gradientTwoDarkGrayDNight;
                }                      
                                       
                break;                 
                                       
            case >= 300 and <= 321:
                weather = "shower_rain";
                if (icon[^1] == 'd')   
                {                      
                    gradientColorOne = _gradientOneGrayDayNight;
                    gradientColorTwo = _gradientTwoGrayDayNight;
                }                      
                if (icon[^1] == 'n')   
                {                      
                    gradientColorOne = _gradientOneDarkGrayDNight;
                    gradientColorTwo = _gradientTwoDarkGrayDNight;
                }                      
                                       
                break;                 
                                       
            case >= 500 and <= 504:    
                weather = "rain";      
                if (icon[^1] == 'd')   
                {                      
                    gradientColorOne = _gradientOneAquaDay;
                    gradientColorTwo = _gradientTwoAquaDay;
                }                      
                if (icon[^1] == 'n')   
                {                      
                    gradientColorOne = _gradientOneDarkGrayDNight;
                    gradientColorTwo = _gradientTwoDarkGrayDNight;
                }                      
                                       
                break;                 
                                       
            case 511:                  
                weather = "snow";      
                if (icon[^1] == 'd')   
                {                      
                    gradientColorOne = _gradientOneAquaDay;
                    gradientColorTwo = _gradientTwoAquaDay;
                }                      
                if (icon[^1] == 'n')   
                {                      
                    gradientColorOne = _gradientOneDarkGrayDNight;
                    gradientColorTwo = _gradientTwoDarkGrayDNight;
                }                      
                                       
                break;                 
                                       
            case >= 520 and <= 531:
                weather = "shower_rain";
                if (icon[^1] == 'd')   
                {                      
                    gradientColorOne = _gradientOneGrayDayNight;
                    gradientColorTwo = _gradientTwoGrayDayNight;
                }                      
                if (icon[^1] == 'n')   
                {                      
                    gradientColorOne = _gradientOneDarkGrayDNight;
                    gradientColorTwo = _gradientTwoDarkGrayDNight;
                }                      
                                       
                break;                 
                                       
            case >= 600 and <= 622:    
                weather = "snow";      
                if (icon[^1] == 'd')   
                {                      
                    gradientColorOne = _gradientOneAquaDay;
                    gradientColorTwo = _gradientTwoAquaDay;
                }                      
                if (icon[^1] == 'n')   
                {                      
                    gradientColorOne = _gradientOneDarkGrayDNight;
                    gradientColorTwo = _gradientTwoDarkGrayDNight;
                }                      
                                       
                break;                 
                                       
            case >= 701 and <= 781:    
                weather = "mist";      
                if (icon[^1] == 'd')   
                {                      
                    gradientColorOne = _gradientOneGrayDayNight;
                    gradientColorTwo = _gradientTwoGrayDayNight;
                }                      
                if (icon[^1] == 'n')   
                {                      
                    gradientColorOne = _gradientOneDarkGrayDNight;
                    gradientColorTwo = _gradientTwoDarkGrayDNight;
                }                      
                                       
                break;                 
                                       
            case 800:                  
                weather = "clear";     
                if (icon[^1] == 'd')   
                {                      
                    gradientColorOne = _gradientOneBlueDay;
                    gradientColorTwo = _gradientTwoBlueDay;
                }                      
                if (icon[^1] == 'n')   
                {                      
                    gradientColorOne = _gradientOneDarkBlueNight;
                    gradientColorTwo = _gradientTwoDarkBlueNight;
                }                      
                                       
                break;                 
                                       
            case 801:                  
                weather = "few_clouds";
                if (icon[^1] == 'd')   
                {                      
                    gradientColorOne = _gradientOneGrayDayNight;
                    gradientColorTwo = _gradientTwoGrayDayNight;
                }                      
                if (icon[^1] == 'n')   
                {                      
                    gradientColorOne = _gradientOneDarkGrayDNight;
                    gradientColorTwo = _gradientTwoDarkGrayDNight;
                }

                break;

            case 802:
                weather = "scattered_clouds";
                if (icon[^1] == 'd')
                {
                    gradientColorOne = _gradientOneGrayDayNight;
                    gradientColorTwo = _gradientTwoGrayDayNight;
                }
                if (icon[^1] == 'n')
                {
                    gradientColorOne = _gradientOneDarkGrayDNight;
                    gradientColorTwo = _gradientTwoDarkGrayDNight;
                }

                break;

            case 803:
                weather = "broken_clouds";
                if (icon[^1] == 'd')
                {
                    gradientColorOne = _gradientOneGrayDayNight;
                    gradientColorTwo = _gradientTwoGrayDayNight;
                }
                if (icon[^1] == 'n')
                {
                    gradientColorOne = _gradientOneDarkGrayDNight;
                    gradientColorTwo = _gradientTwoDarkGrayDNight;
                }

                break;

            case 804:
                weather = "broken_clouds";
                if (icon[^1] == 'd')
                {
                    gradientColorOne = _gradientOneGrayDayNight;
                    gradientColorTwo = _gradientTwoGrayDayNight;
                }
                if (icon[^1] == 'n')
                {
                    gradientColorOne = _gradientOneDarkGrayDNight;
                    gradientColorTwo = _gradientTwoDarkGrayDNight;
                }

                break;
        }

        return ($"{weather}_{icon[^1]}.png", gradientColorOne, gradientColorTwo);
    }

    private static void InitializeColors()
    {
        if (_isInitialized)
            return;

        _isInitialized = true;

        Application.Current!.Resources.TryGetValue("GradientOneGrayDayNight", out var gradientOneGrayDayNight);
        Application.Current!.Resources.TryGetValue("GradientTwoGrayDayNight", out var gradientTwoGrayDayNight);
        _gradientOneGrayDayNight = (Color)gradientOneGrayDayNight;
        _gradientTwoGrayDayNight = (Color)gradientTwoGrayDayNight;

        Application.Current!.Resources.TryGetValue("GradientOneDarkGrayDNight", out var gradientOneDarkGrayDNight);
        Application.Current!.Resources.TryGetValue("GradientTwoDarkGrayDNight", out var gradientTwoDarkGrayDNight);
        _gradientOneDarkGrayDNight = (Color)gradientOneDarkGrayDNight;
        _gradientTwoDarkGrayDNight = (Color)gradientTwoDarkGrayDNight;

        Application.Current!.Resources.TryGetValue("GradientOneDarkBlueNight", out var gradientOneDarkBlueNight);
        Application.Current!.Resources.TryGetValue("GradientTwoDarkBlueNight", out var gradientTwoDarkBlueNight);
        _gradientOneDarkBlueNight = (Color)gradientOneDarkBlueNight;
        _gradientTwoDarkBlueNight = (Color)gradientTwoDarkBlueNight;

        Application.Current!.Resources.TryGetValue("GradientOneAquaDay", out var gradientOneAquaDay);
        Application.Current!.Resources.TryGetValue("GradientTwoAquaDay", out var gradientTwoAquaDay);
        _gradientOneAquaDay = (Color)gradientOneAquaDay;
        _gradientTwoAquaDay = (Color)gradientTwoAquaDay;

        Application.Current!.Resources.TryGetValue("GradientOneBlueDay", out var gradientOneBlueDay);
        Application.Current!.Resources.TryGetValue("GradientTwoBlueDay", out var gradientTwoBlueDay);
        _gradientOneBlueDay = (Color)gradientOneBlueDay;
        _gradientTwoBlueDay = (Color)gradientTwoBlueDay;

    }
}