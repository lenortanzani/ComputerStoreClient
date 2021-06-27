using ComputerStore.Data;
using ComputerStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IComputerStoreDbClient _dbClient;

        public HomeController(ILogger<HomeController> logger, IComputerStoreDbClient dbClient)
        {
            _logger = logger;
            _dbClient = dbClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateItemForm()
        {
            return View(new Item());
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateItem(Item item)
        {
            var result = await _dbClient.CreateItemAsync(item);
            return RedirectToAction("ItemsList");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateItemForm(int itemId)
        {
            var item = await _dbClient.GetItemAsync(itemId);

            return View(item);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateItem(Item item)
        {
            var result = await _dbClient.UpdateItemAsync(item);

            return RedirectToAction("ItemsList");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteItemForm(int itemId)
        {
            var item = await _dbClient.GetItemAsync(itemId);

            return View(item);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteItem(Item item)
        {
            //var result = await _dbClient.DeleteItemAsync(item.Id);

            item.Visibility = false; // new
            var result = await _dbClient.UpdateItemAsync(item); // new

            return RedirectToAction("ItemsList");
        }


        public async Task<IActionResult> ItemsList()
        {
            var items = await _dbClient.GetItemsAsync();
            if (User.Identity.IsAuthenticated)
            {
                var orders = await _dbClient.GetOrdersByUserAsync(User.Identity.Name);
                ShowStatuses(orders);

                ViewBag.Orders = orders.OrderBy(o => o.Position).ToList();
            }           
            return View(items);
        }

        public async Task<IActionResult> VideoCardsList()
        {
            var items = await _dbClient.GetVideoCardsAsync();
            if (User.Identity.IsAuthenticated)
            {
                var orders = await _dbClient.GetOrdersByUserAsync(User.Identity.Name);
                ShowStatuses(orders);

                ViewBag.Orders = orders.OrderBy(o => o.Position).ToList();
            }
            return View(items); 
        }

        public async Task<IActionResult> ProcessorsList()
        {
            var items = await _dbClient.GetProcessorsAsync();
            if (User.Identity.IsAuthenticated)
            {
                var orders = await _dbClient.GetOrdersByUserAsync(User.Identity.Name);
                ShowStatuses(orders);

                ViewBag.Orders = orders.OrderBy(o => o.Position).ToList();
            }
            return View(items); 
        }

        public async Task<IActionResult> RAMsList()
        {
            var items = await _dbClient.GetRAMsAsync();
            if (User.Identity.IsAuthenticated)
            {
                var orders = await _dbClient.GetOrdersByUserAsync(User.Identity.Name);
                ShowStatuses(orders);

                ViewBag.Orders = orders.OrderBy(o => o.Position).ToList();
            }
            return View(items);
        }

        public async Task<IActionResult> MotherboardsList()
        {
            var items = await _dbClient.GetMotherboardsAsync();
            if (User.Identity.IsAuthenticated)
            {
                var orders = await _dbClient.GetOrdersByUserAsync(User.Identity.Name);
                ShowStatuses(orders);

                ViewBag.Orders = orders.OrderBy(o => o.Position).ToList();
            }
            return View(items);
        }

        public async Task<IActionResult> HardDisksList()
        {
            var items = await _dbClient.GetHardDisksAsync();
            if (User.Identity.IsAuthenticated)
            {
                var orders = await _dbClient.GetOrdersByUserAsync(User.Identity.Name);
                ShowStatuses(orders);

                ViewBag.Orders = orders.OrderBy(o => o.Position).ToList();
            }
            return View(items);
        }

        public async Task<IActionResult> MyOrdersList() 
        {           
            if (User.Identity.IsAuthenticated)
            {
                var orders = await _dbClient.GetOrdersByUserAsync(User.Identity.Name);
                ShowStatuses(orders);

                ViewBag.Orders = orders.OrderBy(o => o.Position).ToList();
            }

            return View();
        }

        private static void ShowStatuses(List<Order> orders)
        {
            foreach (var order in orders)
            {
                if (order.Datetimeorderdelivered > DateTime.MinValue)
                {
                    order.Status = "Доставлен";
                    order.Position = 3;
                }
                else if (string.IsNullOrWhiteSpace(order.CourierId))
                {
                    order.Status = "В ожидании доставки";
                    order.Position = 2;
                }
                else
                {
                    order.Status = "Уже в пути";
                    order.Position = 1;
                }
            }
         
        }

        [Authorize]
        public async Task<IActionResult> CreateOrderForm(int id)
        {
            ViewBag.Item = await _dbClient.GetItemAsync(id);
            return View(new Order());
        }

        [Authorize]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            order.Datetimeorderplaced = DateTime.Now;
            order.UserId = User.Identity.Name;

            await _dbClient.CreateOrderAsync(order);

            return RedirectToAction("ItemsList");
        }

        [Authorize(Roles = "Courier")]
        public async Task<IActionResult> DeliveryList()
        {
            List<Order> orders = await _dbClient.GetOrdersForDeliveryAsync();
            orders = orders.Where(o => string.IsNullOrWhiteSpace(o.CourierId) || o.CourierId.Equals(User.Identity.Name)).ToList();
            return View(orders);
        }

        // NEW METHODS

        [Authorize(Roles = "Courier")]
        public async Task<IActionResult> StartDelivery(int id)
        {
            var order = await _dbClient.GetOrderAsync(id);
            order.CourierId = User.Identity.Name;
            var result = _dbClient.UpdateOrderAsync(order);
            return RedirectToAction("DeliveryList");
        }

        [Authorize(Roles = "Courier")]
        public async Task<IActionResult> FinishDelivery(int id)
        {
            var order = await _dbClient.GetOrderAsync(id);
            order.Datetimeorderdelivered = DateTime.Now;
            var result = _dbClient.UpdateOrderAsync(order);
            return RedirectToAction("DeliveryList");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




    }
}
