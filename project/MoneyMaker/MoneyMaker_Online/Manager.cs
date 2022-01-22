using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyMaker_Online
{
    public class Manager
    {
        public static int lastdayinmonth(int month)
        {
            switch (month)
            {
                case 1:
                    return 31;

                case 2:
                    return 28;

                case 3:
                    return 31;

                case 4:
                    return 30;

                case 5:
                    return 31;

                case 6:
                    return 30;

                case 7:
                    return 31;

                case 8:
                    return 31;

                case 9:
                    return 30;

                case 10:
                    return 31;

                case 11:
                    return 30;

                case 12:
                    return 31;

                default:
                    return 0;
            }
        }
        public static int get_months_registered(string date)
        {
            DateTime date1 = Convert.ToDateTime(date);
            int months_registered = DateTime.Now.Month - date1.Month + ((DateTime.Now.Year - date1.Year) * 12);
            return months_registered;
        }

        public static string get_string_month(int month)
        {

            switch (month)
            {
                case 1:
                    return "Jauary";

                case 2:
                    return "February";

                case 3:
                    return "March";

                case 4:
                    return "April";

                case 5:
                    return "May";

                case 6:
                    return "June";

                case 7:
                    return "July";

                case 8:
                    return "August";

                case 9:
                    return "September";

                case 10:
                    return "October";

                case 11:
                    return "November";

                case 12:
                    return "December";

                default:
                    return "";
            }
        }

        public static string day_to_string(int day)
        {
            if (day < 10)
            {
                return "0" + day;
            }
            else
            {
                return day.ToString();
            }
        }
    }
}