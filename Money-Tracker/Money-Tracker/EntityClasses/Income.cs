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
        public string Date { get; set; }
        public int Category_Id { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
             
        string[] strArrColumn = Properties.Settings.Default.Income_Cols.Split('|');

        public bool Insert()
        {
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DateTime Today = DateTime.Today;
            Date = Today.ToString("yyyy-MM-dd");
            
            string strQuery = Properties.Settings.Default.Income_INSERT;
            string[] strArrColNames = new string[] { strArrColumn[0], strArrColumn[1], strArrColumn[2], strArrColumn[3] };
            object[] objArrColValue = new object[] { this.User_Id, this.Expense, Date, this.Category_Id };

            return objSqlConLib.ExecuteQuery(strQuery, strArrColNames, objArrColValue);
        }
        public List<Income> GetAllIncomeCategories(string strType)
        {
            this.Type = strType;
            string[] strColValues = { "Type"};
            object[] objArrColValues = { this.Type};
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DataTable dtTable = objSqlConLib.SelectQuery("Select Id,Name from Category where Type=@Type", strColValues, objArrColValues);
            List<Income> lstIncome = new List<Income>();
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                Income objIncome = new Income();
                objIncome.Id =TypeTranslation.GetInt( dtTable.Rows[i]["Id"].ToString());
                objIncome.Name = dtTable.Rows[i]["Name"].ToString();
                lstIncome.Add(objIncome);
            }
            return lstIncome;
        }
    }
}