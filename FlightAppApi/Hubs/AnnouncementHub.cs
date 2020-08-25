using FlightAppApi.Model;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Hubs
{
    public class AnnouncementHub : Hub
    {
        private readonly IPassengerRepository _passengerRepository;

        public AnnouncementHub(IPassengerRepository passengerRepo)
        {
            _passengerRepository = passengerRepo;
        }

        public Task JoinNotificationRoom(string passengerEmail)
        {
            Passenger passenger = _passengerRepository.GetPassengerByEmail(passengerEmail);
            if (passenger.NotificationRoom == null)
            {
                passenger.NotificationRoom = CreateNotificationRoomName(passenger.Email);
                _passengerRepository.SaveChanges();
            }

            return Groups.AddToGroupAsync(Context.ConnectionId, passenger.NotificationRoom);
        }

        public Task LeaveRoom(string passengerEmail)
        {

            return Groups.RemoveFromGroupAsync(Context.ConnectionId, CreateNotificationRoomName(passengerEmail));
        }

        public async Task SendNotification(string title, string content, string passengerEmail, bool isChecked)
        {
            Passenger passenger = _passengerRepository.GetPassengerByEmail(passengerEmail);
            if (isChecked)
            {
                await Clients.All.SendAsync("ReceiveNotification", title, content);
            }
            else if (passengerEmail != null)
            {
                await Clients.Group(passenger.NotificationRoom).SendAsync("ReceiveNotification", title, content);
            }

        }
        private string CreateNotificationRoomName(string passengerEmail)
        {
            int help = string.Compare(passengerEmail, "notification");
            if (help < 0)
            {
                return passengerEmail + "notification";
            }
            else
            {
                return "notification" + passengerEmail;
            }

        }
    }
}
