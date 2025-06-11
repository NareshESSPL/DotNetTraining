using SurveyNew.Models;

using System.Collections.Generic;

namespace SurveyNew.Interfaces
{
    public interface ISurvey
    {
       void  AddSurvey(Surveyy survey);
        void UpdateSurvey(Surveyy survey);
        void DeleteSurvey(int surveyId);
        List<Surveyy> GetAllSurveys();
    }
}
