using CommunityToolkit.Mvvm.ComponentModel;

namespace WeatherWise.Models;

public partial class MainWeatherModel : ObservableObject
{
    [ObservableProperty]
    private double latitude;
    [ObservableProperty]
    private double longitude;
}
