using Microsoft.AspNetCore.SignalR;

namespace SpaChatApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
            => await Clients.All.SendAsync("chatApi", user, message);
    }
}
