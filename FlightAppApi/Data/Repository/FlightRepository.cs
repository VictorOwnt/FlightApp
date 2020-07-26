using FlightAppApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace FlightAppApi.Data.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightDbContext _context;
        private readonly DbSet<Flight> _flights;

        public FlightRepository(FlightDbContext dbContext)
        {
            _context = dbContext;
            _flights = dbContext.Flights;
        }
        public IEnumerable<Flight> GetAllFlights()
        {
            return _flights;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
