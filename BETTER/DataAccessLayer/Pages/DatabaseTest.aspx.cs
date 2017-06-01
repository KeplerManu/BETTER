using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BETTER.DataAccessLayer.Pages
{
    public partial class DatabaseTest : System.Web.UI.Page
    {
        string DBConn;

        protected void Page_Load(object sender, EventArgs e)
        {
            DBConn = ConfigurationManager.ConnectionStrings["udbBetterConnectionString"].ConnectionString;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(DBConn))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO tblUser (email, username, passcode, parentEmail, pIN) Values (@email, @username, @passcode, @parentEmail, @pIN)";
                //SqlCommand command = new SqlCommand("INSERT INTO tblUser (username) Values (@username)");

                command.Parameters.AddWithValue("@email", txbDatabaseTest1.Text);
                command.Parameters.AddWithValue("@username", txbDatabaseTest2.Text);
                command.Parameters.AddWithValue("@passcode", txbDatabaseTest3.Text);
                command.Parameters.AddWithValue("@parentEmail", txbDatabaseTest4.Text);
                command.Parameters.AddWithValue("@pIN", txbDatabaseTest5.Text);
 
                int result = command.ExecuteNonQuery();
                
            }

        }
       
    }
}