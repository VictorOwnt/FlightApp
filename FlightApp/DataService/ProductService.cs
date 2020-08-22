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
    public class ProductService
    {
        private readonly ApplicationDataContainer LocalSettings = ApplicationData.Current.LocalSettings;
        //HttpClient is intended to be instantiated once and re-used throughout the life of an application. 
        //Instantiating an HttpClient class for every request will exhaust the number of sockets available under heavy loads. This will result in SocketException errors.
        private static readonly HttpClient client = new HttpClient();
        private string Token { get; set; }


        public ProductService()
        {
            Token = LocalSettings.Values["Token"] as string;
            client.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", Token);
        }

        public async Task<IEnumerable<Product>> GetProductsOfCategory(string categoryName)
        {
            string url = string.Format("http://localhost:5000/api/category/product/?categoryName={0}", categoryName);
            var response = await client.GetAsync(new Uri(url));
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().GetResults();
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
                return products;
            }
            else
            {
                throw new Exception();
            }

        }

        public async void SaveDiscountChanges(IEnumerable<Product> products)
        {
            var productsJson = JsonConvert.SerializeObject(products);
            var response = await client.PutAsync(new Uri("http://localhost:5000/api/steward/products/discount"), new HttpStringContent(productsJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var response = await client.GetAsync(new Uri("http://localhost:5000/api/product"));
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().GetResults();
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
                return products;
            }
            else throw new Exception();
        }

        public async Task OrderProductsAsync(IEnumerable<Product> products)
        {
            var productsJson = JsonConvert.SerializeObject(products);

            var response = await client.PostAsync(new Uri("http://localhost:5000/api/product"), new HttpStringContent(productsJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
        }
    }
}
