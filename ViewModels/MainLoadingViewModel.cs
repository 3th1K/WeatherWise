using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using WeatherWise.Views;

namespace WeatherWise.ViewModels;
public partial class MainLoadingViewModel : ObservableObject
{
    private double Latitude { get; set; }
    private double Longitude { get; set; }

    private readonly IGeolocation _geolocation;
    public MainLoadingViewModel(IGeolocation geolocation)
    {
        _geolocation = geolocation;
        Task.Run(FetchGeoLocation);
    }

    public async Task FetchGeoLocation()
    {
        try
        {
            Location? location = await _geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                Debug.WriteLine($"Fetching Geo Coordinates");
                location = await _geolocation.GetLocationAsync(new GeolocationRequest()
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                });
            }
            Debug.WriteLine($"Geo Coordinates Acquired");
            Latitude = location.Latitude;
            Longitude = location.Longitude;
            Debug.WriteLine($"Latitude : {Latitude}\nLongitude : {Longitude}");

            //Shell.Current.Dispatcher.Dispatch(async () =>
            //{
            //    await Shell.Current.GoToAsync(nameof(MainWeatherView), true, new Dictionary<string, object>()
            //    {
            //        {"Latitude", Latitude},
            //        {"Longitude", Longitude}
            //    });
            //});

            Shell.Current.Dispatcher.Dispatch(async () =>
            {
                await Shell.Current.GoToAsync(nameof(MainWeatherView), true, new Dictionary<string, object>()
                {
                    { "Latitude", 22.4930602 },
                    { "Longitude", 87.95076913504252 }
                });
            });
        }
        catch (Exception ex)
        {
            Debug.Fail($"Exception : {ex.Message}");
        }
    }

}