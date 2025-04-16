namespace MixedTeam.Services
{
    public class ChatService
    {

        public List<string> Messages { get; } = new();
        public event Action? OnMessageAdded;

        public void AddMessage(string message)
        {
            Messages.Add(message);
            OnMessageAdded?.Invoke(); 
        }
    }
}
