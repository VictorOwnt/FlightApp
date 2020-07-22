using FlightAppApi.Data;
using FlightAppApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Repository
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
        public Passenger GetPassengerByEmailWithOrders(string email)
        {
            return _passengers.Include(p => p.Orders).ThenInclude(o => o.Orderlines).ThenInclude(ol => ol.Product).SingleOrDefault(p => p.Email == email);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
