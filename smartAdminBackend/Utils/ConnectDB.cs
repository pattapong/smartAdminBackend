using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;

namespace SmartAdmin.Utils
{
	public class ConnectDB
	{
		public ConnectDB()
		{
		}

		public static SqlConnection GetConnection()
		{
			SqlConnection sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["smartConnection"]);
			sqlConnection.Open();
			return sqlConnection;
		}

		public static string ToDB(string data)
		{
			return data.Replace("'", "''");
		}
	}
}