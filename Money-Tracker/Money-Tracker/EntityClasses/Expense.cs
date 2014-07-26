using SqlConnectorLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Money_Tracker.EntityClasses
{
    public class Expense
    {
        public int User_Id { get; set; }
        public decimal Expenses { get; set; }
        public DateTime Date { get; set; }
        public string strDate { get { return this.Date.ToString("yyyy-MM-dd"); } }
        public string Note { get; set; }
        public string DateString
        {
            get
            {
                return this.Date.ToString("yyyy-MM-dd");
            }
        }
        public int Category_Id { get; set; }

        string[] strArrColumn = Properties.Settings.Default.Expense_Cols.Split('|');


        public bool Insert()
        {
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            Date = DateTime.Today;

            string strQuery = Properties.Settings.Default.Expense_INSERT;
            string[] strArrColNames = new string[] { strArrColumn[0], strArrColumn[1], strArrColumn[2], strArrColumn[3] };
            object[] objArrColValue = new object[] { this.User_Id, this.Expenses, Date, this.Category_Id };

            return objSqlConLib.ExecuteQuery(strQuery, strArrColNames, objArrColValue);
        }

        public List<Expense> GetExpense(int Id)
        {
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            Expense objExpense = null;
            List<Expense> lstExpense = new List<Expense>();

            string strQuery = "SELECT [Expence],[Date],[Note] FROM [Expense]";
            string[] strArrColNames = { };
            object[] objArrColValue = { };

            DataTable dtTemp = new DataTable();
            dtTemp = objSqlConLib.SelectQuery(strQuery, strArrColNames, objArrColValue);

            decimal decTemp;
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                objExpense = new Expense();
                decimal.TryParse(dtTemp.Rows[i]["Expence"].ToString(), out decTemp);
                objExpense.Expenses = decTemp;
                objExpense.Note = dtTemp.Rows[i]["Note"].ToString() != null ? dtTemp.Rows[i]["Note"].ToString() : string.Empty;
                DateTime dateTemp = Convert.ToDateTime(dtTemp.Rows[i]["Date"].ToString());
                objExpense.Date = dateTemp;
                lstExpense.Add(objExpense);
            }
            return lstExpense;
        }

        public bool InsertExpense(object[] objExpense)
        {
            string[] strArrCol = { "User_Id", "Income","Expense", "Date", "Category_Id", "Note" };
            this.Date = DateTime.Now;
            object[] objArrColValues = { objExpense[0], objExpense[1], this.Date, objExpense[2], objExpense[3] };
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            return objSqlConLib.ExecuteQuery(@"INSERT INTO [dbo].[IncomeExpense]
                                                                   ([User_Id]
                                                                   ,[Income]
                                                                   ,[Expense]
                                                                   ,[Date]
                                                                   ,[Category_Id]
                                                                   ,[Note])
                                                             VALUES
                                                                   (@User_id
                                                                   ,@Expence
                                                                   ,@Date
                                                                   ,@Category_Id
                                                                   ,@Note)", strArrCol, objArrColValues);
        }

        public List<CalendarEvents> GetExpenseForCalendar()
        {
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            CalendarEvents objCalEvents = null;
            Expense objExpense = new Expense();
            List<CalendarEvents> lstCalEvents = new List<CalendarEvents>();

            string strQuery = "SELECT [Expence],[Date],[Note] FROM [Expense]";
            string[] strArrColNames = { };
            object[] objArrColValue = { };

            DataTable dtTemp = new DataTable();
            dtTemp = objSqlConLib.SelectQuery(strQuery, strArrColNames, objArrColValue);

            decimal decTemp;
            float flTemp;
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                objCalEvents = new CalendarEvents();

                decimal.TryParse(dtTemp.Rows[i]["Expence"].ToString(), out decTemp);
                flTemp = (float)decTemp;
                string strNote = dtTemp.Rows[i]["Note"].ToString() != null ? dtTemp.Rows[i]["Note"].ToString() : string.Empty;

                objCalEvents.title = strNote + "  -" + flTemp.ToString();
                DateTime dateTemp = Convert.ToDateTime(dtTemp.Rows[i]["Date"].ToString());
                objExpense.Date = dateTemp;
                objCalEvents.start = objExpense.strDate;
                objCalEvents.backgroundColor = "#F62817";
                objCalEvents.borderColor = "#F62817";
                lstCalEvents.Add(objCalEvents);
            }
            return lstCalEvents;
        }
    }
}