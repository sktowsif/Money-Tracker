using SqlConnectorLib;
using System;
using System.Collections.Generic;
using System.Data;
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

        public static List<Country> GetAll()
        {
            Country objCountry = null;
            List<Country> lstCountry = new List<Country>();

            string strQuery = Properties.Settings.Default.Country_SELECT;
            string[] strArrColNames = new string[] { };
            object[] objArrColValue = new string[] { };

            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DataTable dtTemp = new DataTable();
            dtTemp = objSqlConLib.SelectQuery(strQuery, strArrColNames, objArrColValue);

            int intTemp;
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                objCountry=new Country();
                int.TryParse(dtTemp.Rows[i]["Id"].ToString(), out intTemp);
                objCountry.Id = intTemp;
                objCountry.Name = dtTemp.Rows[i]["Name"] != null ? dtTemp.Rows[i]["Name"].ToString() : string.Empty;
                lstCountry.Add(objCountry);
            }
            return lstCountry;
        }
       

    }
}