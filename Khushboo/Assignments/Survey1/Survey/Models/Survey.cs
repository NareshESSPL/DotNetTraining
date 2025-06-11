using SurveyNew.Models.DTOs;
using System;

namespace SurveyNew.Models
{
    public class Surveyy : SurveyBase
    {
        public override void DisplaySurveyDetails()
        {
            Console.WriteLine(
                $"SurveyID: {SurveyID}, TypeID: {SurveyTypeID}, " +
                $"TypeName: '{SurveyTypeName}', ModifiedBy: '{ModifiedBy}', " +
                $"ModifiedDate: {ModifiedDate}");
        }
    }
}
