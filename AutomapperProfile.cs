using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
