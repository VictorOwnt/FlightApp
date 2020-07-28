using FlightApp.DataService;
using FlightApp.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.ViewModels
{
    public class FlightsInfoModel : BindableBase
    {
        private Flight _flight;

        public Flight Flight
        {
            get { return _flight; }
            set { SetProperty(ref _flight, value); }
        }

        private readonly FlightService flightService = new FlightService();

        public FlightsInfoModel()
        {
            // TODO start with getAllFlights
        }

        public async void SetFlightAsync()
        {
            Flight = await flightService.GetFlightAsync();
        }
        
    }
}
