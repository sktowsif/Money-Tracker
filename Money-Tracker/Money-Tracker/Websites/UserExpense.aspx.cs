using Money_Tracker.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Money_Tracker.Websites
{
    public partial class UserExpense : System.Web.UI.Page
    {
        public string DaysCal { get; set; }
        public string WeeksCal { get; set; }
        public string MonthsCal { get; set; }
        [WebMethod]
        public static List<Income> GetIncome()
        {
            DateTime dtDate= DateTime.Today;
            Income objInc = new Income();
            return objInc.GetAllIncome();
        }
        [WebMethod]
        public static List<Expense> GetExpense()
        {
            DateTime dtDate = DateTime.Today;
            Expense objExp = new Expense();
            return objExp.GetExpense();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }


    }
}