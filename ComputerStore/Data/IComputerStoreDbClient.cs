using ComputerStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ComputerStore.Data
{
    public interface IComputerStoreDbClient
    {
        Task<List<Item>> GetItemsAsync();
        Task<List<Item>> GetVideoCardsAsync(); ///NEW
        Task<List<Item>> GetProcessorsAsync();
        Task<List<Item>> GetRAMsAsync();
        Task<List<Item>> GetMotherboardsAsync();
        Task<List<Item>> GetHardDisksAsync();

        Task<Item> GetItemAsync(int id);
        Task<int> CreateItemAsync(Item item);

        Task<bool> UpdateItemAsync(Item item);

        Task<bool> DeleteItemAsync(int id);

        Task<List<Order>> GetOrdersAsync();

        Task<Order> GetOrderAsync(int id);

        Task<List<Order>> GetOrdersForDeliveryAsync();

        Task<List<Order>> GetOutdatedOrdersForDeliveryAsync();

        Task<List<Order>> GetOrdersByCourierAsync(string id);
        Task<List<Order>> GetOrdersByUserAsync(string id);

        Task<int> CreateOrderAsync(Order order);

        Task<bool> UpdateOrderAsync(Order order);

        Task<bool> DeleteOrderAsync(int id);
    }
}
