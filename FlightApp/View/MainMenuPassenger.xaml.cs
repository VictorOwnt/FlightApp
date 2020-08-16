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

        public MainMenuPassengerViewModel ViewModel { get; set; }
        public MainMenuPassenger()
        {
            InitializeComponent();
            ViewModel = new MainMenuPassengerViewModel();
            // Is dit wel nodig? start standaar op flightinfo en boel werkt niet met dit erbij :p 
            // navigationViewPassengerMenu.SelectedItem = navigationViewPassengerMenu.MenuItems[0]; // Set to flight info
        }

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
    }
}
