using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherWise.Models;

namespace WeatherWise.ViewModels;

[QueryProperty(nameof(Latitude), "Latitude")]
[QueryProperty(nameof(Longitude), "Longitude")]
public partial class MainWeatherViewModel : ObservableObject
{
    [ObservableProperty] private double latitude;
    [ObservableProperty] private double longitude;
    public MainWeatherViewModel()
    {
    }
}