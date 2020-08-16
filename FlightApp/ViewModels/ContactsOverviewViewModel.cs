using FlightApp.DataService;
using FlightApp.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.ViewModels
{
    public class ContactsOverviewViewModel : BindableBase
    {
        #region fields & properties
        private IEnumerable<Passenger> _contacts;
        public IEnumerable<Passenger> Contacts
        {
            get { return _contacts; }
            set { SetProperty(ref _contacts, value); }
        }
        private readonly PassengerService passengerService = new PassengerService();
        #endregion

        #region Methods        

        public ContactsOverviewViewModel()
        {
            SetContacts();
        }
        public async void SetContacts()
        {
            Contacts = await passengerService.GetContactsOfLoggedInPassenger();
        }


        #endregion
    }
}
