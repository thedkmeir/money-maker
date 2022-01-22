using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace ServerData
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);
        [OperationContract]
        void Income_History_add(int userid, string description, int income, string date, int type, string comment, int ID, string typegroup, string typestring);
        [OperationContract]
        DataTable Income_History_selectsingle(int id);
        [OperationContract]
        DataTable Income_History_selectspecific(int userid, string des, int income, string date1, string date2, int type, string comment, int ID, string typegroup, string typestring);
        [OperationContract]
        DataTable Income_History_selectbyuser(int userid);
        [OperationContract]
        void Income_History_update(int id, string description, int income, string date, int type, string comment, string typegroup, string typestring);
        [OperationContract]
        void Income_History_delete(int id);
        [OperationContract]
        DataTable Income_History_getall(int id);
        [OperationContract]
        int Income_History_get_money(int userid, string date1, string date2);
        [OperationContract]
        int Income_History_get_monthly_money(int userid, string date1, string date2);
        [OperationContract]
        DataTable Income_History_get_monthly_history(int userid, int monthlyid, string date);
        [OperationContract]
        void Income_History_clean_user_data(int id);

        [OperationContract]
        void Monthly_Expenses_add(int userid, int averaged_price, string product, int num_payments, int total_payed, int product_type, string date, int Payments, string typegroup, string typestring);
        [OperationContract]
        void Monthly_Expenses_delete(int id);
        [OperationContract]
        void Monthly_Expenses_change(int id, int averaged_price, string product, int num_payments, int total_payed, int product_type, string dateou, int payments, string typegroup, string typestring);
        [OperationContract]
        DataTable Monthly_Expenses_getsingle(int id);
        [OperationContract]
        DataTable Monthly_Expenses_getall(int id);
        [OperationContract]
        void Monthly_Expenses_repeat(int id, string date, int addprice, bool ispayment);
        [OperationContract]
        DataTable Monthly_Expenses_Getmoutcome(int userid, string product, int money, int type, string date1, string date2, int payments, string typegroup, string typestring);
        [OperationContract]
        void Monthly_Expenses_clean_user_data(int id);
        [OperationContract]
        DataTable Monthly_Expenses_get_to_add_price(int userid, string date1, string date2);
        [OperationContract]
        int Monthly_Expenses_getaverage(int userid);

        [OperationContract]
        void Monthly_Income_Add(int cpm, string des, int userid, int totalpayed, int numofpay, string date, int type, string typegroup, string typestring);
        [OperationContract]
        DataTable Monthly_Income_getall(int userid);
        [OperationContract]
        DataTable Monthly_Income_getspecific(int id);
        [OperationContract]
        void Monthly_Income_Repeat(int ID, string date, int addprice);
        [OperationContract]
        DataTable Monthly_Income_Getmincome(int userid, string des, int cpm, string date1, string date2, int type, string typegroup, string typestring);
        [OperationContract]
        void Monthly_Income_change(int monthlyid, int cashpermonth, string description, int totalpay, int numofpay, string dateou, int type, string typegroup, string typestring);
        [OperationContract]
        void Monthly_Income_delete(int monthlyid);
        [OperationContract]
        void Monthly_Income_clean_user_data(int id);
        [OperationContract]
        DataTable Monthly_Income_get_to_add_price(int userid, string date1, string date2);
        [OperationContract]
        int Monthly_Income_getaverage(int userid);

        [OperationContract]
        void Outcome_History_AddProduct(int userid, int typeid, int price, string product, string comment, string date, int ID, string typegroup, string typestring);
        [OperationContract]
        DataTable Outcome_History_selectbyuser(int userid);
        [OperationContract]
        DataTable Outcome_History_selectbypro(int id);
        [OperationContract]
        DataTable Outcome_History_Getproducts(int userid, int typeid, int price, string product, string comment, string date1, string date2, int ID, string typegroup, string typestring);
        [OperationContract]
        void Outcome_History_SetProduct(int proid, int typeid, int price, string product, string comment, string date, string typegroup, string typestring);
        [OperationContract]
        void Outcome_History_delete(int id);
        [OperationContract]
        int Outcome_History_get_money(int userid, string date1, string date2);
        [OperationContract]
        int Outcome_History_get_monthly_money(int userid, string date1, string date2);
        [OperationContract]
        DataTable Outcome_History_get_monthly_history(int userid, int monthlyid, string date);
        [OperationContract]
        void Outcome_History_clean_user_data(int id);

        [OperationContract]
        void Type_Group_Suggestion_add(int userid, string type_group, string comment);
        [OperationContract]
        DataTable Type_Group_Suggestion_select(int id, int userid, string type_group);
        [OperationContract]
        DataTable Type_Group_Suggestion_getall();
        [OperationContract]
        void Type_Group_Suggestion_delete(int id);

        [OperationContract]
        void Types_add(string type, string type_group);
        [OperationContract]
        void Types_add_Group(string type_group);
        [OperationContract]
        DataTable Types_gettype(int id, string type);
        [OperationContract]
        DataTable Types_getall();
        [OperationContract]
        int Types_getid(string type, string type_group);
        [OperationContract]
        string Types_gettypestring(int id);
        [OperationContract]
        void Types_delete(int id);
        [OperationContract]
        bool Types_checkduplicate(string newtype);
        [OperationContract]
        bool Types_checkduplicategroups(string typegroup);
        [OperationContract]
        DataTable Types_get_all_groups();
        [OperationContract]
        DataTable Types_get_all_types_in_group(string group);
        [OperationContract]
        string Types_get_group(string type);
        [OperationContract]
        string Types_gettypegroupstring(int id);
        [OperationContract]
        string Types_gettypeItemstring(int id);
        [OperationContract]
        DataTable Types_get_group_table(string type_group);
        [OperationContract]
        DataTable Types_get_specific_types(string type, string type_group);
        [OperationContract]

        [OperationContract]

        [OperationContract]


        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
