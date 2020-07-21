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

        public FlightDbContext(DbContextOptions<FlightDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Steward>();
            builder.Entity<Passenger>().HasKey(p => p.Id);
            builder.Entity<Passenger>().HasMany(p => p.Orders).WithOne().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>().HasKey(p => p.Id);

            builder.Entity<Order>().HasKey(o => o.Id);
            builder.Entity<Order>().HasMany(o => o.Orderlines).WithOne().HasForeignKey(ol => ol.OrderId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Orderline>().HasKey(ol => new { ol.OrderId, ol.ProductId });
            builder.Entity<Orderline>().HasOne(ol => ol.Product).WithMany().IsRequired().HasForeignKey(ol => ol.ProductId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Category>().HasKey(c => c.Id);
            builder.Entity<Category>().HasMany(c => c.Products).WithOne();



        }


    }
}

