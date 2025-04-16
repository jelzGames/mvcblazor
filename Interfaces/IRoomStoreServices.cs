using MixedTeam.Models;

namespace MixedTeam.Interfaces
{
    public interface IRoomStoreServices
    {
        List<RoomModel> Rooms { get; set; }

        Dictionary<string, List<ChatMessageModel>> RoomMessages { get; set; }

        string FindRoom(List<string> users);
        public void AddNewMessage(ChatMessageModel message);

        public event Action<ChatMessageModel>? OnMessageAdded;

    }
}
