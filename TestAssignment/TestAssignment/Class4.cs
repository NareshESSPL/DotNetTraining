using SurveyFeedbackSystem.DTO;
namespace SurveyFeedbackSystem.BusinessLogic
{
    public interface ISurvey
    {
        void AddSurvey(Survey survey);
        void UpdateSurvey(Survey survey);
        void DeleteSurvey(int surveyId);
    }
}