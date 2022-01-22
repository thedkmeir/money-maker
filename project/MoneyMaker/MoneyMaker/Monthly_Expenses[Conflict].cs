using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Threading;

namespace MoneyMaker
{
    public class Monthly_Expenses
    {
        public static void add(int userid, int averaged_price, string product, int num_payments, int total_payed, int product_type, string date, int Payments, string typegroup, string typestring)
        {
            int payment1 = Payments - 1;
            string com = "insert into Monthly_Expenses (User_ID, Averaged_Price, Type_ID, Num_Payments, Total_Payed, Product_Type, Date_OA, Date_OU, PayMents, Type_Group, Type_Item) VALUES (" + userid + "," + averaged_price + ",'" + product + "', " + num_payments + ", " + total_payed + ", " + product_type + ", '" + date + "', '" + date + "', " + payment1 + ", '" + typegroup + "', '" + typestring + "')";
            oledbhelper.Execute(com);
            Thread.Sleep(500);
            com = "SELECT Monthly_Expenses.ID FROM Monthly_Expenses WHERE(((Monthly_Expenses.User_ID) = " + userid + ") AND((Monthly_Expenses.Averaged_Price) = " + averaged_price + ") AND((Monthly_Expenses.Type_ID) = '" + product + "') AND((Monthly_Expenses.Num_Payments) = " + num_payments + ") AND((Monthly_Expenses.Total_Payed) = " + total_payed + ") AND((Monthly_Expenses.Product_Type) = " + product_type + ") AND((Monthly_Expenses.Date_OA) = '" + date + "') AND((Monthly_Expenses.PayMents) = " + payment1 + "))";
            DataRow rows = oledbhelper.GetTable(com).Rows[0];
            MoneyMaker.Outcome_History.AddProduct(userid, product_type, averaged_price, product, "", date, int.Parse(rows["ID"].ToString()), typegroup, typestring);
        }
        //

        public static void delete(int id)
        {
            string com = "DELETE FROM Monthly_Expenses WHERE(((Monthly_Expenses.ID) = " + id + "))";
            oledbhelper.Execute(com);
        }

        public static void change(int id, int averaged_price, string product, int num_payments, int total_payed, int product_type, string dateou, int payments, string typegroup, string typestring)
        {
            int i = 0;
            string com = "UPDATE Monthly_Expenses SET";

            if (averaged_price != -1)
            {
                com += " Monthly_Expenses.Averaged_Price = " + averaged_price + "";
                i = 1;
            }
            if (product != "")
            {
                if (i == 1)
                {
                    com += ",";
                }
                com += " Monthly_Expenses.Type_ID = '" + product + "'";
                i = 1;
            }
            if (num_payments != -1)
            {
                if (i == 1)
                {
                    com += ",";
                }
                com += " Monthly_Expenses.Num_Payments = " + num_payments + "";
                i = 1;
            }
            if (total_payed != -1)
            {
                if (i == 1)
                {
                    com += ",";
                }
                com += " Monthly_Expenses.Total_Payed = " + total_payed + "";
            }
            if (product_type != -1)
            {
                if (i == 1)
                {
                    com += ",";
                }
                com += " Monthly_Expenses.Product_Type = " + product_type + "";
            }
            if (dateou != "")
            {
                if (i == 1)
                {
                    com += ",";
                }
                com += " Monthly_Expenses.Date_OU = '" + dateou + "'";
            }
            if (payments != -1)
            {
                if (i == 1)
                {
                    com += ",";
                }
                com += " Monthly_Expenses.PayMents = " + payments + "";
            }
            if (typegroup != "")
            {
                if (i == 1)
                {
                    com += ",";
                }
                com += " Monthly_Expenses.Type_Group = '" + typegroup + "'";
                i = 1;
            }
            if (typestring != "")
            {
                if (i == 1)
                {
                    com += ",";
                }
                com += " Monthly_Expenses.Type_Item = '" + typestring + "'";
                i = 1;
            }
            com += " WHERE(((Monthly_Expenses.ID) = " + id + "))";
            oledbhelper.Execute(com);
        }
        //

        public static DataTable getsingle(int id)
        {
            string com = "SELECT * FROM Monthly_Expenses WHERE(((Monthly_Expenses.ID) =" + id + "))";
            return oledbhelper.GetTable(com);
        }
        //

        public static DataTable getall(int id)
        {
            string com = "SELECT * FROM Monthly_Expenses WHERE(((Monthly_Expenses.User_ID) =" + id + "))";
            return oledbhelper.GetTable(com);
        }
        //

        public static void repeat(int id, string date, int addprice, bool ispayment)
        {
            if (!ispayment)
            {
                DataRow rows = Monthly_Expenses.getsingle(id).Rows[0];
                int totalpayed = int.Parse(rows["Total_Payed"].ToString());
                int numofpay = int.Parse(rows["Num_Payments"].ToString());
                int userid = int.Parse(rows["User_ID"].ToString());
                string product = rows["Type_ID"].ToString();
                int product_type = int.Parse(rows["Product_Type"].ToString());
                int payments = int.Parse(rows["PayMents"].ToString());
                string typegroup = rows["Type_Group"].ToString();
                string typestring = rows["Type_Item"].ToString();
                int average = int.Parse(rows["Averaged_Price"].ToString());
                payments--;
                numofpay++;
                totalpayed += average;
                if (payments == 0)
                {
                    Monthly_Expenses.delete(id);
                }
                else
                {
                    Monthly_Expenses.change(id, -1, "", numofpay, totalpayed, -1, date, payments, "", "");
                }
                Outcome_History.AddProduct(userid, product_type, average, product, "", date, id, typegroup, typestring);
            }
            else
            {
                DataRow rows = Monthly_Expenses.getsingle(id).Rows[0];
                int totalpayed = int.Parse(rows["Total_Payed"].ToString());
                int numofpay = int.Parse(rows["Num_Payments"].ToString());
                int userid = int.Parse(rows["User_ID"].ToString());
                string product = rows["Type_ID"].ToString();
                int product_type = int.Parse(rows["Product_Type"].ToString());
                int payments = int.Parse(rows["PayMents"].ToString());
                string typegroup = rows["Type_Group"].ToString();
                string typestring = rows["Type_Item"].ToString();
                int average = int.Parse(rows["Averaged_Price"].ToString());
                numofpay++;
                payments--;
                totalpayed = totalpayed + average;
                Monthly_Expenses.change(id, average, "", numofpay, totalpayed, -1, date, payments, "", "");
                Outcome_History.AddProduct(userid, product_type, average, product, "", date, id, typegroup, typestring);
            }
        }
        //

        public static DataTable Getmoutcome(int userid, string product, int money, int type, string date1, string date2, int payments, string typegroup, string typestring)
        {
            int i = 0;
            string com = "SELECT * FROM Monthly_Expenses WHERE(((Monthly_Expenses.User_ID)=" + userid + ")";
            if (product != "")
            {
                com += " AND((Monthly_Expenses.Type_ID) like '%" + product + "%')";
            }
            if (money != -1)
            {
                com += " AND((Monthly_Expenses.Averaged_Price) = " + money + ")";
            }
            if (type != -1)
            {
                com += " AND((Monthly_Expenses.Product_Type) = " + type + ")";
            }
            if (date1 != "")
            {
                if (date2 != "")
                {
                    com += " AND((Monthly_Expenses.Date_OA) >= '" + date1 + "')";
                    com += " AND((Monthly_Expenses.Date_OA) <= '" + date2 + "')";
                }
                else
                {
                    com += " AND((Monthly_Expenses.Date_OA) = '" + date1 + "')";
                }
            }
            if (payments != 0)
            {
                com += " AND((Monthly_Expenses.PayMents) = " + payments + ")";
            }
            if (typegroup != "")
            {
                com += " AND((Monthly_Expenses.Type_Group)='" + typegroup + "')";
            }
            if (typestring != "")
            {
                com += " AND((Monthly_Expenses.Type_Item)='" + typestring + "')";
            }
            com += ")";
            return oledbhelper.GetTable(com);
        }
        //

        public static void clean_user_data(int id)
        {
            string com = "DELETE * FROM Monthly_Expenses WHERE(((Monthly_Expenses.User_ID) = " + id + "))";
            oledbhelper.Execute(com);
        }
        //

        public static DataTable get_to_add_price(int userid, string date1, string date2)
        {
            string com = "SELECT * FROM Monthly_Expenses WHERE(((Monthly_Expenses.User_ID) = " + userid + ") AND((Monthly_Expenses.Date_OU) <= '" + date2 + "') AND((Monthly_Expenses.Date_OU) >= '" + date1 + "'))";
            return oledbhelper.GetTable(com);
        }

        public static int getaverage(int userid)
        {
            string com = "SELECT Monthly_Expenses.Averaged_Price FROM Monthly_Expenses WHERE(((Monthly_Expenses.User_ID) = " + userid + "))";
            int count = 0;
            foreach (DataRow rows in oledbhelper.GetTable(com).Rows)
            {
                count += int.Parse(rows["Averaged_Price"].ToString());
            }
            return count;
        }
        //
    }
}
