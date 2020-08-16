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
    public class ChangeSeatsViewModel : BindableBase
    {
        //Replace Passenger 1 + 2 with list?
        private Passenger _passenger1;
        public Passenger Passenger1
        {
            get { return _passenger1; }
            set { SetProperty(ref _passenger1, value); }
        }

        private Passenger _passenger2;
        public Passenger Passenger2
        {
            get { return _passenger2; }
            set { SetProperty(ref _passenger2, value); }
        }
        private readonly StewardService StewardService = new StewardService();

        public async void ChangeSeatsAsync(int seat1, int seat2)
        {
            List<Passenger> passengers = await StewardService.ChangeSeats(seat1, seat2);
            Passenger1 = passengers[0];
            Passenger2 = passengers[1];
        }
    }
}
