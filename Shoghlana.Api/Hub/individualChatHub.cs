//using Microsoft.AspNetCore.SignalR;
//using Shoghlana.Api.Services.Implementaions;
//using Shoghlana.Core.DTO;


//namespace Shoghlana.Api.Hubs
//{
//    public class individualChatHub : Hub
//    {
//        private readonly ChatServices _chatService;

//        public individualChatHub(ChatServices chatService)
//        {
//            _chatService = chatService;
//        }

//        public override async Task OnConnectedAsync()
//        {
//            await Groups.AddToGroupAsync(Context.ConnectionId, "come2chat");
//            await Clients.Caller.SendAsync("UserConnected");
//        }
//        public override async Task OnDisconnectedAsync(Exception? exception)
//        {
//            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "come2chat");
//            var user = _chatService.GetUserByConnectionID(Context.ConnectionId);
//            _chatService.RemoveUserFromList(user);
//            await DisplayOnlineUsers();
//            await base.OnDisconnectedAsync(exception);
//        }

//        public async Task AddUserConnectionId(string name)
//        {
//            _chatService.AddUserConnectionID(name, Context.ConnectionId);
//            await DisplayOnlineUsers();
//        }
//        public async Task ReceiveMessage(MessageDto message)
//        {
//            await Clients.Groups("come2chat").SendAsync("NewMessage", message);
//        }

//        public async Task createPrivateChat(MessageDto message)
//        {
//            string privateGroupName = GetPrivateGroupName(message.From, message.To);
//            await Groups.AddToGroupAsync(Context.ConnectionId, privateGroupName);
//            var toConnectoinId = _chatService.GetConnectionByUser(message.To);
//            await Groups.AddToGroupAsync(toConnectoinId, privateGroupName);

//            //opening Private Chatbox For other End Users
//            await Clients.Client(toConnectoinId).SendAsync("openPrivateChat", message);
//        }
//        public async Task ReceivePrivateMessage(MessageDto message)
//        {
//            string privateGroupName = GetPrivateGroupName(message.From, message.To);
//            await Clients.Group(privateGroupName).SendAsync("NewPrivateMessage", message);
//        }

//        public async Task RemovePrivateChat(string From, string To)
//        {
//            string privateGroupName = GetPrivateGroupName(From, To);
//            await Clients.Group(privateGroupName).SendAsync("ClosePrivateChat");
//            await Groups.RemoveFromGroupAsync(Context.ConnectionId, privateGroupName);
//            var toConnectionId = _chatService.GetConnectionByUser(To);
//            //await Groups.AddToGroupAsync(toConnectionId , privateGroupName);
//            await Groups.RemoveFromGroupAsync(toConnectionId, privateGroupName);

//        }
//        private async Task DisplayOnlineUsers()
//        {
//            var onlineUsers = _chatService.GetOnlineUsers();
//            await Clients.Groups("come2chat").SendAsync("OnlineUsers", onlineUsers);
//        }
//        private string GetPrivateGroupName(string From, string To)
//        {
//            var stringCompare = string.Compare(From, To) < 0;
//            return stringCompare ? $"{From}-{To}" : $"{To}-{From}";
//        }
//    }
//}

using Microsoft.AspNetCore.SignalR;
using Shoghlana.Api.Services.Implementaions;
using Shoghlana.Core.DTO;

namespace Shoghlana.Api.Hubs
{
    public class individualChatHub : Hub
    {
        private readonly ChatServices _chatService;

        public individualChatHub(ChatServices chatService)
        {
            _chatService = chatService;
        }

        public override async Task OnConnectedAsync()
        {
            // Add user to a general group for general notifications or updates
            await Groups.AddToGroupAsync(Context.ConnectionId, "come2chat");
            await Clients.Caller.SendAsync("UserConnected");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            // Remove user from the general group upon disconnection
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "come2chat");
            var user = _chatService.GetUserByConnectionID(Context.ConnectionId);
            _chatService.RemoveUserFromList(user);
            await DisplayOnlineUsers();
            await base.OnDisconnectedAsync(exception);
        }

        public async Task AddUserConnectionId(string name)
        {
            _chatService.AddUserConnectionID(name, Context.ConnectionId);
            await DisplayOnlineUsers();
        }

        public async Task ReceiveMessage(MessageDto message)
        {
            // Broadcast a message to the general group
            await Clients.Groups("come2chat").SendAsync("NewMessage", message);
        }

        public async Task CreatePrivateChat(MessageDto message)
        {
            // Create a unique group for the private chat session
            string privateGroupName = GetPrivateGroupName(message.From, message.To);
            await AddToPrivateGroup(privateGroupName, message.From, message.To);

            // Notify the recipient to open a private chat box
            var toConnectionId = _chatService.GetConnectionByUser(message.To);
            await Clients.Client(toConnectionId).SendAsync("openPrivateChat", message);
        }

        public async Task ReceivePrivateMessage(MessageDto message)
        {
            // Send a private message within the unique group
            string privateGroupName = GetPrivateGroupName(message.From, message.To);
            await Clients.Group(privateGroupName).SendAsync("NewPrivateMessage", message);
        }

        public async Task RemovePrivateChat(string from, string to)
        {
            // Remove users from the private chat group when the chat ends
            string privateGroupName = GetPrivateGroupName(from, to);
            await Clients.Group(privateGroupName).SendAsync("ClosePrivateChat");
            await RemoveFromPrivateGroup(privateGroupName, from, to);
        }

        private async Task AddToPrivateGroup(string privateGroupName, string from, string to)
        {
            var fromConnectionId = _chatService.GetConnectionByUser(from);
            var toConnectionId = _chatService.GetConnectionByUser(to);

            if (fromConnectionId != null)
            {
                await Groups.AddToGroupAsync(fromConnectionId, privateGroupName);
            }

            if (toConnectionId != null)
            {
                await Groups.AddToGroupAsync(toConnectionId, privateGroupName);
            }
        }

        private async Task RemoveFromPrivateGroup(string privateGroupName, string from, string to)
        {
            var fromConnectionId = _chatService.GetConnectionByUser(from);
            var toConnectionId = _chatService.GetConnectionByUser(to);

            if (fromConnectionId != null)
            {
                await Groups.RemoveFromGroupAsync(fromConnectionId, privateGroupName);
            }

            if (toConnectionId != null)
            {
                await Groups.RemoveFromGroupAsync(toConnectionId, privateGroupName);
            }
        }

        private async Task DisplayOnlineUsers()
        {
            var onlineUsers = _chatService.GetOnlineUsers();
            await Clients.Groups("come2chat").SendAsync("OnlineUsers", onlineUsers);
        }

        private string GetPrivateGroupName(string from, string to)
        {
            // Ensure unique group names for private chats
            var stringCompare = string.Compare(from, to) < 0;
            return stringCompare ? $"{from}-{to}-{Guid.NewGuid()}" : $"{to}-{from}-{Guid.NewGuid()}";
        }
    }
}
