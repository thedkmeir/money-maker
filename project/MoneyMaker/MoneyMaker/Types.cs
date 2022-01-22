using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace MoneyMaker
{
    public class Types
    {
        public static void add(string type, string type_group)
        {
            string com = "insert into Types (Type, Type_Group) VALUES ('" + type + "', '" + type_group + "')";
            oledbhelper.Execute(com);
        }
        //

        public static void add_Group(string type_group)
        {
            string com = "insert into Types (Type, Type_Group, IS_Group) VALUES ('" + type_group + "', '" + type_group + "', " + true + ")";
            oledbhelper.Execute(com);
        }
        //

        public static DataTable gettype(int id, string type)
        {
            string com = "SELECT Types.ID, Types.Type FROM Types WHERE(( ";
            if (id != -1)
            {
                com += " (Types.ID) = " + id + "";
            }
            else
            {
                com += " (Types.Type) = '" + type + "'";
            }
            com += "))";
            return oledbhelper.GetTable(com);
        }
        //

        public static DataTable getall()
        {
            string com = "SELECT * FROM Types";
            return oledbhelper.GetTable(com);
        }
        //

        public static int getid(string type, string type_group)
        {
            if (type_group == "")
            {
                return -1;
            }
            string com = "SELECT Types.ID FROM Types WHERE(((Types.Type_Group) = '" + type_group + "')";
            if (type != "")
            {
                com += " AND ((Types.Type) = '" + type + "')";
            }
            com += ")";
            DataRow rows = oledbhelper.GetTable(com).Rows[0];
            return int.Parse(rows["ID"].ToString());
        }
        //

        public static string gettypestring(int id)
        {
            string com = "SELECT Types.Type FROM Types WHERE(((Types.ID) = " + id + "))";
            DataRow row = oledbhelper.GetTable(com).Rows[0];
            return row["Type"].ToString();
        }
        //

        public static void delete(int id)
        {
            string com = "DELETE * FROM Types WHERE(((Types.ID) =" + id + "))";
            oledbhelper.Execute(com);
        }
        //

        public static bool checkduplicate(string newtype)
        {
            string com = "SELECT * From Types WHERE(((Types.Type) = '" + newtype + "'))";
            if (oledbhelper.GetTable(com).Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //

        public static bool checkduplicategroups(string typegroup)
        {
            string com = "SELECT * From Types WHERE (((Types.Type_Group)= '" + typegroup + "') AND ((Types.IS_Group)= " + true + "))";
            if (oledbhelper.GetTable(com).Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //

        public static DataTable get_all_groups()
        {
            string com = "SELECT * FROM Types WHERE(((Types.IS_Group) = " + true + "))";
            return oledbhelper.GetTable(com);
        }
        //

        public static DataTable get_all_types_in_group(string group)
        {
            string com = "SELECT Types.Type FROM Types WHERE(((Types.Type_Group) ='" + group + "'))";
            return oledbhelper.GetTable(com);
        }
        //

        public static string get_group(string type)
        {
            string com = "SELECT Types.Type_Group FROM Types WHERE(((Types.Type) = '" + type + "'))";
            DataRow rows = oledbhelper.GetTable(com).Rows[0];
            return rows["Type_Group"].ToString();
        }
        //

        public static string gettypegroupstring(int id)
        {
            string com = "SELECT Types.Type_Group FROM Types WHERE(((Types.ID) = " + id + "))";
            DataRow row = oledbhelper.GetTable(com).Rows[0];
            return row["Type_Group"].ToString();
        }
        //

        public static string gettypeItemstring(int id)
        {
            string com = "SELECT Types.Type FROM Types WHERE(((Types.ID) = " + id + "))";
            DataRow row = oledbhelper.GetTable(com).Rows[0];
            return row["Type"].ToString();
        }
        //

        public static DataTable get_group_table(string type_group)
        {
            string com = "SELECT * FROM Types WHERE(((Types.Type_Group) = '" + type_group + "'))";
            return oledbhelper.GetTable(com);
        }
        //

        public static DataTable get_specific_types(string type, string type_group)
        {
            int i = 0;
            string com = "SELECT * FROM Types";
            if (type != "")
            {
                com += " WHERE(((Types.Type) = '" + type + "') ";
                i = 1;
            }
            if (type_group != "")
            {
                if (i == 1)
                {
                    com += "AND ";
                }
                else
                {
                    com += " WHERE(";
                }
                com += "((Types.Type_Group) = '" + type_group + "')";
                i = 1;
            }
            if (i == 1)
            {
                com += ")";
            }
            return oledbhelper.GetTable(com);
        }
        //

    }
}
