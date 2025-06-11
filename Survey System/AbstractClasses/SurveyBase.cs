namespace Survey_System.AbstractClasses
{
    public abstract class SurveyBase
    {
        public int SurveyID { get; set; }
        public int SurveyTypeID { get; set; }
        public string SurveyTypeName { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
        public string ModifiedDate { get; set; } = string.Empty;

        public void DisplaySurveyDetails()
        {
            Console.WriteLine($"SurveyID: {SurveyID}");
            Console.WriteLine($"SurveyTypeName: {SurveyTypeName}");
            Console.WriteLine($"ModifiedDate: {ModifiedDate}");
        }
    }
}
