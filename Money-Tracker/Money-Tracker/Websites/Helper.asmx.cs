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
            bool blnSuccess = false;
            Guid id = Guid.NewGuid();
            DateTime dtNow = DateTime.Now;
            string strTime = dtNow.ToString("H:mm");

            string strUserEmail = objEmail[0].ToString();
            string strPasswordLink = "This mail is sent to reset password<html><a href='http://localhost:56554/Websites/ChangePassword.aspx?id=" + id + "'>click here to change password</a><html>";
            User objUser = new User();
            blnSuccess = objUser.ResetOperation(id, strTime, strUserEmail);

            if (blnSuccess)
            {
                MailMessage mail = new MailMessage("moneytracker30@gmail.com", strUserEmail);
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("moneytracker30@gmail.com", "moneytracker");

                mail.Subject = "Money Management";
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.Body = strPasswordLink;
                mail.IsBodyHtml = true;
                client.Send(mail);
            }
        }

        public static void FirstAndLastDayOfMonth(DateTime date, out DateTime first, out DateTime last)
        {
            first = new DateTime(date.Year, date.Month, 1);
            DateTime nextFirst;
            if (first.Month == 12) nextFirst = new DateTime(first.Year + 1, 1, 1);
            else nextFirst = new DateTime(first.Year, first.Month + 1, 1);
            last = nextFirst.AddDays(-1);
        }

        [WebMethod]
        public List<Income> GetWeekData(int intId, int intYear, int intMonth, int intWeekNumber)
        {
            string strDate = "01" + "-" + intMonth + "-" + intYear;
            DateTime dtDate = Convert.ToDateTime(strDate);
            DateTime dtFirst;
            DateTime dtLast;
            FirstAndLastDayOfMonth(dtDate, out dtFirst, out dtLast);
            int intWeekCount = 7 * intWeekNumber;
            DateTime dtAddDays = dtFirst.AddDays(intWeekCount - 1);
            dtLast = dtAddDays.AddDays(-7);
            Income objIncome = new Income();
            return objIncome.GetMonthlyIncomeData(intId, dtLast, dtAddDays);
        }

        [WebMethod]
        public List<Weeks> GetWeeks()
        {
            Weeks objMonths = new Weeks();
            return objMonths.GetWeeks();

        }

        [WebMethod]
        public List<Year> GetYears()
        {
            Year objYear = new Year();
            return objYear.GetYears();

        }

        [WebMethod]
        public List<Year> GetYearData(int intYear)
        {
            Year objYear = new Year();
            return objYear.GetYears();

        }

        [WebMethod]
        public List<Category> GetIncomeTypeList()
        {
            Category objCategory = new Category();
            return objCategory.GetDropDownList("Income");
        }

        [WebMethod]
        public List<Category> GetExpenseTypeList()
        {
            Category objCategory = new Category();
            return objCategory.GetDropDownList("Expense");
        }
    }


}
