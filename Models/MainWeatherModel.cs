using CommunityToolkit.Mvvm.ComponentModel;

namespace WeatherWise.Models;

public partial class MainWeatherModel : ObservableObject
{
    [ObservableProperty] private double? tempareture;
}
public partial class MainGeolocationModel : ObservableObject
{
    [ObservableProperty] private string country;
    [ObservableProperty] private string state;
    [ObservableProperty] private string name;
    [ObservableProperty] private double? latitude;
    [ObservableProperty] private double? longitude;
}
