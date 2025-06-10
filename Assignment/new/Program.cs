using SurveySystem.Interfaces;
using SurveySystem.DTO;
using System;

class Program
{
    static void Main()
    {
        SurveyManager manager = new SurveyManager();
        manager.Logger = Console.WriteLine;

        SurveyTypeDTO type1 = new SurveyTypeDTO
        {
            SurveyTypeID = 101,
            SurveyTypeName = "Customer Feedback"
        };

        SurveyDTO survey1 = new SurveyDTO
        {
            SurveyID = 1,
            SurveyTypeID = 101,
            ModifiedBy = "Admin",
            ModifiedDate = "2025-06-10"
        };

        manager.AddSurvey(survey1);

        manager.DisplaySurveyDetails();

        survey1.ModifiedDate = "2025-06-11";
        manager.UpdateSurvey(survey1);

        manager.DeleteSurvey(1);
    }
}
