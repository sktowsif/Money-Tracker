using SqlConnectorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Money_Tracker.EntityClasses
{
    public class Expense
    {
        public int User_Id { get; set; }
        public decimal Expense { get; set; }
        public string Date { get; set; }
        public int Category_Id { get; set; }

        string[] strArrColumn = Properties.Settings.Default.Expense_Cols.Split('|');
        

        public bool Insert()
        {
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DateTime Today = DateTime.Today;
            Date = Today.ToString("yyyy-mm-dd");

            string strQuery = Properties.Settings.Default.Expense_INSERT;
            string[] strArrColNames = new string[] { strArrColumn[0], strArrColumn[1], strArrColumn[2], strArrColumn[3] };
            object[] objArrColValue = new object[] { this.User_Id, this.Expense, Date, this.Category_Id };

            return objSqlConLib.ExecuteQuery(strQuery, strArrColNames, objArrColValue);
        }
    }
}