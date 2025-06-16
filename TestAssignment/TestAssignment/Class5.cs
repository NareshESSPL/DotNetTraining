using System;
using System.Collections.Generic;
using SurveyFeedbackSystem.DTO;

namespace SurveyFeedbackSystem.BusinessLogic
{
    public delegate void LogHandler(string message);

    public class SurveyManager : SurveyBase, ISurvey
    {
        private List<Survey> surveys = new List<Survey>();
        public event LogHandler Log;

        public override void DisplaySurveyDetails(Survey survey)
        {
            Console.WriteLine("Survey Details:");
            Console.WriteLine($"SurveyID: {survey.SurveyID}, SurveyTypeID: {survey.SurveyTypeID}, SurveyTypeName: {survey.SurveyTypeName}");
            Console.WriteLine($"ModifiedBy: {survey.ModifiedBy}, ModifiedDate: {survey.ModifiedDate}");
        }

        public void AddSurvey(Survey survey)
        {
            try
            {
                surveys.Add(survey);
                Log?.Invoke($"Survey with ID {survey.SurveyID} added.");
            }
            catch (Exception ex)
            {
                Log?.Invoke($"Error adding survey: {ex.Message}");
            }
        }

        public void UpdateSurvey(Survey survey)
        {
            try
            {
                var existing = surveys.Find(s => s.SurveyID == survey.SurveyID);
                if (existing != null)
                {
                    existing.SurveyTypeID = survey.SurveyTypeID;
                    existing.SurveyTypeName = survey.SurveyTypeName;
                    existing.ModifiedBy = survey.ModifiedBy;
                    existing.ModifiedDate = survey.ModifiedDate;

                    Log?.Invoke($"Survey with ID {survey.SurveyID} updated.");
                }
                else
                {
                    Log?.Invoke($"Survey with ID {survey.SurveyID} not found.");
                }
            }
            catch (Exception ex)
            {
                Log?.Invoke($"Error updating survey: {ex.Message}");
            }
        }

        public void DeleteSurvey(int surveyId)
        {
            try
            {
                var survey = surveys.Find(s => s.SurveyID == surveyId);
                if (survey != null)
                {
                    surveys.Remove(survey);
                    Log?.Invoke($"Survey with ID {surveyId} deleted.");
                }
                else
                {
                    Log?.Invoke($"Survey with ID {surveyId} not found.");
                }
            }
            catch (Exception ex)
            {
                Log?.Invoke($"Error deleting survey: {ex.Message}");
            }
        }
    }
}