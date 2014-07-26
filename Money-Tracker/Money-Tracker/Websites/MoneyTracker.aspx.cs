using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Money_Tracker.EntityClasses;
namespace Money_Tracker.Websites
{
    public partial class MoneyTracker : System.Web.UI.Page
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
        public static void InsertIncome(object[] objIncome)
        {
            Income objectIncome = new Income();
            objectIncome.InsertIncome(objIncome);
        }

        [WebMethod]
        public static void InsertExpense(object[] objExpense)
        {
            Expense objectExpense = new Expense();
            objectExpense.InsertExpense(objExpense);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
    }
}