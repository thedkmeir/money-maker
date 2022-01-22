using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace MoneyMaker
{
    public class Outcome_History
    {
        public static void AddProduct(int userid, int typeid, int price, string product, string date, int ID, string typegroup, string typestring)
        {
            string com = "insert into Product_History (User_ID,Type_ID,Price,Product,Date_OP,MO_ID,Type_Group, Type_Item) VALUES (" + userid + "," + typeid + "," + price + ",'" + product + "','" + date + "'," + ID + ", '" + typegroup + "', '" + typestring + "')";
            oledbhelper.Execute(com);
            Users.addmoney(price, userid, 'o');
        }
        //

        public static DataTable selectbyuser(int userid)
        {
            string com = "SELECT * FROM Product_History WHERE(((Product_History.User_ID) = " + userid + "))";
            return oledbhelper.GetTable(com);
        }
        //

        public static DataTable selectbypro(int id)
        {
            string com = "SELECT * FROM Product_History WHERE(((Product_History.ID) = " + id + "))";
            return oledbhelper.GetTable(com);
        }
        //

        public static DataTable Getproducts(int userid, int typeid, int price, string product, string date1, string date2, int ID, string typegroup, string typestring)
        {
            string com = "SELECT * FROM Product_History WHERE(((Product_History.User_ID)=" + userid + ")";
            if (typeid != -1)
            {
                com += " AND((Product_History.Type_ID)=" + typeid + ")";
            }
            if (price != -1)
            {
                com += " AND((Product_History.Price) = " + price + ")";
            }
            if (product != "")
            {
                com += " AND((Product_History.Product) like '%" + product + "%')";
            }
            if (date1 != "")
            {
                if (date2 != "")
                {
                    com += " AND((Product_History.Date_OP) >= '" + date1 + "')";
                    com += " AND((Product_History.Date_OP) <= '" + date2 + "')";
                }
                else
                {
                    com += " AND((Product_History.Date_OP) = '" + date1 + "')";
                }
            }
            if (ID != -1)
            {
                com += " AND((Product_History.MO_ID) = " + ID + ")";
            }
            if (typegroup != "")
            {
                com += " AND((Product_History.Type_Group)='" + typegroup + "')";
            }
            if (typestring != "")
            {
                com += " AND((Product_History.Type_Item)='" + typestring + "')";
            }
            com += ")";

            return oledbhelper.GetTable(com);
        }
        //

        public static void SetProduct(int proid, int typeid, int price, string product, string date, string typegroup, string typestring)
        {
            int i = 0;
            string com = "UPDATE Product_History SET";
            if (typeid != -1)
            {
                com += " Product_History.Type_ID = " + typeid + "";
                i++;
            }
            if (price != -1)
            {
                if (i != 0)
                {
                    com += " ,";
                }
                com += "Product_History.Price = " + price + "";
                i++;
                DataRow dt = MoneyMaker.Outcome_History.selectbypro(proid).Rows[0];
                if (int.Parse(dt["Price"].ToString()) != price)
                {
                    Users.addmoney(price - int.Parse(dt["Price"].ToString()), int.Parse(dt["User_ID"].ToString()), 'o');
                }
            }
            if (product != "")
            {
                if (i != 0)
                {
                    com += " ,";
                }
                com += "Product_History.Product = '" + product + "'";
                i++;
            }
            if (date != "")
            {
                if (i != 0)
                {
                    com += " ,";
                }
                com += "Product_History.Date_OP = '" + date + "'";
            }
            if (typegroup != "")
            {
                if (i != 0)
                {
                    com += " ,";
                }
                com += "Product_History.Type_Group = '" + typegroup + "'";
                i++;
            }
            if (typestring != "")
            {
                if (i != 0)
                {
                    com += " ,";
                }
                com += "Product_History.Type_Item = '" + typestring + "'";
                i++;
            }
            com += " WHERE(((Product_History.ID) = " + proid + "))";
            oledbhelper.Execute(com);
        }
        //

        public static void delete(int id)
        {
            string com = "SELECT Product_History.User_ID, Product_History.Price FROM Product_History WHERE(((Product_History.ID) =" + id + "))";
            DataRow dt = oledbhelper.GetTable(com).Rows[0];
            int adding = int.Parse(dt["Income"].ToString());
            int userid = int.Parse(dt["User_ID"].ToString());
            Users.addmoney(adding, userid, 'o');
            com = "DELETE * FROM Product_History WHERE(((Product_History.ID) = " + id + "))";
            oledbhelper.Execute(com);
        }
        //

        public static int get_money(int userid, string date1, string date2)
        {
            int money = 0;
            string com = "SELECT * FROM Product_History WHERE(((Product_History.User_ID) = " + userid + ") AND((Product_History.Date_OP) >= '" + date1 + "') AND((Product_History.Date_OP) <= '" + date2 + "'))";
            foreach (DataRow rows in oledbhelper.GetTable(com).Rows)
            {
                money += int.Parse(rows["Price"].ToString());
            }
            return money;
        }
        //

        public static int get_monthly_money(int userid, string date1, string date2)
        {
            int money = 0;
            string com = "SELECT * FROM Product_History WHERE(((Product_History.User_ID) = " + userid + ") AND((Product_History.Date_OP) >= '" + date1 + "') AND((Product_History.Date_OP) <= '" + date2 + "') AND((Product_History.MO_ID) <> " + -1 + "))";
            foreach (DataRow rows in oledbhelper.GetTable(com).Rows)
            {
                money += int.Parse(rows["Price"].ToString());
            }
            return money;
        }
        //

        public static DataTable get_monthly_history(int userid, int monthlyid, string date)
        {
            string com = "SELECT * FROM Product_History WHERE(((Product_History.User_ID) =" + userid + ") AND((Product_History.MO_ID) =" + monthlyid + ")";
            if (date != "")
            {
                com += "AND((Product_History.Date_OP) ='" + date + "')";
            }
            com += ")";
            return oledbhelper.GetTable(com);
        }
        //

        public static void clean_user_data(int id)
        {
            string com = "DELETE * FROM Product_History WHERE(((Product_History.User_ID) = " + id + "))";
            oledbhelper.Execute(com);
        }
        //
    }

}

