using DTO;
using Microsoft.AspNetCore.Mvc;
using Repositry;

namespace SurveyFeedBackSystem.Controllers
{


    public class SurveyController : Controller
    {
        private readonly Isurvey _SurveyRepo;
        public delegate IActionResult Loggger();

        Loggger logger;

        SurveyController()
        {
            _SurveyRepo = new SurveyManager();
            logger += Index;
            logger += create;
            logger += Delete;
            logger += Update;

        }


        public IActionResult Index()
        {
            return View(_SurveyRepo.GetAllSurveyDetails());
        }

        [HttpPost]
        public IActionResult create(Survey survey)
        {
            if(ModelState.IsValid)
            {
                _SurveyRepo.AddSurvey(survey);
                return RedirectToAction("Index");
            }
            return View(survey);   
           
        }

        [HttpGet]
        public IActionResult create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _SurveyRepo.DeleteSurvey(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Update(Survey survey)
        {
           _SurveyRepo.UpdateSurvey(survey);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
    }
}
