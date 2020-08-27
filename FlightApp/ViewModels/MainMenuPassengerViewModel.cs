using Microsoft.AspNetCore.SignalR.Client;
using Prism.Mvvm;
using System;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace FlightApp.ViewModels
{
    public class MainMenuPassengerViewModel : BindableBase
    {
        #region properties & fields
        private HubConnection hubConnection;
        private bool _isConnected;

        public bool IsConnected
        {
            get { return _isConnected; }
            set { SetProperty(ref _isConnected, value); }
        }
        #endregion

        #region methods
        public MainMenuPassengerViewModel()
        {
            IsConnected = false;
            hubConnection = new HubConnectionBuilder().WithUrl($"http://localhost:5000/announcementhub").Build();

            hubConnection.On<string, string>("ReceiveNotification", (title, content) =>
            {
                ShowToastNotification(title, content);
            });
        }

        public async void Connect(string passengerEmail)
        {
            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("JoinNotificationRoom", passengerEmail);

            IsConnected = true;
        }

        public async Task Disconnect()
        {
            await hubConnection.StopAsync();
            IsConnected = false;
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
        #endregion
    }
}
