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
        private IEnumerable<Flight> _flights;

        public IEnumerable<Flight> Flights
        {
            get { return _flights; }
            set { SetProperty(ref _flights, value); }
        }

        private readonly FlightService flightService = new FlightService();

        public FlightsInfoModel()
        {
            // TODO start with getAllFlights
        }

        public async void SetAllFlightsAsync()
        {
            Flights = await flightService.GetAllFlightsAsync();
        }
        
    }
}
