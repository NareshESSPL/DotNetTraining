using Survey.Interfaces;
using Survey.Models;

namespace Survey.Managers
{
    public class SurveyManager : ISurvey
    {
        private List<Survey> _surveyList = new List<Survey>();
        public Action<string>? Logger { get; set; }

        public void AddSurvey(Survey survey)
        {
            if (string.IsNullOrWhiteSpace(survey.SurveyTypeName))
                throw new Exception("SurveyTypeName cannot be empty!");

            _surveyList.Add(survey);
            Logger?.Invoke($"Added Survey: {survey.SurveyID}");
        }

        public void UpdateSurvey(Survey survey)
        {
            var existing = _surveyList.Find(x => x.SurveyID == survey.SurveyID);
            if (existing != null)
            {
                if (string.IsNullOrWhiteSpace(survey.SurveyTypeName))
                    throw new Exception("SurveyTypeName cannot be empty!");

                existing.SurveyTypeID = survey.SurveyTypeID;
                existing.SurveyTypeName = survey.SurveyTypeName;
                existing.ModifiedBy = survey.ModifiedBy;
                existing.ModifiedDate = survey.ModifiedDate;

                Logger?.Invoke($"Updated Survey: {survey.SurveyID}");
            }
            else
                throw new Exception("Survey not found.");
        }

        public void DeleteSurvey(int surveyId)
        {
            var survey = _surveyList.Find(x => x.SurveyID == surveyId);
            if (survey != null)
            {
                _surveyList.Remove(survey);
                Logger?.Invoke($"Deleted Survey: {surveyId}");
            }
            else
                throw new Exception("Survey not found.");
        }

        public List<Survey> GetAllSurveys()
        {
            return _surveyList;
        }
    }
}
