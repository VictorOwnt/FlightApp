using FlightApp.Models;
using FlightApp.ViewModels;
using System;
using System.Windows.Input;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FlightInfoPage : Page
    {
        public FlightsInfoModel ViewModel;
        public FlightInfoPage()
        {
            this.InitializeComponent();
            ViewModel = new FlightsInfoModel();
        }

        private async void GetWeatherForecastAsync(object sender, RoutedEventArgs e)
        {
            Location location = ((HyperlinkButton)sender).Tag as Location;
            await Launcher.LaunchUriAsync(new Uri("msnweather://forecast?la=" + location.Latitude + "&lo=" + location.Longitude));
        }
    }
}
