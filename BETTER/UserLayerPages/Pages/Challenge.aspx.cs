using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BETTER.BusinessLayer.Classes;

namespace BETTER.Pages
{
    public partial class Challenge : System.Web.UI.Page
    {
        private TitanManager titanManager = new TitanManager();

        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //selectChamp function displays selected champ (to the left), sets the chosen champs information to session variable for future use,
        //and makes enemy selection list visible (to the right)
        protected void lvActiveTitanList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Selected")
            {

                ImageButton selectTitan = (ImageButton)e.Item.FindControl("imgBtnTitan");
                Label lblActiveTitanName = (Label)e.Item.FindControl("lblActiveTitanName");
                TitanManager obj = new TitanManager();
                ChampSelection.Visible = false;
                EnemySelection.Visible = true;

                Session["ChampID"] = obj.GetTitanID(lblActiveTitanName.Text).ToString();
                Session["SelectedChampImage"] = obj.GetTitanImagePath(lblActiveTitanName.Text);
                Session["ChampName"] = lblActiveTitanName.Text;
                Session["SelectedChampElement"] = obj.GetElementName(lblActiveTitanName.Text).ToString();

                lblUserName.Text = obj.GetUserNameByTitanID(Session["ChampID"].ToString()).ToString();
                imgSelectedChamp.ImageUrl = obj.GetTitanImagePath(lblActiveTitanName.Text);
                lblChampName.Text = lblActiveTitanName.Text;
                lblChampElement.Text = obj.GetElementName(lblActiveTitanName.Text).ToString();
                lblChampLevel.Text = obj.GetTitanLevel(lblActiveTitanName.Text).ToString();
                lblChampStep.Text = obj.GetTitanStep(lblActiveTitanName.Text).ToString();
                lblChampXP.Text = obj.GetTitanExperience(lblActiveTitanName.Text).ToString();
                lblChampRemainingXP.Text = obj.GetTitanMaxLevelExperience(lblActiveTitanName.Text).ToString();
                lblChampWins.Text = obj.GetTitanWins(lblActiveTitanName.Text).ToString();
                lblChampLosses.Text = obj.GetTitanLosses(lblActiveTitanName.Text).ToString();

                Session["ChallengeSelectedTitan"] = lblActiveTitanName.Text;
                Session["ChallengeSelectedTitanElement"] = obj.GetElementName(lblActiveTitanName.Text).ToString();

            }
        }

        //selectEnemyChamp function displays selected enemy champ (to the right), sets the chosen enemy champ's information
        //to session variables for future use, makes the list of enemy champions and "choose champion" text invisible, and makes
        //VS text, Fight button, Cancel Fight button, and "Are you ready?" text visible.
        protected void lvEnemyTitanList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Selected")
            {
                ImageButton selectTitan = (ImageButton)e.Item.FindControl("imgBtnEnemy");
                Label lblEnemyTitanName = (Label)e.Item.FindControl("lblEnemyChampName");
                EnemyTitanManager obj = new EnemyTitanManager();
                UserManager um = new UserManager();

                Session["EnemyChampID"] = obj.GetEnemyTitanID(lblEnemyTitanName.Text).ToString();
                Session["EnemyTitanElement"] = obj.GetEnemyElementName(lblEnemyTitanName.Text).ToString();

                enemyElementalList.Visible = false;
                enemyElemental.Visible = true;
                lblEnemyUserName.Text = obj.GetUserNameByTitanID(Session["EnemyChampID"].ToString()).ToString();
                imgSelectedEnemyChamp.ImageUrl = obj.GetEnemyTitanImagePath(lblEnemyTitanName.Text);
                lblEnemyChampName.Text = lblEnemyTitanName.Text;
                lblEnemyChampElement.Text = obj.GetEnemyElementName(lblEnemyTitanName.Text).ToString();
                lblEnemyChampLevel.Text = obj.GetEnemyTitanLevel(lblEnemyTitanName.Text).ToString();
                lblEnemyChampStep.Text = obj.GetEnemyTitanStep(lblEnemyTitanName.Text).ToString();
                lblEnemyChampXP.Text = obj.GetEnemyTitanExperience(lblEnemyTitanName.Text).ToString();
                lblEnemyChampXPRemaining.Text = obj.GetEnemyTitanMaxLevelExperience(lblEnemyTitanName.Text).ToString();
                lblEnemyChampWins.Text = obj.GetEnemyTitanWins(lblEnemyTitanName.Text).ToString();
                lblEnemyChampLosses.Text = obj.GetEnemyTitanLosses(lblEnemyTitanName.Text).ToString();
                Session["EnemyImage"] = obj.GetEnemyTitanImagePath(lblEnemyTitanName.Text).ToString();
                Session["EnemyChampName"] = lblEnemyTitanName.Text;

                textVS.Visible = true;
                btnFight.Visible = true;
                btnCancelFight.Visible = true;
                h2Choose.Visible = false;
                h2Fight.Visible = true;

            }
        }

        //Link to fight outcome page
        protected void btnFight_Click(object sender, EventArgs e)
        {
            var obj = new TitanManager();
            var etm = new EnemyTitanManager();
            var battle = new BattleManager();
            Battle objBattle = new Battle();
            string fight = battle.BattleOutcome(Session["ChallengeSelectedTitan"].ToString(), Session["EnemyChampName"].ToString(), Session["SelectedChampElement"].ToString(), Session["EnemyTitanElement"].ToString());
            if (fight == "win")
            {
                objBattle.battler1 = Session["ChallengeSelectedTitan"].ToString();
                objBattle.battler2 = Session["EnemyChampName"].ToString();
                objBattle.battleWinner = true;
                objBattle.AddBattle();
                Session["FightStatus"] = "win";
                double experience = Math.Round(Convert.ToDouble(obj.GetTitanExperience(Session["ChallengeSelectedTitan"].ToString())) * 0.25, 0);
                obj.UpdateTitanExperience(Session["ChallengeSelectedTitan"].ToString(), Convert.ToInt32(experience));
            }
            else if (fight == "loss")
            {
                objBattle.battler1 = Session["ChallengeSelectedTitan"].ToString();
                objBattle.battler2 = Session["EnemyChampName"].ToString();
                objBattle.battleWinner = false;
                objBattle.AddBattle();
                Session["FightStatus"] = "loss";
                double experience = Math.Round(Convert.ToDouble(etm.GetEnemyTitanExperience(Session["EnemyChampName"].ToString())) * 0.25, 0);
                etm.UpdateEnemyTitanExperience(Session["EnemyChampName"].ToString(), Convert.ToInt32(experience));
            }
            else if (fight == "draw")
            {
                Session["FightStatus"] = "draw";
            }
            Response.Redirect("FightOutcome.aspx");
        }

        //Link to beginning of challenge page
        protected void btnCancelFight_Click(object sender, EventArgs e)
        {
            Response.Redirect("Challenge.aspx");
        }
    }
}