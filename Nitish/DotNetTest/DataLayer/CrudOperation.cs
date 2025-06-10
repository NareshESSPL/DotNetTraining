using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DataLayer
{
    interface ISurvey
    {
        public abstract void AddOrUpdateSurvey();
        public abstract void DeleteSurvey(int Surveyid);
    }

    public class SurveyManager : SurveyBase, ISurvey {
            public void AddOrUpdateSurvey(){

            using (var connection= new SqlConnection("ConnectionString"))
            {
                using(var command = new SqlCommand("Command",connection))
                {
                    connection.Open();

                    command.CommandType = CommandType.StoredProcedure;

                 
                    command.Parameters.Add(new SqlParameter("@SurveyID", obj.SurveyID));
                    command.Parameters.Add(new SqlParameter("@SurveyTypeID", obj.SurveyTypeID));
                    command.Parameters.Add(new SqlParameter("@SurveyTypeName", obj.SurveyTypeName));
                    command.Parameters.Add(new SqlParameter("@ModifiedBy", obj.ModifiedBy));
                    command.Parameters.Add(new SqlParameter("@ModifiedDate", obj.ModifiedDate.ToDateTime(TimeOnly.MinValue)));
                    command.ExecuteNonQuery();

                }
            }
            
            }

        public void DeleteSurvey(int Surveyid) {

            using (var connection = new SqlConnection("ConnectionString"))
            {
                using (var command = new SqlCommand("Proc_Delete_StudentById", connection))
                {
                    connection.Open();

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@SurveyID", Surveyid);

                    command.ExecuteNonQuery();

                }

            }

        }
        public SurveyManager GetDetailsById(int Surveyid)
        {

            var obj = new SurveyManager();

            using (var connection = new SqlConnection("ConnectionString"))
            {
                using (var command = new SqlCommand($"Select * from Db where SurveyID = {Surveyid}", connection))
                {
                    connection.Open();

                    command.CommandType = CommandType.Text;

                    var reader = command.ExecuteReader();

                    while (reader.read()) {
                            obj.SurveyID = reader.GetInt32("SurveyID");
                            obj.SurveyTypeID = reader.GetInt32("SurveyTypeID");
                            obj.SurveyTypeName = reader.GetString("SurveyTypeName");
                            obj.ModifiedBy = reader.GetString("ModifiedBy");
                            obj.ModifiedDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("ModifiedDate")));

                    }
                }
            }

                return obj;
         }

           
            

            
        

     public List<SurveyManager> GetAllData()
        {
            List<SurveyManager> obj = new List<SurveyManager>();

            using (var connection = new SqlConnection("ConnectionString"))
            {
                using (var command = new SqlCommand($"Select * from Db", connection))
                {
                    connection.Open();

                    command.CommandType = CommandType.Text;

                    var reader = command.ExecuteReader();

                    while (reader.read())
                    {
                        var data = new SurveyManager();
                            data.SurveyID = reader.GetInt32("SurveyID");
                            data.SurveyTypeID = reader.GetInt32("SurveyTypeID");
                            data.SurveyTypeName = reader.GetString("SurveyTypeName");
                            data.ModifiedBy = reader.GetString("ModifiedBy");
                            data.ModifiedDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("ModifiedDate")));

                        obj.Add(data);
                    }
                
                    }
                }

            return obj;
        }


    }
}
