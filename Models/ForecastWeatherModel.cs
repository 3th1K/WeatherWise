using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WeatherWise.Models;

public partial class ForecastWeatherModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<CurrentWeatherModel> forecasts;
    [ObservableProperty] private ObservableCollection<SingleDayForecast> forecastPerDay;
    [ObservableProperty] private ObservableCollection<SingleHourForecast> focusedForecastPerHour;
    [ObservableProperty] private SingleHourForecast focusedForecast = null;
    partial void OnForecastsChanged(ObservableCollection<CurrentWeatherModel> value)
    {
        ForecastPerDay = new ObservableCollection<SingleDayForecast>();
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
                IsDayTime = forecast.Pod == "d" ? true : false,
                ColorA = forecast.Pod == "d" ? Color.FromArgb("#F3D7E9") : Color.FromArgb("#686D6D"),
                ColorB = forecast.Pod == "d" ? Color.FromArgb("#F3054D") : Color.FromArgb("#242626"),
                Hour = ConvertToAmpm(forecast.CurrentDateTime.Hour),
                CurrentHourForecast = forecast
            });
        }
    }
    public DateTime Date { get; set; }
    public List<SingleHourForecast> ForecastsPerHour { get; set; }

    private string ConvertToAmpm(int hour)
    {
        DateTime dateTime = DateTime.MinValue.AddHours(hour);

        return dateTime.ToString("h tt").ToLower();
    }
}

public class SingleHourForecast
{
    public string Hour { get; set; }
    public bool IsDayTime { get; set; }
    public Color ColorA { get; set; }
    public Color ColorB { get; set; }
    public CurrentWeatherModel CurrentHourForecast { get; set; }
}