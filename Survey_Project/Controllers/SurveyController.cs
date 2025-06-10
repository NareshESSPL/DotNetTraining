using System;
using Microsoft.AspNetCore.Mvc;
using Survey_Project.Models;
using Survey_Project.Interface;

namespace Survey_Project.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ISurvey _surveyManager;

        public SurveyController(ISurvey surveyManager)
        {
            _surveyManager = surveyManager;
        }

        public IActionResult Index()
        {
            // Example usage
            var survey = new Survey
            {
                SurveyID = 1,
                SurveyTypeID = 101,
                SurveyTypeName = "Customer Feedback",
                ModifiedBy = "Admin",
                ModifiedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            _surveyManager.AddSurvey(survey);

            return View();
        }
    }
}
