﻿using FlightApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private string token { get; set; }

        public ProductService()
        {
            token = LocalSettings.Values["Token"] as string;
            client.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", token);
        }
        public async Task<Category> GetCategoryWithProducts(string categoryName)
        {
            string url = string.Format("http://localhost:5000/api/category/products/?categoryName={0}", categoryName);
            var response = await client.GetAsync(new Uri(url));
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().GetResults();
                var category = JsonConvert.DeserializeObject<Category>(result);
                return category;
            }
            //TODO error handling
            return new Category();
        }

        public async Task OrderProductsAsync(List<Product> products)
        {
            var productsJson = JsonConvert.SerializeObject(products);

            var response = await client.PostAsync(new Uri("http://localhost:5000/api/products"), new HttpStringContent(productsJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
        }
    }
}
