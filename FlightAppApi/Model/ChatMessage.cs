using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public class ChatMessage
    {
        public int ChatMessageId { get; set; }
        public string Message { get; set; }
        public string Author { get; set; } //name of the author of the message
        public ChatMessage() // EF default ctor
        {

        }
        public ChatMessage(string message, string author)
        {
            Message = message;
            Author = author;
        }
    }
}
