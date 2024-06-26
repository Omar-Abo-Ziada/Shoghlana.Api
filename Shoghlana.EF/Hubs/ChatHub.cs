using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Api.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IDictionary<string, UserRoomConnection> _connection;

        public ChatHub(IDictionary<string, UserRoomConnection> connection)
        {
            _connection = connection;
        }

        public async Task JoinRoom(UserRoomConnection UserConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName: UserConnection.Room!);
            _connection[Context.ConnectionId] = UserConnection;
            await Clients.Group(UserConnection.Room!)
                .SendAsync("ReceiveMessage", "Lets Program Bot",
                $"{UserConnection.User} has Joined The Group", DateTime.Now);
            await SendConnectedUser(UserConnection.Room!);
        }

        public async Task SendMessage(string message)
        {
            if (_connection.TryGetValue(Context.ConnectionId, out UserRoomConnection userRoomConnection))
            {
                await Clients.Group(userRoomConnection.Room!)
                    .SendAsync("ReceiveMessage", userRoomConnection.User, message, DateTime.Now);
            }
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            if (!_connection.TryGetValue(Context.ConnectionId, out UserRoomConnection roomConnection))
            {
                return base.OnDisconnectedAsync(exception);
            }
            _connection.Remove(Context.ConnectionId);
            Clients.Group(roomConnection.Room!)
                .SendAsync("ReceiveMessage", "Lets Program bot",
                "${ roomConnection.User} has Left The Group", DateTime.Now);
            SendConnectedUser(roomConnection.Room!);
            return base.OnDisconnectedAsync(exception);

        }
        public Task SendConnectedUser(string room)
        {
            var users = _connection.Values
                .Where(u => u.Room == room)
                .Select(s => s.User);
            return Clients.Group(room).SendAsync("ConnectedUser", users);
        }
    }
}
