using SqlConnectorLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Money_Tracker.EntityClasses
{
    public class Expenses
    {
        public int User_id{get;set;}
        public decimal Expence{get;set;}
        public decimal Balance { get; set; }
        public decimal Income { get; set; }
        public DateTime Date { get; set; }

        public int Category_Id{get;set;}

        public  void GetAll(DateTime dtPresentDate)
        {
            DateTime dtDate;
            //string[] strColValuesWorkers = Properties.Settings.Default.TierCols.Split('|');
            //object[] objArrColValuesWorkers = { this.TierId, this.Tier, this.TierMultiplier};
            string[] strColValuesExpense = {};
            object[] objArrColValuesExpense = { };
            SqlConLib objSqlConLibMaxDate = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DataTable dtTableMaxDate = objSqlConLibMaxDate.SelectQuery(@"select  Max(date) from Balance", strColValuesExpense, objArrColValuesExpense);
            if (dtTableMaxDate.Rows.Count!=1)
            {
                dtDate = (DateTime)dtTableMaxDate.Rows[0][0];
            }
            else
            {
                SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
                DataTable dtTable = objSqlConLib.SelectQuery(@"select top 1 date from Expense", strColValuesExpense, objArrColValuesExpense);
                dtDate = (DateTime)dtTable.Rows[0]["date"];
            }
            DateTime dtAddDate=dtDate.AddDays(7);
            while (dtAddDate <= dtPresentDate)
            {
                
                object[] objArrColValuesExpenseWeek = { dtDate,dtAddDate};
                string[] strColValuesExpenseWeek = { "ad", "dtdate" };
                SqlConLib objSqlConLib1 = new SqlConLib(Properties.Settings.Default.ConnectionString);
                DataTable dtTableWeekExpense = objSqlConLib1.SelectQuery(@"Select sum(Expence) from expense where date between @ad and @dtdate", strColValuesExpenseWeek, objArrColValuesExpenseWeek);
                this.Expence =TypeTranslation.GetDecimal(dtTableWeekExpense.Rows[0][0].ToString());
                SqlConLib objSqlConLibExpense = new SqlConLib(Properties.Settings.Default.ConnectionString);
                DataTable dtTableWeekIncome = objSqlConLibExpense.SelectQuery(@"Select sum(Income) from Income where date between @ad and @dtdate", strColValuesExpenseWeek, objArrColValuesExpenseWeek);
                this.Income = TypeTranslation.GetDecimal(dtTableWeekIncome.Rows[0][0].ToString());
                SqlConLib objSqlConLibIncome = new SqlConLib(Properties.Settings.Default.ConnectionString);
                this.Date = dtAddDate;
                this.Balance = this.Income - this.Expence;
                this.User_id = 1;
                string[] strColValues = {"User_id","Date","Expense","Income","Balance"};
                object[] objArrColValues = {this.User_id,this.Date,this.Expence,this.Income,this.Balance};
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
                dtAddDate = dtDate.AddDays(7);
                
            }
            //DataTable dtTable = objSqlConLib.SelectQuery(@"Select sum(Expence) from expense where date between"+, strColValuesTier, objArrColValuesTier);
            //List<Expenses> lstTiers = new List<Expenses>();
            //for (int i = 0; i < dtTable.Rows.Count; i++)
            //{
            //    Expenses objTiers = new Expenses();
            //    objTiers.User_id =int.Parse( dtTable.Rows[i]["User_id"].ToString());
            //    objTiers.Expence =decimal.Parse(dtTable.Rows[i]["Expence"].ToString());
            //    objTiers.Date = dtTable.Rows[i]["Date"].ToString();
            //    objTiers.Category_Id = int.Parse(dtTable.Rows[i]["Category_id"].ToString());
            //    lstTiers.Add(objTiers);
            //}
        }
    }
}