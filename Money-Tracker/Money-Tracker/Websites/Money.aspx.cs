using Money_Tracker.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Money_Tracker
{
    public partial class Default : System.Web.UI.Page
    {
        public string DaysCal { get; set; }
        public string WeeksCal { get; set; }
        public string MonthsCal { get; set; }
      
        protected void Page_Load(object sender, EventArgs e)
        {
            //DateTime dtDate= DateTime.Today;
            //Expenses obj = new Expenses();
            //this.DaysCal = "Months";
            //obj.GetAllWeeks(dtDate,this.DaysCal,"Balance");
            //Default.GetAllIncome();

            

        }
        
    }
}