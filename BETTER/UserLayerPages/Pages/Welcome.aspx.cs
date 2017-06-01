using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace BETTER.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Redirect to login when login button clicked
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        //Redirect to register when register button clicked
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
        
        //Redirect to rules when rules button clicked
        protected void btnRules_Click(object sender, EventArgs e)
        {
            Response.Redirect("Rules.aspx");
        }

        //Redirect to Hall of Fame when hall of fame button clicked
        protected void btnHOF_Click(object sender, EventArgs e)
        {
            Response.Redirect("HallOfFameLoggedOut.aspx");
        }
    }
}