using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace SurveyManagement.DTO
{
   
    public class SurveyNameFieldException : Exception
    {
        public SurveyNameFieldException(string message) : base(message) { }

    }

    public interface ISurvey
    {
        void AddSurvey(SurveyManager surman);
        void UpdateSurvey(SurveyManager s);
        void DeleteSurvey(int SurveyTypeID);
    }
    public abstract class SurveyBase
    {
        public int SurveyID { get; set; }
        public int SurveyTypeID { get; set; }

        public string? SurveyTypeName;
        public string _SurveyTypeName
        {
            get => SurveyTypeName;
            set
            {
                if (value == null) throw new SurveyNameFieldException("SurveyName Field Requied");
                SurveyTypeName = value;
            }
        }


        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }


        public abstract void SurveyDetails(Action<SurveyManager> action);
        

    }

    public class SurveyManager : SurveyBase, ISurvey
    { 
           
             public Action<SurveyManager> logger = s =>
             {
                 string connectionstring = "Server = ESSPLLAP11\\SQL2019; Database = ServeyManagement; User Id = sa; Password = sa123@123; TrustServerCertificate = True;";
                 using (SqlConnection conn = new SqlConnection(connectionstring))
                 {
                     string query = "select * from SurveyType";
                     using (SqlCommand cmd = new SqlCommand(query, conn))
                     {
                         conn.Open();
                         SqlDataReader reader = cmd.ExecuteReader();
                          Console.WriteLine("......Your Survey Report .....");
                          while (reader.Read())
                         {
                             Console.WriteLine($"SurveyTypeId : {Convert.ToInt32(reader["SurveyTypeID"])}");
                             Console.WriteLine($"SurveyTypeName : {Convert.ToString(reader["SurveyTypeName"])}");
                             Console.WriteLine($"Modified By : {Convert.ToString(reader["ModifiedBy"])}");

                             Console.WriteLine($"Modified Date : {Convert.ToDateTime(reader["ModifiedDate"])}");

                             Console.WriteLine("------------------------------");
                         }
                     }
                 }
         
             

             };

        public override void SurveyDetails(Action<SurveyManager> logger)
        {
            logger(this);
        }


        public void AddSurvey(SurveyManager surman)
        {
            try
            {
                string connectionstring = "Server = ESSPLLAP11\\SQL2019; Database = ServeyManagement; User Id = sa; Password = sa123@123; TrustServerCertificate = True;";
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    string query = "Insert into SurveyType (SurveyTypeName,ModifiedBy) values (@SurveyTypeName,@ModifiedBy)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@SurveyTypeName", surman.SurveyTypeName);
                        cmd.Parameters.AddWithValue("@ModifiedBy", surman.ModifiedBy);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Inserted Successfully");
                    }
                }
            }
            catch (SurveyNameFieldException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateSurvey(SurveyManager sm)
        {
            try
            {
                string connectionstring = "Server = ESSPLLAP11\\SQL2019; Database = ServeyManagement; User Id = sa; Password = sa123@123; TrustServerCertificate = True;";
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    string query = "update SurveyType set SurveyTypeName = @SurveyTypeName, ModifiedBy = @ModifiedBy where SurveyTypeID = @SurveyTypeID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SurveyTypeID", sm.SurveyTypeID);
                        cmd.Parameters.AddWithValue("@SurveyTypeName", sm.SurveyTypeName);
                        cmd.Parameters.AddWithValue("@ModifiedBy", sm.ModifiedBy);
                       
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Updated Successfully");
                    }

                }
            }
            catch (SurveyNameFieldException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteSurvey(int SurveyTypeID)
        {
            try
            {
                string connectionstring = "Server = ESSPLLAP11\\SQL2019; Database = ServeyManagement; User Id = sa; Password = sa123@123; TrustServerCertificate = True;";
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    string query = "delete from SurveyType where SurveyTypeID = @SurveyTypeID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SurveyTypeID", SurveyTypeID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Deleted Successfully");

                    }
                }
            }
            catch (SurveyNameFieldException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}