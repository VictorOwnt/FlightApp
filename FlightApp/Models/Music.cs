using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Models
{
    public class Music
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Artist { get; private set; }
        public string Poster { get; private set; }
        public string Source => $"{Artist}.{Title}.mp3";

        public Music(int id, string title, string artist, string poster)
        {
            Id = id;
            Title = title;
            Artist = artist;
            Poster = poster;
        }
    }
}
