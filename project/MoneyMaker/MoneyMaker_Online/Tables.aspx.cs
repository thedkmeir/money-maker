using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MoneyMaker_Online.ServiceReference;

namespace MoneyMaker_Online
{
    public partial class Tables : System.Web.UI.Page
    {
        public Service1Client s = new Service1Client();
        int future_monthly_income_average = 0;
        int future_monthly_outcome_average = 0;
        int income_average;
        int outcome_average;
        public string alert;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Session["signed"]))
            {
                Button1.Visible = false;
                Button2.Visible = false;
                Button3.Visible = false;
                Button4.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
                Session["BAD_BOI"] = true;
                Response.Redirect("Home_Page.aspx");
            }
            else
            {
                Label1.Text = Session["table_year"].ToString();
                Label2.Text = Session["table_num"].ToString() + " / 4";

                int months_registered = Manager.get_months_registered(Session["register_Date"].ToString());
                months_registered++;

                //Session["future_monthly_income_average"] = s.Income_History_get_monthly_money(int.Parse(Session["user_id"].ToString()), date, DateTime.Now.ToString("yyyy/MM/dd")) / months_registered;
                //Session["future_monthly_outcome_average"] = s.Outcome_History_get_monthly_money(int.Parse(Session["user_id"].ToString()), date, DateTime.Now.ToString("yyyy/MM/dd")) / months_registered;
                //Session["income_average"] = int.Parse(Session["all_income"].ToString()) / months_registered;
                //Session["outcome_average"] = int.Parse(Session["all_outcome"].ToString()) / months_registered;

                DataRow dt = s.Users_get_specific("", "", "", -1, -1, "", "", "", false, Session["email"].ToString()).Rows[0];

                //future_monthly_income_average = s.Income_History_get_monthly_money(int.Parse(Session["user_id"].ToString()), DateTime.Now.Year + "/" + Manager.day_to_string(DateTime.Now.Month) + "/01", DateTime.Now.ToString("yyyy/MM/dd"));
                //future_monthly_outcome_average = s.Outcome_History_get_monthly_money(int.Parse(Session["user_id"].ToString()), DateTime.Now.Year + "/" + Manager.day_to_string(DateTime.Now.Month - 1) + "/01", DateTime.Now.ToString("yyyy/MM/dd"));

                foreach (DataRow d in s.Monthly_Income_getall(int.Parse(Session["user_id"].ToString())).Rows)
                {
                    future_monthly_income_average += int.Parse(d["Cash_Per_Month"].ToString());
                }

                foreach (DataRow d in s.Monthly_Expenses_getall(int.Parse(Session["user_id"].ToString())).Rows)
                {
                    future_monthly_outcome_average += int.Parse(d["Averaged_Price"].ToString());
                }

                foreach (DataRow d in s.Income_History_selectbyuser(int.Parse(Session["user_id"].ToString())).Rows)
                {
                    if (int.Parse(d["MI_ID"].ToString()) == -1)
                    {
                        income_average += int.Parse(d["Income"].ToString());
                    }
                }

                foreach (DataRow d in s.Outcome_History_selectbyuser(int.Parse(Session["user_id"].ToString())).Rows)
                {
                    if (int.Parse(d["MO_ID"].ToString()) == -1)
                    {
                        outcome_average += int.Parse(d["Price"].ToString());
                    }
                }

                income_average = income_average / months_registered;
                outcome_average = outcome_average / months_registered;

                Chart1.ChartAreas[0].AxisX.Maximum = 13;
                Chart1.ChartAreas[0].AxisX.Minimum = 0;

                switch (int.Parse(Session["table_num"].ToString()))
                {
                    case 1:
                        Chart1.Titles[0].Text = "single incomes vs both vs monthly income";
                        Chart1.Series[0].Name = "Income";
                        Chart1.Series[1].Name = "Both";
                        Chart1.Series[2].Name = "Monthly_Income";
                        for (int i = 1; i <= 12; i++)
                        {

                            string j = i.ToString();
                            if (i < 10)
                            {
                                j = "0" + j;
                            }
                            string date1 = int.Parse(Session["table_year"].ToString()) + "/" + j + "/01";
                            string date2 = int.Parse(Session["table_year"].ToString()) + "/" + j + "/" + Manager.lastdayinmonth(i);
                            int mincome;
                            int income;
                            if (DateTime.Now.Month < i && DateTime.Now.Year <= int.Parse(Session["table_year"].ToString()))
                            {
                                mincome = future_monthly_income_average;
                                income = income_average;
                            }
                            else if (DateTime.Now.Year < int.Parse(Session["table_year"].ToString()))
                            {
                                mincome = future_monthly_income_average;
                                income = income_average;
                            }
                            else
                            {
                                income = s.Income_History_get_money(int.Parse(Session["user_id"].ToString()), date1, date2);
                                mincome = s.Income_History_get_monthly_money(int.Parse(Session["user_id"].ToString()), date1, date2);

                                income = income - mincome;
                            }

                            Chart1.Series[0].Points.AddXY(i, income);
                            Chart1.Series[1].Points.AddXY(i, mincome + income);
                            Chart1.Series[2].Points.AddXY(i, mincome);
                        }
                        break;

                    case 2:
                        Chart1.Titles[0].Text = "single outcomes vs both vs monthly outcome";
                        Chart1.Series[0].Name = "Outcome";
                        Chart1.Series[1].Name = "Both";
                        Chart1.Series[2].Name = "Monthly_Outcome";
                        for (int i = 1; i <= 12; i++)
                        {
                            string j = i.ToString();
                            if (i < 10)
                            {
                                j = "0" + j;
                            }
                            string date1 = int.Parse(Session["table_year"].ToString()) + "/" + j + "/01";
                            string date2 = int.Parse(Session["table_year"].ToString()) + "/" + j + "/" + Manager.lastdayinmonth(i);
                            int outcome;
                            int moutcome;
                            if (DateTime.Now.Month < i && DateTime.Now.Year <= int.Parse(Session["table_year"].ToString()))
                            {
                                moutcome = future_monthly_outcome_average;
                                outcome = outcome_average;
                            }
                            else if (DateTime.Now.Year < int.Parse(Session["table_year"].ToString()))
                            {
                                moutcome = future_monthly_outcome_average;
                                outcome = outcome_average;
                            }
                            else
                            {
                                outcome = s.Outcome_History_get_money(int.Parse(Session["user_id"].ToString()), date1, date2);
                                moutcome = s.Outcome_History_get_monthly_money(int.Parse(Session["user_id"].ToString()), date1, date2);

                                outcome = outcome - moutcome;
                            }
                            Chart1.Series[0].Points.AddXY(i, outcome);
                            Chart1.Series[1].Points.AddXY(i, outcome + moutcome);
                            Chart1.Series[2].Points.AddXY(i, moutcome);
                        }
                        break;

                    case 3:
                        Chart1.Titles[0].Text = "monthly income vs monthly outcome and profit";
                        Chart1.Series[0].Name = "Monthly_Income";
                        Chart1.Series[1].Name = "Profit";
                        Chart1.Series[2].Name = "Monthly_Outcome";
                        for (int i = 1; i <= 12; i++)
                        {
                            string j = i.ToString();
                            if (i < 10)
                            {
                                j = "0" + j;
                            }
                            string date1 = int.Parse(Session["table_year"].ToString()) + "/" + j + "/01";
                            string date2 = int.Parse(Session["table_year"].ToString()) + "/" + j + "/" + Manager.lastdayinmonth(i);
                            int onlymincome;
                            int onlymoutcome;
                            if (DateTime.Now.Month < i && DateTime.Now.Year <= int.Parse(Session["table_year"].ToString()))
                            {
                                onlymincome = future_monthly_income_average;
                                onlymoutcome = future_monthly_outcome_average;
                            }
                            else if (DateTime.Now.Year < int.Parse(Session["table_year"].ToString()))
                            {
                                onlymincome = future_monthly_income_average;
                                onlymoutcome = future_monthly_outcome_average;
                            }
                            else
                            {
                                onlymincome = s.Income_History_get_monthly_money(int.Parse(Session["user_id"].ToString()), date1, date2);
                                onlymoutcome = s.Outcome_History_get_monthly_money(int.Parse(Session["user_id"].ToString()), date1, date2);
                            }
                            Chart1.Series[0].Points.AddXY(i, onlymincome);
                            Chart1.Series[1].Points.AddXY(i, onlymincome - onlymoutcome);
                            Chart1.Series[2].Points.AddXY(i, onlymoutcome);
                        }
                        break;

                    case 4:
                        Chart1.Titles[0].Text = "single income vs single outcome and profit";
                        Chart1.Series[0].Name = "Income";
                        Chart1.Series[1].Name = "Profit";
                        Chart1.Series[2].Name = "Outcome";
                        for (int i = 1; i <= 12; i++)
                        {
                            string j = i.ToString();
                            if (i < 10)
                            {
                                j = "0" + j;
                            }
                            string date1 = int.Parse(Session["table_year"].ToString()) + "/" + j + "/01";
                            string date2 = int.Parse(Session["table_year"].ToString()) + "/" + j + "/" + Manager.lastdayinmonth(i);
                            int mincome;
                            int moutcome;
                            if (DateTime.Now.Month < i && DateTime.Now.Year <= int.Parse(Session["table_year"].ToString()))
                            {
                                mincome = income_average;
                                moutcome = outcome_average;
                            }
                            else if (DateTime.Now.Year < int.Parse(Session["table_year"].ToString()))
                            {
                                mincome = income_average;
                                moutcome = outcome_average;
                            }
                            else
                            {
                                mincome = s.Income_History_get_money(int.Parse(Session["user_id"].ToString()), date1, date2) - s.Income_History_get_monthly_money(int.Parse(Session["user_id"].ToString()), date1, date2);
                                moutcome = s.Outcome_History_get_money(int.Parse(Session["user_id"].ToString()), date1, date2) - s.Outcome_History_get_monthly_money(int.Parse(Session["user_id"].ToString()), date1, date2);
                            }
                            Chart1.Series[1].Points.AddXY(i, mincome - moutcome);
                            Chart1.Series[0].Points.AddXY(i, mincome);
                            Chart1.Series[2].Points.AddXY(i, moutcome);
                        }
                        break;
                }

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        Chart1.Series[i].Points[j].LegendText = Manager.get_string_month(j + 1);
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int year = int.Parse(Session["table_year"].ToString()) - 1;
            if (year < int.Parse(Session["year_registered"].ToString()))
            {
                alert = "You werent registered in " + year;
            }
            else
            {
                Session["table_year"] = year;
                Label1.Text = year.ToString();
                Response.Redirect("Tables.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int year = int.Parse(Session["table_year"].ToString()) + 1;
            Session["table_year"] = year;
            Label1.Text = year.ToString();
            Response.Redirect("Tables.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int tabnum = int.Parse(Session["table_num"].ToString()) - 1;
            if (tabnum < 1)
            {
                tabnum = 4;
            }
            Session["table_num"] = tabnum;
            Label2.Text = tabnum.ToString();
            Response.Redirect("Tables.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int tabnum = int.Parse(Session["table_num"].ToString()) + 1;
            if (tabnum > 4)
            {
                tabnum = 1;
            }
            Session["table_num"] = tabnum;
            Label2.Text = tabnum.ToString();
            Response.Redirect("Tables.aspx");
        }
    }
}
