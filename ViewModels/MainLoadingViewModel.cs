using CommunityToolkit.Mvvm.ComponentModel;
using WeatherWise.Views;

namespace WeatherWise.ViewModels;

public partial class MainLoadingViewModel : ObservableObject
{
    [ObservableProperty] private double latitude;
    [ObservableProperty] private double longitude;
    private readonly IGeolocation _geolocation;
    public MainLoadingViewModel(IGeolocation geolocation)
    {
        _geolocation = geolocation;
        FetchGeoLocation();
    }
    private async void FetchGeoLocation()
    {
        try
        {
            Location? location = await _geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await _geolocation.GetLocationAsync(new GeolocationRequest()
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                });
            }
            Latitude = location.Latitude;
            Longitude = location.Longitude;
            await Shell.Current.GoToAsync(nameof(MainWeatherView), true, new Dictionary<string, object>()
            {
                {"Latitude", Latitude},
                {"Longitude", Longitude}
            });
        }
        catch (Exception ex)
        {
            //
        }
    }

}

