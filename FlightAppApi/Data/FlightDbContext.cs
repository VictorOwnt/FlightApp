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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Flight> Flights { get; set; }

        public FlightDbContext(DbContextOptions<FlightDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Steward>().HasKey(s => s.PersonId);
            builder.Entity<Passenger>().HasKey(p => p.PersonId);
            builder.Entity<Passenger>().HasMany(p => p.Orders).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Passenger>().HasMany(p => p.Contacts).WithOne();

            builder.Entity<PassengerContact>().HasKey(pc => new { pc.PassengerId, pc.ContactId });
            //builder.Entity<PassengerContact>().HasOne(pc => pc.Contact).WithMany(p => p.ContactOf).HasForeignKey(pc => pc.ContactId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<PassengerContact>().HasOne(pc => pc.Passenger).WithMany(p => p.Contacts).HasForeignKey(pc => pc.PassengerId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ChatMessage>().HasKey(cm => cm.ChatMessageId);
            builder.Entity<PassengerContact>().HasMany(pc => pc.ChatMessages).WithOne();

            builder.Entity<Product>().HasKey(p => p.ProductId);

            builder.Entity<Order>().HasKey(o => o.OrderId);
            builder.Entity<Order>().HasMany(o => o.Orderlines).WithOne().HasForeignKey(ol => ol.OrderId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Orderline>().HasKey(ol => new { ol.OrderId, ol.ProductId });
            builder.Entity<Orderline>().HasOne(ol => ol.Product).WithMany().IsRequired().HasForeignKey(ol => ol.ProductId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Category>().HasKey(c => c.CategoryId);
            builder.Entity<Category>().HasMany(c => c.Products).WithOne();

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

