using SmartAdmin.Utils;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SmartAdmin.Data
{
	public class Report
	{
		public Report()
		{
		}

		public static DataTable SalesHistory(int timeid, int paymentmethodid, int monthfrom, int monthto, int year)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptSales", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@timeid", SqlDbType.Int);
			sqlParameter.Value = timeid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@paymentmethodid", SqlDbType.Int);
			sqlParameter1.Value = paymentmethodid;
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			sqlParameter2.Value = monthfrom;
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			sqlParameter3.Value = monthto;
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@year", SqlDbType.Int);
			sqlParameter4.Value = year;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable SalesTipsToday()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptSalesTips", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable SalesToday(int timeid, int paymentmethodid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptSales", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@timeid", SqlDbType.Int);
			sqlParameter.Value = timeid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@paymentmethodid", SqlDbType.Int);
			sqlParameter1.Value = paymentmethodid;
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			sqlParameter2.Value = 0;
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			sqlParameter3.Value = 0;
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@year", SqlDbType.Int);
			sqlParameter4.Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable SumMonth()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptSumMonth", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable SumMonthly(int monthfrom, int monthto, int year)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptSumMonthly", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			sqlParameter.Value = monthfrom;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			sqlParameter1.Value = monthto;
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@year", SqlDbType.Int);
			sqlParameter2.Value = year;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable SumToday()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptSumToday", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable SumWeek()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptSumWeek", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable SumYear(int yearfrom, int yearto)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptSumYear", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			sqlParameter.Value = yearfrom;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			sqlParameter1.Value = yearto;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable SumYearly(int yearfrom, int yearto)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptSumYearly", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			sqlParameter.Value = yearfrom;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			sqlParameter1.Value = yearto;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable TopFavourites(int topnumber, int monthfrom, int monthto, int year)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptTopFavourites", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@topnumber", SqlDbType.Int);
			sqlParameter.Value = topnumber;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			sqlParameter1.Value = monthfrom;
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			sqlParameter2.Value = monthto;
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@year", SqlDbType.Int);
			sqlParameter3.Value = year;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}
	}
}