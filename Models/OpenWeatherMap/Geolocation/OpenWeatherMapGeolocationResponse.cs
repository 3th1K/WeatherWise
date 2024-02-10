using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherWise.Models.OpenWeatherMap.Geolocation;
public class OpenWeatherMapGeolocationResponse
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("local_names")]
    public LocalNames LocalNames { get; set; }

    [JsonPropertyName("lat")]
    public double Lat { get; set; }

    [JsonPropertyName("lon")]
    public double Lon { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }
}


