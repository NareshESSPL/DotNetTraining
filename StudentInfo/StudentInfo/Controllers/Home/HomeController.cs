using System.Diagnostics;
using DataLayer;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using StudentInfo.Models;

namespace StudentInfo.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly LoginDAL _loginDAL;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _loginDAL = new LoginDAL(_configuration);
        }

        public IActionResult Index()
        {
            return View();
        }

        //controller for login 
        public IActionResult Login()
        {
            return View("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginAction(UserProfile user)
        {
            // Here you would typically validate the user credentials against a database
            // For simplicity, we are just logging the credential

            ModelState.Remove("UserId");
            ModelState.Remove("IsActive");

            if (!ModelState.IsValid) {
                

                return View("~/Views/Home/Index.cshtml",user);
            }

            bool credentialValidation = _loginDAL.CredsValid(user);

            if (!credentialValidation)
            {
                ModelState.AddModelError("", "Invalid credentials. Please try again.");
                return View("~/Views/Home/Index.cshtml", user); // Stay on login page with error message
            }


            user.IsActive = 1;
            
                _loginDAL.AddLogin(user);

            return RedirectToAction("Index", "Student");
        }
        
        public IActionResult CreateUser(UserProfile user)
        {
            if (ModelState.IsValid)
            {
                user.IsActive = 0;
                _loginDAL.AddLogin(user);

                return RedirectToAction("Index", "Student");
            }


            return View("~/Views/Home/CreateUser.cshtml", user);
        }

        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Login");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
