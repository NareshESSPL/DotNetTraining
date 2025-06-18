namespace SurveyManager1.Models
{
    public interface ISurvey
    {

        void AddSurvey(Survey survey);
        void UpdateSurvey(Survey survey);
        void DeleteSurvey(int surveyId);
    }
}
