using System.Collections.Generic;

namespace FlightAppApi.Model
{
    public interface IFlightRepository
    {
        IEnumerable<Flight> GetAllFlights();
        void SaveChanges();
    }
}
