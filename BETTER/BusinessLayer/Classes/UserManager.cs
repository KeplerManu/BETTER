using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace BETTER.BusinessLayer.Classes
{
    public class UserManager
    {
        string DBConn = ConfigurationManager.ConnectionStrings["udbBetterConnectionString"].ConnectionString;

        public bool NameExists(string userName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM tblUser WHERE username LIKE @username", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@username", userName);
                    int userCount = (int)sqlCommand.ExecuteScalar();
                    if (userCount > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool EmailExists(string userEmail)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM tblUser WHERE email LIKE @email", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@email", userEmail);
                    int userCount = (int)sqlCommand.ExecuteScalar();
                    if (userCount > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool LoginValidation(string userEmail, string userPassword)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM tblUser WHERE email=@email AND passcode=@passcode", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@email", userEmail);
                    sqlCommand.Parameters.AddWithValue("@passcode", userPassword);
                    int userCount = (int)sqlCommand.ExecuteScalar();
                    if (userCount > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ValidateParentPIN(string userName, int pIN)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM tblUser WHERE username=@username AND pIN=@pIN", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@username", userName);
                    sqlCommand.Parameters.AddWithValue("@pIN", pIN);
                    int userCount = (int)sqlCommand.ExecuteScalar();
                    if (userCount == 1)
                    {
                        return true;
                    }


                }
            }
            return false;
        }

        public string GetUsernameByEmail(string userEmail)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT username FROM tblUser WHERE email=@email", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@email", userEmail);
                    
                    string result = sqlCommand.ExecuteScalar().ToString();
                    return result;
                }
            }
        }

        public int GetUserID()
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT userId FROM tblUser WHERE username=@username", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@username", System.Web.HttpContext.Current.Session["UserName"]);

                    int result = (int)sqlCommand.ExecuteScalar();
                    return result;
                }
            }
        }

        public string GetExercisePoints()
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT exercisePoints FROM tblUser WHERE username=@username", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@username", System.Web.HttpContext.Current.Session["UserName"]);
                    string result = sqlCommand.ExecuteScalar().ToString();
                    return result;
                }
            }
        }

        public void AddExercisePoints(string UserName, int ExercisePoints)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE tblUser SET exercisePoints = exercisePoints+@input WHERE username=@username", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@username", UserName);
                    sqlCommand.Parameters.AddWithValue("@input", ExercisePoints);

                    sqlCommand.ExecuteScalar();
                }
            }
        }

        public void SubtractExercisePoints(string UserName, int ExercisePoints)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE tblUser SET exercisePoints = exercisePoints-@input WHERE username=@username", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@username", UserName);
                    sqlCommand.Parameters.AddWithValue("@input", ExercisePoints);

                    sqlCommand.ExecuteScalar();
                }
            }
        }
    }
}