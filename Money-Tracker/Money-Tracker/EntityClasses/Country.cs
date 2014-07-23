using SqlConnectorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Money_Tracker.EntityClasses
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }

        string[] strArrColValuesCountry = Properties.Settings.Default.User_Cols.Split('|');
        public bool InsertOperation()
        {
            string[] strArrColCountry = { strArrColValuesCountry[1], strArrColValuesCountry[2] };
            object[] objArrColValuesCountry = {this.Name, this.Currency };
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            return objSqlConLib.ExecuteQuery(Properties.Settings.Default.InsertUser, strArrColCountry, objArrColValuesCountry);
        }
       

    }
}