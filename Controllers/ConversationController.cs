using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalR_Chat_Demo.Contexts;
using SignalR_Chat_Demo.Models;
using SignalR_Chat_Demo.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace SignalR_Chat_Demo.Controllers
{
    [Route("api/[controller]")]
    public class ConversationController : Controller
    {
        MSSQLDbContext DBContext;
        private IHubContext<ChatHub> _chatHub;
        public ConversationController(MSSQLDbContext context, IHubContext<ChatHub> chathub)
        {
            DBContext = context;
            _chatHub = chathub;
        }
        // GET api/values
        [HttpGet]
        public List<ChatHistory> Get()
        {
            var conversations = DBContext.ChatHistories.ToList();
            return conversations;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] ChatHistory chatHistory)
        {
            var newConversation = new ChatHistory
            {
                UserName = chatHistory.UserName,
                Message = chatHistory.Message,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            DBContext.ChatHistories.Add(newConversation);
            DBContext.SaveChanges();
            //_chatHub.Clients.All.InvokeAsync("Send", "<h3> Name: " + name + "</h3>" + message);
            //_chatHub.Send("<h3> Name: " + name + "</h3>" + message);
            return Json(new
            {
                success = true
            });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
