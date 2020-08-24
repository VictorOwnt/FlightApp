using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Web.Http;
using Windows.Web.Http.Headers;
using FlightApp.Models;
using Newtonsoft.Json;

namespace FlightApp.DataService
{
    public class FlightService
    {
        private readonly ApplicationDataContainer LocalSettings = ApplicationData.Current.LocalSettings;
        //HttpClient is intended to be instantiated once and re-used throughout the life of an application. 
        //Instantiating an HttpClient class for every request will exhaust the number of sockets available under heavy loads. This will result in SocketException errors.
        private static readonly HttpClient client = new HttpClient();
        private string Token { get; set; }

        public FlightService()
        {
            Token = LocalSettings.Values["Token"] as string;
            client.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", Token);
        }

        public async Task<Flight> GetFlightAsync()
        {
            var response = await client.GetAsync(new Uri("http://localhost:5000/api/flight"));
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().GetResults();
                var flights = JsonConvert.DeserializeObject<IEnumerable<Flight>>(result);
                return flights.Single();
            }
            else throw new Exception();
        }
    }
}
