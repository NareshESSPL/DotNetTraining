
using System;
using Survey.Models;

namespace Survey.Interfaces
{
    public interface ISurvey
    {
        void AddSurvey(Survey survey);
        void UpdateSurvey(Survey survey);
        void DeleteSurvey(int surveyId);
        List<Survey> GetAllSurveys();
    }
}
