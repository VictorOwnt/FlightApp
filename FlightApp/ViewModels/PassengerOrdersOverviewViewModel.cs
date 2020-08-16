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
    public class PassengerOrdersOverviewViewModel : BindableBase
    {
        private Passenger _passenger;
        public Passenger Passenger
        {
            get { return _passenger; }
            set { SetProperty(ref _passenger, value); }
        }

        private readonly PassengerService passengerService = new PassengerService();

        public PassengerOrdersOverviewViewModel()
        {
            GetPassengersWithAllOrders();
        }
        public async void GetPassengersWithAllOrders()
        {
            Passenger = await passengerService.GetPassengerIncludeOrders();
        }
    }
}
