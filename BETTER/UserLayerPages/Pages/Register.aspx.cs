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

namespace BETTER.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        string DBConn;

        protected void Page_Load(object sender, EventArgs e)
        {
            DBConn = ConfigurationManager.ConnectionStrings["udbBetterConnectionString"].ConnectionString;
        }

        //"already have an account" button redirects to login
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        //back to welcome splash
        protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }

        //If validated, session username variable is set as User Email and the user is redirected to the main menu.
        //In assignment 2, will setup email functionality and will send an email to user for user validation
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            User objUser = new User();
            objUser.UserEmail = txbEmail.Text;
            objUser.FirstName = txbFirstName.Text;
            objUser.LastName = txbLastName.Text;
            objUser.UserName = txbUsername.Text;
            objUser.UserParentEmail = txbParentEmail.Text;
            objUser.UserPasscode = txbPassword.Text;

            var userManager = new UserManager();

            bool nameExists = userManager.NameExists(txbUsername.Text);
            bool emailExists = userManager.EmailExists(txbEmail.Text);
  
            if (nameExists == true)
            {
                if (emailExists == true)
                {
                    lblNameError.Visible = true;
                    lblEmailError.Visible = true;
                }
                else
                {
                    lblNameError.Visible = true;
                    lblEmailError.Visible = false;
                }
            }
            else if (emailExists == true)
            {
                lblEmailError.Visible = true;
                lblNameError.Visible = false;
            }
            else
            {
                objUser.AddUser();
                if (rdbAnonymous.Checked == true)
                {
                    Session["AnonMode"] = true;
                }
                else
                {
                    Session["AnonMode"] = false;
                }
                Session["UserName"] = txbUsername.Text;
                Session["LoginStatus"] = true;
                Response.Redirect("MainMenu.aspx");
            }
        }
    }
}