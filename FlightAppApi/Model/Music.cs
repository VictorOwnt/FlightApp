using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public class Music
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Poster { get; set; }

        public Music(string title, string artist, string poster)
        {
            Title = title;
            Artist = artist;
            Poster = poster;
        }
    }
}
