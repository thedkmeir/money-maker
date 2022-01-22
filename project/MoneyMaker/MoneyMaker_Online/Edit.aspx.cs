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
    public partial class Edit : System.Web.UI.Page
    {
        public Service1Client s = new Service1Client();
        public string moneyhide = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //session["line_id"] is the id of the record
            //session["type_record"] is the table: mi mo i o

            if (Convert.ToBoolean(Session["signed"]))
            {

                if (DropDownList1.AppendDataBoundItems == false)
                {
                    DropDownList1.AppendDataBoundItems = true;
                    DropDownList1.Items.Add("Select");

                    DropDownList2.AppendDataBoundItems = true;
                    DropDownList2.Items.Add("Select");

                    foreach (DataRow rows in s.Types_get_all_groups().Rows)
                    {
                        DropDownList1.Items.Add(rows["Type_Group"].ToString());
                    }
                }

                DataRow dt;

                switch (Session["type_record"].ToString())
                {
                    //monthly income
                    case "mi":
                        moneyhide = "style=\"display: none\"";
                        dt = s.Monthly_Income_getspecific(int.Parse(Session["line_id"].ToString())).Rows[0];
                        Label7.Text = dt["Type_Group"].ToString();
                        Label9.Text = dt["Type_Item"].ToString();
                        Label14.Text = dt["Description"].ToString();
                        break;

                    //monthly outcome
                    case "mo":
                        moneyhide = "style=\"display: none\"";
                        dt = s.Monthly_Expenses_getsingle(int.Parse(Session["line_id"].ToString())).Rows[0];
                        Label7.Text = dt["Type_Group"].ToString();
                        Label9.Text = dt["Type_Item"].ToString();
                        Label14.Text = dt["Product"].ToString();
                        break;

                    //outcome
                    case "o":
                        dt = s.Outcome_History_selectbypro(int.Parse(Session["line_id"].ToString())).Rows[0];
                        Label3.Text = dt["Price"].ToString();
                        Label5.Text = dt["Date_OP"].ToString();
                        Label7.Text = dt["Type_Group"].ToString();
                        Label9.Text = dt["Type_Item"].ToString();
                        Label14.Text = dt["Product"].ToString();
                        break;

                    //income
                    case "i":
                        dt = s.Income_History_selectsingle(int.Parse(Session["line_id"].ToString())).Rows[0];
                        Label3.Text = dt["Income"].ToString();
                        Label5.Text = dt["Date_OI"].ToString();
                        Label7.Text = dt["Type_Group"].ToString();
                        Label9.Text = dt["Type_Item"].ToString();
                        Label14.Text = dt["Dscription"].ToString();
                        break;

                    default:
                        Label1.Text = "wrongwrongwrongwrongwrongwrongwrongwrongwrongwrongwrongwrongwrongwrongwrongwrongwrongwrongwrongwrongwrongwrongwrongwrong";
                        break;
                }

            }
            else
            {
                Session["BAD_BOI"] = true;
                Response.Redirect("Home_Page.aspx");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Label11.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
            Calendar1.Visible = false;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("Select");
            foreach (DataRow rows in s.Types_get_all_types_in_group(DropDownList1.SelectedValue).Rows)
            {
                DropDownList2.Items.Add(rows["Type"].ToString());
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int type = 0;
            string alert = "";
            if (!Field_Limitor.only_numbers(TextBox1.Text))
            {
                alert += "Money field cant have any letters or signs....<br />";
            }
            if (!Field_Limitor.signs_check_alltext(TextArea1.Value))
            {
                alert += "Description field cant have any signs....<br />";
            }

            string type_group = "";
            string typestring = "";
            if (DropDownList1.SelectedIndex != 0 && DropDownList2.SelectedIndex != 0)
            {
                type_group = DropDownList1.SelectedValue;
                typestring = DropDownList2.SelectedValue;
            }
            else if (DropDownList1.SelectedIndex != 0 && DropDownList2.SelectedIndex == 0)
            {
                type_group = DropDownList1.SelectedValue;
                typestring = type_group;
            }

            string date = "";
            if (Label11.Text != "Chose date")
            {
                date = Label11.Text;
            }

            if (alert == "")
            {
                Label18.Text = "";
                switch (Session["type_record"].ToString())
                {
                    //monthly income
                    case "mi":
                        s.Monthly_Income_change(int.Parse(Session["line_id"].ToString()), -1, TextArea1.Value, -1, -1, "", -1, type_group, typestring);
                        break;

                    //monthly outcome
                    case "mo":
                        s.Monthly_Expenses_change(int.Parse(Session["line_id"].ToString()), -1, TextArea1.Value, -1, -1, -1, "", -1, type_group, typestring);
                        break;

                    //outcome
                    case "o":
                        s.Outcome_History_SetProduct(int.Parse(Session["line_id"].ToString()), -1, int.Parse(TextBox1.Text), TextArea1.Value, date, type_group, typestring);
                        break;

                    //income
                    case "i":
                        s.Income_History_update(int.Parse(Session["line_id"].ToString()), TextArea1.Value, int.Parse(TextBox1.Text), date, -1, type_group, typestring);
                        break;

                    default:
                        Label18.Text = "something is horrobly wrong...<br />";
                        break;
                }
                Session["Money"] = s.Users_getmoney((int)Session["user_id"]).ToString();
                Response.Redirect("Home_Page.aspx", false);
            }
            else
            {
                Label18.Text = alert;
            }

        }
    }
}