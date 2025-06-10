using System;
using SurveyFeedbackSystem.DTO;
using SurveyFeedbackSystem.BusinessLogic;

namespace SurveyFeedbackSystem.DTO
{

    class Program
    {
        static void Main()
        {
            SurveyManager manager = new SurveyManager();
            manager.Log += Console.WriteLine; 

            Survey newSurvey = new Survey
            {
                SurveyID = 1,
                SurveyTypeID = 101,
                SurveyTypeName = "Customer Feedback",
                ModifiedBy = "Admin",
                ModifiedDate = DateTime.Now.ToString("yyyy-MM-dd")
            };
            Survey SSurvey = new Survey
            {
                SurveyID = 2,
                SurveyTypeID = 102,
                SurveyTypeName = "Customer Feedback",
                ModifiedBy = "Soumya",
                ModifiedDate = DateTime.Now.ToString("yyyy-MM-dd")
            };

            manager.AddSurvey(newSurvey);
            manager.DisplaySurveyDetails(newSurvey);
            manager.DisplaySurveyDetails(SSurvey);


            newSurvey.SurveyTypeName = "Product Feedback";
            SSurvey.SurveyTypeName = "Testing";
            manager.UpdateSurvey(newSurvey);
            manager.DisplaySurveyDetails(newSurvey);
            manager.DisplaySurveyDetails(SSurvey);


            manager.DeleteSurvey(1);
            manager.DeleteSurvey(1);


        }
    }

}
