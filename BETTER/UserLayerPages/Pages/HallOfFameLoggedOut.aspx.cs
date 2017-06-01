using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BETTER.Pages
{
    public partial class HallOfFameLoggedOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }
    }
}