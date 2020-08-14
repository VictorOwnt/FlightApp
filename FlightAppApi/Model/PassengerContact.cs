using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public class PassengerContact
    {
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }

        public int ContactId { get; set; }
        public Passenger Contact { get; set; }

        public string RoomName { get; set; }
        public List<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();
    }
}
