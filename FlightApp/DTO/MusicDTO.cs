using FlightApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.DTO
{
    public class MusicDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Poster { get; set; }

        public Music ToMusic()
        {
            return new Music(Id, Title, Artist, Poster);
        }
    }
}
