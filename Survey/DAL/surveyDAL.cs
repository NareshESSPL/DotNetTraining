using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlTypes;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public interface ISurvey
    {
        public void AddSurvey();

        public void DeleteSurvey();
        public void UpdateSurvey();
    }
    public abstract class SurveyBase
    {
        public int SurveyID { get; set; }
        public string SurveyTypeID { get; set; }

        public string SurveyTypeName { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public void SurveyDetails()
        {
            Console.WriteLine("survey ID=" + SurveyID);
            Console.WriteLine("SurveyTypeID =" + SurveyTypeID);
            Console.WriteLine("SurveyTypeName=" + SurveyTypeName);
            Console.WriteLine("ModifiedDate=" + ModifiedDate);
            Console.WriteLine("ModifiedBY=" + ModifiedBy);


        }
    }

   
    public interface SurveyManager : ISurvey
    {

        public void AddSurvey(Survey s)
        {
            var surveys = new List<Survey>();

            string insertstmt = @"insert into Survey values(@SurveyTypeID,@SurveyTypeName,@ModifiedBy,@ModifiedDate);";
            using (var sqlCon = new SqlConnection("Data Source=ESSPLLAP64\\SQL2019;Initial Catalog=surveyDB;Integrated Security=SSPI;trustservercertificate=true"))
            {
                using (var sqlCmd = new SqlCommand(insertstmt, sqlCon))
                {
                    sqlCmd.CommandType = CommandType.Text;
                    try
                    {
                        sqlCon.Open();

                        sqlCmd.Parameters.Add(new SqlParameter("@survey ID", s.SurveyID));
                        sqlCmd.Parameters.Add(new SqlParameter("@SurveyTypeID", s.SurveyTypeID));
                        sqlCmd.Parameters.Add(new SqlParameter("@SurveyTypeName", s.SurveyTypeName));
                        sqlCmd.Parameters.Add(new SqlParameter("@ModifiedBy", s.ModifiedBy));
                        sqlCmd.Parameters.Add(new SqlParameter("@ModifiedDate", s.ModifiedDate));
                        sqlCon.Open();

                        sqlCmd.ExecuteNonQuery();
                        Console.WriteLine("Survey added");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
        public void UpdateSurvey(Survey s)
        {

            string updatestmt = @"UPDATE Student SET  SurveyTypeID= @SurveyTypeID,SurveyTypeName=@SurveyTypeName WHERE SurveyID = @;";
            using (var sqlCon = new SqlConnection("Data Source=ESSPLLAP64\\SQL2019;Initial Catalog=surveyDB;Integrated Security=SSPI;trustservercertificate=true"))
            {
                using (var sqlCmd = new SqlCommand(updatestmt, sqlCon))
                {
                    sqlCmd.CommandType = CommandType.Text;
                    try
                    {
                        sqlCon.Open();

                        sqlCmd.Parameters.Add(new SqlParameter("@survey ID", s.SurveyID));
                        sqlCmd.Parameters.Add(new SqlParameter("@SurveyTypeID", s.SurveyTypeID));
                        sqlCmd.Parameters.Add(new SqlParameter("@SurveyTypeName", s.SurveyTypeName));
                        sqlCmd.Parameters.Add(new SqlParameter("@ModifiedBy", s.ModifiedBy));
                        sqlCmd.Parameters.Add(new SqlParameter("@ModifiedDate", s.ModifiedDate));
                        sqlCon.Open();

                        sqlCmd.ExecuteNonQuery();
                        Console.WriteLine("Survey updated");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }
        }
        public void DeleteSurvey(int SurveyID)
        {
            string deletestmt = @"DELETE FROM Student WHERE SurveyID = @SurveyID;";
            using (var sqlCon = new SqlConnection("Data Source=ESSPLLAP64\\SQL2019;Initial Catalog=surveyDB;Integrated Security=SSPI;trustservercertificate=true"))
            {
                using (var sqlCmd = new SqlCommand(deletestmt, sqlCon))
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@SurveyID", SurveyID);
                    sqlCon.Open();
                    sqlCmd.ExecuteNonQuery();
                    Console.WriteLine($"Student with SurveyId {SurveyID} deleted");
                }
            }
        }
    }

    public delegate void functionaldelegate(int SurveyTypeID, string SurveyTypeName, string ModifiedBy, string ModifiedDate);
    //public delegate void functionaldelegate(Survey s);


    public class Testdelegate
    {
        public void AddSurvey()
        {
            Console.WriteLine("Add survey method");
        }
        public void UpdateSurvey()
        {
            Console.WriteLine("Update survey method");
        }
        public void DeleteSurvey()
        {
            Console.WriteLine(" Delete survey method");
        }
        public static void main(String[] args)
        { 
            functionaldelegate fd = new functionaldelegate(AddSurvey;
            fd += UpdateSurvey;
            fd += Deletesurvey;
        }
}
}



























