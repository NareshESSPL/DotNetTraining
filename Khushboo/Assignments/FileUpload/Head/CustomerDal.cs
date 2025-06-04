using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Support;

namespace MAINNN
{
    public class StudentDal
    {
        private readonly string _connectionString;

        public StudentDal(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Retrieve all students
        public List<help> AllStudents
        {
            get
            {
                var students = new List<help>();

                using (var conn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("SELECT * FROM Help", conn);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var student = new help
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Branch = reader["Branch"].ToString(),
                                DocumentPath = reader["DocumentPath"]?.ToString()
                            };
                            students.Add(student);
                        }
                    }
                }

                return students;
            }
        }

        // Retrieve a student by ID
        public help GetStudentById(int id)
        {
            help student = null;

            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Help WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        student = new help
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Branch = reader["Branch"].ToString(),
                            DocumentPath = reader["DocumentPath"]?.ToString()
                        };
                    }
                }
            }

            return student;
        }

        // Add a new student
        public void AddStudent(help student)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("INSERT INTO Help (Name, Branch, DocumentPath) VALUES (@Name, @Branch, @DocumentPath)", conn);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Branch", student.Branch);
                cmd.Parameters.AddWithValue("@DocumentPath", student.DocumentPath ?? (object)DBNull.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Update an existing student
        public void UpdateStudent(help model)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("UPDATE Help SET Name = @Name, Branch = @Branch, DocumentPath = @DocumentPath WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Branch", model.Branch);
                cmd.Parameters.AddWithValue("@DocumentPath", model.DocumentPath ?? (object)DBNull.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Delete a student by ID
        public void DeleteStudent(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("DELETE FROM Help WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
