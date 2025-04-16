using MixedTeam.Models;

namespace MixedTeam.Interfaces
{
    public interface IUserStoreServices
    {
        string SelectedUser { get; set; }
        List<string> ConnectedUsers { get; set; }
        Task<bool> Add(string username);

        bool Remove(string username);

        event Action<string>? OnUserUpdate;
    }
}
