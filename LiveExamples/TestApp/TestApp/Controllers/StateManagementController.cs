using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestApp.Controllers
{
    public class StateManagementController : Controller
    {
        /*
         * Used pass data to action methods with same or 
         * different controller
         * TempData allows data to persist across redirects.
         *                                
         * Unlike ViewData and ViewBag, TempData retains data until 
         * it is read.
        */
        public IActionResult Index()
        {
            #region Session

            /*
             * Add Session Services
             * 
             * To use session in program.cs in Main()
             * after this line " var builder = WebApplication.CreateBuilder(args);"
             * add the below code
                builder.Services.AddSession();

             *Use Session Middleware
             *In Main() method after this line "var app = builder.Build();"
             * add the below code
                app.UseSession();
            */

            //Set session
            HttpContext.Session.SetString("Username", "JohnDoe");
            HttpContext.Session.SetInt32("UserId", 123);

            //To clear one session
            //HttpContext.Session.Remove("Username");

            // Clears all session data
            //HttpContext.Session.Clear(); 

            //get seesion in next controller
            #endregion

            #region TempData

            TempData["Message"] = "Student created successfully!";
            return RedirectToAction("Index", "StateManagement2");

            #endregion
        }
    }
}
