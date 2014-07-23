using SqlConnectorLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Money_Tracker.EntityClasses
{
    public class Expenses
    {
        public int User_id{get;set;}
        public decimal Expence{get;set;}

        public DateTime Date { get; set; }

        public int Category_Id{get;set;}

        public  void GetAll(DateTime date)
        {
            //string[] strColValuesWorkers = Properties.Settings.Default.TierCols.Split('|');
            //object[] objArrColValuesWorkers = { this.TierId, this.Tier, this.TierMultiplier};
            string[] strColValuesTier = {};
            object[] objArrColValuesTier = { };
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            DataTable dt=objSqlConLib.SelectQuery(@"select top 1 date from Expense", strColValuesTier, objArrColValuesTier);
            string str1=dt.Rows[0]["date"].ToString();
            DateTime ad = (DateTime)dt.Rows[0]["date"];
            DateTime dtdate=ad.AddDays(7);
            while (dtdate <= date)
            {
                
                object[] objArrColValuesTier1 = { ad,dtdate};
                string[] strColValuesTier1 = { "ad", "dtdate"};
                SqlConLib objSqlConLib1 = new SqlConLib(Properties.Settings.Default.ConnectionString);
                DataTable dtTable = objSqlConLib1.SelectQuery(@"Select sum(Expence) from expense where date between @ad and @dtdate" , strColValuesTier1, objArrColValuesTier1);
                SqlConLib objSqlConLib2 = new SqlConLib(Properties.Settings.Default.ConnectionString);
                DataTable dtTable1 = objSqlConLib2.SelectQuery(@"Select sum(Income) from Income where date between @ad and @dtdate", strColValuesTier1, objArrColValuesTier1);

                ad = dtdate;
                dtdate = ad.AddDays(7);
                
            }
            //DataTable dtTable = objSqlConLib.SelectQuery(@"Select sum(Expence) from expense where date between"+, strColValuesTier, objArrColValuesTier);
            //List<Expenses> lstTiers = new List<Expenses>();
            //for (int i = 0; i < dtTable.Rows.Count; i++)
            //{
            //    Expenses objTiers = new Expenses();
            //    objTiers.User_id =int.Parse( dtTable.Rows[i]["User_id"].ToString());
            //    objTiers.Expence =decimal.Parse(dtTable.Rows[i]["Expence"].ToString());
            //    objTiers.Date = dtTable.Rows[i]["Date"].ToString();
            //    objTiers.Category_Id = int.Parse(dtTable.Rows[i]["Category_id"].ToString());
            //    lstTiers.Add(objTiers);
            //}
        }
    }
}