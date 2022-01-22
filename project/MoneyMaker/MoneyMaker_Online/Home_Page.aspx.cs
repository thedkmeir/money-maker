using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoneyMaker_Online.ServiceReference;

namespace MoneyMaker_Online
{
    public partial class Home_Page : System.Web.UI.Page
    {
        public Service1Client s = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}