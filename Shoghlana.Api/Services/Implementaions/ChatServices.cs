namespace Shoghlana.Api.Services.Implementaions
{
    public class ChatServices
    {
        private static readonly Dictionary<string ,string> Users = new Dictionary<string ,string>();

        public bool AddUsersToList(string userToAdd)
        {
            lock (Users)
            {
                foreach (var user in Users)
                {
                    if (user.Key.ToLower() == userToAdd.ToLower())
                    {
                        return false;
                    }
                }
                Users.Add(userToAdd, null) ;
                return true;
            }
        }
        public void AddUserConnectionID (string user,string connectionID) 
        {
            lock (Users)
            {
                if (Users.ContainsKey(user))
                {
                    Users[user] = connectionID;
                }
            }
        }

        public string GetUserByConnectionID(string connectionId)
        {
            lock(Users)
            {
                return Users.Where(x=>x.Value == connectionId).Select(x=>x.Key).FirstOrDefault();
            }
        }
        public string GetConnectionByUser (string user)
        {
            lock (Users)
            {
                return Users.Where(x => x.Key == user).Select(x => x.Value).FirstOrDefault();
            }
        }

        public void RemoveUserFromList(string user)
        {
            lock( Users)
            {
                if(Users.ContainsKey(user))
                {
                    Users.Remove(user);
                }
            }
        }

        public string[] GetOnlineUsers()
        {
            lock (Users)
            {
                return Users.OrderBy(x => x.Key).Select(x=> x.Key).ToArray();
            }
        }
    }
}
