using FlightApp.DataService;
using FlightApp.Models;
using FlightApp.Util;
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
            try
            {
                Flight = await flightService.GetFlightAsync();
            }
            catch
            {
                await DialogService.ShowDefaultErrorMessageAsync();
            }

        }
    }
}
