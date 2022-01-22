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
    public partial class Profile : System.Web.UI.Page
    {
        public Service1Client s = new Service1Client();
        string alert = "";

        public int earned = 0, spent = 0;
        public string llnie = "";

        public int earneds = 0, spents = 0;
        public string llnies = "";

        public string calc_hidden = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                change.Visible = true;
                calc_hidden = "";
                //all the calculations for this month summary
                foreach (DataRow row in s.Income_History_selectspecific(int.Parse(Session["user_id"].ToString()), "", -1, DateTime.Now.Year + "/" + Manager.day_to_string(int.Parse(DateTime.Now.Month.ToString())) + "/01", DateTime.Now.Date.ToString("yyyy/MM/dd"), -1, -1, "", "").Rows)
                    {
                        earned += int.Parse(row["Income"].ToString());
                    }

                foreach (DataRow row in s.Outcome_History_Getproducts(int.Parse(Session["user_id"].ToString()), -1, -1, "", DateTime.Now.Year + "/" + Manager.day_to_string(int.Parse(DateTime.Now.Month.ToString())) + "/01", DateTime.Now.Date.ToString("yyyy/MM/dd"), -1, "", "").Rows)
                {
                    spent += int.Parse(row["Price"].ToString());
                }

                int temp = earned - spent;
                if (temp == 0)
                {
                    llnie = "you spent as much as you earned!";
                }
                else
                {
                    if (temp < 0)
                    {
                        llnie = "you spent: " + temp + " this month";
                    }
                    else
                    {
                        llnie = "you earned: " + temp + " this month";
                    }
                }
            }
            else
            {
                change.Visible = false;
                calc_hidden = "hidden = 'hidden'";
                if (Convert.ToBoolean(Session["signed"]))
                {
                    if (DropDownList1.AppendDataBoundItems == false)
                    {

                        Calendar1.SelectedDate = DateTime.Parse(DateTime.Now.Year + "/" + DateTime.Now.Month + "/01");
                        Label10.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
                        Calendar2.SelectedDate = DateTime.Now.Date;
                        Label11.Text = Calendar2.SelectedDate.ToString("yyyy/MM/dd");

                        DropDownList1.AppendDataBoundItems = true;
                        DropDownList1.Items.Add("All");

                        DropDownList2.AppendDataBoundItems = true;
                        DropDownList2.Items.Add("All");

                        foreach (DataRow rows in s.Types_get_all_groups().Rows)
                        {
                            DropDownList1.Items.Add(rows["Type_Group"].ToString());
                        }
                    }
                }
                else
                {
                    Session["BAD_BOI"] = true;
                    Response.Redirect("Home_Page.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            alert = "";

            if (TextBox1.Text == "")
            {
                alert += "Password field is empty....<br />";
            }
            if (!Field_Limitor.signs_check_alltext(TextBox1.Text))
            {
                alert += "Password field cant have signs in it....<br />";
            }

            if (alert == "")
            {
                Label7.Text = "";
                if (TextBox1.Text == Session["password"].ToString())
                {
                    Label3.Text += " " + Session["fname"].ToString();
                    Label4.Text += " " + Session["lname"].ToString();
                    Label5.Text += " " + Session["password"].ToString();
                    Label6.Text += " " + Session["email"].ToString();

                    verify.Visible = false;
                    change.Visible = true;
                }
                else
                {
                    Label7.Text = "The Password is incorrect...";
                }
            }
            else
            {
                Label7.Text = alert;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            alert = "";

            if (TextBox2.Text == "" && TextBox3.Text == "" && TextBox4.Text == "" && TextBox5.Text == "")
            {
                alert += "All the fields are empty you need to fill at least one of the fields in order to update your information....<br />";
            }
            else
            {
                if (TextBox2.Text != "")
                {
                    if (!Field_Limitor.letter_check(TextBox2.Text))
                    {
                        alert += "First Name field cant have signs or numbers in it.<br />";
                    }
                }

                if (TextBox3.Text != "")
                {
                    if (!Field_Limitor.letter_check(TextBox3.Text))
                    {
                        alert += "Last Name field cant have signs or numbers in it.<br />";
                    }
                }

                if (TextBox4.Text != "")
                {
                    if (!Field_Limitor.signs_check_alltext(TextBox4.Text))
                    {
                        alert += "Password field cant have signs or numbers in it.<br />";
                    }
                    if (!Field_Limitor.length_check(20, 8, TextBox4.Text))
                    {
                        alert += "Password needs to be between 20-8 characters.<br />";
                    }
                    if (!Field_Limitor.has_number(TextBox4.Text))
                    {
                        alert += "Password field need to have at least one number.<br />";
                    }
                    if (!Field_Limitor.has_uppercut(TextBox4.Text))
                    {
                        alert += "Password field need to have at least one upercut letter.<br />";
                    }
                    if (!Field_Limitor.has_lowercut(TextBox4.Text))
                    {
                        alert += "Password field need to have at least one lowercut letter.<br />";
                    }
                }

                if (TextBox5.Text != "")
                {
                    if (!Field_Limitor.signs_check_alltext(TextBox5.Text))
                    {
                        alert += "Email field cant have signs in it (exept: @ . _ -)...<br />";
                    }
                }
            }

            if (alert == "")
            {
                Label8.Text = "";
                s.Users_Change(int.Parse(Session["user_id"].ToString()), TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text);
                if (TextBox2.Text != "")
                {
                    Session["fname"] = TextBox2.Text;
                    Label3.Text = "Name: " + TextBox2.Text;
                }
                if (TextBox3.Text != "")
                {
                    Session["lname"] = TextBox3.Text;
                    Label4.Text = "Last name: " + TextBox3.Text;
                }
                if (TextBox4.Text != "")
                {
                    Session["password"] = TextBox4.Text;
                    Label5.Text = "Password: " + TextBox4.Text;
                }
                if (TextBox5.Text != "")
                {
                    Session["email"] = TextBox5.Text;
                    Label6.Text = "Email: " + TextBox5.Text;
                }
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
            }
            else
            {
                Label8.Text = alert;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Label10.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
            Calendar1.Visible = false;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            Label11.Text = Calendar2.SelectedDate.ToString("yyyy/MM/dd");
            Calendar2.Visible = false;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("All");
            foreach (DataRow rows in s.Types_get_all_types_in_group(DropDownList1.SelectedValue).Rows)
            {
                DropDownList2.Items.Add(rows["Type"].ToString());
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Calendar1.Visible == true)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (Calendar2.Visible == true)
            {
                Calendar2.Visible = false;
            }
            else
            {
                Calendar2.Visible = true;
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            calc_hidden = "";
            string alert = "";
            if (Calendar1.SelectedDate.CompareTo(Calendar2.SelectedDate) > 0)
            {
                alert += "In the date section the 'from' date is later then the 'to' date....<br />";
            }

            string type_group = "";
            string typestring = "";
            if (DropDownList1.SelectedValue != "All")
            {
                type_group = DropDownList1.SelectedValue;
            }
            if (DropDownList2.SelectedValue != "All")
            {
                typestring = DropDownList2.SelectedValue;
            }
            

            if (alert == "")
            {
                foreach (DataRow row in s.Income_History_selectspecific(int.Parse(Session["user_id"].ToString()), "", -1, Calendar1.SelectedDate.ToString("yyyy/MM/dd"), Calendar2.SelectedDate.ToString("yyyy/MM/dd"), -1, -1, type_group, typestring).Rows)
                {
                    earneds += int.Parse(row["Income"].ToString());
                }

                foreach (DataRow row in s.Outcome_History_Getproducts(int.Parse(Session["user_id"].ToString()), -1, -1, "", Calendar1.SelectedDate.ToString("yyyy/MM/dd"), Calendar2.SelectedDate.ToString("yyyy/MM/dd"), -1, type_group, typestring).Rows)
                {
                    spents += int.Parse(row["Price"].ToString());
                }

                int temp = earneds - spents;
                if (temp == 0)
                {
                    llnies = "you spent as much as you earned!";
                }
                else
                {
                    if (temp < 0)
                    {
                        llnies = "you spent: " + temp + " this month";
                    }
                    else
                    {
                        llnies = "you earned: " + temp + " this month";
                    }
                }
            }
            else
            {
                Label8.Text = alert;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            s.Income_History_clean_user_data(int.Parse(Session["user_id"].ToString()));
            s.Monthly_Expenses_clean_user_data(int.Parse(Session["user_id"].ToString()));
            s.Monthly_Income_clean_user_data(int.Parse(Session["user_id"].ToString()));
            s.Outcome_History_clean_user_data(int.Parse(Session["user_id"].ToString()));
            s.Users_clean_user_data(int.Parse(Session["user_id"].ToString()));
            Response.Redirect("Logout.aspx");
        }
    }
}