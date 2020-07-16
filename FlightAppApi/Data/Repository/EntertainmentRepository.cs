//using FlightAppApi.Model;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace FlightAppApi.Data.Repository
//{
//    public class EntertainmentRepository : IEntertainmentRepository
//    {
//        private readonly FlightDbContext _dbContext;
//        private readonly DbSet<Movie> _movies;
//        private readonly DbSet<Music> _music;

//        public EntertainmentRepository(FlightDbContext dbContext)
//        {
//            _dbContext = dbContext;
//            _movies = dbContext.Movies;
//            _music = dbContext.Music;
//        }

//        public IList<Movie> GetMovies()
//        {
//            return _movies.ToList();
//        }

//        public IList<Music> GetMusic()
//        {
//            return _music.ToList();
//        }
//    }
//}
