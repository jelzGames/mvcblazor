using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MixedTeam.Interfaces;
using MixedTeam.Models;
using MixedTeam.Services;
using System.Linq;

namespace MixedTeam.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserStoreServices UserStoreServices;

        public HomeController(IUserStoreServices userStoreServices)
        {
            UserStoreServices = userStoreServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Main()
        {
            var username = HttpContext.Session.GetString("Username");

            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Index");
            }

            ViewBag.Username = username;
            ViewBag.Users = UserStoreServices.ConnectedUsers;
            return View();
        }

        
        [HttpGet]
        public IActionResult Main(string guest)
        {
            ViewBag.guest = guest;
            return View("Main");
        }

        /*
        [HttpPost("SelectRoom")]
        public IActionResult SelectRoom(string guest, string me)
        {
            ViewBag.guest = guest;
            ViewBag.me = me;
            return View("Main");
        }*/
    }
}
