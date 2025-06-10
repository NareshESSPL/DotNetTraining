using Microsoft.AspNetCore.Mvc;
using DTO;
using DAL;


namespace Survey.Controllers
    {
        public class StudentController : Controller
        {
            private readonly IConfiguration _configuration;
            private readonly ILogger<StudentController> _logger;
            private readonly surveyDAL sDAL;
            public StudentController(ILogger<StudentController> logger, IConfiguration configuration)
            {
                _logger = logger;
                _configuration = configuration;
              sDAL = new surveyDAL(_configuration);
            }
            public IActionResult Index()
            {
                return View();

            }
            
            public IActionResult Create(Survey s)
            {
                if (ModelState.IsValid)
                {
                    sDAL.AddSurvey(s);
                    return RedirectToAction("Index");

                }
                return View();
            }
            
            [HttpGet]
            public IActionResult Update(Survey s) 
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                  
                        sDAL.Updatesurvey(s);
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                       
                        ModelState.AddModelError("", "An error occurred while updating the student: " + ex.Message);
                        return View(s);
                    }
                }
                return View(s);
            }
            
            public IActionResult Delete(int SurveyID)
            {
                if (SurveyID == 0) 
                {
                    return NotFound(); 
                }

                Survey s = s.DeleteSurvey(SurveyID);
                return View(s); 
            }
          
        
         
            
        }
    }

