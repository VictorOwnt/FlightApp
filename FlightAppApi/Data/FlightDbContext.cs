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



            //Another way to seed the database
            builder.Entity<Steward>().HasData(
                new Steward { Id = 1, FirstName = "Sebastien", LastName = "Wojtyla", Email = "sebastienwojtyla@gmail.com" },
                new Steward { Id = 2, FirstName = "Julien", LastName = "Wojtyla", Email = "julienwojtyla@gmail.com" });

            builder.Entity<Passenger>().HasData(
                new Passenger { Id = 1, FirstName = "Marie", LastName = "Louise", SeatNumber = 1, Email = "marielouise@gmail.com" },
                new Passenger { Id = 2, FirstName = "George", LastName = "Floyd", SeatNumber = 2, Email = "gerogefloyd@gmail.com" });
        }



        public DbSet<Steward> Stewards { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
    }
}

