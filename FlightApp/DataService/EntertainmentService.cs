using FlightApp.DTO;
using FlightApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlightApp.DataService
{
    public static class EntertainmentService
    {
        public static async Task<IList<Movie>> GetAllMoviesAsync()
        {
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(new Uri($"http://localhost:5000/api/Entertainment/get_movies/"));
            IList<MovieDTO> movies = JsonConvert.DeserializeObject<ObservableCollection<MovieDTO>>(json);
            return movies.Select(m => m.ToMovie()).ToList();
        }

        public static async Task<IList<Music>> GetAllMusicAsync()
        {
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(new Uri($"http://localhost:5000/api/Entertainment/get_music/"));
            IList<MusicDTO> music = JsonConvert.DeserializeObject<ObservableCollection<MusicDTO>>(json);
            return music.Select(m => m.ToMusic()).ToList();
        }
    }
}
