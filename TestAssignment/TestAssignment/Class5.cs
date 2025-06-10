using System;
using System.Data;
using System.Data.SqlClient;
using SurveyFeedbackSystem.DTO;
using Microsoft.Data.Sqlclient;

namespace SurveyFeedbackSystem.BusinessLogic
{
    public delegate void LogHandler(string message);

    public class SurveyManager : SurveyBase, ISurvey
    {
        private readonly string connectionString = "Server=ESSPLLAP58\\SQL2019;Database=YourDbName;Trusted_Connection=True;";
        public event LogHandler Log;

        public override void DisplaySurveyDetails(Survey survey)
        {
            Console.WriteLine($"SurveyID: {survey.SurveyID}");
            Console.WriteLine($"SurveyTypeID: {survey.SurveyTypeID}");
            Console.WriteLine($"SurveyTypeName: {survey.SurveyTypeName}");
            Console.WriteLine($"ModifiedBy: {survey.ModifiedBy}");
            Console.WriteLine($"ModifiedDate: {survey.ModifiedDate}");
        }

        public void AddSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Survey (SurveyTypeID, SurveyTypeName, ModifiedBy, ModifiedDate) " +
                                   "VALUES (@SurveyTypeID, @SurveyTypeName, @ModifiedBy, @ModifiedDate)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@SurveyTypeID", survey.SurveyTypeID);
                        cmd.Parameters.AddWithValue("@SurveyTypeName", survey.SurveyTypeName);
                        cmd.Parameters.AddWithValue("@ModifiedBy", survey.ModifiedBy);
                        cmd.Parameters.AddWithValue("@ModifiedDate", survey.ModifiedDate);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        Log?.Invoke("Survey added successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                Log?.Invoke($"Error in AddSurvey: {ex.Message}");
            }
        }

        public void UpdateSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Survey SET SurveyTypeID = @SurveyTypeID, SurveyTypeName = @SurveyTypeName, " +
                                   "ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate WHERE SurveyID = @SurveyID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@SurveyID", survey.SurveyID);
                        cmd.Parameters.AddWithValue("@SurveyTypeID", survey.SurveyTypeID);
                        cmd.Parameters.AddWithValue("@SurveyTypeName", survey.SurveyTypeName);
                        cmd.Parameters.AddWithValue("@ModifiedBy", survey.ModifiedBy);
                        cmd.Parameters.AddWithValue("@ModifiedDate", survey.ModifiedDate);

                        con.Open();
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                            Log?.Invoke("Survey updated successfully.");
                        else
                            Log?.Invoke("Survey not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Log?.Invoke($"Error in UpdateSurvey: {ex.Message}");
            }
        }

        public void DeleteSurvey(int surveyId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Survey WHERE SurveyID = @SurveyID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@SurveyID", surveyId);

                        con.Open();
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                            Log?.Invoke("Survey deleted successfully.");
                        else
                            Log?.Invoke("Survey not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Log?.Invoke($"Error in DeleteSurvey: {ex.Message}");
            }
        }
    }
}
