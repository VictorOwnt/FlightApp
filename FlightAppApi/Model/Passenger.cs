using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public class Passenger : Person
    {
        [Required]
        public int SeatNumber { get; set; }
    }
}
