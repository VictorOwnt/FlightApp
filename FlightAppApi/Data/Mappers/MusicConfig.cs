//using FlightAppApi.Model;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace FlightAppApi.Data.Mappers
//{
//    public class MusicConfig : IEntityTypeConfiguration<Music>
//    {
//        public void Configure(EntityTypeBuilder<Music> builder)
//        {
//            builder.ToTable("Music");

//            builder.HasKey(m => m.Id);
//            builder.Property(m => m.Title).IsRequired();
//            builder.Property(m => m.Artist).IsRequired();
//            builder.Property(m => m.Poster).IsRequired();
//        }
//    }
//}
