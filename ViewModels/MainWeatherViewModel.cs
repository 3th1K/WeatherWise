using System.Diagnostics;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherWise.Interfaces;
using WeatherWise.Models;

namespace WeatherWise.ViewModels;

[QueryProperty(nameof(Latitude), "Latitude")]
[QueryProperty(nameof(Longitude), "Longitude")]
public partial class MainWeatherViewModel : ObservableObject
{
    [ObservableProperty] private double latitude;
    [ObservableProperty] private double longitude;
    [ObservableProperty] private string location = "Loading ...";
    partial void OnLongitudeChanged(double value)
    {
        Task.Run(GetWeatherReport);
    }
    [ObservableProperty] private MainWeatherModel weatherModel;
    [ObservableProperty] private MainGeolocationModel geolocationModel;
    partial void OnGeolocationModelChanged(MainGeolocationModel value)
    {
        Location = $"{value.Name}, {value.State}, {value.Country}";
    }
    partial void OnGeolocationModelChanging(MainGeolocationModel value)
    {
        Location = "Loading ...";
    }

    private readonly IOpenWeatherMapService _openWeatherMapService;


    public MainWeatherViewModel(
        MainWeatherModel mainWeatherModel,
        IOpenWeatherMapService openWeatherMapService,
        MainGeolocationModel mainGeolocationModel)
    {
        weatherModel = mainWeatherModel;
        _openWeatherMapService = openWeatherMapService;
        geolocationModel = mainGeolocationModel;
    }

    public async void GetWeatherReport()
    {
        try
        {
            GeolocationModel = await _openWeatherMapService.GetGeolocationAsync(Latitude, Longitude);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
        }
    }
}