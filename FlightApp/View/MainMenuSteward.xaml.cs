using Windows.Storage;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainMenuSteward : Page
    {
        public MainMenuSteward()
        {
            this.InitializeComponent();
            navigationViewStewardMenu.SelectedItem = navigationViewStewardMenu.MenuItems[0]; // Set to View orders
        }

        private void NavigationViewStewardMenu_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;

            switch (item.Tag.ToString())
            {
                case "ChangeSeatsView":
                    PageFrame.Navigate(typeof(ChangeSeatsView));
                    break;
                case "OrdersOverview":
                    PageFrame.Navigate(typeof(OrdersOverview));
                    break;
                case "DiscountView":
                    PageFrame.Navigate(typeof(DiscountView));
                    break;
                case "Notification":
                    PageFrame.Navigate(typeof(SendAnnouncementView));
                    break;
                case "Logout":
                    Frame.Navigate(typeof(MainPage));
                    ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
                    localSettings.Values["Token"] = string.Empty;
                    break;
            }

        }
    }
}
