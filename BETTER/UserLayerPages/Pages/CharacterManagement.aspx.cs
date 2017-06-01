using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BETTER.BusinessLayer.Classes;

namespace BETTER.Pages
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        //Public variable allow access to remaining exercise points in .aspx page
        private UserManager userManager = new UserManager();
        public int Points { get { return Convert.ToInt32(userManager.GetExercisePoints()); } set { Convert.ToInt32(userManager.GetExercisePoints()); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataBind();

                //if coming from the create new character page, display new character stats (when create character button clicked)
                if (Session["InfoSelected"] != null)
                {
                    TitanManager tm = new TitanManager();
                    imgManage.ImageUrl = tm.GetTitanImagePath(Session["InfoSelected"].ToString()).ToString();
                    lblChampName.Text = Session["InfoSelected"].ToString();
                    lblChampLevel.Text = tm.GetTitanLevel(Session["InfoSelected"].ToString());
                    lblChampStep.Text = tm.GetTitanStep(Session["InfoSelected"].ToString()).ToString();
                    lblChampXP.Text = tm.GetTitanExperience(Session["InfoSelected"].ToString()).ToString();
                    lblChampBattles.Text = tm.GetTitanBattles(Session["InfoSelected"].ToString()).ToString();
                    lblChampWins.Text = tm.GetTitanWins(Session["InfoSelected"].ToString()).ToString();
                    lblChampLosses.Text = tm.GetTitanLosses(Session["InfoSelected"].ToString()).ToString();
                }

            }
        }

        //selectElemental function makes selected elemental's border larger and changes
        //the elemental that's currently being managed's image and name to the values of the selected elemental

        protected void btnNameChange_Click(object sender, EventArgs e)
        {
            TitanManager tm = new TitanManager();
            if (tm.NameExists(txbNameChange.Text) == true)
            {
                lblNameError.Visible = true;
            }
            else
            {
                tm.RenameTitan(txbNameChange.Text, lblChampName.Text);
                lblChampName.Text = txbNameChange.Text;
                lblNameError.Visible = false;
                Response.Redirect("CharacterManagement.aspx");
            }
        }

        protected void lvAvailableTitanList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            TitanManager tm = new TitanManager();
            Label lblTitanName = (Label)e.Item.FindControl("lblTitanName");            
            if (e.CommandName == "Selected")
            {
                Session["InfoSelected"] = lblTitanName.Text;
                imgManage.ImageUrl = tm.GetTitanImagePath(Session["InfoSelected"].ToString()).ToString();
                lblChampName.Text = Session["InfoSelected"].ToString();
                lblChampLevel.Text = tm.GetTitanLevel(Session["InfoSelected"].ToString());
                lblChampStep.Text = tm.GetTitanStep(Session["InfoSelected"].ToString()).ToString();
                lblChampXP.Text = tm.GetTitanExperience(Session["InfoSelected"].ToString()).ToString();
                lblChampBattles.Text = tm.GetTitanBattles(Session["InfoSelected"].ToString()).ToString();
                lblChampWins.Text = tm.GetTitanWins(Session["InfoSelected"].ToString()).ToString();
                lblChampLosses.Text = tm.GetTitanLosses(Session["InfoSelected"].ToString()).ToString();
                Session["InfoSelected"] = null;
            }
        }


        //When assignpoints is clicked, champPoints is the amount of xp the champ currently has,
        //remaining points is the amount of exercise points the user currently has, and spendPoints is the amount
        //of points input into the text box.
        protected void btnAssignPoints_Click(object sender, EventArgs e)
        {
            TitanManager tm = new TitanManager();

            int champPoints = Convert.ToInt32(lblChampXP.Text);
            int remainingPoints = Convert.ToInt32(Session["ExercisePoints"]);
            int spendPoints = Convert.ToInt32(txbAssignPoints.Text);

            //if the input is below 1 or above the available points that the user has, return an error
            if (!vldAssignPoints.IsValid)
            {
                vldAssignPoints.ErrorMessage = "Between 0 and " + remainingPoints.ToString();
            }

            //otherwise, reduce the user's points by input amount and increase the champ's xp by input amount
            else
            {
                remainingPoints = remainingPoints - spendPoints;
                champPoints = champPoints + spendPoints;
                ((Label)Master.FindControl("lblExercisePoints")).Text = Convert.ToString(remainingPoints);
                lblChampXP.Text = Convert.ToString(champPoints);
                userManager.SubtractExercisePoints(Session["UserName"].ToString(), Convert.ToInt32(txbAssignPoints.Text));
                Session["ExercisePoints"] = remainingPoints;
                tm.UpdateTitanExperience(lblChampName.Text, spendPoints);
                lblChampLevel.Text = tm.GetTitanLevel(lblChampName.Text);
                lblChampStep.Text = tm.GetTitanStep(lblChampName.Text).ToString();
            }
                
            }
        }
    }