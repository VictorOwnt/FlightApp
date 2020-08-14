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
        public Task JoinRoom(string passengerEmail, string contactEmail)
        {
            PassengerContact pc = GetCurrentPassengerContact(passengerEmail, contactEmail);
            if (pc.RoomName == null)
            {
                pc.RoomName = CreateRoomName(passengerEmail, contactEmail);
                _passengerRepository.SaveChanges();
            }

            return Groups.AddToGroupAsync(Context.ConnectionId, pc.RoomName);
        }
        public Task LeaveRoom(string passengerEmail, string contactEmail)
        {

            return Groups.RemoveFromGroupAsync(Context.ConnectionId, CreateRoomName(passengerEmail, contactEmail));
        }

        public async Task SendMessage(string passengerEmail, string contactEmail, string message)
        {
            PassengerContact pc = GetCurrentPassengerContact(passengerEmail, contactEmail);
            pc.ChatMessages.Add(new ChatMessage(message, pc.Passenger.FirstName + " " + pc.Passenger.LastName));
            _passengerRepository.SaveChanges();

            await Clients.Group(pc.RoomName).SendAsync("ReceiveMessage", pc.Passenger.Name, message);
        }

        private PassengerContact GetCurrentPassengerContact(string passengerEmail, string contactEmail)
        {
            Passenger passenger = _passengerRepository.GetPassengerByEmailWithContacts(passengerEmail);
            Passenger contact = _passengerRepository.GetPassengerByEmailWithContacts(contactEmail);
            PassengerContact pc = passenger.Contacts.SingleOrDefault(c => c.Contact == contact);
            return pc;
        }

        private string CreateRoomName(string passengerEmail, string contactEmail)
        {
            int help = string.Compare(passengerEmail, contactEmail);
            if (help < 0)
            {
                return passengerEmail + contactEmail;
            }
            else
            {
                return contactEmail + passengerEmail;
            }

        }
    }
}
