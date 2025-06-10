namespace Survey.DTO
{
    public class SurveyDTO
    {
        SurveyType stype = new SurveyType();
        public int SurveyID { get; set; }
        public int SurveyTypeID;
        public string SurveyTypeName { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public SurveyDTO()
        {
            SurveyTypeID = stype.SurveyTypeID;
        }
    }
}
