using WeatherWise.Views;

namespace WeatherWise
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainWeatherView), typeof(MainWeatherView));
        }
    }
}
