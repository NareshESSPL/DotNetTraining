using Survey_Project.Models;
using Survey_Project.Services;

namespace Survey_Project
{
        public class New
        {
            public static void Main()
            {
                SurveyManager manager = new SurveyManager();

                // Subscribe to log events
                manager.LogEvent += Console.WriteLine;

                Survey survey1 = new Survey
                {
                    SurveyID = 1,
                    SurveyTypeID = 101,
                    SurveyTypeName = "Customer Feedback",
                    ModifiedBy = "Admin",
                    ModifiedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };

                Survey survey2 = new Survey
                {
                    SurveyID = 2,
                    SurveyTypeID = 102,
                    SurveyTypeName = "", 
                    ModifiedBy = "Admin",
                    ModifiedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };

                manager.AddSurvey(survey1); 
                manager.AddSurvey(survey2);

                survey1.SurveyTypeName = "Client Feedback Updated";
                manager.UpdateSurvey(survey1);

                manager.DeleteSurvey(1); 
                manager.DeleteSurvey(10); 

                Console.WriteLine("\nSurvey Details:");
                manager.DisplaySurveyDetails();
            }
        }
    }
