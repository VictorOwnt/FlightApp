using FlightApp.DataService;
using FlightApp.Models;
using FlightApp.Util;
using Microsoft.AspNetCore.SignalR.Client;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.ViewModels
{
    public class AnnouncementViewModel : BindableBase
    {
        public ObservableCollection<object> Passengers { get; set; } = new ObservableCollection<object>();

        private readonly StewardService stewardService = new StewardService();

        public AnnouncementViewModel()
        {
            GetAllPassengersAsync();
        }

        public async void GetAllPassengersAsync()
        {
            try
            {
                var passengers = await stewardService.GetAllPassengersAsync();
                Passengers.Add("All passengers");
                passengers.ToList().ForEach(p => Passengers.Add(p));
            }
            catch
            {
                await DialogService.ShowDefaultErrorMessageAsync();
            }
        }
    }
}
