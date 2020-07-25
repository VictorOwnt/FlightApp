using FlightApp.DTO;
using FlightApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Web.Http;
using Windows.Web.Http.Headers;

namespace FlightApp.DataService
{
    public class StewardService
    {
        private readonly ApplicationDataContainer LocalSettings = ApplicationData.Current.LocalSettings;
        //HttpClient is intended to be instantiated once and re-used throughout the life of an application. 
        //Instantiating an HttpClient class for every request will exhaust the number of sockets available under heavy loads. This will result in SocketException errors.
        private static readonly HttpClient client = new HttpClient();
        private string Token { get; set; }


        public StewardService()
        {
            Token = LocalSettings.Values["Token"] as string;
            client.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", Token);
        }
        public async Task<List<Passenger>> ChangeSeats(int seatNumber1, int seatNumber2)
        {
            SeatDTO seatDTO = new SeatDTO(seatNumber1, seatNumber2);
            var seatDTOJson = JsonConvert.SerializeObject(seatDTO);
            var response = await client.PutAsync(new Uri("http://localhost:5000/api/steward/seat/change"), new HttpStringContent(seatDTOJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().GetResults();
                var passengers = JsonConvert.DeserializeObject<List<Passenger>>(result);
                return passengers;
            }
            //TODO error handling
            return new List<Passenger>();
        }
    }
}
