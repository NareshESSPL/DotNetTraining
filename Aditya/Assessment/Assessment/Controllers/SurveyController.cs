using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Assessment.Models;
using DataLayer;
using DTO;

namespace Assessment.Controllers
{
    namespace YourProjectName.Web.Controllers
    {
        public class SurveyController : Controller
        {
            private readonly ISurveyRepository _surveyRepository;

            public SurveyController(ISurveyRepository surveyRepository)
            {
                _surveyRepository = surveyRepository;
            }

            public SurveyController()
            {
                _surveyRepository = new SurveyRepository(Console.WriteLine); 
            }


            // GET: Survey
            public ActionResult Index()
            {
                // Retrieve all surveys
                List<Survey> surveys = _surveyRepository.GetAllSurveys();
                return View(surveys);
            }

            // GET: Survey/Details/5
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    TempData["ErrorMessage"] = "Survey ID not provided.";
                    return RedirectToAction("Index");
                }

                Survey survey = _surveyRepository.GetSurveyById(id.Value);
                if (survey == null)
                {
                    TempData["ErrorMessage"] = $"Survey with ID {id} not found.";
                    return RedirectToAction("Index");
                }
                return View(survey);
            }

            // GET: Survey/Create
            public ActionResult Create()
            {
                // Populate SurveyTypes for the dropdown
                var surveyTypes = _surveyRepository.GetAllSurveyTypes();
                var viewModel = new SurveyViewModel
                {
                    SurveyTypes = surveyTypes.Select(st => new SelectListItem
                    {
                        Value = st.SurveyTypeID.ToString(),
                        Text = st.SurveyTypeName
                    }).OrderBy(item => item.Text) // Order the dropdown items alphabetically
                };
                return View(viewModel);
            }

            // POST: Survey/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(SurveyViewModel viewModel)
            {
                if (ModelState.IsValid)
                {
                    // Convert ViewModel to DTO
                    var survey = new Survey
                    {
                        SurveyTypeID = viewModel.SurveyTypeID,
                        SurveyName = viewModel.SurveyName,
                        ModifiedBy = viewModel.ModifiedBy,
                        ModifiedDate = viewModel.ModifiedDate
                    };

                    int newSurveyId = _surveyRepository.AddSurvey(survey);
                    if (newSurveyId > 0)
                    {
                        TempData["SuccessMessage"] = $"Survey '{survey.SurveyName}' added successfully!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Failed to add survey. Survey Name might be empty or a database error occurred.";
                    }
                }

                // If validation failed or add failed, re-populate SurveyTypes and return view
                viewModel.SurveyTypes = _surveyRepository.GetAllSurveyTypes().Select(st => new SelectListItem
                {
                    Value = st.SurveyTypeID.ToString(),
                    Text = st.SurveyTypeName
                }).OrderBy(item => item.Text);
                return View(viewModel);
            }

            // GET: Survey/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    TempData["ErrorMessage"] = "Survey ID not provided.";
                    return RedirectToAction("Index");
                }

                Survey survey = _surveyRepository.GetSurveyById(id.Value);
                if (survey == null)
                {
                    TempData["ErrorMessage"] = $"Survey with ID {id} not found.";
                    return RedirectToAction("Index");
                }

                // Convert DTO to ViewModel for editing
                var viewModel = new SurveyViewModel
                {
                    SurveyID = survey.SurveyID,
                    SurveyTypeID = survey.SurveyTypeID,
                    SurveyName = survey.SurveyName,
                    ModifiedBy = survey.ModifiedBy,
                    ModifiedDate = survey.ModifiedDate,
                    SurveyTypes = _surveyRepository.GetAllSurveyTypes().Select(st => new SelectListItem
                    {
                        Value = st.SurveyTypeID.ToString(),
                        Text = st.SurveyTypeName
                    }).OrderBy(item => item.Text)
                };
                return View(viewModel);
            }

            // POST: Survey/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(SurveyViewModel viewModel)
            {
                if (ModelState.IsValid)
                {
                    // Convert ViewModel to DTO
                    var survey = new Survey
                    {
                        SurveyID = viewModel.SurveyID,
                        SurveyTypeID = viewModel.SurveyTypeID,
                        SurveyName = viewModel.SurveyName,
                        ModifiedBy = viewModel.ModifiedBy,
                        ModifiedDate = viewModel.ModifiedDate
                    };

                    if (_surveyRepository.UpdateSurvey(survey))
                    {
                        TempData["SuccessMessage"] = $"Survey '{survey.SurveyName}' updated successfully!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Failed to update survey. Survey Name might be empty or a database error occurred.";
                    }
                }

                // If validation failed or update failed, re-populate SurveyTypes and return view
                viewModel.SurveyTypes = _surveyRepository.GetAllSurveyTypes().Select(st => new SelectListItem
                {
                    Value = st.SurveyTypeID.ToString(),
                    Text = st.SurveyTypeName
                }).OrderBy(item => item.Text);
                return View(viewModel);
            }

            // GET: Survey/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    TempData["ErrorMessage"] = "Survey ID not provided.";
                    return RedirectToAction("Index");
                }

                Survey survey = _surveyRepository.GetSurveyById(id.Value);
                if (survey == null)
                {
                    TempData["ErrorMessage"] = $"Survey with ID {id} not found.";
                    return RedirectToAction("Index");
                }
                return View(survey);
            }

            // POST: Survey/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                if (_surveyRepository.DeleteSurvey(id))
                {
                    TempData["SuccessMessage"] = $"Survey ID {id} deleted successfully!";
                }
                else
                {
                    TempData["ErrorMessage"] = $"Failed to delete Survey ID {id}. It might not exist.";
                }
                return RedirectToAction("Index");
            }
        }
    }

}



