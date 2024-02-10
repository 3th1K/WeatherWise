using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherWise.Models;

namespace WeatherWise.Interfaces;
public interface IOpenWeatherMapService : IWeatherService
{
    Task<MainGeolocationModel> GetGeolocationAsync(double lat, double lon);
}
