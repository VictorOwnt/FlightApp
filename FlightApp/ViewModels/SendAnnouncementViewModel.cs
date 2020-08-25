using FlightApp.DataService;
using FlightApp.Models;
using FlightApp.Util;
using Prism.Mvvm;
using System;
using System.Collections.Generic;

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

        private readonly StewardService stewardService = new StewardService();

        public SendAnnouncementViewModel()
        {
            GetAllPassengersAsync();

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

        public void SendAnnouncement(string text1, string text2, Passenger selectedPassenger, bool? isChecked)
        {
            throw new NotImplementedException();
        }
    }
}
