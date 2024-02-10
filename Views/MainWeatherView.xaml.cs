using WeatherWise.ViewModels;

namespace WeatherWise.Views;

public partial class MainWeatherView : ContentPage
{
	public MainWeatherView(MainWeatherViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}