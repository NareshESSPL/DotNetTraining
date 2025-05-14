using DTO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlTypes;

namespace DataLayer
{
    public class StudentDAL
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;


        public StudentDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("ConString");
        }

        public List<Students> GetStudentData() 
        {
            var StudentsData = new List<Students>();

            using (var connection = new SqlConnection(_connectionstring))
            {
                using (var command = new SqlCommand("Select * from StudentData",connection))
                { 
                    command.CommandType = CommandType.Text; 
                    
                    connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read()) 
                    {
                        var SingleStudent = new Students();

                        SingleStudent.StudentId = reader.GetInt32("StudentId");
                        SingleStudent.StudentName = reader.GetString("StudentName");
                        SingleStudent.StudentEmail = reader.GetString("StudentEmail");
                        SingleStudent.StudentAge = reader.GetInt32("StudentAge");
                        SingleStudent.Address = reader.GetString("StudentAddress");
                        SingleStudent.AddmissionDate= reader.GetDateTime("AddmissionDate");
                        SingleStudent.DOB = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("DOB")));
                        SingleStudent.Gender = reader.GetString("Gender");

                        StudentsData.Add(SingleStudent);
                    }
                
                }
            }
            return StudentsData ; 
        }


        public void  AddStudentInDB(Students obj)
        {
            

            using (var connection = new SqlConnection(_connectionstring))
            {
                using (var command = new SqlCommand("Proc_Insert_into_StudentData", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    command.Parameters.Add(new SqlParameter("@StudentName",obj.StudentName));
                    command.Parameters.Add(new SqlParameter("@StudentEmail", obj.StudentEmail));
                    command.Parameters.Add(new SqlParameter("@StudentAge", obj.StudentAge));
                    command.Parameters.Add(new SqlParameter("@StudentAddress", obj.Address));
                    command.Parameters.Add(new SqlParameter("@DOB", obj.DOB.ToDateTime(TimeOnly.MinValue)));
                    command.Parameters.Add(new SqlParameter("@Gender", obj.Gender));

                    command.ExecuteNonQuery();

                }
            }
           
        }

        public Students GetStudentData(int id)
        {

            var obj = new Students();

            using (var connection = new SqlConnection(_connectionstring))
            {
                using (var command = new SqlCommand($"Select * From StudentData where StudentId ={id}", connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        obj.StudentId = reader.GetInt32("StudentId");
                        obj.StudentName = reader.GetString("StudentName");
                        obj.StudentEmail = reader.GetString("StudentEmail");
                        obj.StudentAge = reader.GetInt32("StudentAge");
                        obj.Address = reader.GetString("StudentAddress");
                        obj.AddmissionDate = reader.GetDateTime("AddmissionDate");
                        obj.DOB = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("DOB")));
                        obj.Gender = reader.GetString("Gender");

                    }
                }
            }

            return obj;
        }


        public void DeleteFromDB(int id)
        {
            using (var connection = new SqlConnection(_connectionstring)) {

                using (var command = new SqlCommand("Proc_Delete_StudentById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    command.Parameters.AddWithValue("@StudentId", id);

                    command.ExecuteNonQuery();

                }

            }
        }
    }
}
