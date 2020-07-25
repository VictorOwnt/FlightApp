using FlightApp.DTO;
using FlightApp.View;
using Newtonsoft.Json;
using System;

using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;
using Windows.Web.Http.Headers;


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
            InitializeComponent();
        }


        private async void Log_In(object sender, RoutedEventArgs e)
        {
            LoginDTO login = new LoginDTO(Email.Text, Password.Password);
            var loginJson = JsonConvert.SerializeObject(login);
            HttpClient client = new HttpClient();

            var res = await client.PostAsync(new Uri("http://localhost:5000/api/account/"), new HttpStringContent(loginJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
            var token = await res.Content.ReadAsStringAsync();
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values["Token"] = token;
            client.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", token);

            res = await client.GetAsync(new Uri("http://localhost:5000/api/Person"));
            string value = await res.Content.ReadAsStringAsync();
            bool isSteward = Convert.ToBoolean(value);
            if (isSteward)
            {
                Frame.Navigate(typeof(MainMenuSteward));
            }
            else
            {
                Frame.Navigate(typeof(MainMenuPassenger));
            }


        }


    }
}
