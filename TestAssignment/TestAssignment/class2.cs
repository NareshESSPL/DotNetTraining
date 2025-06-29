﻿using SurveyFeedbackSystem.DTO;


namespace SurveyFeedbackSystem.BusinessLogic
{
    public abstract class SurveyBase
    {
        public int SurveyID { get; set; }
        public int SurveyTypeID { get; set; }
        public string SurveyTypeName { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }

        public abstract void DisplaySurveyDetails(Survey survey);
    }
}

