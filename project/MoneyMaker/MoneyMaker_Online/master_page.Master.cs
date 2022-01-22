using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoneyMaker_Online
{
    public partial class master_page : System.Web.UI.MasterPage
    {
        public string name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["fname"] != null)
            {
                name = Session["fname"].ToString();
                name[0].ToString().ToUpper();
                dropdown.Visible = true;
                profile.Visible = true;
                userintro.Visible = true;
                userintro.InnerText = "Hello " + name + " your balance is: " + Session["Money"].ToString(); ;
                iii.InnerText = "Log Out";
                iii.HRef = "Logout.aspx";
            }
            else
            {
                dropdown.Visible = false;
                profile.Visible = false;
                userintro.Visible = false;
                iii.InnerText = "Log In";
                iii.HRef = "Log_in.aspx";
            }
        }
    }
}