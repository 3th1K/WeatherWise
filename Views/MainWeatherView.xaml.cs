using WeatherWise.ViewModels;

namespace WeatherWise.Views;

public partial class MainWeatherView : ContentPage
{
	public MainWeatherView(MainWeatherViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
    protected override bool OnBackButtonPressed()
    {
        return true;
    }

}