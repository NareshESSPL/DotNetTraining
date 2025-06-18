namespace SurveyManager1.Models
{
    public abstract class SurveyBase
    {
        public int SurveyID { get; set; }

        public abstract void DisplaySurveyDetails(Survey survey);

        public int SurveyTypeID { get; set; }
        public string SurveyTypeName { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedDate { get; set; }
    }
}
