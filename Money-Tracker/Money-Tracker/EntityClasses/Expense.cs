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

        public List<Expense> GetExpense()
        {
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            Expense objExpense = null;
            List<Expense> lstExpense = new List<Expense>();

            string strQuery = "SELECT [Expence],[Date] FROM [Expense]";
            string[] strArrColNames = {};
            object[] objArrColValue = {};

            DataTable dtTemp = new DataTable();
            dtTemp = objSqlConLib.SelectQuery(strQuery, strArrColNames, objArrColValue);

            decimal decTemp;
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                objExpense = new Expense();
                decimal.TryParse(dtTemp.Rows[i]["Expence"].ToString(), out decTemp);
                objExpense.Expenses = decTemp;
                DateTime dateTemp = Convert.ToDateTime(dtTemp.Rows[i]["Date"].ToString());
                objExpense.Date = dateTemp;
                lstExpense.Add(objExpense);
            }
            return lstExpense;
        }

        public bool InsertExpense(object[] objExpense)
        {
            string[] strArrCol = { "User_Id", "Expence", "Date", "Category_Id", "Note" };
            this.Date = DateTime.Now;
            object[] objArrColValues = { objExpense[0], objExpense[1], this.Date, objExpense[2], objExpense[3] };
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            return objSqlConLib.ExecuteQuery(@"INSERT INTO [dbo].[Expense]
                                                                   ([User_Id]
                                                                   ,[Expence]
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
    }
}