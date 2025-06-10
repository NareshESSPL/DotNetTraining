using Microsoft.AspNetCore.Mvc;

namespace Survey.Controllers
{
    public class SurveyController : Controller
    {
        SurveyManager manager = new SurveyManager();
        
        public IActionResult Details()
        {
            manager.SurveyDetails();
            return View();
        }
        public IActionResult ADD()
        {
           
            return View();
        }
        public IActionResult Update()
        {
            
            return View();
        }
        public void  Delete()
        {
          
            RedirectToAction("Details");
        }
       
    }
}
