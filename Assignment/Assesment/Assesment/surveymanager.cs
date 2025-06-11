using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Assesment.DTO;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Logging;

namespace Assesment
{
    // Define the LogHandler delegate  
    public delegate void LogHandler(string message);




    public class SurveyManager : survey, Isurvey
    {
        // Added missing method implementations for AddSurvey, UpdateSurvey, and DeleteSurvey  
         public void AddSurvey()
        {
            AddSurvey(this);
        }

        public void Update()
        {
            UpdateSurvey(this);
        }

        public void Delete()
        {
            DeleteSurvey(this.SurveyID);
        }

        public void DisplaySurveyDetails()
        {
            Console.WriteLine("Survey Details:");
            Console.WriteLine($"SurveyID       : {SurveyID}");
            Console.WriteLine($"SurveyTypeID   : {SurveyTypeID}");
            Console.WriteLine($"SurveyTypeName : {SurveyTypeName}");
            Console.WriteLine($"ModifiedBy     : {ModifiedBy}");
            Console.WriteLine($"ModifiedDate   : {ModifiedDate}");
            Console.WriteLine();
        }

        // Implementing the missing methods  
        public void AddSurvey()
        {
            AddSurvey(this);
        }

        public void UpdateSurvey()
        {
            UpdateSurvey(this);
        }

        public void DeleteSurvey()
        {
            DeleteSurvey(this.SurveyID);
        }

        public void AddSurvey(SurveyManager survey)
        {
            using (SqlConnection connection = new SqlConnection("YourConnectionString"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Surveys (SurveyTypeID, SurveyTypeName, ModifiedBy, ModifiedDate) VALUES (@SurveyTypeID, @SurveyTypeName, @ModifiedBy, @ModifiedDate)", connection);
                // Logic to add survey to the database  
                command.Parameters.AddWithValue("@SurveyTypeID", survey.SurveyTypeID);
                command.Parameters.AddWithValue("@SurveyTypeName", survey.SurveyTypeName);
                command.Parameters.AddWithValue("@ModifiedBy", survey.ModifiedBy);
                command.Parameters.AddWithValue("@ModifiedDate", survey.ModifiedDate);
                command.ExecuteNonQuery();
                // Assuming the survey was added successfully, log the action
                Logger.Log("Survey added to the database successfully.");
                // Log the action of adding a survey
                // Assuming the survey was added successfully, log the action

                Logger.Log("Survey added to the database.");
            }


            // Logic for adding a survey  
            Logger.Log("Survey added successfully.");
        }

        private void UpdateSurvey(SurveyManager survey)
        {
            using (SqlConnection connection = new SqlConnection("YourConnectionString"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Surveys SET SurveyTypeID = @SurveyTypeID, SurveyTypeName = @SurveyTypeName, ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate WHERE SurveyID = @SurveyID", connection);
                // Logic to update survey in the database  
                command.Parameters.AddWithValue("@SurveyID", survey.SurveyID);
                command.Parameters.AddWithValue("@SurveyTypeID", survey.SurveyTypeID);
                command.Parameters.AddWithValue("@SurveyTypeName", survey.SurveyTypeName);
                command.Parameters.AddWithValue("@ModifiedBy", survey.ModifiedBy);
                command.Parameters.AddWithValue("@ModifiedDate", survey.ModifiedDate);
                command.ExecuteNonQuery();
                // Assuming the survey was updated successfully, log the action
                Logger.Log("Survey updated in the database successfully.");
            }
            // Logic for updating a survey  
            Logger.Log("Survey updated successfully.");
        }

        private void DeleteSurvey(int surveyID)
        {
            using (SqlConnection connection = new SqlConnection("YourConnectionString"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Surveys WHERE SurveyID = @SurveyID", connection);
                // Logic to delete survey from the database  
                command.Parameters.AddWithValue("@SurveyID", surveyID);
                command.ExecuteNonQuery();
                // Assuming the survey was deleted successfully, log the action
                Logger.Log($"Survey with ID {surveyID} deleted from the database successfully.");
            }
            // Logic for deleting a survey  
            Logger.Log($"Survey with ID {surveyID} deleted successfully.");
        }
    }

    public static class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
