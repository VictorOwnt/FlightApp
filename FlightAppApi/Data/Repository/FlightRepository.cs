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
            return _flights.Include(f => f.Airline)
                .Include(f => f.Aircraft)
                .Include(f => f.FlightDetail).ThenInclude(fd => fd.ArrivalAirport).ThenInclude(aa => aa.Location)
                .Include(f => f.FlightDetail).ThenInclude(fd => fd.DepartingAirport).ThenInclude(da => da.Location);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
