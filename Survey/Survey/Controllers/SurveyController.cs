using Microsoft.AspNetCore.Mvc;
using Survey.Managers;
using Survey.Models;
using System;

namespace Survey.Controllers
{
    public class SurveyController : Controller
    {
        // ✅ Create an instance of SurveyManager
        private static readonly SurveyManager _manager = new SurveyManager();

        public SurveyController()
        {
            // ✅ Assign logger delegate
            _manager.Logger = LogToConsole;
        }

        // ✅ Display all surveys
        public IActionResult Index()
        {
            var surveys = _manager.GetAllSurveys();
            return View(surveys);
        }

        // ✅ Show form to create new survey
        public IActionResult Create()
        {
            return View();
        }

        // ✅ Handle create form submission
        [HttpPost]
        public IActionResult Create(Survey.Models.Survey survey)
        {
            try
            {
                _manager.AddSurvey(survey);
                TempData["Success"] = "Survey added successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(survey);
            }
        }

        // ✅ Show form to edit an existing survey
        public IActionResult Edit(int id)
        {
            var survey = _manager.GetAllSurveys().Find(s => s.SurveyID == id);
            if (survey == null)
            {
                return NotFound();
            }
            return View(survey);
        }

        // ✅ Handle edit form submission
        [HttpPost]
        public IActionResult Edit(Survey.Models.Survey survey)
        {
            try
            {
                _manager.UpdateSurvey(survey);
                TempData["Success"] = "Survey updated successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(survey);
            }
        }

        // ✅ Handle delete request
        public IActionResult Delete(int id)
        {
            try
            {
                _manager.DeleteSurvey(id);
                TempData["Success"] = "Survey deleted successfully.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction("Index");
        }

        // ✅ Console log method
        private void LogToConsole(string message)
        {
            Console.WriteLine($"[LOG {DateTime.Now}] {message}");
        }
    }
}
