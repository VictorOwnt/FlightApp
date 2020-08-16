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
    public class OrdersOverviewViewModel : BindableBase
    {
        private IEnumerable<Passenger> _passengers;
        public IEnumerable<Passenger> Passengers
        {
            get { return _passengers; }
            set { SetProperty(ref _passengers, value); }
        }

        private readonly StewardService stewardService = new StewardService();

        public async void GetPassengersWithAllOrders()
        {
            Passengers = await stewardService.GetPassengersIncludeOrders();
        }

        public async void GetPassengerWithFilteredOrders(bool delivery)
        {
            Passengers = await stewardService.GetPassengersWithFilteredOrders(delivery);
        }

        public async Task DeliverOrderAsync(int orderId)
        {
            await stewardService.DeliverOrderAsync(orderId);
        }
    }
}
