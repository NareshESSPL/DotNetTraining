using System.Data.Common;

namespace DTO
{
    public class SurveyType
    {
        public int SurveyTypeID { get; set; }
        public string SurveyTypeName { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedDate { get; set; }
    }
}

