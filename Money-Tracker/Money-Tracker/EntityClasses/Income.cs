using SqlConnectorLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ValueTypeCasting;

namespace Money_Tracker.EntityClasses
{
    public class Income
    {
        public int User_Id { get; set; }
        public decimal Expense { get; set; }
        public DateTime Date { get; set; }
        public string strDate { get { return this.Date.ToString("yyyy-MM-dd"); } }
        public int Category_Id { get; set; }
        public decimal Incomes { get; set; }
        public string Note { get; set; }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        string[] strArrColumn = Properties.Settings.Default.Income_Cols.Split('|');

        public bool Insert()
        {
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DateTime Today = DateTime.Today;
            

            string strQuery = Properties.Settings.Default.Income_INSERT;
            string[] strArrColNames = new string[] { strArrColumn[0], strArrColumn[1], strArrColumn[2], strArrColumn[3] };
            object[] objArrColValue = new object[] { this.User_Id, this.Expense, Today, this.Category_Id };

            return objSqlConLib.ExecuteQuery(strQuery, strArrColNames, objArrColValue);
        }
        public List<Income> GetAllIncomeCategories(string strType)
        {
            this.Type = strType;
            string[] strColValues = { "Type" };
            object[] objArrColValues = { this.Type };
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DataTable dtTable = objSqlConLib.SelectQuery("Select Id,Name from Category where Type=@Type", strColValues, objArrColValues);
            List<Income> lstIncome = new List<Income>();
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                Income objIncome = new Income();
                objIncome.Id = TypeTranslation.GetInt(dtTable.Rows[i]["Id"].ToString());
                objIncome.Name = dtTable.Rows[i]["Name"].ToString();
                lstIncome.Add(objIncome);
            }
            return lstIncome;
        }

        public List<Income> GetAllIncome(int Id)
        {
            string[] strColValues = {  "User_Id"};
            object[] objArrColValues = {Id};
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DataTable dtTable = objSqlConLib.SelectQuery("Select Income,Date,Expense from IncomeExpense Where User_id=@User_id", strColValues, objArrColValues);
            List<Income> lstIncome = new List<Income>();
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                Income objIncome = new Income();
                objIncome.Incomes = TypeTranslation.GetDecimal(dtTable.Rows[i]["Income"].ToString());
                objIncome.Date = (DateTime)dtTable.Rows[i]["Date"];
                objIncome.Expense = TypeTranslation.GetDecimal(dtTable.Rows[i]["Expense"].ToString());
                lstIncome.Add(objIncome);
            }
            return lstIncome;
        }
        public bool InsertIncome(object[] objIncome)
        {
            string[] strArrCol = { "User_Id","Income","Expense","Date","Category_Id","Note" };
            this.Date = DateTime.Now;
            object[] objArrColValues = { objIncome[0], objIncome[1],objIncome[2], this.Date, objIncome[3],objIncome[4]};
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
                                                                   ,@Income
                                                                   ,@Expense
                                                                   ,@Date
                                                                   ,@Category_Id
                                                                   ,@Note)", strArrCol, objArrColValues);
        }
        public List<Income> GetMonthlyIncomeData(int intId,DateTime dtFDate,DateTime dtLDate)
        {
            object[] objArrColValuesExpenseWeek = { dtFDate, dtLDate };
            string[] strColValuesExpenseWeek = { "dtFDate", "dtLDate" };
            SqlConLib objSqlConLib1 = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DataTable dtTableWeekExpense = objSqlConLib1.SelectQuery(@"Select  Income,Date, expense from IncomeExpense where date between @dtFDate and @dtLDate", strColValuesExpenseWeek, objArrColValuesExpenseWeek);
            List<Income> lstIncome = new List<Income>();
            for (int i = 0; i < dtTableWeekExpense.Rows.Count; i++)
            {
                Income objIncome = new Income();
                objIncome.Incomes = TypeTranslation.GetDecimal(dtTableWeekExpense.Rows[i]["Income"].ToString());
                objIncome.Date = (DateTime)dtTableWeekExpense.Rows[i]["Date"];
                objIncome.Expense = TypeTranslation.GetDecimal(dtTableWeekExpense.Rows[i]["Expense"].ToString());
                lstIncome.Add(objIncome);
            }
            return lstIncome;
        }
    }
}