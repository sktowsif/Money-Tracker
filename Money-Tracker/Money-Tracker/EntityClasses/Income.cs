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
        public string Day { get; set; }
        public string Name { get; set; }
        public string MonthName { get; set; }
        public string Type { get; set; }
        public decimal Balance { get; set; }

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
            string[] strColValues = { "User_Id" };
            object[] objArrColValues = { Id };
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DataTable dtTable = objSqlConLib.SelectQuery("Select Income,Date,Expense from IncomeExpense Where User_id=@User_id", strColValues, objArrColValues);
            List<Income> lstIncome = new List<Income>();
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                Income objIncome = new Income();
                objIncome.Incomes = TypeTranslation.GetDecimal(dtTable.Rows[i]["Income"].ToString());
                objIncome.Date = (DateTime)dtTable.Rows[i]["Date"];
                objIncome.Day = dtTable.Rows[i]["Date"].ToString().Substring(0, 2);
                objIncome.Expense = TypeTranslation.GetDecimal(dtTable.Rows[i]["Expense"].ToString());
                lstIncome.Add(objIncome);
            }
            return lstIncome;
        }
        public decimal GetBalance(int intId)
        {
            string[] strArrTemp = {"User_Id"};
            object[] objArrTemp = {intId};
            SqlConLib objSqlConLibBal = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DataTable dtBalance = objSqlConLibBal.SelectQuery(@"select top (1) * from IncomeExpense where User_Id=@User_Id order by Id DESC ", strArrTemp, objArrTemp);
            List<Income> lstIncome = new List<Income>();
            if (dtBalance.Rows.Count != 0)
            {
               return this.Balance = TypeTranslation.GetDecimal(dtBalance.Rows[0]["Balance"].ToString());
            }
            else
            {
              return  this.Balance = 0;
            }
        }
        public bool InsertIncome(object[] objIncome)
        {
            string[] strArrCol = { "User_Id", "Income", "Expense", "Date", "Category_Id", "Note", "Balance" };
            this.Date = DateTime.Now;
            this.Balance = GetBalance(TypeTranslation.GetInt(objIncome[0].ToString()));
            this.Balance = this.Balance + TypeTranslation.GetDecimal(objIncome[1].ToString()) - TypeTranslation.GetDecimal(objIncome[2].ToString());
            object[] objArrColValues = { objIncome[0], objIncome[1], objIncome[2], this.Date, objIncome[3], objIncome[4], this.Balance };
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            return objSqlConLib.ExecuteQuery(@"INSERT INTO [dbo].[IncomeExpense]
                                                                   ([User_Id]
                                                                   ,[Income]
                                                                   ,[Expense]
                                                                   ,[Date]
                                                                   ,[Category_Id]
                                                                   ,[Note]
                                                                   ,[Balance])
                                                             VALUES
                                                                   (@User_id
                                                                   ,@Income
                                                                   ,@Expense
                                                                   ,@Date
                                                                   ,@Category_Id
                                                                   ,@Note
                                                                   ,@Balance)", strArrCol, objArrColValues);
        }

        public List<CalendarEvents> GetIncomeForCalendar()
        {
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            CalendarEvents objCalEvents = null;
            Income obIncome = new Income();
            List<CalendarEvents> lstCalEvents = new List<CalendarEvents>();

            string strQuery = "SELECT [Income],[Date],[Note] FROM [Income]";
            string[] strArrColNames = { };
            object[] objArrColValue = { };

            DataTable dtTemp = new DataTable();
            dtTemp = objSqlConLib.SelectQuery(strQuery, strArrColNames, objArrColValue);

            decimal decTemp;
            float flTemp;
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                objCalEvents = new CalendarEvents();

                decimal.TryParse(dtTemp.Rows[i]["Income"].ToString(), out decTemp);
                flTemp = (float)decTemp;
                string strNote = dtTemp.Rows[i]["Note"].ToString() != null ? dtTemp.Rows[i]["Note"].ToString() : string.Empty;

                objCalEvents.title = strNote + "  +" + flTemp.ToString();
                DateTime dateTemp = Convert.ToDateTime(dtTemp.Rows[i]["Date"].ToString());
                obIncome.Date = dateTemp;
                objCalEvents.start = obIncome.strDate;
                objCalEvents.backgroundColor = "#89C35C";
                objCalEvents.borderColor = "#89C35C";
                lstCalEvents.Add(objCalEvents);
            }
            return lstCalEvents;
        }
        public List<Income> GetMonthlyIncomeData(int intId, DateTime dtFDate, DateTime dtLDate)
        {
            object[] objArrColValuesExpenseWeek = { dtFDate, dtLDate, intId };
            string[] strColValuesExpenseWeek = { "dtFDate", "dtLDate", "User_Id" };
            SqlConLib objSqlConLib1 = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DataTable dtTableWeekExpense = objSqlConLib1.SelectQuery(@"Select  sum(Income) as Income,Date as Date,sum(expense) as Expense from IncomeExpense where date between @dtFDate and @dtLDate AND User_Id=@User_Id  group by date", strColValuesExpenseWeek, objArrColValuesExpenseWeek);
            List<Income> lstIncome = new List<Income>();
            for (int i = 0; i < dtTableWeekExpense.Rows.Count; i++)
            {
                Income objIncome = new Income();
                objIncome.Incomes = TypeTranslation.GetDecimal(dtTableWeekExpense.Rows[i]["Income"].ToString());
                objIncome.Date = (DateTime)dtTableWeekExpense.Rows[i]["Date"];
                objIncome.Day = dtTableWeekExpense.Rows[i]["Date"].ToString().Substring(0, 2);
                objIncome.Expense = TypeTranslation.GetDecimal(dtTableWeekExpense.Rows[i]["Expense"].ToString());
                lstIncome.Add(objIncome);
            }
            return lstIncome;
        }
        public List<Income> GetYearsData(int intId, DateTime dtFirstDate, DateTime dtLastDate)
        {
            string[] strColValues = { "dtFirstDate", "dtLastDate", "User_Id" };
            object[] objArrColValues = { dtFirstDate, dtLastDate, intId };
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DataTable dtTable = objSqlConLib.SelectQuery(@"select sum(Income) as Income,sum(Expense) as Expense ,DATENAME(month,date) as MonthName from IncomeExpense where User_Id=@User_Id AND date between
                                                            @dtFirstDate and @dtLastDate group by Datename(month,date)", strColValues, objArrColValues);
            List<Income> lstIncome = new List<Income>();
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                Income objIncome = new Income();
                objIncome.Incomes = TypeTranslation.GetDecimal(dtTable.Rows[i]["Income"].ToString());
                objIncome.Expense = TypeTranslation.GetDecimal(dtTable.Rows[i]["Expense"].ToString());
                objIncome.MonthName = dtTable.Rows[i]["MonthName"].ToString();
                lstIncome.Add(objIncome);
            }
            return lstIncome;
        }
    }
}