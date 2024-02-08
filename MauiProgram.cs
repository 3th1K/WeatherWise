using Microsoft.Extensions.Logging;
using WeatherWise.Models;
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
            //dependency
            builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
            builder.Services.AddSingleton<MainLoadingView>();
            builder.Services.AddSingleton<MainLoadingViewModel>();
            builder.Services.AddSingleton<MainWeatherView>();
            builder.Services.AddSingleton<MainWeatherViewModel>();
            builder.Services.AddSingleton<MainWeatherModel>();
            return builder.Build();
        }
    }
}
