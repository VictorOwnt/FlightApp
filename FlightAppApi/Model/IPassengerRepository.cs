using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public interface IPassengerRepository
    {
        Passenger GetPassengerByEmail(string email);
        Passenger GetPassengerByEmailWithOrders(string email);
        Passenger GetPassengerBySeatNumber(int seatNumber);
        IEnumerable<Passenger> GetPassengersWithOrders();
        void SaveChanges();
        Passenger GetPassengerByEmailWithContacts(string name);
    }
}
