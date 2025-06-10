// Create an interface (ISurvey)

//Define methods for AddSurvey(), UpdateSurvey(), and DeleteSurvey().


namespace interfa
{
    namespace interfa
    {
        // Define the ISurvey interface
        public interface ISurvey
        {
            void AddSurvey(Survey survey);
            void UpdateSurvey(int surveyId, Survey survey);
            void DeleteSurvey(int surveyId);
        }

        // Define the Survey class
        public class Survey
        {
            public int SurveyID { get; set; }
            public string SurveyTypeID { get; set; }
            public string SurveyTypeName { get; set; }
            public string ModifiedDate { get; set; }
        }

        // Class1 remains empty or can be used for other purposes
        public class Class1
        {
            public int SurveyID { get; set; }
            public string SurveyTypeID { get; set; }
            public string SurveyTypeName { get; set; }
            public string ModifiedDate { get; set; }
            public string ModifiedBy { get; set; }
            public DateTime ModifiedDateTime { get; set; }
            public Class1()
            {
                SurveyID = 1;
                SurveyTypeID = "DefaultType";
                SurveyTypeName = "Default Survey";
                ModifiedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ModifiedBy = "System";
                ModifiedDateTime = DateTime.Now;

                 
            }
        }
    }
}
