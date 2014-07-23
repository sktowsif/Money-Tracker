
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

        public bool InsertOperation()
        {
            string[] strColValuesUser = Properties.Settings.Default.User_Cols.Split('|');
            //object[] objArrColValuesUser = { this.Id, this.Name, this.Email, this.Password,this.Type,this.Country };
            object[] objArrColValuesUser = { "sai","sdk@gmail.com","djsh","jjsahk","India" };
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            return objSqlConLib.ExecuteQuery(Properties.Settings.Default.InsertUser, strColValuesUser, objArrColValuesUser);
        }

    }
}