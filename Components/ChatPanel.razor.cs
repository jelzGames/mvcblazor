using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR;
using Microsoft.JSInterop;
using MixedTeam.Interfaces;
using MixedTeam.Models;

namespace MixedTeam.Components
{
    public partial class ChatPanel: IDisposable
    {
        [Inject]
        IRoomStoreServices RoomStoreServices { get; set; }

        [Inject]
        IJSRuntime JS { get; set; }

        [Parameter]
        public string guest { get; set; }

        [Parameter]
        public string me { get; set; }

        [Parameter]
        public string idRoom { get; set; }

        private string newMessage = string.Empty;

        protected override void OnInitialized()
        {
       
            CheckIfChatExist();

            RoomStoreServices.OnMessageAdded += RoomStoreServices_OnMessageAdded;

        }

        private void RoomStoreServices_OnMessageAdded(ChatMessageModel message)
        {
            if (idRoom == message.idRoom && me != message.Sender)
            {
                InvokeAsync(StateHasChanged);
            }
        }

        private void CheckIfChatExist()
        {
            var users = new List<string> { me, guest };
            idRoom = RoomStoreServices.FindRoom(users);
        }

        private async Task SendMessage()
        {
            if (!string.IsNullOrWhiteSpace(newMessage))
            {
                RoomStoreServices.AddNewMessage(
                    new ChatMessageModel
                    {
                        idRoom = idRoom,
                        Sender = me,
                        Text = newMessage,
                        Timestamp = DateTime.Now
                    }
                );

                newMessage = string.Empty;

                await JS.InvokeVoidAsync("scrollToBottom");
            }
        }

        private async Task HandleEnter(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                await SendMessage();
            }
        }

        public void Dispose()
        {
            RoomStoreServices.OnMessageAdded -= RoomStoreServices_OnMessageAdded;
        }
    }
}
