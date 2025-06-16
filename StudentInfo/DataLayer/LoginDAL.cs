using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataLayer
{
    public class LoginDAL
    {
        private readonly string _connectionString;
        private IConfiguration _configuration;
        // private UserProfile userLogin;

        public LoginDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("ConString");
        }

        public void AddLogin(UserProfile userProfile)
        {

            using (var sqlConn = new SqlConnection(_connectionString))
            {
                using (var sqlCmd = new SqlCommand("sp_entrAlterLoginCreds", sqlConn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        sqlCmd.Parameters.Add(new SqlParameter("@UserId", userProfile.Id));
                        sqlCmd.Parameters.Add(new SqlParameter("@UserName", userProfile.UserName));
                        sqlCmd.Parameters.Add(new SqlParameter("@UserPassword", userProfile.UserPassword));
                        sqlCmd.Parameters.Add(new SqlParameter("@IsActive", userProfile.IsActive));

                        sqlConn.Open();
                        sqlCmd.ExecuteNonQuery();
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


        public bool CredsValid(UserProfile user)
        {
            bool ConfirmCreds = false;
            using (var sqlConn = new SqlConnection(_connectionString))
            {
                using (var sqlCmd = new SqlCommand("SELECT  UserPassword FROM UserProfile Where UserName=@UserName", sqlConn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@UserName", user.UserName); 

                    sqlConn.Open();
                    using (SqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        if (reader.Read()) 
                        {
                            ConfirmCreds = reader.GetString("UserPassword") == user.UserPassword;
                        }
                    }
                }
            }
            return ConfirmCreds;
        }

    }
}

