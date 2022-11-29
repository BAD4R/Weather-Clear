using System.Diagnostics;
using WeatherAppLearning.ViewModels;

namespace WeatherAppLearning;

public partial class App : Application
{
	public App(AppShellViewModel appShellViewModel)
	{
        InitializeComponent();

		MainPage = new AppShell(appShellViewModel);
    }
}
