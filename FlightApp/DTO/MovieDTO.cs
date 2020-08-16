using FlightApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Runtime { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Poster { get; set; }
        public string Trailer { get; set; }

        public Movie ToMovie()
        {
            return new Movie(Id, Title, ReleaseDate, Runtime, Description, Director, Poster, Trailer);
        }
    }
}
