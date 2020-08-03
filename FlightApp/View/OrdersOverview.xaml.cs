using FlightApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrdersOverview : Page
    {
        OrdersOverviewViewModel ViewModel;
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

        private void Deliver_Order_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
