using Money_Tracker.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValueTypeCasting;

namespace Money_Tracker.Websites
{
    public partial class UserExpense : System.Web.UI.Page
    {
        public string DaysCal { get; set; }
        public string WeeksCal { get; set; }
        public string MonthsCal { get; set; }
        [WebMethod]
        public static List<Income> GetIncome(object Id)
        {

            DateTime dtDate = DateTime.Today;
            Income objInc = new Income();
            return objInc.GetAllIncome(TypeTranslation.GetInt(Id.ToString()));
        }
        [WebMethod]
        public static List<Expense> GetExpense(object Id)
        {
            DateTime dtDate = DateTime.Today;
            Expense objExp = new Expense();
            return objExp.GetExpense(TypeTranslation.GetInt(Id.ToString()));
        }


        //public static List<Expenses> GetExpense(object Id)
        //{
        //    DateTime dtDate = DateTime.Today;
        //    Expenses objExp = new Expenses();
        //    objExp.GetAllWeeks(dtDate, "Weeks", "BalanceWeekly");
        //}
        public static void FirstAndLastDayOfMonth(DateTime date, out DateTime first, out DateTime last)
        {
            first = new DateTime(date.Year, date.Month, 1);
            DateTime nextFirst;
            if (first.Month == 12) nextFirst = new DateTime(first.Year + 1, 1, 1);
            else nextFirst = new DateTime(first.Year, first.Month + 1, 1);
            last = nextFirst.AddDays(-1);
        }
        [WebMethod]
        public static List<Income> GetSelectedMonth(int intId,int intYear, int intMonth)
        {
            string strDate = "01" +"-"+ intMonth +"-"+ intYear;
            DateTime dtDate = Convert.ToDateTime(strDate);
            DateTime dtFirst;
            DateTime dtLast;
            FirstAndLastDayOfMonth(dtDate,out dtFirst,out dtLast);
            Income objIncome = new Income();
            return objIncome.GetMonthlyIncomeData(intId, dtFirst, dtLast);
        }
        [WebMethod]
        public static List<Months> GetMonths()
        {
            Months objMonths = new Months();
            return objMonths.GetMonths();

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }


    }
}