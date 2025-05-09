using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestApp.Controllers
{
    [Authorize(Roles = "Admin")] //Requires authentication for the entire controller 
    public class TestAuthController : Controller
    {
        [AllowAnonymous]
        public string NonSecureMethod()
        {
            return "This method can be accessed by everyone as it is non-secure method";
        }

        public string SecureMethod()
        {
            return "This method needs to be access by authorized users as it SecureMethod";
        }

        public string SecureMethod2()
        {
            return "This method needs to be access by authorized users as it SecureMethod";
        }
    }
}
