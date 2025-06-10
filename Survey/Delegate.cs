using Survey.DTO;

namespace Survey
{
    public delegate void Logging(SurveyDTO survey);
    public class Delegate
    {

        public void logging(SurveyDTO survey)
        {
            if (survey.SurveyID != 0 && survey.SurveyTypeName != null)
            {
                SurveyManager sm = new SurveyManager();
                survey = new SurveyDTO();
                sm.AddSurvey(survey);
                sm.UpdateSurvey(survey);
                sm.DeleteSurvey(survey.SurveyID);
            }

        }
    }
    public class Testing
    {
        public void test()
        {
            Delegate d = new Delegate();
            Logging log = new Logging(d.logging);
            log(new SurveyDTO());
        }
    }
}
