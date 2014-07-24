
using SqlConnectorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Money_Tracker.EntityClasses
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string Country { get; set;}

        string[] strArrColValuesUser = Properties.Settings.Default.User_Cols.Split('|');
        public bool InsertOperation()
        {
            string[] strArrCol = { strArrColValuesUser[1], strArrColValuesUser[2], strArrColValuesUser[3], strArrColValuesUser[4], strArrColValuesUser[5] };
            object[] objArrColValuesUser = {this.Name, this.Email, this.Password,this.Type,this.Country };
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            return objSqlConLib.ExecuteQuery(Properties.Settings.Default.InsertUser, strArrCol, objArrColValuesUser);
        }
        public bool UpdateOperation()
        {
            object[] objArrColValuesUser = { this.Id, this.Name, this.Email, this.Password,this.Type,this.Country };
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            return objSqlConLib.ExecuteQuery(Properties.Settings.Default.UpdateUser, strArrColValuesUser, objArrColValuesUser);
        }

        public bool DeleteOperation()
        {
            string[] strArrCol = { strArrColValuesUser[0] };
            object[] objArrColValuesUser = { this.Id};
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            return objSqlConLib.ExecuteQuery(Properties.Settings.Default.DeleteUser, strArrCol, objArrColValuesUser);
        }

    }
}