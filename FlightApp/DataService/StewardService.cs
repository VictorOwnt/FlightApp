using FlightApp.DTO;
using FlightApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public async Task DeliverOrderAsync(int orderId)
        {
            var orderIdJson = JsonConvert.SerializeObject(orderId);
            string url = string.Format("http://localhost:5000/api/steward/passenger/order/deliver?orderId={0}", orderId);
            var response = await client.PutAsync(new Uri(url), new HttpStringContent(orderIdJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
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
            else throw new Exception();
        }

        public async Task<IEnumerable<Passenger>> GetPassengersIncludeOrders()
        {
            var response = await client.GetAsync(new Uri("http://localhost:5000/api/steward/passengers/orders"));
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().GetResults();
                var passengers = JsonConvert.DeserializeObject<IEnumerable<Passenger>>(result);
                return passengers;
            }
            else throw new Exception(); //Throw general exception because class Windows.Web.Http has no specific exception, only system.http. More info https://stackoverflow.com/questions/27031408/why-are-network-exceptions-raised-by-windows-web-http-httpclient-of-type-system
        }
        public async Task<IEnumerable<Passenger>> GetPassengersWithFilteredOrders(bool delivery)
        {
            string url = string.Format("http://localhost:5000/api/steward/passengers/orders/deliver?delivery={0}", delivery);
            var response = await client.GetAsync(new Uri(url));
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().GetResults();
                var passengers = JsonConvert.DeserializeObject<IEnumerable<Passenger>>(result);
                return passengers;
            }
            else throw new Exception();
        }

        public async Task<IEnumerable<Passenger>> GetAllPassengersAsync()
        {
            var response = await client.GetAsync(new Uri("http://localhost:5000/api/steward/passengers"));
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().GetResults();
                var passengers = JsonConvert.DeserializeObject<IEnumerable<Passenger>>(result);
                return passengers;
            }
            else
            {
                throw new Exception();
            }
        }

    }
}
