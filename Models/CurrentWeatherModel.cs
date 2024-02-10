using CommunityToolkit.Mvvm.ComponentModel;

namespace WeatherWise.Models;

public partial class CurrentWeatherModel : ObservableObject
{
    [ObservableProperty] private double? currentTemperature;
    [ObservableProperty] private string weatherCondition;
    [ObservableProperty] private DateTime sunrise;
    [ObservableProperty] private DateTime sunset;
    [ObservableProperty] private double? feelsLike;
    [ObservableProperty] private double humidity;
    [ObservableProperty] private int pressure;
    [ObservableProperty] private double visibility;

}