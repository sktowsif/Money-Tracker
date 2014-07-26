using SqlConnectorLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ValueTypeCasting;

namespace Money_Tracker.EntityClasses
{
    public class Weeks
    {
        public int Id { get; set; }
        public string Week { get; set; }

        public List<Weeks> GetWeeks()
        {
            string[] strColValues = { };
            object[] objArrColValues = { };
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DataTable dtTable = objSqlConLib.SelectQuery(@"SELECT [Id]
                                                                  ,[Week]
                                                              FROM [dbo].[Weeks]", strColValues, objArrColValues);
            List<Weeks> lstWeek = new List<Weeks>();
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                Weeks objWeeks = new Weeks();
                objWeeks.Week = dtTable.Rows[i]["Week"].ToString();
                objWeeks.Id = TypeTranslation.GetInt(dtTable.Rows[i]["Id"].ToString());
                lstWeek.Add(objWeeks);
            }
            return lstWeek;
        }
    }
}