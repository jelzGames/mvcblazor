using MixedTeam.Interfaces;
using MixedTeam.Models;
using System.Collections.Generic;
using System.Reflection;

namespace MixedTeam.Services
{
  
    public class UserStoreServices: IUserStoreServices
    {
        public string SelectedUser { get; set; }
        public event Action<string>? OnUserUpdate;

        public List<string> ConnectedUsers { get; set; } = new List<string>();

        public async Task<bool> Add(string username)
        {
            if (!ConnectedUsers.Contains(username))
            {
                ConnectedUsers.Add(username);

                OnUserUpdate?.Invoke(username);

                return true;
            }

            return false;
        }

        public bool Remove(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                ConnectedUsers.Remove(username);

                OnUserUpdate?.Invoke(username);

                return true;
            }

            return false;
        }
    }

}
