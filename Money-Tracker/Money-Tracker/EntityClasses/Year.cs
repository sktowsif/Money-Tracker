using SqlConnectorLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ValueTypeCasting;

namespace Money_Tracker.EntityClasses
{
    public class Year
    {
        public int Id { get; set; }
        public int Years { get; set; }

        public List<Year> GetYears()
        {
            string[] strColValues = { };
            object[] objArrColValues = { };
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DataTable dtTable = objSqlConLib.SelectQuery(@"SELECT [Id]
                                                                  ,[Year]
                                                              FROM [dbo].[Year]", strColValues, objArrColValues);
            List<Year> lstYear = new List<Year>();
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                Year objYear = new Year();
                objYear.Years =TypeTranslation.GetInt( dtTable.Rows[i]["Year"].ToString());
                objYear.Id = TypeTranslation.GetInt(dtTable.Rows[i]["Id"].ToString());
                lstYear.Add(objYear);
            }
            return lstYear;
        }
       
    }
}