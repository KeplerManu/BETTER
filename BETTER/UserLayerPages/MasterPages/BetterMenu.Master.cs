using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BETTER.BusinessLayer.Classes;

namespace BETTER.MasterPages
{
    public partial class BetterMenu : System.Web.UI.MasterPage
    {
        string DBConn;

        //Page validation and set exercise points
        protected void Page_Load(object sender, EventArgs e)
        {
            var userManager = new UserManager();
            if ((bool)Session["LoginStatus"] == true)
            {
                lblUsername.Text = (String)Session["UserName"];
                DBConn = ConfigurationManager.ConnectionStrings["udbBetterConnectionString"].ConnectionString;
                Session["ExercisePoints"] = userManager.GetExercisePoints().ToString();
                lblExercisePoints.Text = Session["ExercisePoints"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}