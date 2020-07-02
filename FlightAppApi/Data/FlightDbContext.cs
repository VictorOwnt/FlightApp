using FlightAppApi.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Data
{
    public class FlightDbContext : IdentityDbContext
    {
        public FlightDbContext(DbContextOptions<FlightDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Steward>();
            builder.Entity<Passenger>();

        }

        public DbSet<Steward> Stewards { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
    }
}

