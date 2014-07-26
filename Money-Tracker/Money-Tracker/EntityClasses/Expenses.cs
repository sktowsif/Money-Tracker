using SqlConnectorLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ValueTypeCasting;

namespace Money_Tracker.EntityClasses
{
    public class Expenses
    {
        public int User_id { get; set; }
        public decimal Expence { get; set; }
        public decimal Balance { get; set; }
        public decimal Income { get; set; }
        public DateTime Date { get; set; }

        public int Category_Id { get; set; }

        public DateTime GetTimeSpan(DateTime dtDate,string strTimeSpan)
        {
            if (strTimeSpan == "Days")
                return dtDate.AddDays(1);
            else if (strTimeSpan == "Weeks")
                return dtDate.AddDays(7);
            else
                return dtDate.AddMonths(1);
        }
        public void GetAllWeeks(int intId,DateTime dtPresentDate, string strTimeSpan,string strTableName)
        {
            DateTime dtDate;
            string[] strColValuesExpense = { };
            object[] objArrColValuesExpense = { };
            SqlConLib objSqlConLibMaxDate = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DataTable dtTableMaxDate = objSqlConLibMaxDate.SelectQuery(@"select date,Balance from Balance where date = (select max(date) AND User_Id=@UserId from "+strTableName+") ", strColValuesExpense, objArrColValuesExpense);
            if (dtTableMaxDate.Rows.Count != 0)
            {
                dtDate = (DateTime)dtTableMaxDate.Rows[0][0];
                this.Balance = TypeTranslation.GetDecimal(dtTableMaxDate.Rows[0][1].ToString());
            }
            else
            {
                SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
                DataTable dtTable = objSqlConLib.SelectQuery(@"select top 1 date from Income", strColValuesExpense, objArrColValuesExpense);
                dtDate = (DateTime)dtTable.Rows[0]["date"];
            }
            DateTime dtAddDate=GetTimeSpan(dtDate,strTimeSpan);
            
            while (dtAddDate <= dtPresentDate)
            {

                object[] objArrColValuesExpenseWeek = { dtDate, dtAddDate };
                string[] strColValuesExpenseWeek = { "ad", "dtdate" };
                SqlConLib objSqlConLib1 = new SqlConLib(Properties.Settings.Default.ConnectionString);
                DataTable dtTableWeekExpense = objSqlConLib1.SelectQuery(@"Select sum(Expence) from expense where date between @ad and @dtdate", strColValuesExpenseWeek, objArrColValuesExpenseWeek);
                this.Expence = TypeTranslation.GetDecimal(dtTableWeekExpense.Rows[0][0].ToString());
                SqlConLib objSqlConLibExpense = new SqlConLib(Properties.Settings.Default.ConnectionString);
                DataTable dtTableWeekIncome = objSqlConLibExpense.SelectQuery(@"Select sum(Income) from Income where date between @ad and @dtdate", strColValuesExpenseWeek, objArrColValuesExpenseWeek);
                this.Income = TypeTranslation.GetDecimal(dtTableWeekIncome.Rows[0][0].ToString());
                SqlConLib objSqlConLibIncome = new SqlConLib(Properties.Settings.Default.ConnectionString);
                this.Date = dtAddDate;
                //if(this.Income>this.Expence)
                this.Balance = this.Balance + this.Income - this.Expence;
                this.User_id = 1;
                string[] strColValues = { "User_id", "Date", "Expense", "Income", "Balance" };
                object[] objArrColValues = { this.User_id, this.Date, this.Expence, this.Income, this.Balance };
                bool blnResult = objSqlConLibIncome.ExecuteQuery(@"INSERT INTO [dbo].[Balance]
                                                                                           (
                                                                                            [User_id]
                                                                                           ,[Date]
                                                                                           ,[Expense]
                                                                                           ,[Income]
                                                                                           ,[Balance])
                                                                                     VALUES
                                                                                            (
                                                                                             @User_id       
                                                                                            ,@Date
                                                                                           ,@Expense
                                                                                           ,@Income
                                                                                           ,@Balance)", strColValues, objArrColValues);
                dtDate = dtAddDate;
                dtAddDate = GetTimeSpan(dtDate, strTimeSpan);

            }
        }
//        public void GetAllMonths(DateTime dtPresentDate)
//        {
//            DateTime dtDate;
//            string[] strColValuesExpense = { };
//            object[] objArrColValuesExpense = { };
//            SqlConLib objSqlConLibMaxDate = new SqlConLib(Properties.Settings.Default.ConnectionString);
//            DataTable dtTableMaxDate = objSqlConLibMaxDate.SelectQuery(@"select date,Balance from Balance where date=(select max(date) from balance) ", strColValuesExpense, objArrColValuesExpense);
//            if (dtTableMaxDate.Rows.Count != 0)
//            {
//                dtDate = (DateTime)dtTableMaxDate.Rows[0][0];
//                this.Balance = TypeTranslation.GetDecimal(dtTableMaxDate.Rows[0][1].ToString());
//            }
//            else
//            {
//                SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
//                DataTable dtTable = objSqlConLib.SelectQuery(@"select top 1 date from Income", strColValuesExpense, objArrColValuesExpense);
//                dtDate = (DateTime)dtTable.Rows[0]["date"];
//            }
//            DateTime dtAddDate = dtDate.AddMonths(1);
//            while (dtAddDate <= dtPresentDate)
//            {

//                object[] objArrColValuesExpenseWeek = { dtDate, dtAddDate };
//                string[] strColValuesExpenseWeek = { "ad", "dtdate" };
//                SqlConLib objSqlConLib1 = new SqlConLib(Properties.Settings.Default.ConnectionString);
//                DataTable dtTableWeekExpense = objSqlConLib1.SelectQuery(@"Select sum(Expence) from expense where date between @ad and @dtdate", strColValuesExpenseWeek, objArrColValuesExpenseWeek);
//                this.Expence = TypeTranslation.GetDecimal(dtTableWeekExpense.Rows[0][0].ToString());
//                SqlConLib objSqlConLibExpense = new SqlConLib(Properties.Settings.Default.ConnectionString);
//                DataTable dtTableWeekIncome = objSqlConLibExpense.SelectQuery(@"Select sum(Income) from Income where date between @ad and @dtdate", strColValuesExpenseWeek, objArrColValuesExpenseWeek);
//                this.Income = TypeTranslation.GetDecimal(dtTableWeekIncome.Rows[0][0].ToString());
//                SqlConLib objSqlConLibIncome = new SqlConLib(Properties.Settings.Default.ConnectionString);
//                this.Date = dtAddDate;
//                //if(this.Income>this.Expence)
//                this.Balance = this.Balance + this.Income - this.Expence;
//                this.User_id = 1;
//                string[] strColValues = { "User_id", "Date", "Expense", "Income", "Balance" };
//                object[] objArrColValues = { this.User_id, this.Date, this.Expence, this.Income, this.Balance };
//                bool blnResult = objSqlConLibIncome.ExecuteQuery(@"INSERT INTO [dbo].[Balance]
//                                                                                           (
//                                                                                            [User_id]
//                                                                                           ,[Date]
//                                                                                           ,[Expense]
//                                                                                           ,[Income]
//                                                                                           ,[Balance])
//                                                                                     VALUES
//                                                                                            (
//                                                                                             @User_id       
//                                                                                            ,@Date
//                                                                                           ,@Expense
//                                                                                           ,@Income
//                                                                                           ,@Balance)", strColValues, objArrColValues);
//                dtDate = dtAddDate;
//                dtAddDate = dtDate.AddMonths(1);
//            }
//        }
    }
}