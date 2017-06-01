using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BETTER.Pages
{
    public partial class MainMenu : System.Web.UI.Page
    {

        //if session username isn't null, rename userID label as session username variable
        //otherwise use "user" (for testing)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                lblUserID.Text = Session["UserName"].ToString();
            }
            else
            {
                lblUserID.Text = "User";
            }
        }

        //Buttons in Main Menu leading to corresponding pages when clicked on
        protected void btnCharacterSelect_Click(object sender, EventArgs e)
        {
            Response.Redirect("CharacterSelection.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }

        protected void btnCharacterManage_Click(object sender, EventArgs e)
        {
            Response.Redirect("CharacterManagement.aspx");
        }

        protected void btnChallenge_Click(object sender, EventArgs e)
        {
            Response.Redirect("Challenge.aspx");
        }

        protected void btnFightSummary_Click(object sender, EventArgs e)
        {
            Response.Redirect("FightSummary.aspx");
        }

        protected void btnHOF_Click(object sender, EventArgs e)
        {
            Response.Redirect("HallOfFame.aspx");
        }

        protected void btnUploadExercise_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExerciseUpload.aspx");
        }
    }
}