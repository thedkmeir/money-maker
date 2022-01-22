using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MoneyMaker;
using System.Data;

namespace ServerData
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public void Income_History_add(int userid, string description, int income, string date, int type, string comment, int ID, string typegroup, string typestring)
        {
            MoneyMaker.Income_History.add(userid,description, income, date, type, comment, ID, typegroup, typestring);
        }
        public DataTable Income_History_selectsingle(int id)
        {
            return MoneyMaker.Income_History.selectsingle(id);
        }
        public DataTable Income_History_selectspecific(int userid, string des, int income, string date1, string date2, int type, string comment, int ID, string typegroup, string typestring)
        {
            return MoneyMaker.Income_History.selectspecific(userid, des, income, date1, date2, type, comment, ID, typegroup, typestring);
        }
        public DataTable Income_History_selectbyuser(int userid)
        {
            return MoneyMaker.Income_History.selectbyuser(userid);
        }
        public void Income_History_update(int id, string description, int income, string date, int type, string comment, string typegroup, string typestring)
        {
            MoneyMaker.Income_History.update(id, description, income, date, type, comment, typegroup, typestring);
        }
        public void Income_History_delete(int id)
        {
            MoneyMaker.Income_History.delete(id);
        }
        public DataTable Income_History_getall(int id)
        {
            return MoneyMaker.Income_History.getall(id);
        }
        public int Income_History_get_money(int userid, string date1, string date2)
        {
            return MoneyMaker.Income_History.get_money(userid, date1, date2);
        }
        public int Income_History_get_monthly_money(int userid, string date1, string date2)
        {
            return MoneyMaker.Income_History.get_monthly_money(userid, date1, date2);
        }
        public DataTable Income_History_get_monthly_history(int userid, int monthlyid, string date)
        {
            return MoneyMaker.Income_History.get_monthly_history(userid, monthlyid, date);
        }
        public void Income_History_clean_user_data(int id)
        {
            MoneyMaker.Income_History.clean_user_data(id);
        }

        public void Monthly_Expenses_add(int userid, int averaged_price, string product, int num_payments, int total_payed, int product_type, string date, int Payments, string typegroup, string typestring)
        {
            MoneyMaker.Monthly_Expenses.add(userid, averaged_price, product, num_payments, total_payed, product_type, date, Payments, typegroup, typestring);
        }
        public void Monthly_Expenses_delete(int id)
        {
            MoneyMaker.Monthly_Expenses.delete(id);
        }
        public void Monthly_Expenses_change(int id, int averaged_price, string product, int num_payments, int total_payed, int product_type, string dateou, int payments, string typegroup, string typestring)
        {
            MoneyMaker.Monthly_Expenses.change(id, averaged_price, product, num_payments, total_payed, product_type, dateou, payments, typegroup, typestring);
        }
        public DataTable Monthly_Expenses_getsingle(int id)
        {
            return MoneyMaker.Monthly_Expenses.getsingle(id);
        }
        public DataTable Monthly_Expenses_getall(int id)
        {
            return MoneyMaker.Monthly_Expenses.getall(id);
        }
        public void Monthly_Expenses_repeat(int id, string date, int addprice, bool ispayment)
        {
            MoneyMaker.Monthly_Expenses.repeat(id, date, addprice, ispayment);
        }
        public DataTable Monthly_Expenses_Getmoutcome(int userid, string product, int money, int type, string date1, string date2, int payments, string typegroup, string typestring)
        {
            return MoneyMaker.Monthly_Expenses.Getmoutcome(userid, product, money, type, date1,  date2, payments, typegroup, typestring);
        }
        public void Monthly_Expenses_clean_user_data(int id)
        {
            MoneyMaker.Monthly_Expenses.clean_user_data(id);
        }
        public DataTable Monthly_Expenses_get_to_add_price(int userid, string date1, string date2)
        {
            return MoneyMaker.Monthly_Expenses.get_to_add_price(userid, date1, date2);
        }
        public int Monthly_Expenses_getaverage(int userid)
        {
            return MoneyMaker.Monthly_Expenses.getaverage(userid);
        }

        public void Monthly_Income_Add(int cpm, string des, int userid, int totalpayed, int numofpay, string date, int type, string typegroup, string typestring)
        {
            MoneyMaker.Monthly_Income.Add(cpm, des, userid, totalpayed, numofpay, date, type, typegroup, typestring);
        }
        public DataTable Monthly_Income_getall(int userid)
        {
            return MoneyMaker.Monthly_Income.getall(userid);
        }
        public DataTable Monthly_Income_getspecific(int id)
        {
            return MoneyMaker.Monthly_Income.getspecific(id);
        }
        public void Monthly_Income_Repeat(int ID, string date, int addprice)
        {
            MoneyMaker.Monthly_Income.Repeat(ID, date, addprice);
        }
        public DataTable Monthly_Income_Getmincome(int userid, string des, int cpm, string date1, string date2, int type, string typegroup, string typestring)
        {
            return MoneyMaker.Monthly_Income.Getmincome(userid, des, cpm, date1, date2, type, typegroup, typestring);
        }
        public void Monthly_Income_change(int monthlyid, int cashpermonth, string description, int totalpay, int numofpay, string dateou, int type, string typegroup, string typestring)
        {
            MoneyMaker.Monthly_Income.change(monthlyid, cashpermonth, description, totalpay, numofpay, dateou, type, typegroup, typestring);
        }
        public void Monthly_Income_delete(int monthlyid)
        {
            MoneyMaker.Monthly_Income.delete(monthlyid);
        }
        public void Monthly_Income_clean_user_data(int id)
        {
            MoneyMaker.Monthly_Income.clean_user_data(id);
        }
        public DataTable Monthly_Income_get_to_add_price(int userid, string date1, string date2)
        {
            return MoneyMaker.Monthly_Income.get_to_add_price(userid, date1, date2);
        }
        public int Monthly_Income_getaverage(int userid)
        {
            return MoneyMaker.Monthly_Income.getaverage(userid);
        }

        public void Outcome_History_AddProduct(int userid, int typeid, int price, string product, string comment, string date, int ID, string typegroup, string typestring)
        {
            MoneyMaker.Outcome_History.AddProduct(userid, typeid, price, product, comment, date, ID, typegroup, typestring);
        }
        public DataTable Outcome_History_selectbyuser(int userid)
        {
            return MoneyMaker.Outcome_History.selectbyuser(userid);
        }
        public DataTable Outcome_History_selectbypro(int id)
        {
            return MoneyMaker.Outcome_History.selectbypro(id);
        }
        public DataTable Outcome_History_Getproducts(int userid, int typeid, int price, string product, string comment, string date1, string date2, int ID, string typegroup, string typestring)
        {
            return MoneyMaker.Outcome_History.Getproducts(userid, typeid, price, product, comment, date1, date2, ID, typegroup, typestring);
        }
        public void Outcome_History_SetProduct(int proid, int typeid, int price, string product, string comment, string date, string typegroup, string typestring)
        {
            MoneyMaker.Outcome_History.SetProduct(proid, typeid, price, product, comment, date, typegroup, typestring);
        }
        public void Outcome_History_delete(int id)
        {
            MoneyMaker.Outcome_History.delete(id);
        }
        public int Outcome_History_get_money(int userid, string date1, string date2)
        {
            return MoneyMaker.Outcome_History.get_money(userid, date1, date2);
        }
        public int Outcome_History_get_monthly_money(int userid, string date1, string date2)
        {
            return MoneyMaker.Outcome_History.get_monthly_money(userid, date1, date2);
        }
        public DataTable Outcome_History_get_monthly_history(int userid, int monthlyid, string date)
        {
            return MoneyMaker.Outcome_History.get_monthly_history(userid, monthlyid, date);
        }
        public void Outcome_History_clean_user_data(int id)
        {
            MoneyMaker.Outcome_History.clean_user_data(id);
        }

        public void Type_Group_Suggestion_add(int userid, string type_group, string comment)
        {
            MoneyMaker.Type_Group_Suggestion.add(userid, type_group, comment);
        }
        public DataTable Type_Group_Suggestion_select(int id, int userid, string type_group)
        {
            return MoneyMaker.Type_Group_Suggestion.select(id, userid, type_group);
        }
        DataTable Type_Group_Suggestion_getall()
        {
            return MoneyMaker.Type_Group_Suggestion.getall();
        }
        public void Type_Group_Suggestion_delete(int id)
        {
            MoneyMaker.Type_Group_Suggestion.delete(id);
        }

        public void Types_add(string type, string type_group)
        {
            MoneyMaker.Types.add(type, type_group);
        }
        public void Types_add_Group(string type_group)
        {
            MoneyMaker.Types.add_Group(type_group);
        }
        public DataTable Types_gettype(int id, string type)
        {
            return MoneyMaker.Types.gettype(id, type);
        }
        public DataTable Types_getall()
        {
            return MoneyMaker.Types.getall();
        }
        public int Types_getid(string type, string type_group)
        {
            return MoneyMaker.Types.getid(type, type_group);
        }
        public string Types_gettypestring(int id)
        {
            return MoneyMaker.Types.gettypestring(id);
        }
        public void Types_delete(int id)
        {
            MoneyMaker.Types.delete(id);
        }
        public bool Types_checkduplicate(string newtype)
        {
            return MoneyMaker.Types.checkduplicate(newtype);
        }
        public bool Types_checkduplicategroups(string typegroup)
        {
            return MoneyMaker.Types.checkduplicategroups(typegroup);
        }
        public DataTable Types_get_all_groups()
        {
            return MoneyMaker.Types.get_all_groups();
        }
        public DataTable Types_get_all_types_in_group(string group)
        {
            return MoneyMaker.Types.get_all_types_in_group(group);
        }
        public string Types_get_group(string type)
        {
            return MoneyMaker.Types.get_group(type);
        }
        public string Types_gettypegroupstring(int id)
        {
            return MoneyMaker.Types.gettypegroupstring(id);
        }
        public string Types_gettypeItemstring(int id)
        {
            return MoneyMaker.Types.gettypeItemstring(id);
        }
        public DataTable Types_get_group_table(string type_group)
        {
            return MoneyMaker.Types.get_group_table(type_group);
        }
        public DataTable Types_get_specific_types(string type, string type_group)
        {
            return MoneyMaker.Types.get_specific_types(type, type_group);
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
