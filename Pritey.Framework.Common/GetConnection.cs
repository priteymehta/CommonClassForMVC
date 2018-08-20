using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Pritey.Framework.Common.Connection
{
    public static class GetConnection
    {
        [SettingsDescription("This properties will return connection is open of not.")]
        [DefaultSettingValue("false")]
        public static Boolean isConnectionOpen { get; set; }
        public static SqlConnection GetDBConnection()
        {
            SqlConnection sqlcon = null;
            try
            {
                sqlcon = new SqlConnection(ReadConnectionString());
                sqlcon.Open();
                if (sqlcon.State == ConnectionState.Open)
                {
                    isConnectionOpen = true;
                }
                else { isConnectionOpen = false; }
            }
            catch (Exception ex)
            {
                isConnectionOpen = false;
            }
            return sqlcon;
        }

        public static Boolean isServerAvailable()
        {
            Boolean blnResult = false;
            return blnResult;
        }

        public static Boolean OpenConnection(SqlConnection sqlCon)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
                if (sqlCon.State == ConnectionState.Open)
                {
                    isConnectionOpen = true;
                }
                else
                {
                    isConnectionOpen = false;
                }
            }
            catch (Exception ex)
            {
                isConnectionOpen = false;
            }
            return isConnectionOpen;
        }

        public static Boolean CloseConnection(SqlConnection sqlCon)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
                if (sqlCon.State == ConnectionState.Closed)
                {
                    isConnectionOpen = false;
                }
                else { isConnectionOpen = true; }

            }
            catch (Exception ex)
            {
                isConnectionOpen = true;
            }
            return isConnectionOpen;
        }

        private static string ReadConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

    }
}
