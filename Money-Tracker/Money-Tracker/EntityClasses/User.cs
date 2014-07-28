
using SqlConnectorLib;
using System;
using System.Collections.Generic;
using System.Data;
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
        public string GuId { get; set; }
        public string ResetTime { get; set; }

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

        // Insert with ajax call
        public bool Insert(object[] objUserData) 
        {
            string strQuery = Properties.Settings.Default.User_INSERT;
            string[] strArrColNames = new string[] { "Name","Gender","Email","Password","Type","Country" };
            object[] objArrColValue = new object[] { objUserData[0], objUserData[1], objUserData[2], objUserData[3], "User", objUserData[4] };

            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            return objSqlConLib.ExecuteQuery(strQuery,strArrColNames,objArrColValue);
        }

        // Returns User Id if the user is registered
        public int IsValidLogin(object[] objCred)
        {
            string strQuery = "SELECT [Id] FROM [User] WHERE Email=@Email AND Password=@Password";
            string[] strArrColNames = new string[] { "Email","Password" };
            object[] objArrColValue = new object[] { objCred[0], objCred[1] };

            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DataTable dtTemp = new DataTable();
            dtTemp = objSqlConLib.SelectQuery(strQuery, strArrColNames, objArrColValue);
            int intID;
            if (dtTemp.Rows.Count > 0) 
            {
                int.TryParse(dtTemp.Rows[0]["Id"].ToString(), out intID);
                return intID;
            }
            return int.MinValue;
        }

        public bool IsAlreadyRegistered(object[] objUserData)
        {
            string strQuery = "SELECT [Id] FROM [User] WHERE Email=@Email";
            string[] strArrColNames = new string[] { "Email"};
            object[] objArrColValue = new object[] { objUserData[0] };

            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DataTable dtTemp = new DataTable();
            dtTemp = objSqlConLib.SelectQuery(strQuery, strArrColNames, objArrColValue);
            if (dtTemp.Rows.Count > 0)
                return true;
            return false;
        }

        public bool ResetOperation(Guid id,string strTime,string strEmail)
        {
            string strQuery = "UPDATE [User] SET [GuId]=@Guid,[ResetTime]=@ResetTime WHERE [Email]=@Email";
            string[] strArrColNames = new string[] { "GuId","ResetTime","Email"};
            object[] objArrColValue = new object[] { id, strTime, strEmail };
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            return objSqlConLib.ExecuteQuery(strQuery, strArrColNames, objArrColValue);
        }

        public List<User> GetInfoToChangePassword()
        {
            User objUser = new User();
            List<User> lstUser = new List<User>();
            return lstUser;
        }

    }
}