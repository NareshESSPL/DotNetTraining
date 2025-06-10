using System;

namespace sixnodelegate
{
     
    public delegate void LogHandler(string message);

 
    public abstract class SurveyBase
    {
        public abstract void AddSurvey(string surveyName);
        public abstract void UpdateSurvey(string surveyName);
        public abstract void DeleteSurvey(string surveyName);
    }

     
    public interface ISurvey
    {
        void AddSurvey(string surveyName);
        void UpdateSurvey(string surveyName);
        void DeleteSurvey(string surveyName);
    }

    
    public class SurveyManager : SurveyBase, ISurvey
    {
        private readonly LogHandler _logHandler;

        public SurveyManager(LogHandler logHandler)
        {
            _logHandler = logHandler;
        }

        public override void AddSurvey(string surveyName)
        {
            if (string.IsNullOrWhiteSpace(surveyName))
            {
                _logHandler?.Invoke("Error: Survey name cannot be empty.");
                throw new ArgumentException("Survey name cannot be empty.");
            }
            _logHandler?.Invoke($"Survey '{surveyName}' added successfully.");
        }

        public override void UpdateSurvey(string surveyName)
        {
            if (string.IsNullOrWhiteSpace(surveyName))
            {
                _logHandler?.Invoke("Error: Survey name cannot be empty.");
                throw new ArgumentException("Survey name cannot be empty.");
            }
            _logHandler?.Invoke($"Survey '{surveyName}' updated successfully.");
        }

        public override void DeleteSurvey(string surveyName)
        {
            _logHandler?.Invoke($"Survey '{surveyName}' deleted successfully.");
        }
    }

    internal  class Program
    {
        static void Main(string[] args)
        {
            
            LogHandler logHandler = Console.WriteLine;

             
            SurveyManager surveyManager = new SurveyManager(logHandler);

            try
            {
                surveyManager.AddSurvey("Customer Feedback");
                surveyManager.UpdateSurvey("Employee Feedback");
                surveyManager.DeleteSurvey("Customer Feedback");
            }
            catch (Exception ex)
            {
                logHandler($"Exception: {ex.Message}");
            }
        }
    }
}
