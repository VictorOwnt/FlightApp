using FlightApp.DataService;
using FlightApp.Models;
using FlightApp.Util;
using Microsoft.AspNetCore.SignalR.Client;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightApp.ViewModels
{
    public class SendAnnouncementViewModel : BindableBase
    {

        private IEnumerable<Passenger> _passengers;
        public IEnumerable<Passenger> Passengers
        {
            get { return _passengers; }
            set { SetProperty(ref _passengers, value); }
        }

        private bool _isConnected;

        public bool IsConnected
        {
            get { return _isConnected; }
            set { SetProperty(ref _isConnected, value); }
        }

        private HubConnection hubConnection;

        private readonly StewardService stewardService = new StewardService();

        public SendAnnouncementViewModel()
        {
            GetAllPassengersAsync();

            IsConnected = false;
            hubConnection = new HubConnectionBuilder().WithUrl($"http://localhost:5000/announcementhub").Build();

        }

        public async void GetAllPassengersAsync()
        {
            try
            {
                Passengers = await stewardService.GetAllPassengersAsync();
            }
            catch
            {
                await DialogService.ShowDefaultErrorMessageAsync();
            }
        }

        public async void SendAnnouncementAsync(string title, string content, Passenger selectedPassenger, bool isChecked)
        {
            await hubConnection.InvokeAsync("SendNotification", title, content, selectedPassenger.Email, isChecked);
        }

        public async void Connect()
        {
            await hubConnection.StartAsync();
            IsConnected = true;
        }
        public async Task Disconnect()
        {
            await hubConnection.StopAsync();
            IsConnected = false;
        }
    }
}
