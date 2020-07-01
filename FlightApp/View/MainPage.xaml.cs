using FlightApp.DTO;
using FlightApp.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FlightApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>    
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        private async void Log_In(object sender, RoutedEventArgs e)
        {
            LoginDTO login = new LoginDTO(Email.Text, Password.Password);
            var loginJson = JsonConvert.SerializeObject(login);

            HttpClient client = new HttpClient();
            var res = await client.PostAsync("http://localhost:5000/api/account/", new StringContent(loginJson, System.Text.Encoding.UTF8, "application/json"));
            var token = await res.Content.ReadAsStringAsync();
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            Object value = localSettings.Values["Token"] = token;
            string help = "";
            Frame.Navigate(typeof(MainMenu));
        }


    }
}
