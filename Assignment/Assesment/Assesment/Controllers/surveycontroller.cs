using Microsoft.AspNetCore.Mvc;
using Assesment;
using Assesment.DTO;

namespace Assesment.Controllers
{
    public class SurveyController : Controller
    {
        private readonly SurveyManager manager;
        public SurveyController()
        {
            manager = new SurveyManager();
        }

        public IActionResult Details(int id)
        {
            // Added a new method GetSurveyById in SurveyManager to resolve the error
            var survey = manager.GetSurveyById(id);
            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        public IActionResult Index()
        {
            var surveys = manager.GetAllSurveys();
            return View(surveys);
        }
    }

    public class SurveyManager : DTO.survey, Isurvey
    {
        public void Add() { }
        public void Update() { }
        public void Delete() { }
        public void DisplaySurveyDetails() { }
        public void AddSurvey() { }
        public void UpdateSurvey() { }
        public void DeleteSurvey() { }
        private void AddSurvey(SurveyManager survey) { }
        private void UpdateSurvey(SurveyManager survey) { }
        private void DeleteSurvey(int surveyID) { }

        // Added GetSurveyById method to resolve the error
        public survey GetSurveyById(int id)
        {
            // Simulated logic to fetch a survey by ID
            return new survey
            {
                SurveyID = id,
                SurveyTypeID = 1,
                SurveyTypeName = "Sample Survey",
                ModifiedBy = "Admin",
                ModifiedDate = "2023-01-01"
            };
        }

        // Added GetAllSurveys method to support the Index action
        public List<survey> GetAllSurveys()
        {
            return new List<survey>
            {
                new survey
                {
                    SurveyID = 1,
                    SurveyTypeID = 1,
                    SurveyTypeName = "Survey 1",
                    ModifiedBy = "Admin",
                    ModifiedDate = "2023-01-01"
                },
                new survey
                {
                    SurveyID = 2,
                    SurveyTypeID = 2,
                    SurveyTypeName = "Survey 2",
                    ModifiedBy = "Admin",
                    ModifiedDate = "2023-01-02"
                }
            };
        }
    }
}
