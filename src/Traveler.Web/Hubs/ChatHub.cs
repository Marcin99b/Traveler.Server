using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Traveler.Web.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendToAll(string name, string message)
        {
            if (Clients != null)
            {
                await Clients.All.SendCoreAsync("sendToAll", new string[] { name, message });
            }
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }

}
