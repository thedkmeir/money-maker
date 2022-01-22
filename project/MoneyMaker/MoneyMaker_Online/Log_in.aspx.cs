using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoneyMaker_Online.ServiceReference;

namespace MoneyMaker_Online
{
    public partial class Log_in : System.Web.UI.Page
    {
        public Service1Client s = new Service1Client();
        public string hell = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string alert = "";

            if (TextBox1.Text == "")
            {
                alert += "Email field is empty.<br />";
            }
            else
            {
                if (!Field_Limitor.signs_check_alltext(TextBox1.Text))
                {
                    alert += "Email field has signs in it.<br />";
                }
            }

            if (TextBox3.Text == "")
            {
                alert += "Password field is empty.<br />";
            }
            else if (!Field_Limitor.signs_check_alltext(TextBox3.Text))
            {
                alert += "Password field has signs in it.<br />";
            }

            if (alert == "")
            {
                Label4.Text = "";
                int userid = s.Users_Login(TextBox1.Text, TextBox3.Text);
                if (userid != -1)
                {
                    Session["user_id"] = userid;
                    Session["signed"] = true;
                    Session["password"] = TextBox3.Text;
                    DataRow dt = s.Users_get_specific("", "", "", -1, -1, "", "", "", false, TextBox1.Text).Rows[0];
                    Session["fname"] = dt["FName"].ToString();
                    Session["lname"] = dt["LName"].ToString();
                    Session["money"] = dt["Money"].ToString();
                    Session["email"] = dt["user_email"].ToString();
                    Session["register_date"] = dt["Date_OR"].ToString();
                    string date = Session["register_date"].ToString();
                    date = date.Substring(0, 4);
                    Session["year_registered"] = date;
                    Session["all_income"] = dt["All_Income"].ToString();
                    Session["all_outcome"] = dt["All_Outcome"].ToString();
                    Session["table_num"] = "1";
                    Session["table_year"] = DateTime.Now.Year.ToString();
                    Session["stopper"] = "false";
                    update_monthly();
                    Response.Redirect("Home_Page.aspx", false);
                }
                else
                {
                    Label4.Text = "login data is incorrect";
                }
            }
            else
            {
                Label4.Text = alert;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        public void update_monthly()
        {
            string today = DateTime.Now.ToString("yyyy/MM/dd");
            int t_year = DateTime.Now.Year;
            int t_month = DateTime.Now.Month;
            int t_day = DateTime.Now.Day;
            int it_year;
            int it_month;
            int it_day;
            int monthdiff = 0;
            foreach (DataRow row in s.Monthly_Income_getall(int.Parse(Session["user_id"].ToString())).Rows)
            {
                string starrr = row["Date_OU"].ToString();
                it_year = int.Parse(starrr.Split('/')[0]);
                it_month = int.Parse(starrr.Split('/')[1]);
                it_day = int.Parse(starrr.Split('/')[2]);

                monthdiff = ((t_year - it_year) * 12) + t_month - it_month;
                if (monthdiff > 0)
                {
                    for (int i = 0; i < monthdiff; i++)
                    {
                        it_month++;
                        if (it_month > 12)
                        {
                            it_year++;
                            it_month = 1;
                        }
                        s.Monthly_Income_Repeat(int.Parse(row["ID"].ToString()), it_year + "/" + Manager.day_to_string(it_month) + "/" + Manager.day_to_string(it_day), int.Parse(row["Cash_Per_Month"].ToString()));
                    }
                }
            }

            bool is_pay = false;
            int payments = 0;
            foreach (DataRow row in s.Monthly_Expenses_getall(int.Parse(Session["user_id"].ToString())).Rows)
            {
                string starrr = row["Date_OU"].ToString();
                it_year = int.Parse(starrr.Split('/')[0]);
                it_month = int.Parse(starrr.Split('/')[1]);
                it_day = int.Parse(starrr.Split('/')[2]);
                payments = int.Parse(row["PayMents"].ToString());
                if (payments <= -1)
                {
                    is_pay = false;
                }
                else
                {
                    is_pay = true;
                }

                monthdiff = ((t_year - it_year) * 12) + t_month - it_month;
                if (monthdiff > 0)
                {
                    for (int i = 0; i < monthdiff; i++)
                    {
                        it_month++;
                        if (it_month > 12)
                        {
                            it_year++;
                            it_month = 1;
                        }

                        payments--;

                        s.Monthly_Expenses_repeat(int.Parse(row["ID"].ToString()), it_year + "/" + Manager.day_to_string(it_month) + "/" + Manager.day_to_string(it_day), int.Parse(row["Averaged_Price"].ToString()), is_pay);
                        if (payments == 0)
                        {
                            i = monthdiff + 1;
                            break;
                        }
                    }
                }
            }
        }
    }
}


