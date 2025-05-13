using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StudentManagementSystem.DTO;
using System.Data;
using System.Data.SqlTypes;
namespace StudentManagement.DataLayer
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

        public List<Student> GetStudents()
        {
            var students = new List<Student>();

            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                using (var sqlCmd = new SqlCommand("SELECT * FROM Student", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.Text;

                    sqlCon.Open();

                    var reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var student = new Student();
                        student.StudentID = reader.GetInt32(reader.GetOrdinal("StudentID"));
                        student.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        student.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                        student.DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth"));
                        student.Email = reader.GetString(reader.GetOrdinal("Email"));
                        student.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                        student.Address = reader.GetString(reader.GetOrdinal("Address"));

                        students.Add(student);
                    }
                }
            }

            return students;
        }

        public void AddStudent(Student student)
        {
            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                using (var sqlCmd = new SqlCommand("AddStudent", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add(new SqlParameter("@StudentID", student.StudentID));
                    sqlCmd.Parameters.Add(new SqlParameter("@FirstName", student.FirstName));
                    sqlCmd.Parameters.Add(new SqlParameter("@LastName", student.LastName));
                    sqlCmd.Parameters.Add(new SqlParameter("@DateOfBirth", student.DateOfBirth));
                    sqlCmd.Parameters.Add(new SqlParameter("@Email", student.Email));
                    sqlCmd.Parameters.Add(new SqlParameter("@PhoneNumber", student.PhoneNumber));
                    sqlCmd.Parameters.Add(new SqlParameter("@Address", student.Address));

                    sqlCon.Open();
                    sqlCmd.ExecuteNonQuery();
                }
            }

        }

        public Student GetStudent(int studentId)
        {
            var student = new Student();

            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                using (var sqlCmd = new SqlCommand("SELECT * FROM Student WHERE StudentID =" + studentId, sqlCon))
                {
                    sqlCmd.CommandType = CommandType.Text;

                    sqlCon.Open();

                    var reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        student.StudentID = reader.GetInt32(reader.GetOrdinal("StudentID"));
                        student.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        student.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                        student.DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth"));
                        student.Email = reader.GetString(reader.GetOrdinal("Email"));
                        student.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                        student.Address = reader.GetString(reader.GetOrdinal("Address"));
                    }
                }
            }

            return student;
        }


        public void DeleteStudent(int studentId)
        {
            using (var sqlCon = new SqlConnection(_connectionstring))
            {
                using (var sqlCmd = new SqlCommand("DELETE FROM Student WHERE StudentID = @StudentID", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.Add(new SqlParameter("@StudentID", studentId));

                    sqlCon.Open();
                    sqlCmd.ExecuteNonQuery();
                }
            }
        }



    }
}
