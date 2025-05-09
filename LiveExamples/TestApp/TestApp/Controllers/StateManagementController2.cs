using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace TestApp.Controllers
{
    public class StateManagement2Controller : Controller
    {
        public IActionResult Index()
        {
            #region TempData

            //ViewBag is dynamic type, hence not type safe
            string tempdata = TempData["Message"] as string;
            ViewBag.Message2 = tempdata;

            //Once read tempdat will lose data
            //You can use TempData.Keep() to retain values for
            //multiple reques
            TempData.Keep();

            #endregion

            #region ViewData

            List<string> messages = new List<string>()
            { "Hello" , "User" };

            //It preserve type i.e. you can type cast to original type in view
            ViewData["Message"] = messages;

            #endregion

            #region Session

            ViewBag.User = HttpContext.Session.GetString("Username");

            HttpContext.Session.Remove("Username");

            #endregion

            return View();
        }
    }
}
