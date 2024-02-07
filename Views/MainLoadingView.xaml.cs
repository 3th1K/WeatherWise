using WeatherWise.ViewModels;

namespace WeatherWise.Views;

public partial class MainLoadingView : ContentPage
{

    public MainLoadingView(MainLoadingViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    
}
