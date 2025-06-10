using SurveyManagement.DTO;

namespace SurveyManagement
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            SurveyManager surveyManager = new SurveyManager();
            
            surveyManager.SurveyTypeID = 3;
            surveyManager.SurveyTypeName = "unit21";
            surveyManager.ModifiedBy = "user31";

            surveyManager.AddSurvey(surveyManager);

            var newsurveyManager = new SurveyManager()
            {
                SurveyTypeID = 2,
                SurveyTypeName = "Group",
                ModifiedBy = "admin"
            };

            surveyManager.UpdateSurvey(newsurveyManager);

            surveyManager.DeleteSurvey(surveyManager.SurveyTypeID);

            surveyManager.logger(surveyManager);




        }
    }
}
