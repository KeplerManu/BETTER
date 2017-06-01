using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using BETTER.BusinessLayer.Classes;

namespace BETTER.DataAccessLayer.Classes
{
    public class UserDAL
    {
        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        public void AddUser(string UserEmail, string UserName, string FirstName, string LastName, string UserPassword, string UserParentEmail)
        {
            string DBConn;
            DBConn = ConfigurationManager.ConnectionStrings["udbBetterConnectionString"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();

                using (SqlCommand command = sqlConnection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO tblUser (email, username, firstName, lastName, passcode, parentEmail, pIN) VALUES (@email, @username, @firstName, @lastName, @passcode, @parentEmail, @pIN)";

                    command.Parameters.AddWithValue("@email", UserEmail);
                    command.Parameters.AddWithValue("@username", UserName);
                    command.Parameters.AddWithValue("@firstName", FirstName);
                    command.Parameters.AddWithValue("@lastName", LastName);
                    command.Parameters.AddWithValue("@passcode", UserPassword);
                    command.Parameters.AddWithValue("@parentEmail", UserParentEmail);
                    command.Parameters.AddWithValue("@pIN", GenerateRandomNo());

                    int result = command.ExecuteNonQuery();
                }
                
                //catch
                //{
                //    throw;
                //}
                //finally
                //{
                //    sqlConnection.Close();
                //}
                
            }
        }
    }
}
