using System.ComponentModel.DataAnnotations;

namespace MixedTeam.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is mandatory.")]
        public string Username { get; set; }

    }
}
