using FlightApp.ViewModels;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainMenuPassenger : Page
    {

        public MainMenuPassengerViewModel ViewModel = new MainMenuPassengerViewModel();
        public MainMenuPassenger()
        {
            InitializeComponent();
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                ContentFrame.Navigate(typeof(FlightInfoPage));
                navigationViewPassenger.Header = "Settings";
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag.ToString())
                {
                    case "FlightInfo":
                        ContentFrame.Navigate(typeof(FlightInfoPage));
                        navigationViewPassenger.Header = "FlightInfo";
                        break;
                    case "Shop":
                        ContentFrame.Navigate(typeof(FlightInfoPage));
                        navigationViewPassenger.Header = "Shop";
                        break;
                    case "Music":
                        ContentFrame.Navigate(typeof(FlightInfoPage));
                        navigationViewPassenger.Header = "Music";
                        break;
                    case "Film":
                        ContentFrame.Navigate(typeof(FlightInfoPage));
                        navigationViewPassenger.Header = "Film";
                        break;
                }
            }
        }


    }
}
