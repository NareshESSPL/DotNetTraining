using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Survey_System.Interfaces;
using Survey_System.DTO;

namespace SurveyFeedbackSystem.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ISurvey _surveyService;

        public SurveyController(ISurvey surveyService)
        {
            _surveyService = surveyService;
        }

        public async Task<IActionResult> Index()
        {
            var surveys = await _surveyService.GetAllSurveys();
            return View(surveys);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SurveyDTO dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _surveyService.AddSurvey(dto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Error: {ex.Message}. Inner Exception: {ex.InnerException?.Message}");
                    return View(dto);
                }
            }
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var survey = await _surveyService.GetSurveyById(id);
            return View(survey);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SurveyDTO dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _surveyService.UpdateSurvey(dto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _surveyService.DeleteSurvey(id);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}