using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DataLayer
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly string _connectionString = "Data Source=ESSPLLAP223\\SQL2019;Initial Catalog=SURVEY;Integrated Security=True;TrustServerCertificate=True";

        // Logging delegate (simplified for this example)
        // In a real application, consider a dedicated logging framework (e.g., NLog, Serilog)
        public delegate void LogHandler(string message);
        private LogHandler _logger;

        public SurveyRepository(LogHandler logger = null)
        {
            _logger = logger ?? Console.WriteLine; // Default to Console.WriteLine if no logger is provided
        }

        public Survey GetSurveyById(int surveyId)
        {
            Survey survey = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = @"
                        SELECT
                            s.SurveyID,
                            s.SurveyTypeID,
                            s.SurveyName,
                            s.ModifiedBy,
                            s.ModifiedDate
                        FROM
                            Survey s
                        WHERE
                            s.SurveyID = @SurveyID;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@SurveyID", surveyId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                survey = new Survey
                                {
                                    SurveyID = reader.GetInt32(reader.GetOrdinal("SurveyID")),
                                    SurveyTypeID = reader.GetInt32(reader.GetOrdinal("SurveyTypeID")),
                                    SurveyName = reader.GetString(reader.GetOrdinal("SurveyName")),
                                    ModifiedBy = reader.GetString(reader.GetOrdinal("ModifiedBy")),
                                    ModifiedDate = reader.GetDateTime(reader.GetOrdinal("ModifiedDate"))
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger?.Invoke($"Database Error in GetSurveyById: {ex.Message}");
                // In a production app, you might rethrow a custom exception or log more details
            }
            catch (Exception ex)
            {
                _logger?.Invoke($"Unexpected Error in GetSurveyById: {ex.Message}");
            }
            return survey;
        }

        public List<Survey> GetAllSurveys()
        {
            List<Survey> surveys = new List<Survey>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    // Joining with SurveyType to potentially display type name in UI
                    string sql = @"
                        SELECT
                            s.SurveyID,
                            s.SurveyTypeID,
                            s.SurveyName,
                            s.ModifiedBy,
                            s.ModifiedDate
                        FROM
                            Survey s
                        ORDER BY s.SurveyName; -- Sort in application if ordering is critical and indexes are missing
                        ";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                surveys.Add(new Survey
                                {
                                    SurveyID = reader.GetInt32(reader.GetOrdinal("SurveyID")),
                                    SurveyTypeID = reader.GetInt32(reader.GetOrdinal("SurveyTypeID")),
                                    SurveyName = reader.GetString(reader.GetOrdinal("SurveyName")),
                                    ModifiedBy = reader.GetString(reader.GetOrdinal("ModifiedBy")),
                                    ModifiedDate = reader.GetDateTime(reader.GetOrdinal("ModifiedDate"))
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger?.Invoke($"Database Error in GetAllSurveys: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger?.Invoke($"Unexpected Error in GetAllSurveys: {ex.Message}");
            }
            return surveys;
        }

        public int AddSurvey(Survey survey)
        {
            // Error Handling: SurveyName field should not be empty
            if (string.IsNullOrWhiteSpace(survey.SurveyName))
            {
                _logger?.Invoke("Validation Error: Survey Name cannot be empty for AddSurvey operation.");
                // Instead of throwing, you might return 0 and handle in controller
                return 0; // Indicate failure
            }

            int newSurveyId = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = @"
                        INSERT INTO Survey (SurveyTypeID, SurveyName, ModifiedBy, ModifiedDate)
                        VALUES (@SurveyTypeID, @SurveyName, @ModifiedBy, @ModifiedDate);
                        SELECT SCOPE_IDENTITY();"; // Returns the ID of the newly inserted row

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@SurveyTypeID", survey.SurveyTypeID);
                        command.Parameters.AddWithValue("@SurveyName", survey.SurveyName);
                        command.Parameters.AddWithValue("@ModifiedBy", survey.ModifiedBy);
                        command.Parameters.AddWithValue("@ModifiedDate", survey.ModifiedDate);

                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            newSurveyId = Convert.ToInt32(result);
                        }
                    }
                }
                _logger?.Invoke($"Survey '{survey.SurveyName}' added successfully with ID: {newSurveyId}");
            }
            catch (SqlException ex)
            {
                _logger?.Invoke($"Database Error in AddSurvey: {ex.Message}");
                newSurveyId = 0; // Ensure 0 is returned on database error
            }
            catch (Exception ex)
            {
                _logger?.Invoke($"Unexpected Error in AddSurvey: {ex.Message}");
                newSurveyId = 0; // Ensure 0 is returned on unexpected error
            }
            return newSurveyId;
        }

        public bool UpdateSurvey(Survey survey)
        {
            // Error Handling: SurveyName field should not be empty
            if (string.IsNullOrWhiteSpace(survey.SurveyName))
            {
                _logger?.Invoke("Validation Error: Survey Name cannot be empty for UpdateSurvey operation.");
                return false; // Indicate failure
            }

            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = @"
                        UPDATE Survey SET
                            SurveyTypeID = @SurveyTypeID,
                            SurveyName = @SurveyName,
                            ModifiedBy = @ModifiedBy,
                            ModifiedDate = @ModifiedDate
                        WHERE SurveyID = @SurveyID;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@SurveyTypeID", survey.SurveyTypeID);
                        command.Parameters.AddWithValue("@SurveyName", survey.SurveyName);
                        command.Parameters.AddWithValue("@ModifiedBy", survey.ModifiedBy);
                        command.Parameters.AddWithValue("@ModifiedDate", survey.ModifiedDate);
                        command.Parameters.AddWithValue("@SurveyID", survey.SurveyID);

                        int rowsAffected = command.ExecuteNonQuery();
                        success = (rowsAffected > 0);
                    }
                }
                if (success)
                {
                    _logger?.Invoke($"Survey ID: {survey.SurveyID} updated successfully.");
                }
                else
                {
                    _logger?.Invoke($"Survey ID: {survey.SurveyID} not found or no changes made.");
                }
            }
            catch (SqlException ex)
            {
                _logger?.Invoke($"Database Error in UpdateSurvey: {ex.Message}");
                success = false;
            }
            catch (Exception ex)
            {
                _logger?.Invoke($"Unexpected Error in UpdateSurvey: {ex.Message}");
                success = false;
            }
            return success;
        }

        public bool DeleteSurvey(int surveyId)
        {
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM Survey WHERE SurveyID = @SurveyID;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@SurveyID", surveyId);
                        int rowsAffected = command.ExecuteNonQuery();
                        success = (rowsAffected > 0);
                    }
                }
                if (success)
                {
                    _logger?.Invoke($"Survey ID: {surveyId} deleted successfully.");
                }
                else
                {
                    _logger?.Invoke($"Survey ID: {surveyId} not found.");
                }
            }
            catch (SqlException ex)
            {
                _logger?.Invoke($"Database Error in DeleteSurvey: {ex.Message}");
                success = false;
            }
            catch (Exception ex)
            {
                _logger?.Invoke($"Unexpected Error in DeleteSurvey: {ex.Message}");
                success = false;
            }
            return success;
        }

        // --- SurveyType Repository Methods (Optional, could be in a separate SurveyTypeRepository) ---
        public List<SurveyType> GetAllSurveyTypes()
        {
            List<SurveyType> surveyTypes = new List<SurveyType>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = "SELECT SurveyTypeID, SurveyTypeName, ModifiedBy, ModifiedDate FROM SurveyType ORDER BY SurveyTypeName;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                surveyTypes.Add(new SurveyType
                                {
                                    SurveyTypeID = reader.GetInt32(reader.GetOrdinal("SurveyTypeID")),
                                    SurveyTypeName = reader.GetString(reader.GetOrdinal("SurveyTypeName")),
                                    ModifiedBy = reader.GetString(reader.GetOrdinal("ModifiedBy")),
                                    ModifiedDate = reader.GetDateTime(reader.GetOrdinal("ModifiedDate"))
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger?.Invoke($"Database Error in GetAllSurveyTypes: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger?.Invoke($"Unexpected Error in GetAllSurveyTypes: {ex.Message}");
            }
            return surveyTypes;
        }

        public SurveyType GetSurveyTypeById(int surveyTypeId)
        {
            SurveyType surveyType = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = "SELECT SurveyTypeID, SurveyTypeName, ModifiedBy, ModifiedDate FROM SurveyType WHERE SurveyTypeID = @SurveyTypeID;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@SurveyTypeID", surveyTypeId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                surveyType = new SurveyType
                                {
                                    SurveyTypeID = reader.GetInt32(reader.GetOrdinal("SurveyTypeID")),
                                    SurveyTypeName = reader.GetString(reader.GetOrdinal("SurveyTypeName")),
                                    ModifiedBy = reader.GetString(reader.GetOrdinal("ModifiedBy")),
                                    ModifiedDate = reader.GetDateTime(reader.GetOrdinal("ModifiedDate"))
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger?.Invoke($"Database Error in GetSurveyTypeById: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger?.Invoke($"Unexpected Error in GetSurveyTypeById: {ex.Message}");
            }
            return surveyType;
        }
    }
}
