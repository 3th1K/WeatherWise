using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WeatherWise.Models;

public partial class ForecastWeatherModel : ObservableObject
{
    [ObservableProperty] private List<CurrentWeatherModel> forecasts;
    [ObservableProperty] private List<SingleDayForecast> forecastPerDay;
    partial void OnForecastsChanged(List<CurrentWeatherModel> value)
    {
        ForecastPerDay = new List<SingleDayForecast>();
        var dateGroup = Forecasts.GroupBy(f => f.CurrentDateTime.Date);
        foreach (var dateList in dateGroup)
        {
            ForecastPerDay.Add(new SingleDayForecast(dateList.Key.Date, dateList.ToList()));
        }
    }
}

public class SingleDayForecast
{
    public SingleDayForecast() { }

    public SingleDayForecast(DateTime date, List<CurrentWeatherModel> forecasts)
    {
        Date = date.Date;
        ForecastsPerHour = new List<SingleHourForecast>();
        foreach (var forecast in forecasts)
        {
            ForecastsPerHour.Add(new SingleHourForecast()
            {
                Hour = forecast.CurrentDateTime.Hour,
                CurrentHourForecast = forecast
            });
        }
    }
    public DateTime Date { get; set; }
    public List<SingleHourForecast> ForecastsPerHour { get; set; }
}

public class SingleHourForecast
{
    public int Hour { get; set; }
    public CurrentWeatherModel CurrentHourForecast { get; set; }
}