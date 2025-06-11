namespace SurveyManager1.Models
{
    public class Survey
    {
        public int SurveyID { get; set; }

        public int SurveyTypeID { get; set; }
        public string SurveyTypeName { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedDate { get; set; }
        // Navigation property
        public virtual SurveyType? SurveyType { get; set; }
    }
}
