using ChatDemoAPI.Hubs;
using ChatDemoAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatDemoAPI.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHubContext<SignalHub> _hubContext;

        public HomeController(IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
        }


        [HttpGet]
        [Route("PushEmployee")]
        public IActionResult PushEmployee(int Id, string Name, string Address)
        {
            Emloyee emloyee = new Emloyee();
            emloyee.Id = Id;
            emloyee.Name = Name;
            emloyee.Address = Address;

            _hubContext.Clients.All.SendAsync("ReceiveEmployee", emloyee);
            return Ok(emloyee);
        }

        [HttpGet]
        [Route("PushMessage")]
        public IActionResult PushMessage(string Message)
        {
            _hubContext.Clients.All.SendAsync("ReceiveMessage", Message);
            return Ok(Message);
        }
    }
}
