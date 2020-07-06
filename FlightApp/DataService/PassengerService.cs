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
        private readonly ApplicationDataContainer LocalSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public async Task<Passenger> GetLoggedInPassengerAsync()
        {


            string token = LocalSettings.Values["Token"] as string;
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var json = await httpClient.GetStringAsync(new Uri("http://localhost:5000/api/passenger/"));
            var passenger = JsonConvert.DeserializeObject<Passenger>(json);
            return passenger;

        }
    }
}
