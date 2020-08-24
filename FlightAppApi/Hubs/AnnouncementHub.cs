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
        private readonly IStewardRepository _stewardRepository;

        public AnnouncementHub(IPassengerRepository passengerRepository, IStewardRepository stewardRepository)
        {
            _passengerRepository = passengerRepository;
            _stewardRepository = stewardRepository;
        }

        public async Task SendAnnouncement(string title, string content, string receiver)
        {
            await Clients.All.SendAsync("ReceiveAnnouncement", receiver, title + ',' + content);
        }
    }
}
