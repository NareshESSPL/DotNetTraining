using System.Data.SqlClient;
using SUPORT;

namespace MAINNN
{
    public class StudentDal
    {
        private readonly string _connectionString;

        public StudentDal(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<help> AllStudents
        {
            get
            {
                List<help> students = new List<help>();

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Students", conn);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        help student = new help
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Branch = reader["Branch"].ToString(),
                            DocumentPath = reader["DocumentPath"].ToString()
                        };
                        students.Add(student);
                    }
                }

                return students;
            }
        }

        public help GetStudentById(int id)
        {
            help student = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Students WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    student = new help
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Branch = reader["Branch"].ToString(),
                        DocumentPath = reader["DocumentPath"].ToString()
                    };
                }
            }

            return student;
        }


        public void AddStudent(help student)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Students (Name, Branch, DocumentPath) VALUES (@Name, @Branch, @DocumentPath)", connection);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@Branch", student.Branch);
                command.Parameters.AddWithValue("@DocumentPath", student.DocumentPath);
                command.ExecuteNonQuery();
            }
        }
        public void UpdateStudent(help model)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Students SET Name = @Name, Branch = @Branch, DocumentPath = @DocumentPath WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Branch", model.Branch);
                cmd.Parameters.AddWithValue("@DocumentPath", model.DocumentPath ?? string.Empty);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }




        public void DeleteStudent(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Students WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
