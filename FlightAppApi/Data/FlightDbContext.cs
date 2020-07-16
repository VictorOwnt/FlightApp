//using FlightAppApi.Data.Mappers;
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
        //public DbSet<Movie> Movies { get; set; }
        //public DbSet<Music> Music { get; set; }

        public FlightDbContext(DbContextOptions<FlightDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Steward>();
            builder.Entity<Passenger>();
            //builder.Entity<Movie>();
            //builder.Entity<Music>();

            //builder.ApplyConfiguration(new MovieConfig());
            //builder.ApplyConfiguration(new MusicConfig());
        }
    }
}

