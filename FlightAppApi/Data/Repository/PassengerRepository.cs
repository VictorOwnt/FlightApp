using FlightAppApi.Data;
using FlightAppApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Data.Repository
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly FlightDbContext _context;
        private readonly DbSet<Passenger> _passengers;

        public PassengerRepository(FlightDbContext dbContext)
        {
            _context = dbContext;
            _passengers = dbContext.Passengers;
        }
        public Passenger GetPassengerByEmail(string email)
        {
            return _passengers.SingleOrDefault(p => p.Email == email);
        }

        public Passenger GetPassengerByEmailWithContacts(string email)
        {
            return _passengers.Include(p => p.Contacts).ThenInclude(p => p.Contact).SingleOrDefault(p => p.Email == email);
        }

        public Passenger GetPassengerByEmailWithOrders(string email)
        {
            return _passengers.Include(p => p.Orders).ThenInclude(o => o.Orderlines).ThenInclude(ol => ol.Product).SingleOrDefault(p => p.Email == email);
        }

        public Passenger GetPassengerBySeatNumber(int seatNumber)
        {
            return _passengers.FirstOrDefault(p => p.SeatNumber == seatNumber);
        }

        public IEnumerable<Passenger> GetPassengersWithOrders()
        {
            return _passengers.Include(p => p.Orders).ThenInclude(o => o.Orderlines).ThenInclude(ol => ol.Product);
        }
        public Passenger GetPassengerByEmailWithChatMessages(string email)
        {
            return _passengers.Include(p => p.Contacts).ThenInclude(c => c.ChatMessages).Include(p => p.Contacts).ThenInclude(c => c.Contact).ThenInclude(c => c.Contacts).ThenInclude(c => c.ChatMessages).SingleOrDefault(p => p.Email == email);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Passenger> GetAllPassengers()
        {
            return _passengers;
        }
    }
}
