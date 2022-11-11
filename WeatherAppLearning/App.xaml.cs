using WeatherAppLearning.ViewModels;

namespace WeatherAppLearning;

public partial class App : Application
{
	public App()
	{
		AppShellViewModel appShellViewModel = new AppShellViewModel();

		InitializeComponent();

		MainPage = new AppShell(appShellViewModel);
	}
}
