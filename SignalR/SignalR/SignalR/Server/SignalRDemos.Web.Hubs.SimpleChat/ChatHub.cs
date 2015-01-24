using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalRDemos.Web.Hubs.SimpleChat
{
    //[HubName("ChatHub")]
    public class ChatHub : Hub
    {
        private static readonly ConcurrentDictionary<string, UserData> Users =
            new ConcurrentDictionary<string, UserData>();

        private static int _usersCount;

        public override Task OnConnected()
        {
            Interlocked.Increment(ref _usersCount);
            var user = new UserData
            {
                Id = Context.ConnectionId,
                Active = true,
                Name = "user" + _usersCount,
                Image = GravatarHelpers.GetImage(null),
                ConnectedAt = DateTime.Now
            };
            Users[Context.ConnectionId] = user;

            var notifyAll = (Task) Clients.All.NewUserNotification(user);
            var sendAllUsers = (Task) Clients.Caller.Welcome(user.Name, Users.Values.ToArray());
            return notifyAll.ContinueWith(_ => sendAllUsers);
        }

        public override Task OnDisconnected()
        {
            UserData user;
            if (Users.TryRemove(Context.ConnectionId, out user))
            {
                return Clients.All.UserDisconnectedNotification(user);
            }
            return base.OnDisconnected();
        }

        public Task ChangeNickname(string newName)
        {
            UserData user;
            if (Users.TryGetValue(Context.ConnectionId, out user))
            {
                string oldName = user.Name;
                user.Name = newName;
                return Clients.All.NicknameChangedNotification(user, oldName);
            }
            return null;
        }

        public Task ChangeImage(string email)
        {
            UserData user;
            if (Users.TryGetValue(Context.ConnectionId, out user))
            {
                user.Image = GravatarHelpers.GetImage(email);
                return Clients.All.ImageChangedNotification(user);
            }
            return null;
        }

        public Task Send(string message)
        {
            UserData user;
            if (Users.TryGetValue(Context.ConnectionId, out user))
            {
                string msgToSend = string.Format("[{0}]: {1}", user.Name, message);
                return Clients.All.Message(msgToSend);
            }
            return null;
        }
    }

    internal class UserData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime ConnectedAt { get; set; }
        public string Image { get; set; }
    }
}