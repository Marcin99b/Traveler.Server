using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Traveler.Web.Areas.Hubs
{
    public class ChatController : BaseApiController
    {
        private ChatHub chatHub;

        public ChatController(ChatHub chatHub)
        {
            this.chatHub = chatHub;
        }

        [HttpPost]
        public IActionResult SendMessage([FromBody] MessageInfo request)
        {
            Task.Factory.StartNew(async () => await chatHub.SendToAll(request.Name, request.Message) );
            
            return Ok();
        }
    }

    public class MessageInfo
    {
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
