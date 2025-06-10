using SurveySystem.Abstracts;
using SurveySystem.DTO;
using SurveySystem.Interfaces;
using System;
using System.Collections.Generic;
using static SurveySystem.Delegates.LoggerDelegates;

public class SurveyManager : SurveyBase, ISurvey
{
    private List<SurveyDTO> surveys = new List<SurveyDTO>();
    private List<SurveyTypeDTO> surveyTypes = new List<SurveyTypeDTO>();
    public LogHandler Logger;

    public void AddSurvey(SurveyDTO dto)
    {
        surveys.Add(dto);
        Logger?.Invoke($"Survey with ID {dto.SurveyID} added.");
    }

    public void UpdateSurvey(SurveyDTO dto)
    {
        var existing = surveys.Find(s => s.SurveyID == dto.SurveyID);
        if (existing != null)
        {
            existing.SurveyTypeID = dto.SurveyTypeID;
            existing.ModifiedBy = dto.ModifiedBy;
            existing.ModifiedDate = dto.ModifiedDate;
            Logger?.Invoke($"Survey with ID {dto.SurveyID} updated.");
        }
    }

    public void DeleteSurvey(int surveyID)
    {
        var survey = surveys.Find(s => s.SurveyID == surveyID);
        if (survey != null)
        {
            surveys.Remove(survey);
            Logger?.Invoke($"Survey with ID {surveyID} deleted.");
        }
    }

    public override void DisplaySurveyDetails()
    {
        foreach (var dto in surveys)
        {
            var typeName = surveyTypes.Find(t => t.SurveyTypeID == dto.SurveyTypeID)?.SurveyTypeName ?? "Unknown";
            Console.WriteLine($"SurveyID: {dto.SurveyID}, SurveyTypeID: {dto.SurveyTypeID}, SurveyTypeName: {typeName}, ModifiedBy: {dto.ModifiedBy}, ModifiedDate: {dto.ModifiedDate}");
        }
    }

   
}
