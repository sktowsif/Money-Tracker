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

        public List<Income> GetAllIncome()
        {
            string[] strColValues = {  };
            object[] objArrColValues = {  };
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DataTable dtTable = objSqlConLib.SelectQuery("Select Income,Date from Income ", strColValues, objArrColValues);
            List<Income> lstIncome = new List<Income>();
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                Income objIncome = new Income();
                objIncome.Incomes = TypeTranslation.GetDecimal(dtTable.Rows[i]["Income"].ToString());
                objIncome.Date = (DateTime)dtTable.Rows[i]["Date"];
                lstIncome.Add(objIncome);
            }
            return lstIncome;
        }
        public bool InsertIncome(object[] objIncome)
        {
            string[] strArrCol = { "User_Id","Income","Date","Category_Id","Note" };
            this.Date = DateTime.Now;
            object[] objArrColValues = { objIncome[0], objIncome[1], this.Date, objIncome[2],objIncome[3]};
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            return objSqlConLib.ExecuteQuery(@"INSERT INTO [dbo].[Income]
                                                                   ([User_Id]
                                                                   ,[Income]
                                                                   ,[Date]
                                                                   ,[Category_Id]
                                                                   ,[Note])
                                                             VALUES
                                                                   (@User_id
                                                                   ,@Income
                                                                   ,@Date
                                                                   ,@Category_Id
                                                                   ,@Note)", strArrCol, objArrColValues);
        }
    }
}