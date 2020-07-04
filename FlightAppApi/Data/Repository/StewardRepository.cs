using FlightAppApi.Data;
using FlightAppApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Repository
{
    public class StewardRepository : IStewardRepository
    {
        private readonly FlightDbContext _context;
        private readonly DbSet<Steward> _stewards;

        public StewardRepository(FlightDbContext dbContext)
        {
            _context = dbContext;
            _stewards = dbContext.Stewards;
        }

        public Steward GetStewardByEmail(string email)
        {
            return _stewards.FirstOrDefault(s => s.Email == email);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

