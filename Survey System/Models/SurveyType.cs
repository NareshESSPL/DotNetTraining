namespace Survey_System.Models
{
    public class SurveyType
    {
        public int SurveyTypeID { get; set; }
        public string SurveyTypeName { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
        public string ModifiedDate { get; set; } = string.Empty;
    }
}
