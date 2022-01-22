using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace MoneyMaker
{
    public class Type_Group_Suggestion
    {
        public static void add(int userid, string type_group, string comment)
        {
            string com = "INSERT INTO Type_Group_Suggestion ( User_ID, Group_Type, Comment ) VALUES (" + userid + ",'" + type_group + "','" + comment + "')";
            oledbhelper.Execute(com);
        }
        //

        public static DataTable select(int id, int userid, string type_group)
        {
            int i = 0;
            string com = "SELECT * FROM Type_Group_Suggestion WHERE";
            if (id != -1)
            {
                i = 1;
                com += " (((Type_Group_Suggestion.ID)= " + id + ") ";
            }
            if (userid != -1)
            {
                if (i == 1)
                {
                    com += "AND ";
                }
                com += "((Type_Group_Suggestion.User_ID)= " + userid + ") ";
            }
            if (type_group != "")
            {
                if (i == 1)
                {
                    com += "AND ";
                }
                com += "((Type_Group_Suggestion.Group_Type)= '" + type_group + "')";
            }
            com += ")";
            return oledbhelper.GetTable(com);
        }
        //

        public static DataTable getall()
        {
            string com = "SELECT * FROM Type_Group_Suggestion";
            return oledbhelper.GetTable(com);
        }
        //

        public static void delete(int id)
        {
            string com = "DELETE * FROM Type_Group_Suggestion WHERE(((Type_Group_Suggestion.ID) = " + id + "))";
            oledbhelper.Execute(com);
        }
        //
    }
}
