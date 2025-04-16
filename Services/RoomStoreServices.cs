using MixedTeam.Interfaces;
using MixedTeam.Models;

namespace MixedTeam.Services
{
    public class RoomStoreServices : IRoomStoreServices
    {
        public List<RoomModel> Rooms { get; set; } = new List<RoomModel>();
        public Dictionary<string, List<ChatMessageModel>> RoomMessages { get; set; } = new Dictionary<string, List<ChatMessageModel>>();

        public event Action<ChatMessageModel>? OnMessageAdded;

        public string FindRoom(List<string> users)
        {
            var matchedRoom = Rooms.FirstOrDefault(room =>
                room.UserNames.Count == users.Count &&
                !room.UserNames.Except(users).Any() &&
                !users.Except(room.UserNames).Any());

            if (matchedRoom != null)
            {
                return matchedRoom.Id; 
            }
           
            RoomModel room = new RoomModel();
            room.UserNames = users;
            room.Id = Guid.NewGuid().ToString();

            Rooms.Add(room);
            RoomMessages.Add(room.Id, new List<ChatMessageModel>());
            
            return room.Id;
        }

        public void AddNewMessage(ChatMessageModel message)
        {
            RoomMessages[message.idRoom].Add(message);
            OnMessageAdded?.Invoke(message);
        }
    }
}
