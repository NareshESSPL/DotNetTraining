using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using support;  // assuming the 'help' model is defined in this namespace

namespace head
{
    public class PatientDal
    {
        private readonly string _connectionString;

        public PatientDal(string connectionString)
        {
            _connectionString = connectionString;
        }

        // ✅ Get all patients
        public List<help> GetPatients(int id)
        {
            List<help> patients = new List<help>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT PatientId, PatientName, Age, Address FROM Patients", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            help patient = new help
                            {
                                PatientId = reader.GetInt32(0),
                                PatientName = reader.GetString(1),
                                Age = reader.GetInt32(2),
                                Address = reader.GetString(3)
                            };
                            patients.Add(patient);
                        }
                    }
                }
            }
            return patients;
        }

        // ✅ Add a new patient
        public void AddPatient(help patient)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Patients (PatientName, Age, Address, DocumentPath) VALUES (@PatientName, @Age, @Address, @DocumentPath)", connection))
                {
                    command.Parameters.AddWithValue("@PatientName", patient.PatientName);
                    command.Parameters.AddWithValue("@Age", patient.Age);
                    command.Parameters.AddWithValue("@Address", patient.Address);
                    command.Parameters.AddWithValue("@DocumentPath", patient.DocumentPath ?? (object)DBNull.Value);
                    command.ExecuteNonQuery();
                }
            }
        }


        // ✅ Update existing patient
        public void EditPatient(help patient)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("EDIT Patients SET PatientName = @PatientName, Age = @Age, Address = @Address WHERE PatientId = @PatientId", connection))
                {
                    command.Parameters.AddWithValue("@PatientId", patient.PatientId);
                    command.Parameters.AddWithValue("@PatientName", patient.PatientName);
                    command.Parameters.AddWithValue("@Age", patient.Age);
                    command.Parameters.AddWithValue("@Address", patient.Address);
                    command.ExecuteNonQuery();
                }
            }
        }

        // ✅ Delete patient by ID
        public void DeletePatient(int patientId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Patients WHERE PatientId = @PatientId", connection))
                {
                    command.Parameters.AddWithValue("@PatientId", patientId);
                    command.ExecuteNonQuery();
                }
            }
        }

        // ✅ Get a single patient by ID
        public help GetPatientById(int patientId)
        {
            help patient = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT PatientId, PatientName, Age, Address FROM Patients WHERE PatientId = @PatientId", connection))
                {
                    command.Parameters.AddWithValue("@PatientId", patientId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            patient = new help
                            {
                                PatientId = reader.GetInt32(0),
                                PatientName = reader.GetString(1),
                                Age = reader.GetInt32(2),
                                Address = reader.GetString(3)
                            };
                        }
                    }
                }
            }
            return patient;
        }

        
    }
}
