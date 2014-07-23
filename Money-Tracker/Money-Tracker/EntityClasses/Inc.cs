using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Money_Tracker.EntityClasses
{
    public class Inc
    {
        public int User_id { get; set; }
        public decimal Income { get; set; }

        public string Date { get; set; }

        public int Category_Id { get; set; }
    }
}