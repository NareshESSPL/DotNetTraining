using System.ComponentModel.DataAnnotations;

namespace Survey.DTO
{
    public class SurveyType
    {
        
        public int SurveyTypeID { get; set; }
        public string SurveyTypeName { get; set; }
        public string ModifiedBy { get; set; }

        public string ModifiedDate { get; set; }
    }
}
