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
        public DbSet<Steward> Stewards { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Flight> Flights { get; set; }

        public FlightDbContext(DbContextOptions<FlightDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Steward>();
            builder.Entity<Passenger>();

            builder.Entity<Airline>().HasKey(al => al.Id);

            builder.Entity<Airport>().HasKey(ap => ap.Id);
            builder.Entity<Airport>().HasOne(ap => ap.Location).WithMany().IsRequired();

            builder.Entity<Aircraft>().HasKey(ac => ac.Id);

            builder.Entity<Location>().HasKey(l => l.Id);

            builder.Entity<FlightDetail>().HasKey(fd => fd.Id);
            builder.Entity<FlightDetail>().HasOne(fd => fd.DepartingAirport).WithMany().IsRequired().HasForeignKey(fd => fd.DepartingAirportId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<FlightDetail>().HasOne(fd => fd.ArrivalAirport).WithMany().IsRequired().HasForeignKey(fd => fd.ArrivalAirportId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Flight>().HasKey(f => f.FlightNr);
            builder.Entity<Flight>().HasOne(f => f.Airline).WithMany().IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Flight>().HasOne(f => f.Aircraft).WithMany().IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Flight>().HasOne(f => f.FlightDetail).WithOne().IsRequired().HasForeignKey<Flight>().OnDelete(DeleteBehavior.Restrict);     // FlightNr will be same as FlightDetail id   
        }
    }
}

