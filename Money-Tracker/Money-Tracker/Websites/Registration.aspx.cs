using Money_Tracker.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Money_Tracker.Websites
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Country> FillCountryDropDown()
        {
            return Country.GetAll();
        }

        [WebMethod]
        public static void InsertUser(object[] objUserData)
        {
            User objUser = new User();
            objUser.Insert(objUserData);
        }
    }


}