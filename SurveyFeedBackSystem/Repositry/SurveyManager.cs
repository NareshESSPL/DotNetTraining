using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Repositry
{
    public class SurveyManager : SurveyBase, Isurvey
    {

        string ConnectionString = "SQLSERVER_CONNECTION_STRING";

        public List<Survey> GetAllSurveyDetails()
        {
            List<Survey> list = new List<Survey>();

            try
            {
                using(var connection = new SqlConnection(ConnectionString))
                {
                    using (var cmd = new SqlCommand("select * from Survey",connection))
                    {
                        connection.Open();

                        cmd.CommandType = CommandType.Text;

                        var reader= cmd.ExecuteReader();


                        while (reader.Read())
                        {
                            Survey survey= new Survey();
                            survey.SurveyId = reader.GetInt32("SurveyId");
                            survey.SurveyTypeId = reader.GetInt32("SurveyTypeId");
                            survey.SurveyTypeName = reader.GetString("SurveyTypeName");
                            survey.ModifiedBy = reader.GetString("ModifiedBy");
                            survey.ModifiedDate = reader.GetString("ModifiedDate");


                            list.Add(survey);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }

            return list;
        }



        public void AddSurvey(Survey survey)
        {
            try
            {
                if (survey.SurveyTypeName == null) throw new Exception("SurveyType Name van not be null");

                using (var con = new SqlConnection(ConnectionString))
                {
                    using (var SqlCmd = new SqlCommand("AddOrUpdate", con))
                    {
                        SqlCmd.Parameters.Add(new SqlParameter("@SurveyId", survey.SurveyId));
                        SqlCmd.Parameters.Add(new SqlParameter("@SurveyTypeId", survey.SurveyTypeId));
                        SqlCmd.Parameters.Add(new SqlParameter("@SurveyTypeName", survey.SurveyTypeName));
                        SqlCmd.Parameters.Add(new SqlParameter("@ModifiedBy", survey.ModifiedBy));
                        SqlCmd.Parameters.Add(new SqlParameter("@ModifiedDate", survey.ModifiedDate));

                        SqlCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }



        public void DeleteSurvey(int id)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    using (var cmd = new SqlCommand("delete from from Survey where SurveyId = "+id, connection))
                    {
                        connection.Open();

                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();

                        
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void UpdateSurvey(Survey survey)
        {
            try
            {
                if (survey.SurveyTypeName == null) throw new Exception("SurveyType Name van not be null");
                using(var con=new  SqlConnection(ConnectionString))
                {
                    using (var SqlCmd = new SqlCommand("AddOrUpdate",con))
                    {
                        SqlCmd.Parameters.Add(new SqlParameter("@SurveyId", survey.SurveyId));
                        SqlCmd.Parameters.Add(new SqlParameter("@SurveyTypeId", survey.SurveyTypeId));
                        SqlCmd.Parameters.Add(new SqlParameter("@SurveyTypeName", survey.SurveyTypeName));
                        SqlCmd.Parameters.Add(new SqlParameter("@ModifiedBy", survey.ModifiedBy));
                        SqlCmd.Parameters.Add(new SqlParameter("@ModifiedDate", survey.ModifiedDate));

                        SqlCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
