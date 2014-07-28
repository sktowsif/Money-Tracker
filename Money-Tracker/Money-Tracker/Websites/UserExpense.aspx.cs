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
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }


    }
}