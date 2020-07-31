using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Runtime { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Poster { get; set; }
        public string Trailer { get; set; }

        public Movie(string title, DateTime releaseDate, int runtime, string description, string director, string poster, string trailer)
        {
            Title = title;
            ReleaseDate = releaseDate;
            Runtime = runtime;
            Description = description;
            Director = director;
            Poster = poster;
            Trailer = trailer;
        }
    }
}
