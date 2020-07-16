using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public int Runtime { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Poster { get; set; }
        [Required]
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
