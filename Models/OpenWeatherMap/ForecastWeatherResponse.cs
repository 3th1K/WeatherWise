using System.Text.Json.Serialization;

namespace WeatherWise.Models.OpenWeatherMap;

public class ForecastWeatherResponse
{
    [JsonPropertyName("cod")]
    public string Cod { get; set; }

    [JsonPropertyName("message")]
    public int Message { get; set; }

    [JsonPropertyName("cnt")]
    public int Cnt { get; set; }

    [JsonPropertyName("list")]
    public List<ForecastList> List { get; set; }

    [JsonPropertyName("city")]
    public City City { get; set; }
}

public class ForecastList
{
    [JsonPropertyName("dt")]
    public int Dt { get; set; }

    [JsonPropertyName("main")]
    public Main Main { get; set; }

    [JsonPropertyName("weather")]
    public List<Weather> Weather { get; set; }

    [JsonPropertyName("clouds")]
    public Clouds Clouds { get; set; }

    [JsonPropertyName("wind")]
    public Wind Wind { get; set; }

    [JsonPropertyName("visibility")]
    public int Visibility { get; set; }

    [JsonPropertyName("pop")]
    public double Pop { get; set; }

    [JsonPropertyName("rain")]
    public Rain Rain { get; set; }

    [JsonPropertyName("sys")]
    public ForecastSys Sys { get; set; }

    [JsonPropertyName("dt_txt")]
    public string DtTxt { get; set; }
}
public class ForecastSys
{
    [JsonPropertyName("pod")]
    public string Pod { get; set; }
}
public class City
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("coord")]
    public Coord Coord { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("population")]
    public int Population { get; set; }

    [JsonPropertyName("timezone")]
    public int Timezone { get; set; }

    [JsonPropertyName("sunrise")]
    public int Sunrise { get; set; }

    [JsonPropertyName("sunset")]
    public int Sunset { get; set; }
}

public class Rain
{
    [JsonPropertyName("3h")]
    public double _3h { get; set; }
}