using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BETTER.BusinessLayer.Classes;

namespace BETTER.Pages
{
    public partial class FightSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if coming from fight outcome, then make match history to that of the champion that
            //the user just fought with


            if ((String)Session["ClickFrom"] == "A")
            {
                TitanManager tm = new TitanManager();
                enemyElemental.Visible = true;
                lblChampName.Visible = true;
                Session["ClickFrom"] = null;
            }
        }

        //Funtion that changes left image in match history to that of the selected elemental
        //More functionality will be implemented when connected to the database
        //i.e. dynamically updating enemies, etc.
        protected void lvAvailableTitanList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Selected")
            {

                TitanManager tm = new TitanManager();
                Label lblTitanName = (Label)e.Item.FindControl("lblTitanName");

                Session["MatchHistorySelect"] = lblTitanName.Text;
                Session["MatchHistorySelectID"] = tm.GetTitanID(lblTitanName.Text);

                Session["MatchHistorySelectImagePath"] = tm.GetTitanImagePath(lblTitanName.Text);

                enemyElemental.Visible = true;
                lblChampName.Visible = true;
                lblChampName.Text = lblTitanName.Text;
            }
        }

        protected void lvMatchHistoryTitanList_DataBound(object sender, ListViewItemEventArgs e)
        {
            TitanManager tm = new TitanManager();
            EnemyTitanManager etm = new EnemyTitanManager();

            Label lblTitanName = (Label)e.Item.FindControl("lblTitanName");
            Image imgSelectedChamp = (Image)e.Item.FindControl("imgSelectedChamp");
            Label lblOutcomeWin = (Label)e.Item.FindControl("lblOutcome1");
            Label lblOutcomeLoss = (Label)e.Item.FindControl("lblOutcome2");
            Label lblBattleWinner = (Label)e.Item.FindControl("lblBattleWinner");
            Image imgEnemy = (Image)e.Item.FindControl("imgEnemy");
            Label lblBattler1ID = (Label)e.Item.FindControl("lblBattler1ID");
            Label lblBattler2ID = (Label)e.Item.FindControl("lblBattler2ID");

            imgSelectedChamp.ImageUrl = Session["MatchHistorySelectImagePath"].ToString();
            if (Convert.ToInt32(Session["MatchHistorySelectID"]) == Convert.ToInt32(lblBattler1ID.Text) && Convert.ToBoolean(lblBattleWinner.Text) == true)
            {
                lblOutcomeWin.Visible = true;
            }
            else if (Convert.ToInt32(Session["MatchHistorySelectID"]) == Convert.ToInt32(lblBattler2ID.Text) && Convert.ToBoolean(lblBattleWinner.Text) == false)
            {
                lblOutcomeWin.Visible = true;
            }
            else
            {
                lblOutcomeLoss.Visible = true;
            }
        }
    }
}  