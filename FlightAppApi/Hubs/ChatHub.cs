using FlightAppApi.Data;
using FlightAppApi.Model;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IPassengerRepository _passengerRepository;

        public ChatHub(IPassengerRepository passengerRepo)
        {
            _passengerRepository = passengerRepo;
        }
        /*public async Task JoinChat(string user)
        {
            await Clients.All.SendAsync("JoinChat", user);
        }

        public async Task LeaveChat(string user)
        {
            await Clients.All.SendAsync("LeaveChat", user);
        }*/

        public async Task SendMessage(string passengerEmail, string contactEmail, string message)
        {

            Passenger passenger = _passengerRepository.GetPassengerByEmailWithContacts(passengerEmail);
            Passenger contact = _passengerRepository.GetPassengerByEmailWithContacts(contactEmail);
            PassengerContact pc = passenger.Contacts.SingleOrDefault(c => c.Contact == contact);
            pc.ChatMessages.Add(new ChatMessage(message, passenger.FirstName + " " + passenger.LastName));
            _passengerRepository.SaveChanges();

            await Clients.All.SendAsync("ReceiveMessage", passenger.Name, message);
        }
    }
}
