using Money_Tracker.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Money_Tracker.Websites
{
    /// <summary>
    /// Summary description for Helper
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Helper : System.Web.Services.WebService
    {

        [WebMethod]
        public List<CalendarEvents> GetIncomeExpenseData()
        {
            List<CalendarEvents> lstCalendar = new List<CalendarEvents>(); 
            Expense objExpence = new Expense();
            Income objIncome = new Income();
            lstCalendar = objExpence.GetExpenseForCalendar();
            lstCalendar.AddRange(objIncome.GetIncomeForCalendar());
            return lstCalendar;
        }
    }
}
