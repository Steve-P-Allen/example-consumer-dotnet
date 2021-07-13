using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Consumer.Models;

namespace Consumer
{
    public class ProductClient
    {
        #nullable enable
        public async Task<List<Product>> GetProducts(string baseUrl, HttpClient? httpClient = null)
        {
            using var client = httpClient == null ? new HttpClient() : httpClient;

            var response = await client.GetAsync(baseUrl + "/products");
            response.EnsureSuccessStatusCode();

            var resp = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Product>>(resp);
        }

        public async Task<Product> GetProduct(string baseUrl, string id, HttpClient? httpClient = null)
        {
            using var client = httpClient == null ? new HttpClient() : httpClient;

            var response = await client.GetAsync(baseUrl + "/product/" + id);
            response.EnsureSuccessStatusCode();

            var resp = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Product>(resp);
        }
    }
}