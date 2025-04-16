using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using MixedTeam.Interfaces;
using MixedTeam.Services;
using static System.Net.WebRequestMethods;

namespace MixedTeam.Components
{
    public partial class UserList
    {
        [Inject]
        IUserStoreServices Services { get; set; }

        [Parameter]
        public string CurrentUser { get; set; }

        [Inject]
        HttpClient Http {  get; set; }

        [Inject]
        NavigationManager Navigation {  get; set; }

        [Inject]
        IRoomStoreServices RoomStoreServices { get; set; }

        private string? SelectedUser;

        protected override void OnInitialized()
        {
            Services.OnUserUpdate += UpdateUsers;
        }

        private void UpdateUsers(string currentuser)
        {
            if (CurrentUser != currentuser)
            {
                InvokeAsync(StateHasChanged);
            }
        }

        private async Task SelectRoom(string guest)
        {
            Services.SelectedUser = guest;

            var users = new List<string> { CurrentUser, guest };
            var idRoom = RoomStoreServices.FindRoom(users);

            await InvokeAsync(() =>
            {
                Navigation.NavigateTo($"/Home/Main?guest={Uri.EscapeDataString(guest)}", true);
            });


            /* http post
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("guest", guest),
                new KeyValuePair<string, string>("me", CurrentUser)
            });

            var baseUri = Navigation.BaseUri; 
            await Http.PostAsync($"{baseUri}SelectRoom", content);*/
        }

        public void Dispose()
        {
            Services.OnUserUpdate += UpdateUsers;
        }
    }
}
