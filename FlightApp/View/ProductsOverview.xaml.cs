using FlightApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class ProductsOverview : Page
    {
        private ObservableCollection<Product> Products;
        public ProductsOverview()
        {
            InitializeComponent();
            GetProducts();

        }

        private async void GetProducts()
        {
            ApplicationDataContainer LocalSettings = ApplicationData.Current.LocalSettings;
            string token = LocalSettings.Values["Token"] as string;
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Uri uri = new Uri("http://localhost:5000/api/product/category=food");

            var json = await httpClient.GetStringAsync(uri);

            var products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(json);
            Products = products;
        }
    }
}
