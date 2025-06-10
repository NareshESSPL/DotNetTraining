using Survey_Project.Models;

namespace Survey_Project.Interface
{
    public interface Isurvey
    {
        void AddSurvey(Survey survey);
        void UpdateSurvey(Survey survey);
        void DeleteSurvey(int surveyId);

    }
}
