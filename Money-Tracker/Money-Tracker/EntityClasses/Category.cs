using SqlConnectorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Money_Tracker.EntityClasses
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        string[] strArrColumn = Properties.Settings.Default.Category_Cols.Split('|');
        

        public bool Insert()
        {
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);

            string strQuery = Properties.Settings.Default.Category_INSERT;
            string[] strArrColNames = new string[] { strArrColumn[1], strArrColumn[2] };
            object[] objArrColValue = new object[] { this.Name,this.Type };

            return objSqlConLib.ExecuteQuery(strQuery, strArrColNames, objArrColValue);
        }

        public bool Delete()
        {
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            string strQuery = Properties.Settings.Default.Category_DELETE;
            string[] strArrColNames = new string[] { strArrColumn[0] };
            object[] objArrColValue = new object[] { this.Id };

            return objSqlConLib.ExecuteQuery(strQuery, strArrColNames, objArrColValue);
        }
    }
}