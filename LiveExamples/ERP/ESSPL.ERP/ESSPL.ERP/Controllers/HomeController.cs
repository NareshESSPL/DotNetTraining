using ESSPL.DTO;
using ESSPL.DTO.IdentityManagement;
using ESSPL.Manager.IdentityManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ESSPL.ERP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IIdentityManager _identityManager;

        public HomeController(ILogger<HomeController> logger, IIdentityManager identityManager)
        {
            _logger = logger;
            _identityManager = identityManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginRequestDTO loginRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", loginRequestDto);
            }            

            var userProfileDto = _identityManager.GetUserProfile(loginRequestDto);

            if (userProfileDto != null & userProfileDto.IsActive)
            {
                var identity = new CustomUserIdentity(userProfileDto);
                var principal = new CustomPrincipal(identity);

                HttpContext.User = principal; // Assign identity to HttpContext

                return View("Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt");

            return View("Index", loginRequestDto);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            //reset identity
            HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
