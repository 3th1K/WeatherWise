using CommunityToolkit.Mvvm.ComponentModel;

namespace WeatherWise.Models;

public partial class CurrentGeolocationModel : ObservableObject
{
    [ObservableProperty] private string country;
    [ObservableProperty] private string state;
    [ObservableProperty] private string name;
    [ObservableProperty] private double latitude;
    [ObservableProperty] private double longitude;
}