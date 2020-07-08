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
        public DbSet<Product> Products { get; set; }

        public FlightDbContext(DbContextOptions<FlightDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Steward>();
            builder.Entity<Passenger>();
            builder.Entity<Product>();
            builder.Entity<PassengerProduct>().HasKey(pp => new { pp.PassengerId, pp.ProductId });
            builder.Entity<PassengerProduct>().HasOne(pp => pp.Passenger).WithMany(p => p.PassengerProducts);
            builder.Entity<PassengerProduct>().HasOne(pp => pp.Product).WithMany(p => p.PassengerProducts);

        }


    }
}

