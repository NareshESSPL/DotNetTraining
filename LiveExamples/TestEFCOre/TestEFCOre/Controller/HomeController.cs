using Microsoft.AspNetCore.Mvc;
using TestEfCore.Manager;
using TestEFCore.Repository;

namespace TestEFCore
{
    public class HomeController : Controller
    {
        private readonly IUserManager _userManager;

        public HomeController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {          
            var users = _userManager.GetUsers();

            return View(users);
        }
    }
}
