using FlightAppApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Repository
{
    public class PassengerRepository : IPassengerRepository
    {
        private List<Passenger> Passengers { get; set; }

        public Passenger GetPassenger(string firstName, string lastName, string seatNumber)
        {
            return Passengers.SingleOrDefault(p => p.FirstName == firstName && p.LastName == lastName && p.SeatNumber == long.Parse(seatNumber));
        }
    }
}
