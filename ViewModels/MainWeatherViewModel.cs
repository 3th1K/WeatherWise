﻿using System.Diagnostics;
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
    [ObservableProperty] private CurrentWeatherModel weatherModel;
    [ObservableProperty] private CurrentGeolocationModel geolocationModel;
    partial void OnGeolocationModelChanged(CurrentGeolocationModel value)
    {
        Location = $"{value.Name}, {value.State}, {value.Country}";
    }
    partial void OnGeolocationModelChanging(CurrentGeolocationModel value)
    {
        Location = "Loading ...";
    }

    private readonly IOpenWeatherMapService _openWeatherMapService;


    public MainWeatherViewModel(
        CurrentWeatherModel currentWeatherModel,
        IOpenWeatherMapService openWeatherMapService,
        CurrentGeolocationModel currentGeolocationModel)
    {
        weatherModel = currentWeatherModel;
        _openWeatherMapService = openWeatherMapService;
        geolocationModel = currentGeolocationModel;
    }

    public async void GetWeatherReport()
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
}