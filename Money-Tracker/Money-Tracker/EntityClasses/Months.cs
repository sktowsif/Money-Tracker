using SqlConnectorLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ValueTypeCasting;

namespace Money_Tracker.EntityClasses
{
    public class Months
    {
        public  int Id { get; set; }
        public string MonthName { get; set; }

        public List<Months> GetMonths()
        {
            string[] strColValues = { };
            object[] objArrColValues = {  };
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DataTable dtTable = objSqlConLib.SelectQuery(@"SELECT [MonthName]
                                                                  ,[Id]
                                                              FROM [Months]", strColValues, objArrColValues);
            List<Months> lstMonth = new List<Months>();
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                Months objMonths = new Months();
                objMonths.MonthName = dtTable.Rows[i]["MonthName"].ToString();
                objMonths.Id = TypeTranslation.GetInt(dtTable.Rows[i]["id"].ToString());
                lstMonth.Add(objMonths);
            }
            return lstMonth;
        }
    }
}