using System;
using System.Collections.Generic;


namespace survey
{
    internal abstract class SurveyBase
    {
        public int SurveyTypeID { get; set; }
        public string SurveyTypeName { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    internal interface ISurveyManager
    {
        void CreateSurvey();
        void DeleteSurvey();
    }

    internal class SurveyManager : SurveyBase, ISurveyManager
    {
        public void CreateSurvey()
        {
            Console.WriteLine("Survey created.");
        }

        public void DeleteSurvey()
        {
            Console.WriteLine("Survey deleted.");
        }
    }

    internal class Program
    {
        public class CustomerSurvey : SurveyBase
        {
            public string CustomerName { get; set; }
            public string Feedback { get; set; }
        }

        private static void Main(string[] args)
        {
            var survey = new CustomerSurvey
            {
                SurveyTypeID = 1,
                SurveyTypeName = "customer satisfaction",
                ModifiedBy = "Admin",
                ModifiedDate = DateTime.Now,
                CustomerName = "Nitish Kumar",
                Feedback = "okhhhhhhhhhh"
            };

            var surveyManager = new SurveyManager();
            surveyManager.CreateSurvey();
            surveyManager.DeleteSurvey();
        }
    }
}
