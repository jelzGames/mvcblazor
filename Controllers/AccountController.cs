using Microsoft.AspNetCore.Mvc;
using MixedTeam.Interfaces;
using MixedTeam.Models;

namespace MixedTeam.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserStoreServices UserStoreServices;

        public AccountController(IUserStoreServices userStoreServices)
        {
            UserStoreServices = userStoreServices;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var username = HttpContext.Session.GetString("Username");

            if (!string.IsNullOrEmpty(username))
            {
                return View("Main");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (UserStoreServices.ConnectedUsers.Contains(model.Username))
            {
                ModelState.AddModelError(nameof(model.Username), "Username is already in use.");
                return View(model);
            }

            UserStoreServices.Add(model.Username);

            HttpContext.Session.SetString("Username", model.Username);
            return RedirectToAction("Main", "Home");
        }

        public IActionResult Logout()
        {
            var username = HttpContext.Session.GetString("Username");

            if (!string.IsNullOrEmpty(username))
            {
                UserStoreServices.Remove(username);
                HttpContext.Session.Clear();
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
