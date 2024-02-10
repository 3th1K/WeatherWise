using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;
using WeatherWise.Interfaces;
using WeatherWise.Models;
using WeatherWise.Services;
using WeatherWise.ViewModels;
using WeatherWise.Views;

namespace WeatherWise
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            //geolocation dependency
            builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);

            //views dependency
            builder.Services.AddSingleton<MainLoadingView>();
            builder.Services.AddSingleton<MainWeatherView>();

            //model dependency
            builder.Services.AddSingleton<MainWeatherModel>();
            builder.Services.AddSingleton<MainGeolocationModel>();

            //view model dependency
            builder.Services.AddSingleton<MainLoadingViewModel>();
            builder.Services.AddSingleton<MainWeatherViewModel>();

            //api services dependency
            builder.Services.AddSingleton<IOpenWeatherMapService, OpenWeatherMapService>();

            //api clients
            builder.Services.AddHttpClient("OpenWeatherMapApiClient", client =>
            {
                client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
            });
            builder.Services.AddHttpClient("OpenWeatherMapGeolocationApiClient", client =>
            {
                client.BaseAddress = new Uri("https://api.openweathermap.org/geo/1.0/");
            });
            return builder.Build();
        }
    }
}
