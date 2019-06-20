using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Traveler.Web.Areas.Connections.Models;

namespace Traveler.Web.Areas.Connections.Controllers
{
    public class ConnectionsController : BaseApiController
    {
        //todo add pinging in loop, and signal r integration for give alerts when disconnected
        [HttpPost]
        public IActionResult Connect([FromBody] ConnectRequest request)
        {
            try
            {
                using (var ping = new Ping())
                {
                    var response = ping.Send(request.IpAddress);
                    return Json(new ConnectResponse
                    {
                        IsConnected = response?.Status == IPStatus.Success
                    });
                }
            }
            catch
            {
                return Json(new ConnectResponse
                {
                    IsConnected = false
                });
            }
        }
    }

    

    
}
