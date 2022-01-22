using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using MoneyMaker_Online.ServiceReference;

namespace MoneyMaker_Online
{
    public partial class Register : System.Web.UI.Page
    {
        public Service1Client s = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string alert = "";

            if (TextBox1.Text == "")
            {
                alert += "First Name field is empty.<br />";
            }
            else
            {
                if (!Field_Limitor.letter_check(TextBox1.Text))
                {
                    alert += "First Name field has signs in it.<br />";
                }
            }

            if (TextBox2.Text == "")
            {
                alert += "Last Name field is empty.<br />";
            }
            else
            {
                if (!Field_Limitor.letter_check(TextBox1.Text))
                {
                    alert += "First Name field has signs in it.<br />";
                }
            }

            if (TextBox3.Text == "")
            {
                alert += "Password field is empty.<br />";
            }
            else
            {
                if (!Field_Limitor.signs_check_alltext(TextBox3.Text))
                {
                    alert += "Password field has signs in it.<br />";
                }
                if (!Field_Limitor.length_check(20, 8, TextBox3.Text))
                {
                    alert += "Password needs to be between 20-8 characters.<br />";
                }
                if (!Field_Limitor.has_number(TextBox3.Text))
                {
                    alert += "Password field need to have at least one number.<br />";
                }
                if (!Field_Limitor.has_uppercut(TextBox3.Text))
                {
                    alert += "Password field need to have at least one upercut letter.<br />";
                }
                if (!Field_Limitor.has_lowercut(TextBox3.Text))
                {
                    alert += "Password field need to have at least one lowercut letter.<br />";
                }
            }

            if (TextBox4.Text == "")
            {
                alert += "Money field is empty.<br />";
            }
            else
            {
                if (!Field_Limitor.only_numbers(TextBox4.Text))
                {
                    alert += "Money field has letters/signs.<br />Money amount cant be smaller then 1.<br />";
                }
            }

            if (TextBox5.Text == "")
            {
                alert += "Email field is empty.<br />";
            }
            else
            {
                if (!Field_Limitor.signs_check_alltext(TextBox5.Text))
                {
                    alert += "Email field has signs in it.<br />";
                }
            }

            if (alert == "")
            {
                Label6.Text = "";
                if (!s.Users_check_email_duplicate(TextBox5.Text))
                {
                    Label6.Text = "This email is already in use";
                }
                else
                {
                    s.Users_Register(TextBox1.Text, TextBox2.Text, TextBox3.Text, int.Parse(TextBox4.Text), "", DateTime.Now.ToString("yyyy/MM/dd"), TextBox5.Text);
                    int userid = s.Users_Login(TextBox5.Text, TextBox3.Text);
                    Session["user_id"] = userid;
                    Session["signed"] = true;
                    Session["fname"] = TextBox1.Text;
                    Session["lname"] = TextBox2.Text;
                    Session["password"] = TextBox3.Text;
                    Session["email"] = TextBox1.Text;
                    Session["money"] = TextBox4.Text;
                    Session["register_date"] = DateTime.Now.ToString("yyyy/MM/dd");
                    string date = Session["register_date"].ToString();
                    date = date.Substring(0, 4);
                    Session["year_registered"] = date;
                    Session["all_income"] = "0";
                    Session["all_outcome"] = "0";
                    Session["table_num"] = "1";
                    Session["table_year"] = DateTime.Now.Year.ToString();
                    Session["future_monthly_income_average"] = 0;
                    Session["future_monthly_outcome_average"] = 0;
                    Session["income_average"] = "0";
                    Session["outcome_average"] = "0";
                    Response.Redirect("Home_Page.aspx");
                }
            }
            else
            {
                Label6.Text = alert;
            }
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}