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
    public class ProductService
    {
        private readonly ApplicationDataContainer LocalSettings = ApplicationData.Current.LocalSettings;
        //HttpClient is intended to be instantiated once and re-used throughout the life of an application. 
        //Instantiating an HttpClient class for every request will exhaust the number of sockets available under heavy loads. This will result in SocketException errors.
        private static readonly HttpClient client = new HttpClient();
        private string token { get; set; }

        public ProductService()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            token = LocalSettings.Values["Token"] as string;
        }
        public async Task<Category> GetCategoryWithProducts(string categoryName)
        {
            string url = string.Format("http://localhost:5000/api/category/products/?categoryName={0}", categoryName);
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var category = JsonConvert.DeserializeObject<Category>(result);
                return category;
            }
            //TODO error handling
            return new Category();
        }
    }
}
