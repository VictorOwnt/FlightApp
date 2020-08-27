using FlightApp.Models;
using FlightApp.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrdersOverview : Page
    {
        public readonly OrdersOverviewViewModel ViewModel;
        public OrdersOverview()
        {
            InitializeComponent();
            ViewModel = new OrdersOverviewViewModel();

        }

        private void OrderMenu_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;
            switch (item.Tag.ToString().ToLower())
            {
                case "all":
                    ViewModel.GetPassengersWithAllOrders();
                    break;
                case "deliver":
                    ViewModel.GetPassengerWithFilteredOrders(false);

                    break;
                case "delivered":
                    ViewModel.GetPassengerWithFilteredOrders(true);

                    break;


            }
        }

        private async void Deliver_Order_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int orderId = ((Order)button.DataContext).OrderId;

            NavigationViewItem item = OrderMenu.SelectedItem as NavigationViewItem;

            await ViewModel.DeliverOrderAsync(orderId);

            switch (item.Tag.ToString().ToLower())
            {
                case "all":
                    ViewModel.GetPassengersWithAllOrders();
                    break;
                case "deliver":
                    ViewModel.GetPassengerWithFilteredOrders(false);
                    break;
                case "delivered":
                    ViewModel.GetPassengerWithFilteredOrders(true);
                    break;


            }
        }
    }
}
