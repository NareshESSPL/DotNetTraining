using SurveyFeedbackSystem.BusinessLogic;
using SurveyFeedbackSystem.DTO;

namespace SurveyFeedbackSystem.DTO
{
    public class Survey
    {
        public int SurveyID { get; set; }
        public int SurveyTypeID { get; set; }
        public string SurveyTypeName { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }
}