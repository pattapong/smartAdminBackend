using SmartAdmin.Utils;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SmartAdmin.Data
{
	public class Menu
	{
		public Menu()
		{
		}

		public static DataTable MenuByTypeList(int menuTypeID)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getMenuByTypeID", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@menutypeid", SqlDbType.Int);
			sqlParameter.Value = menuTypeID;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static bool MenuDefaultDelete(int menuid, int optionid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("deleteMenuDefault", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@menuid", SqlDbType.Int);
			sqlParameter.Value = menuid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@optionid", SqlDbType.Int);
			sqlParameter1.Value = optionid;
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter2.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter2.Value.ToString();
			return true;
		}

		public static bool MenuDefaultInsert(int menuid, int optionid, int choiceid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("insertMenuDefault", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@menuid", SqlDbType.Int);
			sqlParameter.Value = menuid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@optionid", SqlDbType.Int);
			sqlParameter1.Value = optionid;
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@choiceID", SqlDbType.Int);
			sqlParameter2.Value = choiceid;
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter3.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter3.Value.ToString();
			return true;
		}

		public static DataTable MenuDefaultList(int menuid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getMenuDefault", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@menuid", SqlDbType.Int);
			sqlParameter.Value = menuid;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static bool MenuDelete(int menuid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("deleteMenu", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@menuid", SqlDbType.Int);
			sqlParameter.Value = menuid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static int MenuInsert(string keyid, string typeid, string english, string thai, string french, string shortname, string description, string price, string menuset, string estimatetime)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("insertMenu", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@menukeyid", SqlDbType.Int).Value = keyid;
			sqlCommand.Parameters.Add("@menutypeid", SqlDbType.Int).Value = typeid;
			sqlCommand.Parameters.Add("@menunameenglish", SqlDbType.VarChar).Value = english;
			sqlCommand.Parameters.Add("@menunamethai", SqlDbType.NVarChar).Value = thai;
			sqlCommand.Parameters.Add("@menunamefrench", SqlDbType.NVarChar).Value = french;
			sqlCommand.Parameters.Add("@menushortname", SqlDbType.NVarChar).Value = shortname;
			sqlCommand.Parameters.Add("@menudescription", SqlDbType.NVarChar).Value = description;
			sqlCommand.Parameters.Add("@price", SqlDbType.Decimal).Value = price;
			sqlCommand.Parameters.Add("@menuset", SqlDbType.Char).Value = menuset;
			sqlCommand.Parameters.Add("@estimatetime", SqlDbType.VarChar).Value = estimatetime;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			return int.Parse(sqlParameter.Value.ToString());
		}

		public static DataTable MenuList()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getMenu", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@menuid", SqlDbType.Int);
			sqlParameter.Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable MenuList(int id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getMenu", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@menuid", SqlDbType.Int);
			sqlParameter.Value = id;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static bool MenuUpdate(int menuid, string keyid, string typeid, string english, string thai, string french, string shortname, string description, string price, string estimatetime)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("updateMenu", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@menuid", SqlDbType.Int);
			sqlParameter.Value = menuid;
			sqlCommand.Parameters.Add("@menukeyid", SqlDbType.Int).Value = keyid;
			sqlCommand.Parameters.Add("@menutypeid", SqlDbType.Int).Value = typeid;
			sqlCommand.Parameters.Add("@menunameenglish", SqlDbType.VarChar).Value = english;
			sqlCommand.Parameters.Add("@menunamethai", SqlDbType.NVarChar).Value = thai;
			sqlCommand.Parameters.Add("@menunamefrench", SqlDbType.NVarChar).Value = french;
			sqlCommand.Parameters.Add("@menushortname", SqlDbType.NVarChar).Value = shortname;
			sqlCommand.Parameters.Add("@menudescription", SqlDbType.NVarChar).Value = description;
			sqlCommand.Parameters.Add("@price", SqlDbType.Decimal).Value = price;
			sqlCommand.Parameters.Add("@estimatetime", SqlDbType.VarChar).Value = estimatetime;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static DataTable SubMenuByMenuList(int menuid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getSubMenuByMenuID", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@menusetid", SqlDbType.Int);
			sqlParameter.Value = menuid;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable SubMenuByTypeList(int menutypeid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getSubMenuByTypeID", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@menutypeid", SqlDbType.Int);
			sqlParameter.Value = menutypeid;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static bool SubMenuDelete(int menuid, int submenuid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("deleteSubMenu", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@menusetid", SqlDbType.Int);
			sqlParameter.Value = menuid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@menuid", SqlDbType.Int);
			sqlParameter1.Value = submenuid;
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter2.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter2.Value.ToString();
			return true;
		}

		public static bool SubMenuInsert(int menuid, int submenuid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("insertSubMenu", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@menusetid", SqlDbType.Int);
			sqlParameter.Value = menuid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@menuid", SqlDbType.Int);
			sqlParameter1.Value = submenuid;
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter2.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter2.Value.ToString();
			return true;
		}
	}
}