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
    public partial class add : System.Web.UI.Page
    {
        public Service1Client s = new Service1Client();
        public String pay = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DropDownList2.AppendDataBoundItems == false)
            {
                DropDownList2.AppendDataBoundItems = true;
                DropDownList2.Items.Add("Select");

                DropDownList3.AppendDataBoundItems = true;
                DropDownList3.Items.Add("Select");

                foreach (DataRow rows in s.Types_get_all_groups().Rows)
                {
                    DropDownList2.Items.Add(rows["Type_Group"].ToString());
                }
            }
            else
            {

            }
        }

        //payments checkbox
        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 2)
            {
                if (CheckBox3.Checked)
                {
                    TextBox2.Visible = true;
                    pay = "&nbsp Payments";
                }
                else
                {
                    TextBox2.Visible = false;
                    TextBox2.Text = "";
                    pay = "&nbsp Payments";
                }
            }
            else
            {
                CheckBox3.Visible = false;
                TextBox2.Visible = false;
                CheckBox3.Checked = false;
                pay = "";
                TextBox2.Text = "";
            }
        }

        //monthly checkbox
        protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 2)
            {
                if (CheckBox5.Checked == true)
                {
                    CheckBox3.Visible = true;
                    pay = "&nbsp Payments";
                }
                else
                {
                    CheckBox3.Visible = false;
                    TextBox2.Visible = false;
                    CheckBox3.Checked = false;
                    pay = "";
                    TextBox2.Text = "";
                }
            }
            else
            {
                CheckBox3.Visible = false;
                TextBox2.Visible = false;
                CheckBox3.Checked = false;
                pay = "";
                TextBox2.Text = "";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int type = 0;
            int payments = -1;
            string alert = "";

            if (DropDownList1.SelectedValue == "0")
            {
                alert += "Need to select income or outcome....<br />";
            }

            if (TextBox1.Text == "")
            {
                alert += "Money field cant be empty...<br />";
            }
            else
            {
                if (!Field_Limitor.only_numbers(TextBox1.Text))
                {
                    alert += "Money field cant have any letters or signs....<br />";
                }
            }

            if (TextArea1.Value == "")
            {
                alert += "Description field cant be empty...<br />";
            }
            else
            {
                if (!Field_Limitor.signs_check_alltext(TextArea1.Value))
                {
                    alert += "Description field cant have any signs....<br />";
                }
            }

            if (TextBox2.Visible == true)
            {
                payments = int.Parse(TextBox2.Text);
                if (!Field_Limitor.only_numbers(TextBox2.Text))
                {
                    alert += "Payments field cant have any letters or signs....<br />";
                }
                if (int.Parse(TextBox2.Text) <= 0)
                {
                    alert += "payments field cant be a negative number or zero....<br />";
                }
            }
            else
            {
                TextBox2.Text = "1";

            }

            if (DropDownList2.SelectedValue == "Select")
            {
                alert += "Typegroup field cant be empty....<br />";
            }

            if (DropDownList3.SelectedValue == "Select")
            {
                alert += "Group field cant be empty....<br />";
            }

            if (alert == "")
            {
                Label4.Text = "";
                switch (DropDownList1.SelectedValue)
                {
                    case "0":
                        Label4.Text = "select Income or Outcome....";
                        break;

                    //income
                    case "1":
                        type = s.Types_getid(DropDownList3.Text, DropDownList2.Text);
                        if (CheckBox5.Checked)
                        {
                            s.Monthly_Income_Add(int.Parse(TextBox1.Text), TextArea1.Value, (int)Session["user_id"], int.Parse(TextBox1.Text), 1, DateTime.Now.ToString("yyyy/MM/dd"), type, DropDownList2.Text, DropDownList3.Text);
                        }
                        else
                        {
                            s.Income_History_add((int)Session["user_id"], TextArea1.Value, int.Parse(TextBox1.Text), DateTime.Now.ToString("yyyy/MM/dd"), type, -1, DropDownList2.Text, DropDownList3.Text);
                        }
                        break;

                    //outcome
                    case "2":
                        type = s.Types_getid(DropDownList3.Text, DropDownList2.Text);
                        if (CheckBox5.Checked)
                        {
                            s.Monthly_Expenses_add((int)Session["user_id"], int.Parse(TextBox1.Text) / int.Parse(TextBox2.Text), TextArea1.Value, 1, int.Parse(TextBox1.Text) / int.Parse(TextBox2.Text), type, DateTime.Now.ToString("yyyy/MM/dd"), payments, DropDownList2.Text, DropDownList3.Text);
                        }
                        else
                        {
                            s.Outcome_History_AddProduct((int)Session["user_id"], type, int.Parse(TextBox1.Text), TextArea1.Value, DateTime.Now.ToString("yyyy/MM/dd"), -1, DropDownList2.Text, DropDownList3.Text);
                        }
                        break;

                    default:
                        Label4.Text = "something is wrong... stop messing around :(";
                        break;
                }
                
                Session["Money"] = s.Users_getmoney((int)Session["user_id"]).ToString();
                Response.Redirect("Home_Page.aspx", false);
            }
            else
            {
                Label4.Text = alert;
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList3.Items.Clear();
            DropDownList3.Items.Add("Select");
            foreach (DataRow rows in s.Types_get_all_types_in_group(DropDownList2.SelectedValue).Rows)
            {
                DropDownList3.Items.Add(rows["Type"].ToString());
            }
        }
    }
}