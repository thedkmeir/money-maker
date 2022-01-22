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
    public partial class add_type : System.Web.UI.Page
    {
        public Service1Client s = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["signed"]))
            {
                update_list_boxes();
                if (!this.IsPostBack)
                {
                    DropDownList1.AppendDataBoundItems = true;
                    DropDownList1.Items.Add("Select");

                    foreach (DataRow rows in s.Types_get_all_groups().Rows)
                    {
                        ListBox1.Items.Add(new ListItem(rows["Type_Group"].ToString(), " "));
                        ListBox3.Items.Add(new ListItem("$" + rows["Type_Group"].ToString(), " "));
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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox4.Items.Clear();
            foreach (DataRow rows in s.Types_get_all_types_in_group(DropDownList1.SelectedValue).Rows)
            {
                ListBox4.Items.Add(new ListItem("$" + rows["Type"].ToString(), " "));
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            update_list_boxes();

            string alert = "Type Group:<br />";
            if (TextBox1.Text == "")
            {
                alert += "Type Group field cant be empty...<br />";
            }
            else
            {
                if (!Field_Limitor.letter_check(TextBox1.Text))
                {
                    alert += "Type Group field cant have signs in it...<br />";
                }
            }

            foreach (ListItem l in ListBox1.Items)
            {
                if (l.Text.ToUpper() == TextBox1.Text.ToUpper())
                {
                    alert += "Type Group already exists....<br />";
                }
            }

            if (alert == "Type Group:<br />")
            {
                Label5.Text = "";
                s.Types_add_Group(TextBox1.Text);
                Response.Redirect("Home_Page.aspx", false);
            }
            else
            {
                Label5.Text = alert;
            }
        }

        public void update_list_boxes()
        {
            foreach (ListItem L in ListBox1.Items)
            {
                if (L.Text.ToUpper().StartsWith(TextBox1.Text.ToUpper()))
                {
                    L.Enabled = true;
                }
                else
                {
                    L.Enabled = false;
                }
            }

            foreach (ListBox L in ListBox2.Items)
            {
                if (L.Text.ToUpper().StartsWith(TextBox2.Text.ToUpper()))
                {
                    L.Enabled = true;
                }
                else
                {
                    L.Enabled = false;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            update_list_boxes();

            string alert = "Type:<br />";
            if (TextBox2.Text == "")
            {
                alert += "Type field cant be empty...<br />";
            }
            else
            {
                if (!Field_Limitor.letter_check(TextBox2.Text))
                {
                    alert += "Type field cant have signs in it...<br />";
                }
            }

            foreach (ListItem l in ListBox2.Items)
            {
                if (l.Text.ToUpper() == TextBox2.Text.ToUpper())
                {
                    alert += "Type already exists....<br />";
                }
            }

            if (DropDownList1.SelectedValue == "Select")
            {
                alert += "Type Group not selected....<br />";
            }

            if (alert == "Type:<br />")
            {
                Label5.Text = "";
                s.Types_add(TextBox2.Text, DropDownList1.SelectedValue);
                Response.Redirect("Home_Page.aspx", false);
            }
            else
            {
                Label6.Text = alert;
            }
        }
    }
}