using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Threading;

namespace MoneyMaker
{
    public class Monthly_Income
    {
        public static void Add(int cpm, string des, int userid, int totalpayed, int numofpay, string date, int type, string typegroup, string typestring)
        {
            string com = "insert into Monthly_Income (Cash_Per_Month,Description,User_ID,Total_Payed, Num_Of_Pay, Date_OA, Date_OU, Type_ID, Type_Group, Type_Item) VALUES (" + cpm + ",'" + des + "'," + userid + "," + totalpayed + "," + numofpay + ",'" + date + "','" + date + "'," + type + ", '" + typegroup + "', '" + typestring + "')";
            oledbhelper.Execute(com);
            Thread.Sleep(400);
            string com1 = "SELECT Monthly_Income.ID FROM Monthly_Income WHERE(((Monthly_Income.Cash_Per_Month) = " + cpm + ") AND((Monthly_Income.Description) = '" + des + "' ) AND((Monthly_Income.User_ID) = " + userid + " ) AND((Monthly_Income.Total_Payed) = " + totalpayed + " ) AND((Monthly_Income.Num_Of_Pay) = " + numofpay + " ) AND((Monthly_Income.Date_OA) = '" + date + "' ) AND((Monthly_Income.Date_OU) = '" + date + "' ) AND((Monthly_Income.Type_ID) = " + type + " ))";
            DataRow rows = oledbhelper.GetTable(com1).Rows[0];
            Income_History.add(userid, des, cpm, date, type, int.Parse(rows["ID"].ToString()), typegroup, typestring);
        }
        //

        public static DataTable getall(int userid)
        {
            string com = "SELECT * FROM Monthly_Income WHERE(((Monthly_Income.User_ID) = " + userid + "))";
            return oledbhelper.GetTable(com);
        }
        //

        public static DataTable getspecific(int id)
        {
            string com = "SELECT * FROM Monthly_Income WHERE(((Monthly_Income.ID) = " + id + "))";
            return oledbhelper.GetTable(com);
        }
        //

        public static void Repeat(int ID, string date, int addprice)
        {
            string com = "SELECT * FROM Monthly_Income WHERE(((Monthly_Income.ID)=" + ID + "))";
            DataRow rows = oledbhelper.GetTable(com).Rows[0];
            string des = rows["Description"].ToString();
            int userid = int.Parse(rows["User_ID"].ToString());
            int numofpay = int.Parse(rows["Num_Of_Pay"].ToString());
            int totalpay = int.Parse(rows["Total_Payed"].ToString());
            int type = int.Parse(rows["Type_ID"].ToString());
            string typegroup = rows["Type_Group"].ToString();
            string typestring = rows["Type_Item"].ToString();
            numofpay++;
            totalpay = totalpay + addprice;
            int averagenew = totalpay / numofpay;
            Monthly_Income.change(ID, averagenew, "", totalpay, numofpay, date, -1, "", "");
            Income_History.add(userid, des, addprice, date, type, ID, typegroup, typestring);
        }
        //

        public static DataTable Getmincome(int userid, string des, int cpm, string date1, string date2, int type, string typegroup, string typestring)
        {
            string com = "SELECT * FROM Monthly_Income WHERE(((Monthly_Income.User_ID)=" + userid + ")";
            if (des != "")
            {
                com += " AND((Monthly_Income.Description) like '%" + des + "%')";
            }
            if (cpm != -1)
            {
                com += " AND((Monthly_Income.Cash_Per_Month) = " + cpm + ")";
            }
            if (date1 != "")
            {
                if (date2 != "")
                {
                    com += " AND((Monthly_Income.Date_OA) >= '" + date1 + "')";
                    com += " AND((Monthly_Income.Date_OA) <= '" + date2 + "')";
                }
                else
                {
                    com += " AND((Monthly_Income.Date_OA) = '" + date1 + "')";
                }
            }
            if (type != -1)
            {
                com += " AND((Monthly_Income.Type_ID) = " + type + ")";
            }
            if (typegroup != "")
            {
                com += " AND((Monthly_Income.Type_Group)='" + typegroup + "')";
            }
            if (typestring != "")
            {
                com += " AND((Monthly_Income.Type_Item)='" + typestring + "')";
            }
            com += ")";
            return oledbhelper.GetTable(com);
        }
        //

        public static void change(int monthlyid, int cashpermonth, string description, int totalpay, int numofpay, string dateou, int type, string typegroup, string typestring)
        {
            int i = 0;
            string com = "UPDATE Monthly_Income SET";
            if (cashpermonth != -1)
            {
                com += " Monthly_Income.Cash_Per_Month = " + cashpermonth + "";
                i = 1;
            }
            if (description != "")
            {
                if (i == 1)
                {
                    com += ",";
                }
                com += " Monthly_Income.Description = '" + description + "'";
                i = 1;
            }
            if (totalpay != -1)
            {
                if (i == 1)
                {
                    com += ",";
                }
                com += " Monthly_Income.Total_Payed = " + totalpay + "";
                i = 1;
            }
            if (numofpay != -1)
            {
                if (i == 1)
                {
                    com += ",";
                }
                com += " Monthly_Income.Num_Of_Pay = " + numofpay + "";
            }
            if (dateou != "")
            {
                if (i == 1)
                {
                    com += ",";
                }
                com += " Monthly_Income.Date_OU = '" + dateou + "'";
            }
            if (type != -1)
            {
                if (i == 1)
                {
                    com += ",";
                }
                com += " Monthly_Income.Type_ID = " + type + "";
            }
            if (typegroup != "")
            {
                if (i == 1)
                {
                    com += ",";
                }
                com += " Monthly_Income.Type_Group = '" + typegroup + "'";
                i = 1;
            }
            if (typestring != "")
            {
                if (i == 1)
                {
                    com += ",";
                }
                com += " Monthly_Income.Type_Item = '" + typestring + "'";
                i = 1;
            }
            com += " WHERE(((Monthly_Income.ID) =" + monthlyid + "))";
            oledbhelper.Execute(com);
        }
        //

        public static void delete(int monthlyid)
        {
            string com = "DELETE * FROM Monthly_Income WHERE(((Monthly_Income.ID) = " + monthlyid + "))";
            oledbhelper.Execute(com);
        }
        //

        public static void clean_user_data(int id)
        {
            string com = "DELETE * FROM Monthly_Income WHERE(((Monthly_Income.User_ID) = " + id + "))";
            oledbhelper.Execute(com);
        }
        //

        public static DataTable get_to_add_price(int userid, string date1, string date2)
        {
            string com = "SELECT * FROM Monthly_Income WHERE(((Monthly_Income.User_ID) = " + userid + ") AND((Monthly_Income.Date_OU) <= '" + date2 + "') AND((Monthly_Income.Date_OU) >= '" + date1 + "'))";
            return oledbhelper.GetTable(com);
        }
        //

        public static int getaverage(int userid)
        {
            string com = "SELECT Monthly_Income.Cash_Per_Month FROM Monthly_Income WHERE(((Monthly_Income.User_ID) = " + userid + "))";
            int count = 0;
            foreach (DataRow rows in oledbhelper.GetTable(com).Rows)
            {
                count += int.Parse(rows["Cash_Per_Month"].ToString());
            }
            return count;
        }
        //
    }
}
