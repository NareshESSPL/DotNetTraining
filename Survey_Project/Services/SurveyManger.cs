
using Survey_Project.Models;
using System;
using System.Collections.Generic;
using Survey_Project.Delegates;
namespace Survey_Project.Services
{
    using Survey_Project.Controllers;
    using Survey_Project.Models;

    public class SurveyManager : SurveyBase, ISurvey
    {
        private List<Survey> surveys = new List<Survey>();
        public event SurveyDelegates.LogHandler LogEvent;

        public void AddSurvey(Survey survey)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(survey.SurveyTypeName))
                    throw new ArgumentException("SurveyTypeName cannot be empty.");

                surveys.Add(survey);
                LogEvent?.Invoke($"Survey added successfully. ID: {survey.SurveyID}");
            }
            catch (Exception ex)
            {
                LogEvent?.Invoke($"Error : {ex.Message}");
            }
        }

        public void UpdateSurvey(Survey survey)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(survey.SurveyTypeName))
                    throw new ArgumentException("SurveyTypeName cannot be empty.");

                var existingSurvey = surveys.Find(s => s.SurveyID == survey.SurveyID);
                if (existingSurvey != null)
                {
                    existingSurvey.SurveyTypeID = survey.SurveyTypeID;
                    existingSurvey.SurveyTypeName = survey.SurveyTypeName;
                    existingSurvey.ModifiedBy = survey.ModifiedBy;
                    existingSurvey.ModifiedDate = survey.ModifiedDate;
                    LogEvent?.Invoke($"Survey updated successfully. ID: {survey.SurveyID}");
                }
                else
                {
                    LogEvent?.Invoke("Survey not found.");
                }
            }
            catch (Exception ex)
            {
                LogEvent?.Invoke($"Error updating survey: {ex.Message}");
            }
        }

        public void DeleteSurvey(int surveyId)
        {
            try
            {
                var surveyToRemove = surveys.Find(s => s.SurveyID == surveyId);
                if (surveyToRemove != null)
                {
                    surveys.Remove(surveyToRemove);
                    LogEvent?.Invoke($"Survey deleted successfully. ID: {surveyId}");
                }
                else
                {
                    LogEvent?.Invoke("Survey not found.");
                }
            }
            catch (Exception ex)
            {
                LogEvent?.Invoke($"Error deleting survey: {ex.Message}");
            }
        }

        public override void DisplaySurveyDetails()
        {
            foreach (var s in surveys)
            {
                Console.WriteLine($"ID: {s.SurveyID}, TypeID: {s.SurveyTypeID}, Name: {s.SurveyTypeName}, ModifiedBy: {s.ModifiedBy}, Date: {s.ModifiedDate}");
            }
        }
    }

}

