using FlightApp.DTO;
using FlightApp.Models;
using FlightApp.Util;
using FlightApp.View;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using Windows.Storage;
using Windows.UI.Notifications;
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
        private readonly HttpClient client = new HttpClient();
        private HubConnection hubConnection;

        public MainPage()
        {
            InitializeComponent();
        }


        private async void Log_In(object sender, RoutedEventArgs e)
        {
            LoginDTO login = new LoginDTO(Email.Text, Password.Password);
            var loginJson = JsonConvert.SerializeObject(login);

            try
            {
                var res = await client.PostAsync(new Uri("http://localhost:5000/api/account/"), new HttpStringContent(loginJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
                var token = await res.Content.ReadAsStringAsync();
                ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
                localSettings.Values["Token"] = token;
                client.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", token);

                hubConnection = new HubConnectionBuilder().WithUrl($"http://localhost:5000/announcementHub").Build();

                res = await client.GetAsync(new Uri("http://localhost:5000/api/Person"));
                string value = await res.Content.ReadAsStringAsync();
                bool isSteward = Convert.ToBoolean(value);
                if (isSteward)
                {
                    Frame.Navigate(typeof(MainMenuSteward));
                }
                else
                {
                    hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
                    {
                        string[] s = message.Split(',');
                        ShowToastNotification(s[0], s[1]);
                    });
                    Frame.Navigate(typeof(MainMenuPassenger));
                }  
            }
            catch
            {
                await DialogService.ShowDefaultErrorMessageAsync();
            }
        }

        private void ShowToastNotification(string title, string content)
        {
            ToastNotifier toastNotifier = ToastNotificationManager.CreateToastNotifier();
            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            Windows.Data.Xml.Dom.XmlNodeList toastNodeList = toastXml.GetElementsByTagName("text");
            toastNodeList.Item(0).AppendChild(toastXml.CreateTextNode(title));
            toastNodeList.Item(1).AppendChild(toastXml.CreateTextNode(content));
            Windows.Data.Xml.Dom.IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            Windows.Data.Xml.Dom.XmlElement audio = toastXml.CreateElement("audio");
            audio.SetAttribute("src", "ms-winsoundevent:Notification.SMS");

            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = DateTime.Now.AddSeconds(4);
            toastNotifier.Show(toast);
        }
    }
}
