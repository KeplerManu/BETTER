using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BETTER.BusinessLayer.Classes;

namespace BETTER.Pages
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //When the page is first loaded, set session variable to null so when user clicks character info button
            // they are still prompted to pick a champion
            if (!Page.IsPostBack)
            {
                Session["SelectedChampImage"] = null;
                Session["SelectedChampName"] = null;
                Session["SelectedChampLevel"] = null;
            }
        }

        //Function FilterChamps changes border width of selected element, makes selected element border red,
        //and changes visible div depending on selected element
        protected void FilterChamps(int value1, int value2, int value3, int value4, ImageButton SelectedElement, string method)
        {
            imgBtnAir.BorderWidth = (value1);
            imgBtnEarth.BorderWidth = (value2);
            imgBtnFire.BorderWidth = (value3);
            imgBtnWater.BorderWidth = (value4);
            SelectedElement.BorderColor = Color.Red;
            GetTitanListByUserName.SelectMethod = method;
        }

        protected void imgBtnAir_Click(object sender, ImageClickEventArgs e)
        {
            FilterChamps(2, 0, 0, 0, imgBtnAir, "GetAirTitansByUserName");
        }

        protected void imgBtnEarth_Click(object sender, ImageClickEventArgs e)
        {
            FilterChamps(0, 2, 0, 0, imgBtnEarth, "GetEarthTitansByUserName");
        }

        protected void imgBtnFire_Click(object sender, ImageClickEventArgs e)
        {
            FilterChamps(0, 0, 2, 0, imgBtnFire, "GetFireTitansByUserName");
        }

        protected void imgBtnWater_Click(object sender, ImageClickEventArgs e)
        {
            FilterChamps(0, 0, 0, 2, imgBtnWater, "GetWaterTitansByUserName");
        }

        //When connected to the DB, this button will cross check elements and replace elemental if active elemental is of the same element
        //or if no elemental of the same element is active, this button will simply add currently selected elemental to active element table


        //Redirects to create new elemental
        protected void btnNewChamp_Click(object sender, EventArgs e)
        {
            Response.Redirect("CharacterCreation.aspx");
        }

        protected void lvAvailableTitanList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            TitanManager tm = new TitanManager();
            Label lblTitanName = (Label)e.Item.FindControl("lblTitanName");

            if (e.CommandName == "Activate")
            {
                string elementID = tm.GetElementID(lblTitanName.Text).ToString();
                if (tm.ValidateActiveTitan(Convert.ToInt32(elementID), lblTitanName.Text)  == true)
                {
                    lblActivateError.Visible = true;
                }
                else
                {
                    Button btnActivate = (Button)e.Item.FindControl("btnActivate");
                    TitanManager obj = new TitanManager();
                    obj.ActivateTitan(lblTitanName.Text);
                    Response.Redirect("CharacterSelection.aspx");
                }  
            }

            if (e.CommandName == "Info")
            {
                Button btnCharacterInfo = (Button)e.Item.FindControl("btnCharacterInfo");
                Session["InfoSelected"] = lblTitanName.Text;
                Response.Redirect("CharacterManagement.aspx");
            }
        }

        protected void lvActiveTitanList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                Button btnRemove = (Button)e.Item.FindControl("btnRemove");
                Label lblActiveTitanName = (Label)e.Item.FindControl("lblActiveTitanName");
                TitanManager obj = new TitanManager();
                obj.DeactivateTitan(lblActiveTitanName.Text);
                Response.Redirect("CharacterSelection.aspx");
            }
        }
    }
}