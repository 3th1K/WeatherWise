using System.Text.Json.Serialization;

namespace WeatherWise.Models.OpenWeatherMap;

public class Clouds
{
    [JsonPropertyName("all")]
    public int? All { get; set; }
}


