using System;
using System.ComponentModel.DataAnnotations;

namespace FlightAppApi.Model
{
    public class Flight
    {
        [Required]
        public int FlightNr { get; set; } // this is the id

        [Required]
        public Airline Airline { get; set; }

        [Required]
        public Aircraft Aircraft { get; set; }

        [Required]
        public FlightDetail FlightDetail { get; set; }
    }
}
