using DTO;
using System;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DataLayer;

namespace DataLayer
{

    public interface ISurveyRepository
    {
        Survey GetSurveyById(int surveyId);
        List<Survey> GetAllSurveys();
        int AddSurvey(Survey survey);
        bool UpdateSurvey(Survey survey);
        bool DeleteSurvey(int surveyId);

        // Optional: Method for getting survey types, often in a separate repository
        List<SurveyType> GetAllSurveyTypes();
        SurveyType GetSurveyTypeById(int surveyTypeId);
    }
}
