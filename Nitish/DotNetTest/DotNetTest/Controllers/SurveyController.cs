using Microsoft.AspNetCore.Mvc;

namespace DotNetTest.Controllers
{

    public class SurveyController : Controller
    {
        private readonly ILogger<SurveyController> _logger;

        public SurveyController(ILogger<SurveyController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create() 
        {
            if (ModelState.IsValid) { 
            
            }
        
            return View();
        }
        public IActionResult Submit(int id )
        {

            return View();
        }
        



    }
}
