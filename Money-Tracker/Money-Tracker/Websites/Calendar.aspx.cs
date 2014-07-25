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
    public partial class Calendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Expense> GetExpense()
        {
            Expense objExpense = new Expense();
            List<Expense> lstExpense=objExpense.GetExpense();
            return lstExpense;
            
        }
    }
}