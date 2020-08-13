using FlightApp.DataService;
using FlightApp.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.ViewModels
{
    public class ChatViewModel : BindableBase
    {
        #region properties & fields
        private ObservableCollection<ChatMessage> _messages;

        public ObservableCollection<ChatMessage> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }
        private readonly PassengerService passengerService = new PassengerService();

        private bool _isConnected;

        public bool IsConnected
        {
            get { return _isConnected; }
            set { SetProperty(ref _isConnected, value); }
        }

        private HubConnection hubConnection;

        #endregion
        #region methods
        public ChatViewModel()
        {
            Messages = new ObservableCollection<ChatMessage>();
            IsConnected = false;
            hubConnection = new HubConnectionBuilder().WithUrl($"http://localhost:5000/chatHub").Build();
            Connect();

            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Messages.Add(new ChatMessage() { Author = user, Message = message });
            });
        }

        public async void Connect()
        {
            await hubConnection.StartAsync();
            //await hubConnection.InvokeAsync("JoinChat", "TO REPLACE");

            IsConnected = true;
        }

        public async Task SendMessage(string passengerEmail, string contactEmail, string message)
        {
            await hubConnection.InvokeAsync("SendMessage", passengerEmail, contactEmail, message);
        }

        public async Task Disconnect()
        {
            //await hubConnection.InvokeAsync("LeaveChat", "TO REPLACE");
            await hubConnection.StopAsync();

            IsConnected = false;
        }

        public async void SetMessages(string contactEmail)
        {
            IEnumerable<ChatMessage> help = await passengerService.GetMessagesOfPassengerWithContact(contactEmail);
            foreach (ChatMessage message in help)
            {
                Messages.Add(message);
            }
        }
        #endregion
    }
}
