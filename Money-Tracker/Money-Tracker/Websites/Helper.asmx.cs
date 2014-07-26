using Money_Tracker.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;

namespace Money_Tracker.Websites
{
    /// <summary>
    /// Summary description for Helper
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Helper : System.Web.Services.WebService
    {

        [WebMethod]
        public List<CalendarEvents> GetIncomeExpenseData()
        {
            List<CalendarEvents> lstCalendar = new List<CalendarEvents>();
            Expense objExpence = new Expense();
            Income objIncome = new Income();
            lstCalendar = objExpence.GetExpenseForCalendar();
            lstCalendar.AddRange(objIncome.GetIncomeForCalendar());
            return lstCalendar;
        }

        [WebMethod]
        public bool CheckEmail(object[] objUserEmail)
        {
            bool isValid = false;
            User objUser = new User();
            isValid = objUser.IsAlreadyRegistered(objUserEmail);
            return isValid;
        }

        [WebMethod]
        public void SendMail(object[] objEmail)
        {
            bool blnSuccess=false;
            Guid id = Guid.NewGuid();
            DateTime dtNow = DateTime.Now;
            string strUserEmail = objEmail[0].ToString();
            string strPasswordLink = "This mail is sent to reset password<html><a href="+"http://www.google.com"+"></a><html>";
            User objUser = new User();
            blnSuccess=objUser.ResetOperation(id,dtNow,strUserEmail);

            if (blnSuccess)
            {
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(strPasswordLink.ToString(), null, "text/html");
                MailMessage mail = new MailMessage("sktowsif@gmail.com", strUserEmail);
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.google.com";
                mail.Subject = "Money Management";

                mail.AlternateViews.Add(htmlView);
                client.Send(mail);
            }
        }

    }
}
