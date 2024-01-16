using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalR.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message) 
        {
            await Clients.All.SendAsync("ReceivedMessage", message);
        }
        public Task AddGroup(string group)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public Task RemoveGroup(string groupName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendMessageToGroup(string groupName, string message)
        {
            await Clients.Group(groupName).SendAsync("ReceivedMessage", message);
        }
    }
}
