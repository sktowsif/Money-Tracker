using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Money_Tracker.EntityClasses
{
    public class RemainingBalance
    {
        public int User_Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Expense { get; set; }
        public decimal Income { get; set; }
        public decimal Balance { get; set; }


    }
}