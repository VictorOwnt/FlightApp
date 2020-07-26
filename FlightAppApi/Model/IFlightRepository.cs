using System.Collections.Generic;

namespace FlightAppApi.Model
{
    interface IFlightRepository
    {
        IEnumerable<Flight> GetAllFlights();
        void SaveChanges();
    }
}
