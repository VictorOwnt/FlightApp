using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Models
{
    public class FlightDetail
    {
        public int Id;

        public Airport DepartingAirport;

        public DateTime DepartingTime;

        public Airport ArrivalAirport;

        public DateTime ArrivalTime;
    }
}
