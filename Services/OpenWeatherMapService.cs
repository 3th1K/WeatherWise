using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using WeatherWise.Interfaces;
using WeatherWise.Models;
using WeatherWise.Models.OpenWeatherMap;
using WeatherWise.Models.OpenWeatherMap.Geolocation;

namespace WeatherWise.Services;
class OpenWeatherMapService : IOpenWeatherMapService
{
    private HttpClient _weatherClient;
    private HttpClient _geolocationClient;
    private string API_KEY = "8bf8444de5d051019fe60c07a7f9ab11";

    public OpenWeatherMapService(IHttpClientFactory clientFactory)
    {
        _weatherClient = clientFactory.CreateClient("OpenWeatherMapApiClient");
        _geolocationClient = clientFactory.CreateClient("OpenWeatherMapGeolocationApiClient");
    }

    public async Task<MainWeatherModel> GetCurrentWeatherAsync(double lat, double lon)
    {
        try
        {
            HttpResponseMessage response = await _weatherClient.GetAsync($"weather?lat={lat}&lon={lon}&appid={API_KEY}");
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                CurrentWeatherResponse responseObj = JsonSerializer.Deserialize<CurrentWeatherResponse>(responseString);
                var x = new MainWeatherModel() { Tempareture = responseObj.Main.Temp };
            }
            else
            {

            }


        }
        catch (Exception ex)
        {
            //
        }

        return new MainWeatherModel();
    }

    public async Task<MainGeolocationModel> GetGeolocationAsync(double lat, double lon)
    {
        try
        {
            HttpResponseMessage response = await _geolocationClient.GetAsync($"reverse?lat={lat}&lon={lon}&limit=1&appid={API_KEY}");
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                OpenWeatherMapGeolocationResponse responseObj = JsonSerializer.Deserialize<List<OpenWeatherMapGeolocationResponse>>(responseString)[0];
                var geolocation = new MainGeolocationModel()
                {
                    Latitude = responseObj.Lat,
                    Longitude = responseObj.Lon,
                    Country = responseObj.Country,
                    State = responseObj.State,
                    Name = responseObj.Name
                };
                return geolocation;
            }
            else
            {

            }


        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
        }

        return new MainGeolocationModel();
    }
}
