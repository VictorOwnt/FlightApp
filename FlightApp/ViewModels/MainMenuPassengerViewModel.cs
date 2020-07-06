using FlightApp.DataService;
using FlightApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.ViewModels
{
    public class MainMenuPassengerViewModel
    {
        public Passenger LoggedInPassenger { get; set; }
        private readonly PassengerService PassengerService = new PassengerService();
        public MainMenuPassengerViewModel()
        {
            SetLoggedInPassenger();

        }

        private async void SetLoggedInPassenger()
        {
            var passenger = await PassengerService.GetLoggedInPassengerAsync();
            LoggedInPassenger = passenger;

        }
    }
}
