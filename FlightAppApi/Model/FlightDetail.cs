using System;
using System.ComponentModel.DataAnnotations;

namespace FlightAppApi.Model
{
    public class FlightDetail
    {
        [Required]
        public int Id { get; set; }

        public int DepartingAirportId { get; set; }

        [Required]
        public Airport DepartingAirport { get; set; }

        [Required]
        public DateTime DepartingTime { get; set; }

        public int ArrivalAirportId { get; set; }

        [Required]
        public Airport ArrivalAirport { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }
    }
}
