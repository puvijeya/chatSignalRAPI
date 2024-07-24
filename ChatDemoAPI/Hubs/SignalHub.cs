using ChatDemoAPI.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatDemoAPI.Hubs
{
    public class SignalHub : Hub
    {
        public void BroadcastEmployee(Emloyee employee)
        {
            Clients.All.SendAsync("ReceiveEmployee", employee);
        }

        public void BroadcastMessage(string message)
        {
            Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
