using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class AccountController : Controller
    {

        public AccountController()
        {
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                if (model.Email == "naresh@email.com" && model.Password == "123")
                {
                    var identity = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, "Naresh"),
                            new Claim(ClaimTypes.Email, "naresh@email.com"),
                            new Claim(ClaimTypes.Role, "Admin")
                        }, "CustomAuth");

                    var principal = new ClaimsPrincipal(identity);
                    HttpContext.User = principal;

                    return RedirectToAction("SecureMethod", "TestAuth");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Login");
        }
    }
}