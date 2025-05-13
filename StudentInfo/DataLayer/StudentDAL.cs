using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataLayer
{
    public class StudentDAL
    {

        private readonly  string _connectionString;
        private IConfiguration _configuration;


        public StudentDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("ConString");

        }

    

        // Create 
        public void AddStudent(Student student)
        {

            using (var sqlConn = new SqlConnection(_connectionString))
            {

                using (var sqlcmd = new SqlCommand("AddStudent", sqlConn))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;

                    try
                    {

                        sqlcmd.Parameters.Add(new SqlParameter("@RegistrationID", student.StudentRegistrationId));
                        sqlcmd.Parameters.Add(new SqlParameter("@Name", student.StudentName));
                        sqlcmd.Parameters.Add(new SqlParameter("@Age", student.StudentAge));
                        sqlcmd.Parameters.Add(new SqlParameter("@EmailID", student.StudentEmailId));
                        sqlcmd.Parameters.Add(new SqlParameter("@Gender", student.StudentGender));
                        sqlcmd.Parameters.Add(new SqlParameter("@Birthday", student.StudentBirthday));
                       
                        sqlConn.Open();
                        sqlcmd.ExecuteNonQuery();

                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sqlConn.Close();
                    }
                }
            }
        }

        // Read
        public Student GetStudent(int id) { 
        
             Student student = null;

            using (var SqlConn = new SqlConnection(_connectionString))
            {
                using (var sqlcmd = new SqlCommand("select * from Student where RegistrationID =" + id + "", SqlConn))
                {
                    sqlcmd.CommandType=CommandType.Text;
                    SqlConn.Open();

                    var reader = sqlcmd.ExecuteReader();

                    while(reader.Read())
                    {
                        student = new Student()
                        {
                            StudentRegistrationId = reader.GetInt32("RegistrationID"),
                            StudentName = reader.GetString("Name"),
                            StudentAge = reader.GetInt32("Age"),
                            StudentEmailId = reader.GetString("EmailID"),
                            StudentGender = reader.GetInt32("Gender"),
                            StudentBirthday = reader.GetString("Birthday"),

                        };
                    }
                }
            }

            return student;
        
        }

        // Get all Students!!
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (var sqlConn = new SqlConnection(_connectionString))
            {
                using (var sqlCmd = new SqlCommand("select * from Student", sqlConn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.Text;
                    sqlConn.Open();

                    var reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = reader.GetInt32("RegistrationID");
                        var name = reader.GetString("Name");
                        var age = reader.GetInt32("Age");
                        var Email = Convert.ToString(reader["EmailID"]);
                        var Gender = reader.GetInt32("Gender");
                        var Birthday = reader.GetString("Birthday");

                        var student = new Student
                        {
                            StudentRegistrationId = id,
                            StudentName = name,
                            StudentAge = age,
                            StudentBirthday = Birthday,
                            StudentGender = Gender,
                            StudentEmailId=Email
                        };
                        students.Add(student);
                    }
                }
            }

            return students;

        }

        // delete
        public void StudentDelete(int id)
        {
            using (var SqlConn = new SqlConnection(_connectionString))
            {
                using(var sqlCmd=new SqlCommand("DeleteStudent",SqlConn))
                {
                   
                    sqlCmd.CommandType=CommandType.StoredProcedure;
                    SqlConn.Open();

                    sqlCmd.Parameters.Add(new SqlParameter("@RegistrationID",id));
                    sqlCmd.ExecuteNonQuery();


                }
            }
        }

        



    }
}
