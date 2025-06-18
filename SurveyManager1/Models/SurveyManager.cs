using System;
using System.Collections.Generic;
using SurveyManager1.Models;
using SurveyManager1;
using SurveyManager1.Models;

public delegate void LogHandler(string message);

public class SurveyManager : SurveyBase, ISurvey
{
    private readonly List<Survey> _surveys = new();
    public event LogHandler? OnLog;
    public override void DisplaySurveyDetails(Survey survey)
    {
        if (survey == null)
        {
            OnLog?.Invoke("Survey is null.");
            return;
        }
        Console.WriteLine($"ID: {survey.SurveyID}, Name: {survey.SurveyTypeName}, Modified By: {survey.ModifiedBy}, Modified Date: {survey.ModifiedDate}");
    }

    public void AddSurvey(Survey survey)
    {
        if (string.IsNullOrWhiteSpace(survey?.SurveyTypeName))
        {
            OnLog?.Invoke("Survey name cannot be empty.");
            throw new ArgumentException("Survey name cannot be empty.");
        }
        _surveys.Add(survey);
        OnLog?.Invoke($"Survey '{survey.SurveyTypeName}' added.");
    }
    public void UpdateSurvey(Survey survey)
    {
        if (string.IsNullOrWhiteSpace(survey?.SurveyTypeName))
        {
            OnLog?.Invoke("Survey name cannot be empty.");
            throw new ArgumentException("Survey name cannot be empty.");
        }
        var existing = _surveys.Find(s => s.SurveyID == survey.SurveyID);
        if (existing != null)
        {
            existing.SurveyTypeName = survey.SurveyTypeName;
            existing.ModifiedBy = survey.ModifiedBy;
            existing.ModifiedDate = survey.ModifiedDate;
            OnLog?.Invoke($"Survey '{survey.SurveyTypeName}' updated.");
        }
        else
        {
            OnLog?.Invoke("Survey not found.");
            throw new KeyNotFoundException("Survey not found.");
        }
    }
    public void DeleteSurvey(int surveyId)
    {
        var survey = _surveys.Find(s => s.SurveyID == surveyId);
        if (survey != null)
        {
            _surveys.Remove(survey);
            OnLog?.Invoke($"Survey with ID {surveyId} deleted.");
        }
        else
        {
            OnLog?.Invoke("Survey not found.");
            throw new KeyNotFoundException("Survey not found.");
        }
    }
}
