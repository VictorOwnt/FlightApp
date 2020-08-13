using FlightApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Windows.Storage;
using Windows.Web.Http;
using Windows.Web.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Helpers;

namespace FlightApp.DataService
{
    public class PassengerService
    {
        private readonly ApplicationDataContainer LocalSettings = ApplicationData.Current.LocalSettings;
        //HttpClient is intended to be instantiated once and re-used throughout the life of an application. 
        //Instantiating an HttpClient class for every request will exhaust the number of sockets available under heavy loads. This will result in SocketException errors.
        private static readonly HttpClient client = new HttpClient();
        public string Token { get; set; }

        public PassengerService()
        {
            Token = LocalSettings.Values["Token"] as string;
            client.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", Token);
        }
        public async Task<Passenger> GetLoggedInPassengerAsync()
        {
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/passenger/"));
            var passenger = JsonConvert.DeserializeObject<Passenger>(json);

            LocalObjectStorageHelper localObjectStorage = new LocalObjectStorageHelper();
            localObjectStorage.Save("passenger", passenger);

            return passenger;

        }

        public async Task<IEnumerable<Passenger>> GetContactsOfLoggedInPassenger()
        {
            var response = await client.GetAsync(new Uri("http://localhost:5000/api/passenger/contacts/"));
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().GetResults();
                var contacts = JsonConvert.DeserializeObject<IEnumerable<Passenger>>(result);
                return contacts;
            }
            else
            {
                throw new Exception();
            }


        }

        public async Task<IEnumerable<ChatMessage>> GetMessagesOfPassengerWithContact(string contactEmail)
        {
            string url = string.Format("http://localhost:5000/api/passenger/messages/?contactEmail={0}", contactEmail);
            var response = await client.GetAsync(new Uri(url));
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().GetResults();
                var messages = JsonConvert.DeserializeObject<IEnumerable<ChatMessage>>(result);
                return messages;
            }
            else
            {
                throw new Exception();
            }


        }

    }
}
