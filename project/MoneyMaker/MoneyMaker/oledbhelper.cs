using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;


namespace MoneyMaker
{
    public class oledbhelper
    {
        static string database = "";
        static string CONECTIONSTRING = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6) + @"\Info.accdb";
        static OleDbConnection cn = new OleDbConnection(CONECTIONSTRING);

        public static void Execute(string com)
        {
            if (cn.State != ConnectionState.Open)
            {
                cn.Open();
            }

            OleDbCommand command = new OleDbCommand();
            command.Connection = cn;
            command.CommandText = com;

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static DataTable GetTable(string com)
        {
            //בדיקה אם החיבור פתוח ואם הוא לא אז לפתוח
            if (cn.State != ConnectionState.Open)
            {
                cn.Open();
            }

            // command יצירת אובייקט מסוג 
            OleDbCommand command = new OleDbCommand();
            command.Connection = cn;
            command.CommandText = com;
            //יצירת אובייקט מסוג דטהסט - אוסף טבלאות בזיכרון המחשב

            DataTable dt = new DataTable();
            dt.TableName = "Info";
            //יצירת אובייקט אדפטר מטרתו לתאם בין הדטהסט לדטהבייס
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);

            try
            {
                //הפעולה פותחת את הדטהבייס ומחזירה את כל הנתונים לתוך טבלה חדשה בדטהסט
                adapter.Fill(dt);
            }
            catch
            {
                throw;
            }
            finally
            {
            }
            return dt;
        }

        public static void getaddress(string path)
        {
            database = path;
        }
    }
}
