using FlightApp.DataService;
using FlightApp.Models;
using Prism.Mvvm;
using System;
using Windows.System;

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
            SetFlightAsync();
        }

        public async void SetFlightAsync()
        {
            Flight = await flightService.GetFlightAsync();
        }
    }
}
