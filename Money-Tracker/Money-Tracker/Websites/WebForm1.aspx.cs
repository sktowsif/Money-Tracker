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
      
    public partial class WebForm1 : System.Web.UI.Page
    {
        [WebMethod]
        public static List<Income> GetAllIncome()
        {
            Income objIncome = new Income();
            return objIncome.GetAllIncomeCategories("Income");
        }
        [WebMethod]
        public static List<Income> GetAllExpense()
        {
            Income objIncome = new Income();
            return objIncome.GetAllIncomeCategories("Expense");
        }
        [WebMethod]
        public static void InsertUser(object[] objIncome)
        {
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}