using System.Data.SqlClient;
using help;

namespace Student
{
    public class @class
    {
        public class StudentDal
        {
            private readonly string _connectionString;

            public StudentDal(string connectionString)
            {
                _connectionString = connectionString;
            }
            
            public void AddStudent(hello student)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("INSERT INTO Students (Name, RollNo, Age, Address) VALUES (@Name, @RollNo, @Age, @Address)", connection);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@RollNo", student.RollNo);
                    command.Parameters.AddWithValue("@Age", student.Age);
                    command.Parameters.AddWithValue("@Address", student.Address);
                    command.ExecuteNonQuery();
                }
            }

            public void UpdateStudent(hello student)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("UPDATE Students SET Name = @Name, Age = @Age, Address = @Address WHERE RollNo = @RollNo", connection);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@RollNo", student.RollNo);
                    command.Parameters.AddWithValue("@Age", student.Age);
                    command.Parameters.AddWithValue("@Address", student.Address);
                    command.ExecuteNonQuery();
                }
            }

            public void DeleteStudent(int rollNo)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("DELETE FROM Students WHERE RollNo = @RollNo", connection);
                    command.Parameters.AddWithValue("@RollNo", rollNo);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
