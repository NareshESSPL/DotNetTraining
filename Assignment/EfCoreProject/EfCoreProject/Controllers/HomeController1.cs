using Microsoft.AspNetCore.Mvc;

namespace EfCoreProject.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
