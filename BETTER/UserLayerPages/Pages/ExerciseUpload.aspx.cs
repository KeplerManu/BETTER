using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BETTER.BusinessLayer.Classes;

namespace BETTER.Pages
{
    public partial class ExerciseUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //validates whether or not pin is correct and then updates points if Correct
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var userManager = new UserManager();
            //hard coded testing. Parent PIN = 1111
            //If PIN is correct, show "Congratulations" message and update user's exercise points
            if (userManager.ValidateParentPIN(Session["UserName"].ToString(), Convert.ToInt32(txbParentPIN.Text)) == true)
            {
                lblError.Visible = false;
                int newPoints = Convert.ToInt32(txbExercisePoints.Text);
                int newTotal = Convert.ToInt32(Session["ExercisePoints"]) + newPoints;
                ((Label)Master.FindControl("lblExercisePoints")).Text = newTotal.ToString();
                Session["ExercisePoints"] = newTotal;
                getPoints.Visible = true;
                lblPoints.Text = txbExercisePoints.Text;

                userManager.AddExercisePoints(Session["UserName"].ToString(), Convert.ToInt32(txbExercisePoints.Text));
            }
            //If PIN is incorrect, show error message
            else
            {
                lblError.Text = "You need your parent's permission to upload your exercise!";
                lblError.Visible = true;
                getPoints.Visible = false;
            }
            

        }
    }
}