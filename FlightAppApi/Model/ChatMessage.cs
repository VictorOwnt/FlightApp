using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public class ChatMessage
    {
        public int ChatMessageId { get; set; }
        public string content { get; set; }
        public int PassengerId { get; set; }
    }
}
