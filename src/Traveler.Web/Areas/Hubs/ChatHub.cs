﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Traveler.Web.Areas.Hubs
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
    }

}