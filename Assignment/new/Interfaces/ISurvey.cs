using SurveySystem.DTO;

namespace SurveySystem.Interfaces
{
    public interface ISurvey
    {
        void AddSurvey(SurveyDTO survey);
        void UpdateSurvey(SurveyDTO survey);
        void DeleteSurvey(int surveyID);
    }
}
