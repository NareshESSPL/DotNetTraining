using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
namespace StudentPortal.Models.Services

{
    public class StudentService
    {
        private readonly string _connectionString;

        public StudentService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public List<Student> GetStudent()
        {
            var result = new List<Student>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT  StudentID, FirstName, LastName, DateOfBirth,Gender,  Email,  PhoneNumber, EnrollmentDate FROM  Student;"; 
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Student
                    {
                        StudentID = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        DateOfBirth = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                        Gender = reader.IsDBNull(4) ? (char?)null : Convert.ToChar(reader.GetString(4)),
                        Email = reader.IsDBNull(5) ? null : reader.GetString(5),
                        PhoneNumber = reader.IsDBNull(6) ? null : reader.GetString(6),
                        EnrollmentDate = reader.IsDBNull(7) ? (DateTime?)null : reader.GetDateTime(7)
                    });
                }
            }

            return result;
        }

        public void AddStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Student (FirstName, LastName, DateOfBirth, Gender, Email, PhoneNumber, EnrollmentDate)  VALUES ( @FirstName, @LastName, @DateOfBirth, @Gender, @Email, @PhoneNumber, @EnrollmentDate )";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", student.FirstName);
                command.Parameters.AddWithValue("@LastName", student.LastName);
                command.Parameters.AddWithValue("@DateOfBirth", (object?)student.DateOfBirth ?? DBNull.Value);
                command.Parameters.AddWithValue("@Gender", (object?)student.Gender ?? DBNull.Value);
                command.Parameters.AddWithValue("@Email", (object?)student.Email ?? DBNull.Value);
                command.Parameters.AddWithValue("@PhoneNumber", (object?)student.PhoneNumber ?? DBNull.Value);
                command.Parameters.AddWithValue("@EnrollmentDate", (object?)student.EnrollmentDate ?? DBNull.Value);


                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Student WHERE StudentID = @StudentID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public Student GetStudentById(int id)
        {
            Student student = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT StudentID, FirstName, LastName, DateOfBirth, Gender, Email, PhoneNumber, EnrollmentDate FROM Student WHERE StudentID = @StudentID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentID", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    student = new Student
                    {
                        StudentID = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        DateOfBirth = reader.GetDateTime(3),
                        Gender = reader.GetString(4)[0], // Changed from GetChar to GetString + [0] to avoid NotSupportedException
                        Email = reader.GetString(5),
                        PhoneNumber = reader.GetString(6),
                        EnrollmentDate = reader.GetDateTime(7)
                    };
                }
            }
            return student;
        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE Student 
                         SET FirstName = @FirstName, 
                             LastName = @LastName, 
                             DateOfBirth = @DateOfBirth, 
                             Gender = @Gender, 
                             Email = @Email, 
                             PhoneNumber = @PhoneNumber, 
                             EnrollmentDate = @EnrollmentDate 
                         WHERE StudentID = @StudentID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentID", student.StudentID);
                command.Parameters.AddWithValue("@FirstName", student.FirstName);
                command.Parameters.AddWithValue("@LastName", student.LastName);
                command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", student.Gender);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
                command.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


    }
}
              

               
