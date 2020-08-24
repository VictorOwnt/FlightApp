using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public class Announcement
    {
        public int Id { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(255)]
        public string Content { get; set; }

        /*
        [Required]
        public Steward Sender { get; set; }

        public Passenger Receiver { get; set; } = null;
        // if receiver is null everyone?

        public Announcement()
        {
            Timestamp = DateTime.Now;
        }
        */
    }
}
