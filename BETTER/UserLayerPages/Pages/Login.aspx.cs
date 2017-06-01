using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using BETTER.BusinessLayer.Classes;

namespace BETTER.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        string DBConn;

        protected void Page_Load(object sender, EventArgs e)
        {
            DBConn = ConfigurationManager.ConnectionStrings["udbBetterConnectionString"].ConnectionString;
        }

        //when login clicked, test if username & password is valid (hard coded only 1 set of credentials)
        //If Correct, set session username variable to the username used
        //If Incorrect display error message
        //Username = kepler@test.com   Password = password1
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var userManager = new UserManager();
            var Validation = userManager.LoginValidation(txbEmail.Text, txbPassword.Text);
            if (Validation == true)
            {
                var username = userManager.GetUsernameByEmail(txbEmail.Text);
                Session["UserName"] = username;
                Session["LoginStatus"] = true;
                Response.Redirect("MainMenu.aspx");
            }
            else
            {
                lblLoginError.Visible = true;
            }
        }

        //Redirect to register page when "Already have an account?" clicked
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        //Email provided email address with password reset validation code
        protected void btnPasswordReset_Click(object sender, EventArgs e)
        {
         
        }

        //Back to welcome splash
        protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }
    }
}