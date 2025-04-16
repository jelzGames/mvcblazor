namespace MixedTeam.Models
{
    public class ChatMessageModel
    {
        public string idRoom { get; set; }
        public string Sender { get; set; }
        public string Text { get; set; } = "";
        public DateTime Timestamp { get; set; }
        public bool IsMine => Text.StartsWith("Me: ");
        
    }
}
