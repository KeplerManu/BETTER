using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BETTER.BusinessLayer.Classes;

namespace BETTER.Pages
{
    public partial class FightOutcome : System.Web.UI.Page
    {
        //On page load, grab all information from last page for selected champ and enemy champ
        //and insert them into fight outcome image and labels
        protected void Page_Load(object sender, EventArgs e)
        {
            var obj = new TitanManager();
            var etm = new EnemyTitanManager();
            var battle = new BattleManager();
            Battle objBattle = new Battle();

            imgSelectedChamp.ImageUrl = obj.GetTitanImagePath(Session["ChampName"].ToString());
            lblChampName.Text = Session["ChampName"].ToString();
            lblChampElement.Text = obj.GetElementName(Session["ChampName"].ToString()).ToString();
            lblChampLevel.Text = obj.GetTitanLevel(Session["ChampName"].ToString()).ToString();
            lblChampStep.Text = obj.GetTitanStep(Session["ChampName"].ToString()).ToString();
            lblChampXP.Text = obj.GetTitanExperience(Session["ChampName"].ToString()).ToString();
            lblChampRemainingXP.Text = obj.GetTitanMaxLevelExperience(Session["ChampName"].ToString()).ToString();
            lblChampWins.Text = obj.GetTitanWins(Session["ChampName"].ToString()).ToString();
            lblChampLosses.Text = obj.GetTitanLosses(Session["ChampName"].ToString()).ToString();

            lblEnemyUserName.Text = etm.GetUserNameByTitanID(Session["EnemyChampID"].ToString()).ToString();
            imgSelectedEnemyChamp.ImageUrl = etm.GetEnemyTitanImagePath(Session["EnemyChampName"].ToString());
            lblEnemyChampName.Text = Session["EnemyChampName"].ToString();
            lblEnemyChampElement.Text = etm.GetEnemyElementName(Session["EnemyChampName"].ToString()).ToString();
            lblEnemyChampLevel.Text = etm.GetEnemyTitanLevel(Session["EnemyChampName"].ToString()).ToString();
            lblEnemyChampStep.Text = etm.GetEnemyTitanStep(Session["EnemyChampName"].ToString()).ToString();
            lblEnemyChampXP.Text = etm.GetEnemyTitanExperience(Session["EnemyChampName"].ToString()).ToString();
            lblEnemyChampRemainingXP.Text = etm.GetEnemyTitanMaxLevelExperience(Session["EnemyChampName"].ToString()).ToString();
            lblEnemyChampWins.Text = etm.GetEnemyTitanWins(Session["EnemyChampName"].ToString()).ToString();
            lblEnemyChampLosses.Text = etm.GetEnemyTitanLosses(Session["EnemyChampName"].ToString()).ToString();

            if (!Page.IsPostBack)
            {
                string fight = battle.BattleOutcome(lblChampName.Text, lblEnemyChampName.Text, lblChampElement.Text, lblEnemyChampElement.Text);
                if (Session["FightStatus"].ToString() == "win")
                {
                    lblWin.Visible = true;
                }
                else if (Session["FightStatus"].ToString() == "loss")
                {
                    lblLose.Visible = true;
                }
                else if (Session["FightStatus"].ToString() == "draw")
                {
                    lblDraw.Visible = true;
                }
            }
        }

        //Redirects to Challenge page
        protected void btnChallenge_Click(object sender, EventArgs e)
        {
            Response.Redirect("Challenge.aspx");
        }

        //Redirects to Fight Summaries page
        protected void btnFightSummary_Click(object sender, EventArgs e)
        {
            var tm = new TitanManager();
            Session["ClickFrom"] = "A";
            Session["MatchHistorySelect"] = lblChampName.Text;
            Session["MatchHistorySelectID"] = tm.GetTitanID(lblChampName.Text);
            Session["MatchHistorySelectImagePath"] = tm.GetTitanImagePath(lblChampName.Text);
            Response.Redirect("FightSummary.aspx");
        }

        //Redirects to Main Menu
        protected void btnMainMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }
    }
}