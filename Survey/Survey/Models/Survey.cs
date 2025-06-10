using Survey.Models;

namespace Survey.Models
{
    public class Survey : SurveyBase
    {
        // Inherits properties from SurveyBase
        public override void DisplaySurveyDetails()
        {
            Console.WriteLine($"ID: {SurveyID}, Type: {SurveyTypeName}");
        }
    }
}
