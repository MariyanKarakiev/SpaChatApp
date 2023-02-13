using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SpaChatApp.Data;
using SpaChatApp.Hubs;

namespace SpaChatApp.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private AppDbContext _dbContext;
        private IHubContext<ChatHub> _hub;

        public ChatController(IHubContext<ChatHub> hub, AppDbContext dbContext)
        {
            _hub = hub;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var messages =  _dbContext.Messages.Select(x=>x.User).ToList();
            var users = _hub.Clients.All.GetType().GetMembers();
            await _hub.Clients.All.SendAsync("chatApi", string.Join("\n", messages));
            
            return Ok(new { Message = "Request Completed" });
        }

        [HttpPost]
        public async Task<ActionResult> PostTodoItem()
        {
            _dbContext.Add<Message>(new Message() { User = "ne", TextMessage = "dfjdkjf" });
            await _dbContext.SaveChangesAsync();
            Get();
            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return Ok();
        }
    }
}
