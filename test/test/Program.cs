using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SurveyManagement.DTO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SurveyManager sm = new SurveyManager();
            sm.SurveyID = 1;
            sm.SurveyTypeID = 101;
            sm.SurveyTypeName = "Employee Feedback";
            sm.ModifiedBy = "Ravi";
            sm.ModifiedDate = "10-06-2025";

            sm.DisplaySurveyDetails();

            Survey s1 = new Survey();
            s1.SurveyID = 1;
            s1.SurveyTypeID = 101;
            s1.SurveyName = "Annual Survey";
            s1.ModifiedBy = "Ravi";
            s1.ModifiedDate = "10-06-2025";

            sm.AddSurvey(s1);

            s1.SurveyName = "Updated Survey";
            sm.UpdateSurvey(s1);

            sm.DeleteSurvey(s1.SurveyID);
        }
    }

    public class SurveyType
    {
        public int SurveyTypeID { get; set; }
        public string SurveyTypeName { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }

    public class Survey
    {
        public int SurveyID { get; set; }
        public int SurveyTypeID { get; set; }
        public string SurveyName { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }

    public interface ISurvey
    {
        public void AddSurvey(Survey survey);
        public void UpdateSurvey(Survey survey);
        public void DeleteSurvey(int surveyID);

    }

    public abstract class SurveyBase
    {
        public int SurveyID { get; set; }
        public int SurveyTypeID { get; set; }
        public string SurveyTypeName { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }

        public abstract void DisplaySurveyDetails();
    }


    public delegate void LogHandler(string msg);






    public class SurveyManager : SurveyBase, ISurvey
    {
        public static List<Survey> surveyList = new List<Survey>();

        public LogHandler? Logger;

        public SurveyManager()
        {
            Logger = message => Console.WriteLine($"[Log] {message}");
        }

        public override void DisplaySurveyDetails()
        {
            Console.WriteLine($"SurveyID: {SurveyID}");
            Console.WriteLine($"SurveyTypeID: {SurveyTypeID}");
            Console.WriteLine($"SurveyTypeName: {SurveyTypeName}");
            Console.WriteLine($"ModifiedBy: {ModifiedBy}");
            Console.WriteLine($"ModifiedDate: {ModifiedDate}");
        }

        public string connectionString = "Data Source=.;Initial Catalog=TestDB;Integrated Security=True";

        public void AddSurvey(Survey survaay)
        {
            try
            {
                string query = "INSERT INTO Survey (@SurveyID, @SurveyName, @SurveyTypeID, ) ";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SurveyID", SurveyID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
               
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }


        public void UpdateSurvey(Survey survaay)
        {

            try
            {
                string query = "UPDATE Survey SET   WHERE ";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SurveyID", survaay.SurveyID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void DeleteSurvey(int surveyID)
        {
            try
            {
                string query = "DELETE FROM Survey WHERE SurveyID = @SurveyID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SurveyID", SurveyID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

   
}

