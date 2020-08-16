using FlightApp.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainMenuPassenger : Page
    {

        public MainMenuPassengerViewModel ViewModel { get; set; }
        public MainMenuPassenger()
        {
            InitializeComponent();
            ViewModel = new MainMenuPassengerViewModel();
            // Is dit wel nodig? start standaar op flightinfo en boel werkt niet met dit erbij :p 
            // navigationViewPassengerMenu.SelectedItem = navigationViewPassengerMenu.MenuItems[0]; // Set to flight info
        }
            if (_instance is null) _instance = this;
        }

        private static MainMenuPassenger _instance;
        public static MainMenuPassenger Instance { get { return _instance; } }
        private void NavigationViewPassenger_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                //Settingspage needed?
                // ContentFrame.Navigate(typeof(FlightInfoPage));
                // navigationViewPassengerMenu.Header = "Settings";
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag.ToString())
                {
                    case "ProductsOverview":
                        ContentFrame.Navigate(typeof(ProductsOverview));
                        break;
                    case "ContactsOverview":
                        ContentFrame.Navigate(typeof(ContactsOverview));
                        break;
                    case "PassengerOrdersOverview":
                        ContentFrame.Navigate(typeof(PassengerOrdersOverview));
                        break;
                    case "FlightInfo":
                        ContentFrame.Navigate(typeof(FlightInfoPage));
                        // navigationViewPassengerMenu.Header = "FlightInfo";
                        break;
                    case "Music":
                        ContentFrame.Navigate(typeof(FlightInfoPage));
                        // navigationViewPassengerMenu.Header = "Music";
                        break;
                    case "Film":
                        ContentFrame.Navigate(typeof(FlightInfoPage));
                        // navigationViewPassengerMenu.Header = "Film";
                        break;
                }
            }
        }
        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                ContentFrame.Navigate(typeof(EntertainmentView));
                navigationViewPassenger.Header = "Settings";
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag.ToString())
                {
                    case "FlightInfo":
                        ContentFrame.Navigate(typeof(EntertainmentView));
                        // navigationViewPassenger.Header = "FlightInfo";
                        break;
                    case "Shop":
                        ContentFrame.Navigate(typeof(EntertainmentView));
                        // navigationViewPassenger.Header = "Shop";
                        break;

                    case "Entertainment":
                        ContentFrame.Navigate(typeof(EntertainmentView));
                        // navigationViewPassenger.Header = "Music";
                        break;
                }
            }
        }
        public  void NavigateToMoviePlayer(Movie movie)
        {
            ContentFrame.Navigate(typeof(MoviePlayerView), movie, new EntranceNavigationTransitionInfo());
            navigationViewPassenger.Header = "Movie Player";
        }
    }
}