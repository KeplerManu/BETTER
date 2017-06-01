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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Function selectedElement changes border width of selected element, makes selected element border red,
        //and changes visible div depending on selected element
        protected void selectedElement(int value1, int value2, int value3, int value4, ImageButton SelectedElement, Boolean air, Boolean earth, Boolean fire, Boolean water)
        {
            imgBtnAir.BorderWidth = (value1);
            imgBtnEarth.BorderWidth = (value2);
            imgBtnFire.BorderWidth = (value3);
            imgBtnWater.BorderWidth = (value4);
            SelectedElement.BorderColor = Color.Red;
            filterAir.Visible = air;
            filterEarth.Visible = earth;
            filterFire.Visible = fire;
            filterWater.Visible = water;
        }

        protected void imgBtnAir_Click(object sender, ImageClickEventArgs e)
        {
            selectedElement(2, 0, 0, 0, imgBtnAir, true, false, false, false);
        }

        protected void imgBtnEarth_Click(object sender, ImageClickEventArgs e)
        {
            selectedElement(0, 2, 0, 0, imgBtnEarth, false, true, false, false);
        }

        protected void imgBtnFire_Click(object sender, ImageClickEventArgs e)
        {
            selectedElement(0, 0, 2, 0, imgBtnFire, false, false, true, false);
        }

        protected void imgBtnWater_Click(object sender, ImageClickEventArgs e)
        {
            selectedElement(0, 0, 0, 2, imgBtnWater, false, false, false, true);
        }

        //function highlight sets session variables for ChampImage, ChampName, and ChampLevel
        //to that of the selected elemental and selected element border is thicker
        protected void highlight(ImageButton SelectedChampImage, Label ChampName, ImageButton ChampImage1, ImageButton ChampImage2, int value1, int value2, int value3)
        {
            Session["NewChampImage"] = SelectedChampImage.ImageUrl;
            Session["NewChampName"] = ChampName.Text;
            Session["NewChampLevel"] = 1.ToString();
            ChampImage1.BorderWidth = (value1);
            ChampImage2.BorderWidth = (value2);
            Session["elementID"] = (value3);
        }

        //Following methods calls on the highlight function
        protected void imgBtnAir1_Click(object sender, ImageClickEventArgs e)
        {
            highlight(imgBtnAir1, lblAir1Name, imgBtnAir1, imgBtnAir2, 3, 0, 3);
        }

        protected void imgBtnAir2_Click(object sender, ImageClickEventArgs e)
        {
            highlight(imgBtnAir2, lblAir2Name, imgBtnAir1, imgBtnAir2, 0, 3, 3);
        }

        protected void imgBtnEarth1_Click(object sender, ImageClickEventArgs e)
        {
            highlight(imgBtnEarth1, lblEarth1Name, imgBtnEarth1, imgBtnEarth2, 3, 0, 4);
        }

        protected void imgBtnEarth2_Click(object sender, ImageClickEventArgs e)
        {
            highlight(imgBtnEarth2, lblEarth2Name, imgBtnEarth1, imgBtnEarth2, 0, 3, 4);
        }

        protected void imgBtnFire1_Click(object sender, ImageClickEventArgs e)
        {
            highlight(imgBtnFire1, lblFire1Name, imgBtnFire1, imgBtnFire2, 3, 0, 2);
        }

        protected void imgBtnFire2_Click(object sender, ImageClickEventArgs e)
        {
            highlight(imgBtnFire2, lblFire2Name, imgBtnFire1, imgBtnFire2, 0, 3, 2);
        }

        protected void imgBtnWater1_Click(object sender, ImageClickEventArgs e)
        {
            highlight(imgBtnWater1, lblWater1Name, imgBtnWater1, imgBtnWater2, 3, 0, 1);
        }

        protected void imgBtnWater2_Click(object sender, ImageClickEventArgs e)
        {
            highlight(imgBtnWater1, lblWater1Name, imgBtnWater1, imgBtnWater2, 0, 3, 1);
        }

        //Not connected to DB yet
        //Button will add selected character to user's created elementals table
        //Button redirects to character management page where they can view newly created character
        protected void btnCharacterSelect_Click(object sender, EventArgs e)
        {
            if (Session["NewChampImage"] == null) //if user hasn't chosen champ, show error
            {
                lblError.Text = "Please choose an elemental";
            }
            else
            {
                Titan objTitan = new Titan();
                TitanManager tm = new TitanManager();
                string elementID = Session["elementID"].ToString();
                if (string.IsNullOrWhiteSpace(txbChampName.Text)) //if textbox is empty show error
                {
                    lblEmptyError.Visible = true;
                }
                else //otherwise validate if active character already exists
                {
                    if (tm.ValidateActiveTitan(Convert.ToInt32(elementID), txbChampName.Text) == true)
                    {
                        lblActivateError.Visible = true;
                    }
                    else if (tm.NameExists(txbChampName.Text) == true)
                    {
                        lblNameError.Visible = true;
                    }
                    else
                    {
                        tm.ActivateTitan(txbChampName.Text);
                        objTitan.TitanName = txbChampName.Text;
                        Session["NewChampName"] = txbChampName.Text;
                        objTitan.ElementID = Convert.ToInt32(Session["elementID"]);
                        objTitan.AddTitan();
                        Session["InfoSelected"] = txbChampName.Text;
                        Response.Redirect("CharacterManagement.aspx");
                    }    
                }
            }          
        }
    }
}