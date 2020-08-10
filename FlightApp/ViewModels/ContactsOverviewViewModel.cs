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
    public class ContactsOverviewViewModel : BindableBase
    {
        private IEnumerable<Passenger> _contacts;
        public IEnumerable<Passenger> Contacts
        {
            get { return _contacts; }
            set { SetProperty(ref _contacts, value); }
        }

        private readonly PassengerService passengerService = new PassengerService();

        public ContactsOverviewViewModel()
        {
            SetContacts();
        }
        public async void SetContacts()
        {
            Contacts = await passengerService.GetContactsOfLoggedInPassenger();
        }
    }
}
