using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SurveyNew.Interfaces;
using SurveyNew.Models;
using SurveyNew.Managers;

namespace Survey.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ISurvey _manager;
        private readonly ILogger<SurveyController> _logger;

        public SurveyController(ISurvey manager, ILogger<SurveyController> logger)
        {
            _manager = manager;
            _logger = logger;
            if (_manager is SurveyManager svc)
                svc.Logger = msg => _logger.LogInformation(msg);
        }

        public IActionResult Index() => View(_manager.GetAllSurveys());

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Surveyy s)
        {
            try
            {
                _manager.AddSurvey(s);
                _logger.LogInformation("Added survey ID {Id}", s.SurveyID);
                TempData["Success"] = "Survey added successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating survey");
                ViewBag.Error = ex.Message;
                return View(s);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _manager.GetAllSurveys().Find(x => x.SurveyID == id);
            return item == null ? NotFound() : View(item);
        }

        [HttpPost]
        public IActionResult Edit(Surveyy s)
        {
            if (!ModelState.IsValid) return View(s);
            try
            {
                _manager.UpdateSurvey(s);
                _logger.LogInformation("Updated survey ID {Id}", s.SurveyID);
                TempData["Success"] = "Survey updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating survey");
                ViewBag.Error = ex.Message;
                return View(s);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var survey = _manager.GetAllSurveys().FirstOrDefault(x => x.SurveyID == id);
            return survey == null ? NotFound() : View(survey);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _manager.DeleteSurvey(id);
                _logger.LogInformation("Deleted survey ID {Id}", id);
                TempData["Success"] = "Survey deleted successfully!";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting survey");
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

       
        [HttpGet]
        public IActionResult Details(int id)
        {
            var item = _manager.GetAllSurveys().FirstOrDefault(x => x.SurveyID == id);
            return item == null ? NotFound() : View(item);
        }
    }
}
