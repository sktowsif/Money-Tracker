using SqlConnectorLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ValueTypeCasting;
using Microsoft.Office.Interop.Excel;
namespace Money_Tracker.EntityClasses
{
    public class ExportToXL
    {
        public decimal Income { get; set; }
        public decimal Expense { get; set; }
        public decimal Balance { get; set; }
        public DateTime Date { get; set; }

        public void Export(int intId)
        {
            string[] strColValues = { "User_Id" };
            object[] objArrColValues = { intId };
            SqlConLib objSqlConLib = new SqlConLib(Properties.Settings.Default.ConnectionString);
            System.Data.DataTable dtTable = objSqlConLib.SelectQuery("Select Income,Date,Expense,Balance from IncomeExpense Where User_id=@User_id", strColValues, objArrColValues);
            List<ExportToXL> lstEXL = new List<ExportToXL>();
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                ExportToXL objlstEXL = new ExportToXL();
                objlstEXL.Income = TypeTranslation.GetDecimal(dtTable.Rows[i]["Income"].ToString());
                objlstEXL.Date = (DateTime)dtTable.Rows[i]["Date"];
                objlstEXL.Expense = TypeTranslation.GetDecimal(dtTable.Rows[i]["Expense"].ToString());
                objlstEXL.Balance = TypeTranslation.GetDecimal(dtTable.Rows[i]["Balance"].ToString());
                lstEXL.Add(objlstEXL);
            }
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            // Create empty workbook
            excel.Workbooks.Add();

            // Create Worksheet from active sheet
            Microsoft.Office.Interop.Excel._Worksheet workSheet = excel.ActiveSheet;

            // I created Application and Worksheet objects before try/catch,
            // so that i can close them in finnaly block.
            // It's IMPORTANT to release these COM objects!!
            try
            {
                // ------------------------------------------------
                // Creation of header cells
                // ------------------------------------------------
                workSheet.Cells[1, "A"] = "Date";
                workSheet.Cells[1, "B"] = "Income";
                workSheet.Cells[1, "C"] = "Expense";
                workSheet.Cells[1, "D"] = "Balance";

                // ------------------------------------------------
                // Populate sheet with some real data from "cars" list
                // ------------------------------------------------
                int row = 2; // start row (in row 1 are header cells)
                foreach (ExportToXL XL in lstEXL)
                {
                    workSheet.Cells[row, "A"] = XL.Date;
                    workSheet.Cells[row, "B"] = XL.Income;
                    workSheet.Cells[row, "C"] = XL.Expense;
                    workSheet.Cells[row, "D"] = XL.Balance;
                    row++;
                }

                // Apply some predefined styles for data to look nicely :)
                workSheet.Range["A1"].AutoFormat(Microsoft.Office.Interop.Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic1);

                // Define filename
                string fileName = string.Format(@"{0}\ExcelData.xlsx", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));

                // Save this data as a file
                workSheet.SaveAs(fileName);

                // Display SUCCESS message
                //MessageBox.Show(string.Format("The file '{0}' is saved successfully!", fileName));
            }
            catch (Exception exception)
            {
                //MessageBox.Show("Exception",
                //  "There was a PROBLEM saving Excel file!\n" + exception.Message,
                //MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Quit Excel application
                excel.Quit();

                // Release COM objects (very important!)
                if (excel != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);

                if (workSheet != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);

                // Empty variables
                excel = null;
                workSheet = null;

                // Force garbage collector cleaning
                GC.Collect();
            }
        }
    }
}