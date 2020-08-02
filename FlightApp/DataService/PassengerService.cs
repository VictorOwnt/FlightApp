using FlightApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace FlightApp.DataService
{
    public class PassengerService
    {
        private readonly ApplicationDataContainer LocalSettings = ApplicationData.Current.LocalSettings;
        //HttpClient is intended to be instantiated once and re-used throughout the life of an application. 
        //Instantiating an HttpClient class for every request will exhaust the number of sockets available under heavy loads. This will result in SocketException errors.
        private static readonly HttpClient client = new HttpClient();

        public async Task<Passenger> GetLoggedInPassengerAsync()
        {


            string token = LocalSettings.Values["Token"] as string;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/passenger/"));
            var passenger = JsonConvert.DeserializeObject<Passenger>(json);
            return passenger;

        }
    }
}
