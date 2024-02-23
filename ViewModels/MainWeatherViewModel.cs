using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using WeatherWise.Interfaces;
using WeatherWise.Models;

namespace WeatherWise.ViewModels;

[QueryProperty(nameof(Latitude), "Latitude")]
[QueryProperty(nameof(Longitude), "Longitude")]
public partial class MainWeatherViewModel : ObservableObject
{
    [ObservableProperty] private double latitude;
    [ObservableProperty] private double longitude;
    partial void OnLongitudeChanged(double value)
    {
        Task.Run(GetWeatherReportAsync);
        Task.Run(GetWeatherForcastAsync);
    }

    [ObservableProperty] private CurrentWeatherModel weatherModel;
    [ObservableProperty] private ForecastWeatherModel weatherForecastModel;
    [ObservableProperty] private CurrentGeolocationModel geolocationModel;

    private readonly IOpenWeatherMapService _openWeatherMapService;


    public MainWeatherViewModel(
        CurrentWeatherModel currentWeatherModel,
        IOpenWeatherMapService openWeatherMapService,
        CurrentGeolocationModel currentGeolocationModel, 
        ForecastWeatherModel weatherForecastModel)
    {
        weatherModel = currentWeatherModel;
        _openWeatherMapService = openWeatherMapService;
        geolocationModel = currentGeolocationModel;
        this.weatherForecastModel = weatherForecastModel;
    }

    public async Task GetWeatherReportAsync()
    {
        try
        {
            GeolocationModel = await _openWeatherMapService.GetGeolocationAsync(Latitude, Longitude);
            WeatherModel =
                await _openWeatherMapService.GetCurrentWeatherAsync(GeolocationModel.Latitude, GeolocationModel.Longitude);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
        }
    }

    public async Task GetWeatherForcastAsync()
    {
        try
        {
            WeatherForecastModel = await _openWeatherMapService.GetForecastWeatherAsync(Latitude, Longitude);
            foreach (var VARIABLE in WeatherForecastModel.Dts)
            {
                Debug.Write(VARIABLE.ToString());
            }
        }
        catch (Exception ex)
        {

        }
    }
}