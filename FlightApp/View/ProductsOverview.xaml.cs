using FlightApp.Models;
using FlightApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductsOverview : Page
    {

        public ProductsOverviewViewModel ViewModel;
        public ProductsOverview()
        {
            InitializeComponent();
            ViewModel = new ProductsOverviewViewModel();
            ShoppingMenu.SelectedItem = ShoppingMenu.MenuItems.First();

        }

        private void ShoppingMenu_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;
            switch (item.Tag.ToString().ToLower())
            {
                case "food":
                    ViewModel.SetProductsOfCategoryAsync(item.Tag.ToString());
                    break;
                case "drinks":
                    ViewModel.SetProductsOfCategoryAsync(item.Tag.ToString());
                    break;
                case "all":
                    ViewModel.SetAllProductsAsync();
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

        }



        private void Order_Products(object sender, RoutedEventArgs e)
        {
            List<Product> products = new List<Product>();
            foreach (var item in Products_GridView.SelectedItems)
            {
                products.Add(item as Product);
            }

            ViewModel.OrderProducts(products);
            Products_GridView.SelectedItems.Clear();
        }

        private void Products_GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Product selectedProduct = e.ClickedItem as Product;
            ViewModel.ChangeSelectedProducts(selectedProduct);
        }
    }
}
