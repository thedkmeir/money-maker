using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace MoneyMaker
{
    public class Users
    {
        public static void Register(string fname, string lname, string password, int money, string mtype, string date, string email)
        {
            string com = "INSERT INTO Users (FName, LName, [PassWord], [Money], Money_Type, Date_OR, All_Outcome, All_Income, user_email) VALUES ('" + fname + "','" + lname + "','" + password + "'," + money + ",'" + mtype + "', '" + date + "', " + 0 + ", " + 0 + ", '" + email + "')";
            Console.WriteLine("Register1");
            oledbhelper.Execute(com);
        }
        //

        public static int Login(string email, string password)
        {
            string com = "SELECT Users.ID FROM Users WHERE (((Users.user_email) = '" + email + "') AND((Users.PassWord) ='" + password + "'))";
            DataTable td = oledbhelper.GetTable(com);
            if (td.Rows.Count == 0)
            {
                return -1;
            }
            DataRow rows = td.Rows[0];
            if (int.Parse(rows["ID"].ToString()) == 0)
            {
                return -1;
            }
            else
            {
                return int.Parse(rows["ID"].ToString());
            }
        }
        //

        public static DataTable getall()
        {
            string com = "SELECT * FROM Users";
            return oledbhelper.GetTable(com);
        }
        //

        public static string getpassword(int id)
        {
            string com = "SELECT Users.PassWord FROM Users WHERE(((Users.ID) = " + id + "))";
            DataRow rows = oledbhelper.GetTable(com).Rows[0];
            return rows["PassWord"].ToString();
        }
        //

        
        public static DataTable get_specific(string fname, string lname, string pass, int money1, int money2, string moneytype, string date1, string date2, bool admin, string email)
        {
            int i = 0;
            string com = "SELECT * FROM Users ";
            if (fname != "")
            {
                com += "WHERE(((Users.FName) like '%" + fname + "%')";
                i = 1;
            }
            if (lname != "")
            {
                if (i == 0)
                {
                    com += " WHERE(";

                }
                else
                {
                    com += " AND";
                }
                i = 1;
                com += "((Users.LName) like '%" + lname + "%')";
            }
            if (pass != "")
            {
                if (i == 0)
                {
                    com += " WHERE(";

                }
                else
                {
                    com += " AND";
                }
                i = 1;
                com += "((Users.PassWord) like '%" + pass + "%') ";
            }
            if (money1 != -1)
            {
                if (i == 0)
                {
                    com += " WHERE(";

                }
                else
                {
                    com += " AND";
                }
                i = 1;
                if (money2 != -1)
                {
                    com += "((Users.Money) >= " + money1 + ")";
                    com += " AND((Users.Money) <= " + money2 + ")";
                }
                else
                {
                    com += "((Users.Money) = " + money1 + ") ";
                }
            }
            if (moneytype != "")
            {
                if (i == 0)
                {
                    com += " WHERE(";

                }
                else
                {
                    com += " AND";
                }
                i = 1;
                com += "((Users.Money_Type) = '" + moneytype + "') ";
            }
            if (date1 != "")
            {
                if (i == 0)
                {
                    com += " WHERE(";

                }
                else
                {
                    com += " AND";
                }
                i = 1;
                if (date2 != "")
                {
                    com += "((Users.Date_OR) >= '" + date1 + "')";
                    com += " AND((Users.Date_OR) <= '" + date2 + "')";
                }
                else
                {
                    com += "((Users.Date_OR) = '" + date1 + "')";
                }
            }
            if (admin)
            {
                if (i == 0)
                {
                    com += " WHERE(";

                }
                else
                {
                    com += " AND";
                }
                i = 1;
                com += "((Users.Admin) = " + admin + ")";
            }
            if (email != "")
            {
                if (i == 0)
                {
                    com += " WHERE(";

                }
                else
                {
                    com += " AND";
                }
                i = 1;
                com += "((Users.user_email) = '" + email + "') ";
            }
            if (i != 0)
            {
                com += ")";
            }
            return oledbhelper.GetTable(com);
        }
        //

        public static void Change(int id, string fname, string lname, string password, string email)
        {
            int i = 0;
            string com = "UPDATE Users SET";
            if (fname != "")
            {
                com += " Users.FName = '" + fname + "'";
                i++;
            }
            if (lname != "")
            {
                if (i != 0)
                {
                    com += " ,";
                }
                com += " Users.LName = '" + lname + "'";
                i++;
            }
            if (password != "")
            {
                if (i != 0)
                {
                    com += " ,";
                }
                com += " Users.PassWord = '" + password + "'";
            }
            if (email != "")
            {
                if (i != 0)
                {
                    com += " ,";
                }
                com += " Users.user_email = '" + email + "'";
            }
            com += " WHERE (((Users.ID) = " + id + "))";
            oledbhelper.Execute(com);
        }
        //

        static public void addmoney(int toadd, int userid, char ioro)
        {
            if (ioro == 'i')
            {
                string com = "SELECT Users.All_Income, Users.Money FROM Users WHERE(((Users.ID) = " + userid + " ))";
                DataRow rows = oledbhelper.GetTable(com).Rows[0];
                int finalmoney = int.Parse(rows["Money"].ToString()) + toadd;
                int temp = int.Parse(rows["All_Income"].ToString()) + toadd; 
                com = "UPDATE Users SET Users.All_Income = " + temp + ", Users.[Money] = " + finalmoney + " WHERE(((Users.ID) = " + userid + "))";
                oledbhelper.Execute(com);
            }
            else
            {
                string com = "SELECT Users.All_Outcome, Users.Money FROM Users WHERE(((Users.ID) = " + userid + " ))";
                DataRow rows = oledbhelper.GetTable(com).Rows[0];
                int finalmoney = int.Parse(rows["Money"].ToString()) - toadd;
                int temp = int.Parse(rows["All_Outcome"].ToString()) + toadd;
                com = "UPDATE Users SET Users.All_Outcome = " + temp + ", Users.[Money] = " + finalmoney + " WHERE(((Users.ID) = " + userid + "))";
                oledbhelper.Execute(com);
            }
        }
        //

        static public int getmoney(int id)
        {
            string com = "SELECT Users.Money FROM Users WHERE(((Users.ID) = " + id + "))";
            DataRow rows = oledbhelper.GetTable(com).Rows[0];
            return int.Parse(rows["Money"].ToString());
        }
        //

        static public DateTime get_user_reg_date(int id)
        {
            string com = "SELECT Users.Date_OR FROM Users WHERE(((Users.ID) = " + id + "))";
            DataRow rows = oledbhelper.GetTable(com).Rows[0];
            string date = rows["Date_OR"].ToString();
            int year = int.Parse(date.Substring(0, 4));
            int month = int.Parse(date.Substring(5, 2));
            int day = int.Parse(date.Substring(8, 2));
            DateTime date1 = new DateTime(year, month, day);
            return date1;
        }
        //

        static public bool is_admin(int id)
        {
            string com = "SELECT Users.Admin FROM Users WHERE(((Users.ID) = " + id + "))";
            DataRow rows = oledbhelper.GetTable(com).Rows[0];
            if (bool.Parse(rows["Admin"].ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //

        static public void make_admin(int id)
        {
            string com = "UPDATE Users SET Users.Admin = " + true + " WHERE(((Users.ID) =" + id + "))";
            oledbhelper.Execute(com);
        }
        //

        static public void nomake_admin(int id)
        {
            string com = "UPDATE Users SET Users.Admin = " + false + " WHERE(((Users.ID) =" + id + "))";
            oledbhelper.Execute(com);
        }
        //

        public static void clean_user_data(int id)
        {
            string com = "DELETE * FROM Users WHERE(((Users.ID) = " + id + "))";
            oledbhelper.Execute(com);
        }
        //

        public static int getallincome(int id)
        {
            string com = "SELECT Users.All_Income FROM Users WHERE(((Users.ID) = " + id + "))";
            DataRow rows = oledbhelper.GetTable(com).Rows[0];
            return int.Parse(rows["All_Income"].ToString());
        }
        //

        public static int getalloutcome(int id)
        {
            string com = "SELECT Users.All_Outcome FROM Users WHERE(((Users.ID) = " + id + "))";
            DataRow rows = oledbhelper.GetTable(com).Rows[0];
            return int.Parse(rows["All_Outcome"].ToString());
        }
        //

        public static bool check_email_duplicate(string email)
        {
            string com = "SELECT Users.user_email FROM Users WHERE(((Users.user_email)= '" + email + "'))";
            if (oledbhelper.GetTable(com).Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //
    }
}
