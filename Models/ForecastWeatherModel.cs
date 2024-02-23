using CommunityToolkit.Mvvm.ComponentModel;

namespace WeatherWise.Models;

public partial class ForecastWeatherModel : ObservableObject
{
    [ObservableProperty] private List<CurrentWeatherModel> forcasts;
    [ObservableProperty] private 
    partial void OnForcastsChanged(List<CurrentWeatherModel> value)
    {
        throw new NotImplementedException();
    }
}