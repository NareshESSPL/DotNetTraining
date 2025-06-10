using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Survey.DTO;

namespace Survey
{
    
    public class SurveyManager : SurveyBase,ISurvey
    {
        public readonly string connectionstring;
        public SurveyManager (){ }
        public SurveyManager(IConfiguration configuration)
        {
            connectionstring = configuration.GetConnectionString("constring");  
            
        }
      
       
        //Adding 
        public void AddSurvey(SurveyDTO survey)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                using SqlCommand cmd = new SqlCommand("AddSurveydto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    
                    cmd.Parameters.AddWithValue("@SurveyTypeName", survey.SurveyTypeName);
                    cmd.Parameters.AddWithValue("@ModifiedBy", survey.ModifiedBy);
                    cmd.Parameters.AddWithValue("@ModifiedDate", survey.ModifiedDate);
                    if (survey.SurveyTypeName!=null)
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        throw new Exception("name is null");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        //update
        public void UpdateSurvey(SurveyDTO survey)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                using SqlCommand cmd = new SqlCommand("UpdateSurvey", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SurveyId", survey.SurveyID);
                cmd.Parameters.AddWithValue("@SurveyTypeName", survey.SurveyTypeName);
                cmd.Parameters.AddWithValue("@ModifiedBy", survey.ModifiedBy);
                cmd.Parameters.AddWithValue("@ModifiedDate", survey.ModifiedDate);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //delete
        public void DeleteSurvey(int SurveyId)
        {
            SurveyDTO survey = new SurveyDTO();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                using SqlCommand cmd = new SqlCommand("DeleteSurvey", con);
                cmd.CommandType= CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SurveyId", survey.SurveyID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public override SurveyDTO SurveyDetails()
        {
            SurveyDTO s=new SurveyDTO();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                using SqlCommand cmd= new SqlCommand("select * from SurveyDto",con);
                cmd.CommandType=CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    s.SurveyID = reader.GetInt32("SurveyId");
                    s.SurveyTypeName = reader["SurveyTypeName"].ToString();
                    s.ModifiedDate = reader["ModifiedDate"].ToString();
                    s.ModifiedBy = reader["ModifiedBy"].ToString();
                }
            }
            return s;
        }
    }
}
