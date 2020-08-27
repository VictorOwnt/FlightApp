using FlightApp.DataService;
using FlightApp.Models;
using FlightApp.Util;
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
            try
            {
                Passengers = await stewardService.GetPassengersIncludeOrders();
            }
            catch
            {
                await DialogService.ShowDefaultErrorMessageAsync();
            }

        }

        public async void GetPassengerWithFilteredOrders(bool delivery)
        {
            try
            {
                Passengers = await stewardService.GetPassengersWithFilteredOrders(delivery);
            }
            catch
            {
                await DialogService.ShowDefaultErrorMessageAsync();
            }

        }

        public async Task DeliverOrderAsync(int orderId)
        {
            try
            {
                await stewardService.DeliverOrderAsync(orderId);
            }
            catch
            {
                await DialogService.ShowCustomMessageAsync("Something went wrong, could not deliver this order. Please check your internet connection and try again." ,"Error delivering order");
            }

        }
    }
}
