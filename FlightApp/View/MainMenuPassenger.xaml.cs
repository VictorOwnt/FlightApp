using FlightApp.Models;
using FlightApp.ViewModels;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainMenuPassenger : Page
    {


        public MainMenuPassenger()
        {
            InitializeComponent();

            navigationViewPassengerMenu.SelectedItem = navigationViewPassengerMenu.MenuItems[1]; // Set to flight info
            if (Instance is null)
            {
                Instance = this;
            }
        }

        public static MainMenuPassenger Instance { get; set; }
        private void NavigationViewPassenger_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
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
                    break;
                case "Entertainment":
                    ContentFrame.Navigate(typeof(EntertainmentView));
                    break;
                case "Logout":
                    Frame.Navigate(typeof(MainPage));
                    ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
                    localSettings.Values["Token"] = string.Empty;
                    break;
            }
        }
        public void NavigateToMoviePlayer(Movie movie)
        {
            ContentFrame.Navigate(typeof(MoviePlayerView), movie, new EntranceNavigationTransitionInfo());
        }
    }
}