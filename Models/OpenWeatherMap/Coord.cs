using System.Text.Json.Serialization;

namespace WeatherWise.Models.OpenWeatherMap;

public class Coord
{
    [JsonPropertyName("lon")]
    public double? Lon { get; set; }

    [JsonPropertyName("lat")]
    public double? Lat { get; set; }
}


