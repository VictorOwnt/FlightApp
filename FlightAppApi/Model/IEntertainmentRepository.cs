using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public interface IEntertainmentRepository
    {
        IList<Movie> GetMovies();
        IList<Music> GetMusic();
        void SaveChanges();
    }
}
