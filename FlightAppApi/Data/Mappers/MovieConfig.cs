//using FlightAppApi.Model;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace FlightAppApi.Data.Mappers
//{
//    public class MovieConfig : IEntityTypeConfiguration<Movie>
//    {
//        public void Configure(EntityTypeBuilder<Movie> builder)
//        {
//            builder.ToTable("Movies");

//            builder.HasKey(m => m.Id);
//            builder.Property(m => m.Title).IsRequired();
//            builder.Property(m => m.ReleaseDate).IsRequired();
//            builder.Property(m => m.Runtime).IsRequired();
//            builder.Property(m => m.Description).IsRequired();
//            builder.Property(m => m.Director).IsRequired();
//            builder.Property(m => m.Poster).IsRequired();
//            builder.Property(m => m.Trailer).IsRequired();
//        }
//    }
//}
