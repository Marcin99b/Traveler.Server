using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Traveler.Web.Areas.Connections.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ConnectionsController : Controller
    {
        [HttpPost]
        public IActionResult Connect([FromBody] IpAddressRequest request)
        {
            try
            {
                using (var ping = new Ping())
                {
                    var response = ping.Send(request.IpAddress);
                    return Json(new IpAddressResponse
                    {
                        IsConnected = response?.Status == IPStatus.Success
                    });
                }
            }
            catch
            {
                return Json(new IpAddressResponse
                {
                    IsConnected = false
                });
            }
        }
    }

    public class IpAddressRequest
    {
        public string IpAddress { get; set; }
    }

    public class IpAddressResponse
    {
        public bool IsConnected { get; set; }
    }
}
