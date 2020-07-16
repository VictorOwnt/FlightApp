using FlightApp.DataService;
using FlightApp.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.ViewModels
{
    public class MainMenuPassengerViewModel : BindableBase
    {
        private Passenger _passenger;
        public Passenger LoggedInPassenger
        {
            get { return _passenger; }
            set { SetProperty(ref _passenger, value); }
        }

        private readonly PassengerService PassengerService = new PassengerService();
        public MainMenuPassengerViewModel()
        {
            LoggedInPassenger = new Passenger();
            SetLoggedInPassenger();

        }

        private async void SetLoggedInPassenger()
        {
            LoggedInPassenger = await PassengerService.GetLoggedInPassengerAsync();

        }

    }
}
