using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStore.SignalR
{
    public class ComputerStoreHub : Hub
    {
        private readonly IHubContext<ComputerStoreHub> _context;

        public ComputerStoreHub(IHubContext<ComputerStoreHub> context)
        {
            _context = context;
        }

        public async Task SendMessageAsync(string method)
        {
            await _context.Clients.All.SendAsync(method);
        }
    }
}
