using AutoMapper;
using WeatherWise.Models;
using WeatherWise.Models.OpenWeatherMap;

namespace WeatherWise;
class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<CurrentWeatherResponse, CurrentWeatherModel>().ConvertUsing(src => new CurrentWeatherModel()
        {
            CurrentDateTime = DateTimeOffset.FromUnixTimeSeconds(src.Dt).LocalDateTime,
            CurrentTemperature = src.Main.Temp,
            FeelsLike = src.Main.FeelsLike,
            Humidity = src.Main.Humidity,
            Pressure = src.Main.Pressure,
            Sunrise = DateTimeOffset.FromUnixTimeSeconds(src.Sys.Sunrise).LocalDateTime,
            Sunset = DateTimeOffset.FromUnixTimeSeconds(src.Sys.Sunset).LocalDateTime,
            Visibility = src.Visibility/1000.0,
            WeatherCondition = src.Weather[0].Main
        });

        CreateMap<ForecastWeatherResponse, ForecastWeatherModel>().ConvertUsing(src => new ForecastWeatherModel()
        {
            Forecasts = src.List.Select(x => new CurrentWeatherModel()
            {
                CurrentDateTime = DateTimeOffset.FromUnixTimeSeconds(x.Dt).LocalDateTime,
                CurrentTemperature = x.Main.Temp,
                FeelsLike = x.Main.FeelsLike,
                Humidity = x.Main.Humidity,
                Pressure = x.Main.Pressure,
                Visibility = x.Visibility / 1000.0,
                WeatherCondition = x.Weather[0].Main
            }).ToList()
        });
    }
}
