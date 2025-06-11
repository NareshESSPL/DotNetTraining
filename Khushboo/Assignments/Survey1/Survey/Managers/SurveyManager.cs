
using SurveyNew.Models;
using SurveyNew.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyNew.Managers
{
    public class SurveyManager : ISurvey
    {
        private readonly List<Surveyy> _surveyList = new List<Surveyy>();

        public Action<string>? Logger { get; set; }

        private void Validate(Surveyy s)
        {
            if (string.IsNullOrWhiteSpace(s.SurveyTypeName))
                throw new ArgumentException("SurveyTypeName cannot be empty", nameof(s));
            if (string.IsNullOrWhiteSpace(s.ModifiedBy))
                throw new ArgumentException("ModifiedBy cannot be empty", nameof(s));
        }

        public void AddSurvey(Surveyy s)
        {
            Validate(s);
            s.SurveyID = _surveyList.Any() ? _surveyList.Max(x => x.SurveyID) + 1 : 1;
            _surveyList.Add(s);
            s.DisplaySurveyDetails();
            Logger?.Invoke($"Added survey ID {s.SurveyID}");
        }

        public void UpdateSurvey(Surveyy s)
        {
            Validate(s);
            var ex = _surveyList.FirstOrDefault(x => x.SurveyID == s.SurveyID)
                ?? throw new KeyNotFoundException($"Survey with ID {s.SurveyID} not found");
            ex.SurveyTypeID = s.SurveyTypeID;
            ex.SurveyTypeName = s.SurveyTypeName;
            ex.ModifiedBy = s.ModifiedBy;
            ex.ModifiedDate = s.ModifiedDate;
            ex.DisplaySurveyDetails();
            Logger?.Invoke($"Updated survey ID {s.SurveyID}");
        }

        public void DeleteSurvey(int surveyId)
        {
            var s = _surveyList.FirstOrDefault(x => x.SurveyID == surveyId)
                ?? throw new KeyNotFoundException($"Survey with ID {surveyId} not found");
            _surveyList.Remove(s);
            Logger?.Invoke($"Deleted survey ID {surveyId}");
        }

        public List<Surveyy> GetAllSurveys() => _surveyList;
    }
}
