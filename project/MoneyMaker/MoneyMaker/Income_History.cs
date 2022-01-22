using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace MoneyMaker
{
    public class Income_History
    {
        public static void add(int userid, string description, int income, string date, int type, int ID, string typegroup, string typestring)
        {
            string com = "insert into Income_History (User_ID, Dscription, Income,Date_OI, Type_ID, MI_ID, Type_Group, Type_Item) VALUES (" + userid + ",'" + description + "'," + income + ",'" + date + "'," + type + ", " + ID + ", '" + typegroup + "', '" + typestring + "')";
            oledbhelper.Execute(com);
            Users.addmoney(income, userid, 'i');
        }
        //

        public static DataTable selectsingle(int id)
        {
            string com = "SELECT * FROM Income_History WHERE(((Income_History.ID)=" + id + "))";
            return oledbhelper.GetTable(com);
        }
        //

        public static DataTable selectspecific(int userid, string des, int income, string date1, string date2, int type, int ID, string typegroup, string typestring)
        {
            string com = "SELECT * FROM Income_History WHERE(((Income_History.User_ID) = " + userid + ")";

            if (des != "")
            {
                com += " AND((Income_History.Dscription) like '%" + des + "%')";
            }
            if (income != -1)
            {
                com += " AND((Income_History.Income) = " + income + ")";
            }
            if (date1 != "")
            {
                if (date2 != "")
                {
                    com += " AND((Income_History.Date_OI) >= '" + date1 + "')";
                    com += " AND((Income_History.Date_OI) <= '" + date2 + "')";
                }
                else
                {
                    com += " AND((Income_History.Date_OI) = '" + date1 + "')";
                }
            }
            if (type != -1)
            {
                com += " AND((Income_History.Type_ID) = " + type + ")";
            }
            if (ID != -1)
            {
                com += " AND((Income_History.MI_ID) = " + ID + ")";
            }
            if (typegroup != "")
            {
                com += " AND((Income_History.Type_Group) = '" + typegroup + "')";
            }
            if (typestring != "")
            {
                com += " AND((Income_History.Type_Item) = '" + typestring + "')";
            }
            com += ")";
            return oledbhelper.GetTable(com);
        }
        //

        public static DataTable selectbyuser(int userid)
        {
            string com = "SELECT * FROM Income_History WHERE(((Income_History.User_ID) = " + userid + "))";
            return oledbhelper.GetTable(com);
        }
        //

        public static void update(int id, string description, int income, string date, int type, string typegroup, string typestring)
        {
            int i = 0;
            string com = "UPDATE Income_History SET";
            if (description != "")
            {
                com += " Income_History.Dscription = '" + description + "'";
                i = 1;
            }
            if (income != -1)
            {
                if (i == 1)
                {
                    com += ", ";
                }
                com += " Income_History.Income = " + income + "";
                DataRow dt = MoneyMaker.Income_History.selectsingle(id).Rows[0];
                if (int.Parse(dt["Income"].ToString()) != income)
                {
                    Users.addmoney(income - int.Parse(dt["Income"].ToString()), int.Parse(dt["User_ID"].ToString()), 'i');
                }
            }
            if (date != "")
            {
                if (i == 1)
                {
                    com += ", ";
                }
                com += " Income_History.Date_OI = '" + date + "'";
            }
            if (type != -1)
            {
                if (i == 1)
                {
                    com += ", ";
                }
                com += " Income_History.Type_ID = '" + type + "'";
            }
            if (typegroup != "")
            {
                if (i == 1)
                {
                    com += ", ";
                }
                com += " Income_History.Type_Group = '" + typegroup + "'";
            }
            if (typestring != "")
            {
                if (i == 1)
                {
                    com += ", ";
                }
                com += " Income_History.Type_Item = '" + typestring + "'";
            }
            com += " WHERE(((Income_History.ID) = " + id + "))";
            oledbhelper.Execute(com);
        }
        //

        public static void delete(int id)
        {
            string com = "SELECT Income_History.User_ID, Income_History.Income FROM Income_History WHERE(((Income_History.ID) =" + id + "))";
            DataRow dt = oledbhelper.GetTable(com).Rows[0];
            int adding = int.Parse(dt["Income"].ToString());
            int userid = int.Parse(dt["User_ID"].ToString());
            Users.addmoney(-1 * adding, userid, 'i');
            com = "DELETE * FROM Income_History WHERE(((Income_History.ID) = " + id + "))";
            oledbhelper.Execute(com);
        }
        //

        public static DataTable getall(int id)
        {
            string com = "SELECT * FROM Income_History WHERE (((Income_History.User_ID)= " + id + "))";
            return oledbhelper.GetTable(com);
        }
        //

        public static int get_money(int userid, string date1, string date2)
        {
            int money = 0;
            string com = "SELECT * FROM Income_History WHERE(((Income_History.User_ID) = " + userid + ") AND((Income_History.Date_OI) >= '" + date1 + "') AND((Income_History.Date_OI) <= '" + date2 + "'))";
            foreach (DataRow rows in oledbhelper.GetTable(com).Rows)
            {
                money += int.Parse(rows["Income"].ToString());
            }
            return money;
        }
        //

        public static int get_monthly_money(int userid, string date1, string date2)
        {
            int money = 0;
            int i = -1;
            string com = "SELECT * FROM Income_History WHERE(((Income_History.User_ID) = " + userid + ") AND((Income_History.Date_OI) >= '" + date1 + "') AND((Income_History.Date_OI) <= '" + date2 + "') AND((Income_History.MI_ID) <> " + i + "))";
            foreach (DataRow rows in oledbhelper.GetTable(com).Rows)
            {
                money += int.Parse(rows["Income"].ToString());
            }
            return money;
        }
        //

        public static DataTable get_monthly_history(int userid, int monthlyid, string date)
        {
            string com = "SELECT * FROM Income_History WHERE(((Income_History.User_ID) = " + userid + ") AND((Income_History.MI_ID) = " + monthlyid + ")";
            if (date != "")
            {
                com += " AND((Income_History.Date_OI) = '" + date + "')";
            }
            com += ")";
            return oledbhelper.GetTable(com);
        }
        //

        public static void clean_user_data(int id)
        {
            string com = "DELETE * FROM Income_History WHERE(((Income_History.User_ID) = " + id + "))";
            oledbhelper.Execute(com);
        }
        //
    }
}
