using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherWise.Models;

namespace WeatherWise.Interfaces;
public interface IWeatherService
{
    Task<CurrentWeatherModel> GetCurrentWeatherAsync(double lat, double lon);
    Task<ForecastWeatherModel> GetForecastWeatherAsync(double lat, double lon);
}
