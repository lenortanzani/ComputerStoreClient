using ComputerStore.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Data
{
    public class ComputerStoreDbClient : IComputerStoreDbClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        public ComputerStoreDbClient(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
            _baseUrl = $"{_configuration["Database:BaseUrl"]}/api/ComputerStore";
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            return await SendGetAsync<List<Item>>("GetItems");
        }

        public async Task<List<Item>> GetVideoCardsAsync()
        {
            return await SendGetAsync<List<Item>>("GetVideoCards"); ////// NEW
        }

        public async Task<List<Item>> GetProcessorsAsync()
        {
            return await SendGetAsync<List<Item>>("GetProcessors"); 
        }

        public async Task<List<Item>> GetRAMsAsync()
        {
            return await SendGetAsync<List<Item>>("GetRAMs"); 
        }

        public async Task<List<Item>> GetMotherboardsAsync()
        {
            return await SendGetAsync<List<Item>>("GetMotherboards"); 
        }

        public async Task<List<Item>> GetHardDisksAsync()
        {
            return await SendGetAsync<List<Item>>("GetHardDisks");
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await SendGetAsync<Item>($"GetItem/{id}");
        }

        public async Task<int> CreateItemAsync(Item item)
        {
            var serializedResult = await SendPostPutAsync<Item>(item, "CreateItem", HttpMethod.Post);
            return int.Parse(serializedResult);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            try
            {
                var serializedResult = await SendPostPutAsync<Item>(item, "UpdateItem", HttpMethod.Put);
                return bool.Parse(serializedResult);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            return await SendDeleteAsync($"DeleteItem/{id}");
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await SendGetAsync<List<Order>>("GetOrders");
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await SendGetAsync<Order>($"GetOrder/{id}");
        }

        public async Task<List<Order>> GetOrdersForDeliveryAsync()
        {
            return await SendGetAsync<List<Order>>("GetOrdersForDelivery");
        }

        public async Task<List<Order>> GetOutdatedOrdersForDeliveryAsync()
        {
            return await SendGetAsync<List<Order>>("GetOutdatedOrdersForDelivery");
        }

        public async Task<List<Order>> GetOrdersByCourierAsync(string id)
        {
            return await SendGetAsync<List<Order>>($"GetOrdersByCourier/{id}");
        }

        public async Task<List<Order>> GetOrdersByUserAsync(string id)
        {
            return await SendGetAsync<List<Order>>($"GetOrdersByUser/{id}");
        }

        public async Task<int> CreateOrderAsync(Order order)
        {
            var serializedResult = await SendPostPutAsync<Order>(order, "CreateOrder", HttpMethod.Post);
            return int.Parse(serializedResult);
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            var serializedResult = await SendPostPutAsync<Order>(order, "UpdateOrder", HttpMethod.Put);
            return bool.Parse(serializedResult);
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            return await SendDeleteAsync($"DeleteOrder/{id}");
        }

        private async Task<T> SendGetAsync<T>(string action)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/{action}");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var serializedResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(serializedResult);
        }

        private async Task<string> SendPostPutAsync<T>(T obj, string action, HttpMethod method)
        {
            if (method != HttpMethod.Post && method != HttpMethod.Put)
            {
                return "Wrong request method";
            }

            var request = new HttpRequestMessage(method, $"{_baseUrl}/{action}");

            var serializedContent = JsonConvert.SerializeObject(obj);

            request.Content = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var serializedResult = await response.Content.ReadAsStringAsync();
                return serializedResult;
            }
            else if (response.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                throw new KeyNotFoundException();
            }
            else
            {
                return $"Status code {response.StatusCode}";
            }
        }

        private async Task<bool> SendDeleteAsync(string action)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{_baseUrl}/{action}");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var serializedResult = await response.Content.ReadAsStringAsync();
            return bool.Parse(serializedResult);
        }
    }
}
