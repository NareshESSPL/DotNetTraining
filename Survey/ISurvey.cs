using Survey.DTO;

namespace Survey
{
    internal interface  ISurvey
    {
        public void AddSurvey(SurveyDTO s);
        public void UpdateSurvey(SurveyDTO s);
        public void DeleteSurvey(int SurveyId);

    }
}
