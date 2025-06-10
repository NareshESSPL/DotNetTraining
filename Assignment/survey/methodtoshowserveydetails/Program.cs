//. Implement a method to display survey details
//Implement a method to display survey details.

namespace methodtoshowserveydetails
{
    public class Survey
    {
        public int SurveyID { get; set; }
        public string SurveyTypeID { get; set; }
        public string SurveyTypeName { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        
        public void DisplaySurveyDetails()
        {
            Console.WriteLine($"Survey ID: {SurveyID}");
            Console.WriteLine($"Survey Type ID: {SurveyTypeID}");
            Console.WriteLine($"Survey Type Name: {SurveyTypeName}");
            Console.WriteLine($"Modified By: {ModifiedBy}");
            Console.WriteLine($"Modified Date: {ModifiedDate}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Survey survey = new Survey
            {
                SurveyID =10188888,
                SurveyTypeID = "ST001",
                SurveyTypeName = "Customer Feedbacks",
                ModifiedBy = "Admin",
                ModifiedDate = DateTime.Now

            };

            
            survey.DisplaySurveyDetails();
        }
    }
}
