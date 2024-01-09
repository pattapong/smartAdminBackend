using SmartAdmin.Utils;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace SmartAdmin.Data
{
	public class Business
	{
		private static CultureInfo ci;

		static Business()
		{
			Business.ci = new CultureInfo("en-US");
		}

		public Business()
		{
		}

		public static DataTable ConvertColumnString(DataTable dt)
		{
			int i;
			DataTable dataTable = new DataTable();
			for (i = 0; i < dt.Columns.Count; i++)
			{
				if (i != 0)
				{
					dataTable.Columns.Add(dt.Columns[i].ColumnName, dt.Columns[i].DataType);
				}
				else
				{
					dataTable.Columns.Add(dt.Columns[i].ColumnName, typeof(string));
				}
			}
			for (i = 0; i < dt.Rows.Count; i++)
			{
				object[] itemArray = dt.Rows[i].ItemArray;
				if (!(itemArray[0] is DateTime))
				{
					itemArray[0] = itemArray[0].ToString();
				}
				else
				{
					DateTime dateTime = (DateTime)itemArray[0];
					itemArray[0] = dateTime.ToString("dd/MM/yyyy", Business.ci);
				}
				dataTable.Rows.Add(itemArray);
			}
			return dataTable;
		}

		public static DataTable MenuByEmp(string datefrom, string dateto, string monthfrom, string monthto, string yearfrom, string yearto)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptMenuByEmp", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
			if (datefrom != null)
			{
				sqlParameter.Value = datefrom;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
			if (dateto != null)
			{
				sqlParameter1.Value = dateto;
			}
			else
			{
				sqlParameter1.Value = "";
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			if (monthfrom != null)
			{
				sqlParameter2.Value = monthfrom;
			}
			else
			{
				sqlParameter2.Value = 0;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			if (monthto != null)
			{
				sqlParameter3.Value = monthto;
			}
			else
			{
				sqlParameter3.Value = 0;
			}
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			if (yearfrom != null)
			{
				sqlParameter4.Value = yearfrom;
			}
			else
			{
				sqlParameter4.Value = 0;
			}
			SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			if (yearto != null)
			{
				sqlParameter5.Value = yearto;
			}
			else
			{
				sqlParameter5.Value = 0;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable MenuByNumber(string period, string type, string datefrom, string dateto, string monthfrom, string monthto, string yearfrom, string yearto)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptMenuByNumber", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@period", SqlDbType.NVarChar);
			if (period != "==All==")
			{
				sqlParameter.Value = period;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
			if (type != "0")
			{
				sqlParameter1.Value = type;
			}
			else
			{
				sqlParameter1.Value = "";
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
			if (datefrom != null)
			{
				sqlParameter2.Value = datefrom;
			}
			else
			{
				sqlParameter2.Value = "";
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
			if (dateto != null)
			{
				sqlParameter3.Value = dateto;
			}
			else
			{
				sqlParameter3.Value = "";
			}
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			if (monthfrom != null)
			{
				sqlParameter4.Value = monthfrom;
			}
			else
			{
				sqlParameter4.Value = 0;
			}
			SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			if (monthto != null)
			{
				sqlParameter5.Value = monthto;
			}
			else
			{
				sqlParameter5.Value = 0;
			}
			SqlParameter sqlParameter6 = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			if (yearfrom != null)
			{
				sqlParameter6.Value = yearfrom;
			}
			else
			{
				sqlParameter6.Value = 0;
			}
			SqlParameter sqlParameter7 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			if (yearto != null)
			{
				sqlParameter7.Value = yearto;
			}
			else
			{
				sqlParameter7.Value = 0;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable MenuCancel(string datefrom, string dateto, string monthfrom, string monthto, string yearfrom, string yearto, string menutypeid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptMenuCancel", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
			if (datefrom != null)
			{
				sqlParameter.Value = datefrom;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
			if (dateto != null)
			{
				sqlParameter1.Value = dateto;
			}
			else
			{
				sqlParameter1.Value = "";
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			if (monthfrom != null)
			{
				sqlParameter2.Value = monthfrom;
			}
			else
			{
				sqlParameter2.Value = 0;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			if (monthto != null)
			{
				sqlParameter3.Value = monthto;
			}
			else
			{
				sqlParameter3.Value = 0;
			}
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			if (yearfrom != null)
			{
				sqlParameter4.Value = yearfrom;
			}
			else
			{
				sqlParameter4.Value = 0;
			}
			SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			if (yearto != null)
			{
				sqlParameter5.Value = yearto;
			}
			else
			{
				sqlParameter5.Value = 0;
			}
			SqlParameter sqlParameter6 = sqlCommand.Parameters.Add("@menutypeid", SqlDbType.Int);
			if (menutypeid != null)
			{
				sqlParameter6.Value = menutypeid;
			}
			else
			{
				sqlParameter6.Value = 0;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable MenuCancelDetail(string datefrom, string dateto, string monthfrom, string monthto, string yearfrom, string yearto, string menutypeid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptMenuCancelDetail", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
			if (datefrom != null)
			{
				sqlParameter.Value = datefrom;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
			if (dateto != null)
			{
				sqlParameter1.Value = dateto;
			}
			else
			{
				sqlParameter1.Value = "";
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			if (monthfrom != null)
			{
				sqlParameter2.Value = monthfrom;
			}
			else
			{
				sqlParameter2.Value = 0;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			if (monthto != null)
			{
				sqlParameter3.Value = monthto;
			}
			else
			{
				sqlParameter3.Value = 0;
			}
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			if (yearfrom != null)
			{
				sqlParameter4.Value = yearfrom;
			}
			else
			{
				sqlParameter4.Value = 0;
			}
			SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			if (yearto != null)
			{
				sqlParameter5.Value = yearto;
			}
			else
			{
				sqlParameter5.Value = 0;
			}
			SqlParameter sqlParameter6 = sqlCommand.Parameters.Add("@menutypeid", SqlDbType.Int);
			if (menutypeid != null)
			{
				sqlParameter6.Value = menutypeid;
			}
			else
			{
				sqlParameter6.Value = 0;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable MenuChangeOption(string datefrom, string dateto, string monthfrom, string monthto, string yearfrom, string yearto, string menuid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptMenuChangeOption", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
			if (datefrom != null)
			{
				sqlParameter.Value = datefrom;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
			if (dateto != null)
			{
				sqlParameter1.Value = dateto;
			}
			else
			{
				sqlParameter1.Value = "";
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			if (monthfrom != null)
			{
				sqlParameter2.Value = monthfrom;
			}
			else
			{
				sqlParameter2.Value = 0;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			if (monthto != null)
			{
				sqlParameter3.Value = monthto;
			}
			else
			{
				sqlParameter3.Value = 0;
			}
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			if (yearfrom != null)
			{
				sqlParameter4.Value = yearfrom;
			}
			else
			{
				sqlParameter4.Value = 0;
			}
			SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			if (yearto != null)
			{
				sqlParameter5.Value = yearto;
			}
			else
			{
				sqlParameter5.Value = 0;
			}
			SqlParameter sqlParameter6 = sqlCommand.Parameters.Add("@menuid", SqlDbType.Int);
			if (menuid != null)
			{
				sqlParameter6.Value = menuid;
			}
			else
			{
				sqlParameter6.Value = 0;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable MenuChangeOptionDetail(string datefrom, string dateto, string monthfrom, string monthto, string yearfrom, string yearto, string menuid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptMenuChangeOptionDetail", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
			if (datefrom != null)
			{
				sqlParameter.Value = datefrom;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
			if (dateto != null)
			{
				sqlParameter1.Value = dateto;
			}
			else
			{
				sqlParameter1.Value = "";
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			if (monthfrom != null)
			{
				sqlParameter2.Value = monthfrom;
			}
			else
			{
				sqlParameter2.Value = 0;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			if (monthto != null)
			{
				sqlParameter3.Value = monthto;
			}
			else
			{
				sqlParameter3.Value = 0;
			}
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			if (yearfrom != null)
			{
				sqlParameter4.Value = yearfrom;
			}
			else
			{
				sqlParameter4.Value = 0;
			}
			SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			if (yearto != null)
			{
				sqlParameter5.Value = yearto;
			}
			else
			{
				sqlParameter5.Value = 0;
			}
			SqlParameter sqlParameter6 = sqlCommand.Parameters.Add("@menuid", SqlDbType.Int);
			if (menuid != null)
			{
				sqlParameter6.Value = menuid;
			}
			else
			{
				sqlParameter6.Value = 0;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable NewCustomer(string datefrom, string dateto, string monthfrom, string monthto, string yearfrom, string yearto)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptNewCustomer", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
			if (datefrom != null)
			{
				sqlParameter.Value = datefrom;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
			if (dateto != null)
			{
				sqlParameter1.Value = dateto;
			}
			else
			{
				sqlParameter1.Value = "";
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			if (monthfrom != null)
			{
				sqlParameter2.Value = monthfrom;
			}
			else
			{
				sqlParameter2.Value = 0;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			if (monthto != null)
			{
				sqlParameter3.Value = monthto;
			}
			else
			{
				sqlParameter3.Value = 0;
			}
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			if (yearfrom != null)
			{
				sqlParameter4.Value = yearfrom;
			}
			else
			{
				sqlParameter4.Value = 0;
			}
			SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			if (yearto != null)
			{
				sqlParameter5.Value = yearto;
			}
			else
			{
				sqlParameter5.Value = 0;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable PartyByPeriod(string datefrom, string dateto, string monthfrom, string monthto, string yearfrom, string yearto)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptPartyTime", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
			if (datefrom != null)
			{
				sqlParameter.Value = datefrom;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
			if (dateto != null)
			{
				sqlParameter1.Value = dateto;
			}
			else
			{
				sqlParameter1.Value = "";
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			if (monthfrom != null)
			{
				sqlParameter2.Value = monthfrom;
			}
			else
			{
				sqlParameter2.Value = 0;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			if (monthto != null)
			{
				sqlParameter3.Value = monthto;
			}
			else
			{
				sqlParameter3.Value = 0;
			}
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			if (yearfrom != null)
			{
				sqlParameter4.Value = yearfrom;
			}
			else
			{
				sqlParameter4.Value = 0;
			}
			SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			if (yearto != null)
			{
				sqlParameter5.Value = yearto;
			}
			else
			{
				sqlParameter5.Value = 0;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable PartyByUsage(string datefrom, string dateto, string monthfrom, string monthto, string yearfrom, string yearto)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptPartyUsage", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
			if (datefrom != null)
			{
				sqlParameter.Value = datefrom;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
			if (dateto != null)
			{
				sqlParameter1.Value = dateto;
			}
			else
			{
				sqlParameter1.Value = "";
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			if (monthfrom != null)
			{
				sqlParameter2.Value = monthfrom;
			}
			else
			{
				sqlParameter2.Value = 0;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			if (monthto != null)
			{
				sqlParameter3.Value = monthto;
			}
			else
			{
				sqlParameter3.Value = 0;
			}
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			if (yearfrom != null)
			{
				sqlParameter4.Value = yearfrom;
			}
			else
			{
				sqlParameter4.Value = 0;
			}
			SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			if (yearto != null)
			{
				sqlParameter5.Value = yearto;
			}
			else
			{
				sqlParameter5.Value = 0;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable PrintSlipOrder(string type, string datefrom, string dateto, string monthfrom, string monthto, string yearfrom, string yearto)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptPrintSlip", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
			if (datefrom != null)
			{
				sqlParameter.Value = datefrom;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
			if (dateto != null)
			{
				sqlParameter1.Value = dateto;
			}
			else
			{
				sqlParameter1.Value = "";
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			if (monthfrom != null)
			{
				sqlParameter2.Value = monthfrom;
			}
			else
			{
				sqlParameter2.Value = 0;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			if (monthto != null)
			{
				sqlParameter3.Value = monthto;
			}
			else
			{
				sqlParameter3.Value = 0;
			}
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			if (yearfrom != null)
			{
				sqlParameter4.Value = yearfrom;
			}
			else
			{
				sqlParameter4.Value = 0;
			}
			SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			if (yearto != null)
			{
				sqlParameter5.Value = yearto;
			}
			else
			{
				sqlParameter5.Value = 0;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable ReserveTable(string datefrom, string dateto, string monthfrom, string monthto, string yearfrom, string yearto)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptReserveTable", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
			if (datefrom != null)
			{
				sqlParameter.Value = datefrom;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
			if (dateto != null)
			{
				sqlParameter1.Value = dateto;
			}
			else
			{
				sqlParameter1.Value = "";
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			if (monthfrom != null)
			{
				sqlParameter2.Value = monthfrom;
			}
			else
			{
				sqlParameter2.Value = 0;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			if (monthto != null)
			{
				sqlParameter3.Value = monthto;
			}
			else
			{
				sqlParameter3.Value = 0;
			}
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			if (yearfrom != null)
			{
				sqlParameter4.Value = yearfrom;
			}
			else
			{
				sqlParameter4.Value = 0;
			}
			SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			if (yearto != null)
			{
				sqlParameter5.Value = yearto;
			}
			else
			{
				sqlParameter5.Value = 0;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable ReserveTableDetail(string datein, string monthin, string yearin)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptReserveTableDetail", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@datein", SqlDbType.VarChar);
			if (datein != null)
			{
				sqlParameter.Value = datein;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@monthin", SqlDbType.Int);
			if (monthin != null)
			{
				sqlParameter1.Value = monthin;
			}
			else
			{
				sqlParameter1.Value = 0;
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@yearin", SqlDbType.Int);
			if (yearin != null)
			{
				sqlParameter2.Value = yearin;
			}
			else
			{
				sqlParameter2.Value = 0;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable SalesByDiscount(string datefrom, string dateto, string monthfrom, string monthto, string yearfrom, string yearto)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptSalesByDiscount", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
			if (datefrom != null)
			{
				sqlParameter.Value = datefrom;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
			if (dateto != null)
			{
				sqlParameter1.Value = dateto;
			}
			else
			{
				sqlParameter1.Value = "";
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			if (monthfrom != null)
			{
				sqlParameter2.Value = monthfrom;
			}
			else
			{
				sqlParameter2.Value = 0;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			if (monthto != null)
			{
				sqlParameter3.Value = monthto;
			}
			else
			{
				sqlParameter3.Value = 0;
			}
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			if (yearfrom != null)
			{
				sqlParameter4.Value = yearfrom;
			}
			else
			{
				sqlParameter4.Value = 0;
			}
			SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			if (yearto != null)
			{
				sqlParameter5.Value = yearto;
			}
			else
			{
				sqlParameter5.Value = 0;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable SalesByEmp(string datefrom, string dateto, string monthfrom, string monthto, string yearfrom, string yearto)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptSalesByEmp", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
			if (datefrom != null)
			{
				sqlParameter.Value = datefrom;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
			if (dateto != null)
			{
				sqlParameter1.Value = dateto;
			}
			else
			{
				sqlParameter1.Value = "";
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			if (monthfrom != null)
			{
				sqlParameter2.Value = monthfrom;
			}
			else
			{
				sqlParameter2.Value = 0;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			if (monthto != null)
			{
				sqlParameter3.Value = monthto;
			}
			else
			{
				sqlParameter3.Value = 0;
			}
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			if (yearfrom != null)
			{
				sqlParameter4.Value = yearfrom;
			}
			else
			{
				sqlParameter4.Value = 0;
			}
			SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			if (yearto != null)
			{
				sqlParameter5.Value = yearto;
			}
			else
			{
				sqlParameter5.Value = 0;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable SalesByOrderType(string datefrom, string dateto, string monthfrom, string monthto, string yearfrom, string yearto)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptSalesByOrderType", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
			if (datefrom != null)
			{
				sqlParameter.Value = datefrom;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
			if (dateto != null)
			{
				sqlParameter1.Value = dateto;
			}
			else
			{
				sqlParameter1.Value = "";
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			if (monthfrom != null)
			{
				sqlParameter2.Value = monthfrom;
			}
			else
			{
				sqlParameter2.Value = 0;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			if (monthto != null)
			{
				sqlParameter3.Value = monthto;
			}
			else
			{
				sqlParameter3.Value = 0;
			}
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			if (yearfrom != null)
			{
				sqlParameter4.Value = yearfrom;
			}
			else
			{
				sqlParameter4.Value = 0;
			}
			SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			if (yearto != null)
			{
				sqlParameter5.Value = yearto;
			}
			else
			{
				sqlParameter5.Value = 0;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable SalesByPayment(string datefrom, string dateto, string monthfrom, string monthto, string yearfrom, string yearto)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptSalesByPayment", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
			if (datefrom != null)
			{
				sqlParameter.Value = datefrom;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
			if (dateto != null)
			{
				sqlParameter1.Value = dateto;
			}
			else
			{
				sqlParameter1.Value = "";
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			if (monthfrom != null)
			{
				sqlParameter2.Value = monthfrom;
			}
			else
			{
				sqlParameter2.Value = 0;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			if (monthto != null)
			{
				sqlParameter3.Value = monthto;
			}
			else
			{
				sqlParameter3.Value = 0;
			}
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			if (yearfrom != null)
			{
				sqlParameter4.Value = yearfrom;
			}
			else
			{
				sqlParameter4.Value = 0;
			}
			SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			if (yearto != null)
			{
				sqlParameter5.Value = yearto;
			}
			else
			{
				sqlParameter5.Value = 0;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable SalesByPeriod(string datefrom, string dateto, string monthfrom, string monthto, string yearfrom, string yearto)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptSalesByPeriod", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
			if (datefrom != null)
			{
				sqlParameter.Value = datefrom;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
			if (dateto != null)
			{
				sqlParameter1.Value = dateto;
			}
			else
			{
				sqlParameter1.Value = "";
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			if (monthfrom != null)
			{
				sqlParameter2.Value = monthfrom;
			}
			else
			{
				sqlParameter2.Value = 0;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			if (monthto != null)
			{
				sqlParameter3.Value = monthto;
			}
			else
			{
				sqlParameter3.Value = 0;
			}
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			if (yearfrom != null)
			{
				sqlParameter4.Value = yearfrom;
			}
			else
			{
				sqlParameter4.Value = 0;
			}
			SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			if (yearto != null)
			{
				sqlParameter5.Value = yearto;
			}
			else
			{
				sqlParameter5.Value = 0;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable ServiceCheckInOut(string datefrom, string dateto, string monthfrom, string monthto, string yearfrom, string yearto, string weekday)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptServiceCheckInOut", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
			if (datefrom != null)
			{
				sqlParameter.Value = datefrom;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
			if (dateto != null)
			{
				sqlParameter1.Value = dateto;
			}
			else
			{
				sqlParameter1.Value = "";
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			if (monthfrom != null)
			{
				sqlParameter2.Value = monthfrom;
			}
			else
			{
				sqlParameter2.Value = 0;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			if (monthto != null)
			{
				sqlParameter3.Value = monthto;
			}
			else
			{
				sqlParameter3.Value = 0;
			}
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			if (yearfrom != null)
			{
				sqlParameter4.Value = yearfrom;
			}
			else
			{
				sqlParameter4.Value = 0;
			}
			SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			if (yearto != null)
			{
				sqlParameter5.Value = yearto;
			}
			else
			{
				sqlParameter5.Value = 0;
			}
			SqlParameter sqlParameter6 = sqlCommand.Parameters.Add("@weekday", SqlDbType.TinyInt);
			if (weekday != null)
			{
				sqlParameter6.Value = weekday;
			}
			else
			{
				sqlParameter6.Value = 0;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable ServiceOrderServe(string datefrom, string dateto, string monthfrom, string monthto, string yearfrom, string yearto, string menuid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptServiceOrderServe", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
			if (datefrom != null)
			{
				sqlParameter.Value = datefrom;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
			if (dateto != null)
			{
				sqlParameter1.Value = dateto;
			}
			else
			{
				sqlParameter1.Value = "";
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			if (monthfrom != null)
			{
				sqlParameter2.Value = monthfrom;
			}
			else
			{
				sqlParameter2.Value = 0;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			if (monthto != null)
			{
				sqlParameter3.Value = monthto;
			}
			else
			{
				sqlParameter3.Value = 0;
			}
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			if (yearfrom != null)
			{
				sqlParameter4.Value = yearfrom;
			}
			else
			{
				sqlParameter4.Value = 0;
			}
			SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			if (yearto != null)
			{
				sqlParameter5.Value = yearto;
			}
			else
			{
				sqlParameter5.Value = 0;
			}
			SqlParameter sqlParameter6 = sqlCommand.Parameters.Add("@menuid", SqlDbType.Int);
			if (menuid != null)
			{
				sqlParameter6.Value = menuid;
			}
			else
			{
				sqlParameter6.Value = 0;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable TimeStampByEmp(string employeeid, string datefrom, string dateto, string monthfrom, string monthto, string yearfrom, string yearto)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRptTimeStampByEmp", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@employeeid", SqlDbType.Int).Value = employeeid;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
			if (datefrom != null)
			{
				sqlParameter.Value = datefrom;
			}
			else
			{
				sqlParameter.Value = "";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
			if (dateto != null)
			{
				sqlParameter1.Value = dateto;
			}
			else
			{
				sqlParameter1.Value = "";
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@monthfrom", SqlDbType.Int);
			if (monthfrom != null)
			{
				sqlParameter2.Value = monthfrom;
			}
			else
			{
				sqlParameter2.Value = 0;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@monthto", SqlDbType.Int);
			if (monthto != null)
			{
				sqlParameter3.Value = monthto;
			}
			else
			{
				sqlParameter3.Value = 0;
			}
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@yearfrom", SqlDbType.Int);
			if (yearfrom != null)
			{
				sqlParameter4.Value = yearfrom;
			}
			else
			{
				sqlParameter4.Value = 0;
			}
			SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@yearto", SqlDbType.Int);
			if (yearto != null)
			{
				sqlParameter5.Value = yearto;
			}
			else
			{
				sqlParameter5.Value = 0;
			}
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