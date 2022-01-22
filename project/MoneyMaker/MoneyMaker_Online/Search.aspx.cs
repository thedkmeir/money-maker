using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using MoneyMaker_Online.ServiceReference;

namespace MoneyMaker_Online
{
    public partial class Search : System.Web.UI.Page
    {
        public Service1Client s = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            
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

                    DropDownList3.AppendDataBoundItems = true;
                    DropDownList3.Items.Add("Income");
                    DropDownList3.Items.Add("Outcome");
                    DropDownList3.SelectedIndex = 0;
                }

                if (IsPostBack)
                {
                    if (Session["DataSource"] != null)
                    {
                        GridView1.DataSource = Session["DataSource"];
                        GridView1.DataBind();
                        fix_grid();
                    }
                }
                else
                {
                    Session.Remove("DataSource");
                    Session.Remove("selectedindex");
                    Session.Remove("line_id");
                }


                //Button4_Click(sender, e);
                //if (Session["stopper"].ToString() == "false")
                //{
                //    Session["stopper"] = "true";
                //    if (DropDownList3.SelectedValue == "Income")
                //    {
                //        //monthly
                //        if (CheckBox1.Checked)
                //        {
                //            GridView1.DataSource = s.Monthly_Income_Getmincome((int)Session["user_id"], "", -1, "", "", -1, "", "");
                //            GridView1.DataBind();
                //        }
                //        //not monthely
                //        else
                //        {
                //            GridView1.DataSource = s.Income_History_selectspecific((int)Session["user_id"], "", -1, "", "", -1, -1, "", "");
                //            GridView1.DataBind();
                //        }
                //    }
                //    //outcome
                //    else
                //    {
                //        //monthly
                //        if (CheckBox1.Checked)
                //        {
                //            GridView1.DataSource = s.Monthly_Expenses_Getmoutcome((int)Session["user_id"], "", -1, -1, "", "", -1, "", "");
                //            GridView1.DataBind();
                //        }
                //        //not monthly
                //        else
                //        {
                //            GridView1.DataSource = s.Outcome_History_Getproducts((int)Session["user_id"], -1, -1, "", "", "", -1, "", "");
                //            GridView1.DataBind();
                //        }
                //    }
                //    fix_grid();
                //}
            }
            else
            {
                Session["BAD_BOI"] = true;
                Response.Redirect("Home_Page.aspx");
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Label4.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
            Calendar1.Visible = false;
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Calendar2.Visible)
            {
                Calendar2.Visible = false;
            }
            else
            {
                Calendar2.Visible = true;
            }
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            Label5.Text = Calendar2.SelectedDate.ToString("yyyy/MM/dd");
            Calendar2.Visible = false;
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            string alert = "";
            if (!Field_Limitor.only_numbers(TextBox1.Text))
            {
                alert += "Money field cant have any letters or signs in it...<br />";
            }

            if (!Field_Limitor.signs_check_alltext(TextArea1.Value))
            {
                alert += "Description field cant have any signs...<br />";
            }

            if (CheckBox2.Checked)
            {
                if (Calendar1.SelectedDate.ToString("yyyy/MM/dd") == "0001/01/01")
                {
                    alert += "In the date section 'from' date is not selected....<br />";
                }
                if (Calendar2.SelectedDate.ToString("yyyy/MM/dd") == "0001/01/01")
                {
                    alert += "In the date section 'to' date is not selected....<br />";
                }
                if (Calendar1.SelectedDate.CompareTo(Calendar2.SelectedDate) > 0)
                {
                    alert += "In the date section the 'from' date is later then the 'to' date....<br />";
                }
            }

            //group types converter
            string type_group = "";
            string typestring = "";
            if (DropDownList1.SelectedValue != "Select")
            {
                type_group = DropDownList1.SelectedValue;
            }
            if (DropDownList2.SelectedValue != "Select")
            {
                typestring = DropDownList2.SelectedValue;
            }

            //if (DropDownList2.SelectedValue == "Select" && DropDownList1.SelectedValue != "Select")
            //{

            //}

            if (alert == "")
            {
                Label12.Text = "";
                //money field convert
                int money_field = -1;
                string money = TextBox1.Text;
                if (money != "")
                {
                    money_field = int.Parse(money);
                }

                //date convert
                string date_from = "";
                string date_to = "";
                if (CheckBox2.Checked)
                {
                    date_from = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
                    date_to = Calendar2.SelectedDate.ToString("yyyy/MM/dd");
                }

                //income
                if (DropDownList3.SelectedValue == "Income")
                {
                    //monthly
                    if (CheckBox1.Checked)
                    {
                        GridView1.DataSource = s.Monthly_Income_Getmincome((int)Session["user_id"], TextArea1.Value, money_field, date_from, date_to, -1, type_group, typestring);
                        GridView1.DataBind();
                        Session["gridview_index"] = "im";
                    }
                    //not monthely
                    else
                    {
                        GridView1.DataSource = s.Income_History_selectspecific((int)Session["user_id"], TextArea1.Value, money_field, date_from, date_to, -1, -1, type_group, typestring);
                        GridView1.DataBind();
                        Session["gridview_index"] = "i";
                    }
                }
                //outcome
                else
                {
                    //monthly
                    if (CheckBox1.Checked)
                    {
                        GridView1.DataSource = s.Monthly_Expenses_Getmoutcome((int)Session["user_id"], TextArea1.Value, money_field, -1, date_from, date_to, 0, type_group, typestring);
                        GridView1.DataBind();
                        Session["gridview_index"] = "om";
                    }
                    //not monthly
                    else
                    {
                        GridView1.DataSource = s.Outcome_History_Getproducts((int)Session["user_id"], -1, money_field, TextArea1.Value, date_from, date_to, -1, type_group, typestring);
                        GridView1.DataBind();
                        Session["gridview_index"] = "o";
                    }
                }
                Session["DataSource"] = GridView1.DataSource;
                fix_grid();
            }
            else
            {
                Label12.Text = alert;
            }
        }

        public void fix_grid()
        {
            if (GridView1.Rows.Count != 0)
            {
                GridView1.SelectRow(0);
                GridView1.HeaderRow.Cells[1].Visible = false;

                switch (Session["gridview_index"].ToString())
                {
                    case "im":
                        GridView1.HeaderRow.Cells[2].Text = "Money";
                        GridView1.HeaderRow.Cells[4].Visible = false;
                        GridView1.HeaderRow.Cells[5].Text = "Total recieved";
                        GridView1.HeaderRow.Cells[6].Visible = false;
                        GridView1.HeaderRow.Cells[7].Text = "Date added";
                        GridView1.HeaderRow.Cells[8].Visible = false;
                        GridView1.HeaderRow.Cells[9].Visible = false;
                        GridView1.HeaderRow.Cells[10].Text = "Type group";
                        GridView1.HeaderRow.Cells[11].Text = "Type item";
                        break;

                    case "i":
                        GridView1.HeaderRow.Cells[2].Visible = false;
                        GridView1.HeaderRow.Cells[3].Text = "Description";
                        GridView1.HeaderRow.Cells[4].Text = "Money";
                        GridView1.HeaderRow.Cells[5].Text = "Date added";
                        GridView1.HeaderRow.Cells[6].Visible = false;
                        GridView1.HeaderRow.Cells[7].Visible = false;
                        GridView1.HeaderRow.Cells[8].Text = "Type group";
                        GridView1.HeaderRow.Cells[9].Text = "Type item";
                        break;

                    case "om":
                        GridView1.HeaderRow.Cells[2].Visible = false;
                        GridView1.HeaderRow.Cells[3].Text = "Money";
                        GridView1.HeaderRow.Cells[4].Text = "Description";
                        GridView1.HeaderRow.Cells[5].Text = "Total payed";
                        GridView1.HeaderRow.Cells[6].Visible = false;
                        GridView1.HeaderRow.Cells[7].Text = "Date added";
                        GridView1.HeaderRow.Cells[8].Visible = false;
                        GridView1.HeaderRow.Cells[9].Visible = false;
                        GridView1.HeaderRow.Cells[10].Visible = false;
                        GridView1.HeaderRow.Cells[11].Text = "Type group";
                        GridView1.HeaderRow.Cells[12].Text = "Type item";
                        break;

                    case "o":
                        GridView1.HeaderRow.Cells[2].Visible = false;
                        GridView1.HeaderRow.Cells[3].Text = "Money";
                        GridView1.HeaderRow.Cells[4].Text = "Description";
                        GridView1.HeaderRow.Cells[5].Text = "Date added";
                        GridView1.HeaderRow.Cells[6].Visible = false;
                        GridView1.HeaderRow.Cells[7].Visible = false;
                        GridView1.HeaderRow.Cells[8].Text = "Type group";
                        GridView1.HeaderRow.Cells[9].Text = "Type item";
                        break;

                    default:

                        break;
                }

                ////income
                //if (DropDownList3.SelectedValue == "Income")
                //{
                //    //monthly
                //    if (CheckBox1.Checked)
                //    {
                //        GridView1.HeaderRow.Cells[2].Text = "Money";
                //        GridView1.HeaderRow.Cells[4].Visible = false;
                //        GridView1.HeaderRow.Cells[5].Text = "Total recieved";
                //        GridView1.HeaderRow.Cells[6].Visible = false;
                //        GridView1.HeaderRow.Cells[7].Text = "Date added";
                //        GridView1.HeaderRow.Cells[8].Visible = false;
                //        GridView1.HeaderRow.Cells[9].Visible = false;
                //        GridView1.HeaderRow.Cells[10].Text = "Type group";
                //        GridView1.HeaderRow.Cells[11].Text = "Type item";
                //    }
                //    //not monthely
                //    else
                //    {
                //        GridView1.HeaderRow.Cells[2].Visible = false;
                //        GridView1.HeaderRow.Cells[3].Text = "Description";
                //        GridView1.HeaderRow.Cells[4].Text = "Money";
                //        GridView1.HeaderRow.Cells[5].Text = "Date added";
                //        GridView1.HeaderRow.Cells[6].Visible = false;
                //        GridView1.HeaderRow.Cells[7].Visible = false;
                //        GridView1.HeaderRow.Cells[8].Text = "Type group";
                //        GridView1.HeaderRow.Cells[9].Text = "Type item";
                //    }
                //}
                ////outcome
                //else
                //{
                //    //monthly
                //    if (CheckBox1.Checked)
                //    {
                //        GridView1.HeaderRow.Cells[2].Visible = false;
                //        GridView1.HeaderRow.Cells[3].Text = "Money";
                //        GridView1.HeaderRow.Cells[4].Text = "Description";
                //        GridView1.HeaderRow.Cells[5].Text = "Total payed";
                //        GridView1.HeaderRow.Cells[6].Visible = false;
                //        GridView1.HeaderRow.Cells[7].Text = "Date added";
                //        GridView1.HeaderRow.Cells[8].Visible = false;
                //        GridView1.HeaderRow.Cells[9].Visible = false;
                //        GridView1.HeaderRow.Cells[10].Visible = false;
                //        GridView1.HeaderRow.Cells[11].Text = "Type group";
                //        GridView1.HeaderRow.Cells[12].Text = "Type item";
                //    }
                //    //not monthely
                //    else
                //    {
                //        GridView1.HeaderRow.Cells[2].Visible = false;
                //        GridView1.HeaderRow.Cells[3].Text = "Money";
                //        GridView1.HeaderRow.Cells[4].Text = "Description";
                //        GridView1.HeaderRow.Cells[5].Text = "Date added";
                //        GridView1.HeaderRow.Cells[6].Visible = false;
                //        GridView1.HeaderRow.Cells[7].Visible = false;
                //        GridView1.HeaderRow.Cells[8].Text = "Type group";
                //        GridView1.HeaderRow.Cells[9].Text = "Type item";
                //    }
                //}

                //foreach (TableCell cell in GridView1.HeaderRow.Cells)
                //{
                //    if (cell.Text == "ID" || cell.Text == "User_ID" || cell.Text == "MI_ID" || cell.Text == "Type_ID" || cell.Text == "Date_OU" || cell.Text == "Payments" || cell.Text == "MO_ID" || cell.Text == "Total_Payed")
                //    {
                //        cell.Visible = false;
                //    }

                //    if (cell.Text == "Income" || cell.Text == "Averaged_Price" || cell.Text == "Cash_Per_Month" || cell.Text == "Price")
                //    {
                //        cell.Text = "Money";
                //    }

                //    if (cell.Text == "Dscription" || cell.Text == "Product")
                //    {
                //        cell.Text = "Description";
                //    }

                //    if (cell.Text == "Date_OI" || cell.Text == "Date_OA" || cell.Text == "Date_OP")
                //    {
                //        cell.Text = "Date added";
                //    }

                //    if (cell.Text == "Type_Group")
                //    {
                //        cell.Text = "Type group";
                //    }

                //    if (cell.Text == "Type_Item")
                //    {
                //        cell.Text = "Type Item";
                //    }

                //    if (cell.Text == "Num_Payments" || cell.Text == "Num_Of_Pay")
                //    {
                //        cell.Text = "Number of months";
                //    }
                //}

                foreach (GridViewRow row in GridView1.Rows)
                {
                    int i = 0;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (GridView1.HeaderRow.Cells[i].Visible == false)
                        {
                            cell.Visible = false;
                        }
                        i++;
                    }
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[1].Visible = false;

        }

        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (GridView1.SelectedIndex == selected)
        //    {
        //        fix_grid();
        //        selected = GridView1.SelectedIndex;
        //    }
        //}
        protected void Button3_Click(object sender, EventArgs e)
        {
            //income
            if (DropDownList3.SelectedValue == "Income")
            {
                //monthly
                if (CheckBox1.Checked)
                {
                    s.Monthly_Income_delete(int.Parse(GridView1.Rows[int.Parse(Session["selectedindex"].ToString())].Cells[1].Text));
                    GridView1.SelectedRow.Visible = false;
                }
                //not monthly
                else
                {
                    s.Income_History_delete(int.Parse(GridView1.Rows[int.Parse(Session["selectedindex"].ToString())].Cells[1].Text));
                    GridView1.SelectedRow.Visible = false;
                }
            }
            //outcome
            else
            {
                //monthly
                if (CheckBox1.Checked)
                {
                    s.Monthly_Expenses_delete(int.Parse(GridView1.Rows[int.Parse(Session["selectedindex"].ToString())].Cells[1].Text));
                    GridView1.SelectedRow.Visible = false;
                }
                //not monthly
                else
                {
                    s.Outcome_History_delete(int.Parse(GridView1.Rows[int.Parse(Session["selectedindex"].ToString())].Cells[1].Text));
                    GridView1.SelectedRow.Visible = false;
                }
            }
            Session["Money"] = s.Users_getmoney((int)Session["user_id"]).ToString();
            Session.Remove("DataSource");
            Session.Remove("selectedindex");
            Response.Redirect("Search.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //income
            if (DropDownList3.SelectedValue == "Income")
            {
                //monthly
                if (CheckBox1.Checked)
                {
                    Session["type_record"] = "mi";
                }
                //not monthly
                else
                {
                    Session["type_record"] = "i";
                }

            }
            //outcome
            else
            {
                if (CheckBox1.Checked)
                {
                    Session["type_record"] = "mo";
                }
                //not monthly
                else
                {
                    Session["type_record"] = "o";
                }
            }
            Session["line_id"] = GridView1.Rows[int.Parse(Session["selectedindex"].ToString())].Cells[1].Text;
            Session.Remove("DataSource");
            Response.Redirect("Edit.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selected = GridView1.SelectedRow.DataItemIndex;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int ttt = Convert.ToInt32(e.CommandArgument);
            Session["selectedindex"] = GridView1.Rows[ttt].DataItemIndex;
        }
    }
}