using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConnectorLib
{
    public class SqlConLib
    {
         string  _strConnection;
        SqlConnection _objSC;
        public SqlConLib(string strConnection)
        {
            _strConnection = strConnection;
        }

        public void OpenConnection()
        {
            if (_objSC == null)
            {
                _objSC = new SqlConnection(_strConnection);
            }
            if(_objSC.State != ConnectionState.Open)
                _objSC.Open();
        }

        public void CloseConnection()
        {
            if (_objSC != null)
            {
                _objSC.Close();
                _objSC.Dispose();
            }
        }
        /// <summary>
        /// Function that takes columns names, column values as parameters and will execute
        /// INSERT,UPDATE,DELETE Queries.
        /// </summary>
        /// <param name="strQuery"></param>
        /// <param name="strArrColNames"></param>
        /// <param name="objArrColValues"></param>
        /// <returns></returns>
        public bool ExecuteQuery(string strQuery, string[] strArrColNames, object[] objArrColValues)
        {
            if (strArrColNames.Length != objArrColValues.Length)
                return false;

            bool blnRetVal = false;
            OpenConnection();
            SqlCommand objSqlComm = new SqlCommand(strQuery, _objSC);
            for (int i = 0; i < strArrColNames.Length; i++)
			{
                objSqlComm.Parameters.AddWithValue(strArrColNames[i], objArrColValues[i]);    
			}
            
            if (objSqlComm.ExecuteNonQuery() > 0)
                blnRetVal = true;

            CloseConnection();
            return blnRetVal;
        }
        /// <summary>
        /// Function that takes columns names, column values as parameters and will execute
        /// the SELECT, SELECT ALL Queries.
        /// </summary>
        /// <param name="strQuery"></param>
        /// <param name="strArrColNames"></param>
        /// <param name="objArrColValues"></param>
        /// <returns></returns>
        public DataTable SelectQuery(string strQuery, string[] strArrColNames, object[] objArrColValues)
        {
            if (strArrColNames.Length != objArrColValues.Length)
                return null;
            
            OpenConnection();
            SqlCommand objSqlComm = new SqlCommand(strQuery,_objSC);
            for (int i = 0; i < strArrColNames.Length; i++)
            {
                objSqlComm.Parameters.AddWithValue(strArrColNames[i], objArrColValues[i]);
            }
            SqlDataAdapter sdaExecute = new SqlDataAdapter(objSqlComm);
            DataTable dtRetVal = new DataTable();
            sdaExecute.Fill(dtRetVal);
            CloseConnection();
            return dtRetVal;
        }

    }
}
