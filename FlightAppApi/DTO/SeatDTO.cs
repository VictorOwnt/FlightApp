using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.DTO
{
    public class SeatDTO
    {
        public int SeatNumber1 { get; set; }
        public int SeatNumber2 { get; set; }
        public SeatDTO(int seatNumber1, int seatNumber2)
        {
            SeatNumber1 = seatNumber1;
            SeatNumber2 = seatNumber2;
        }
    }
}
