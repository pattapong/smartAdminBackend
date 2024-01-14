using SmartAdmin.Utils;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace SmartAdmin.Data
{
	public class Master
	{
		public Master()
		{
		}

		public static bool AreaInsert(string areaname, string areatypeid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("insertArea", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@areaname", SqlDbType.VarChar).Value = areaname;
			sqlCommand.Parameters.Add("@areatypeid", SqlDbType.Int).Value = areatypeid;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter.Value.ToString();
			return true;
		}

		public static DataTable AreaList()
		{
			return SmartAdmin.Data.Master.AreaList(0);
		}

		public static DataTable AreaList(int id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getArea", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@areaID", SqlDbType.Int);
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

		public static bool AreaTypeDelete(int areatypeid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("deleteAreaType", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@areaTypeID", SqlDbType.Int);
			sqlParameter.Value = areatypeid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static bool AreaTypeInsert(string areatypename)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("insertAreaType", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@areaTypeName", SqlDbType.VarChar).Value = areatypename;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter.Value.ToString();
			return true;
		}

		public static DataTable AreaTypeList()
		{
			return SmartAdmin.Data.Master.AreaTypeList(0);
		}

		public static DataTable AreaTypeList(int id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getAreaType", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@areatypeid", SqlDbType.Int);
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

		public static bool AreaTypeUpdate(int areatypeid, string areatypename)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("updateAreatype", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@areatypeid", SqlDbType.Int);
			sqlParameter.Value = areatypeid;
			sqlCommand.Parameters.Add("@areatypeName", SqlDbType.VarChar).Value = areatypename;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static bool AreaUpdate(int areaid, string areaname, string areatypeid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("updateArea", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@areaid", SqlDbType.Int);
			sqlParameter.Value = areaid;
			sqlCommand.Parameters.Add("@areaname", SqlDbType.VarChar).Value = areaname;
			sqlCommand.Parameters.Add("@areatypeid", SqlDbType.Int).Value = areatypeid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static DataTable DescriptionList()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getDescriptionList", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@descriptionid", SqlDbType.VarChar).Value = "0";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable DescriptionList(string id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getDescriptionList", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@descriptionid", SqlDbType.VarChar).Value = id;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static bool DescriptionUpdate(string descriptionid, string descriptiontext, string descriptionlinkid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("updateDescription", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@descriptionid", SqlDbType.VarChar).Value = descriptionid;
			sqlCommand.Parameters.Add("@descriptiontext", SqlDbType.NVarChar).Value = descriptiontext;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@descriptionlinkid", SqlDbType.Int);
			if (descriptionlinkid != "")
			{
				sqlParameter.Value = descriptionlinkid;
			}
			else
			{
				sqlParameter.Value = "0";
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static bool EmployeeTypeDelete(int employeetypeid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("deleteEmployeeType", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@empTypeID", SqlDbType.Int);
			sqlParameter.Value = employeetypeid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static bool EmployeeTypeInsert(string employeetypename)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("insertEmployeeType", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@empTypeName", SqlDbType.NVarChar).Value = employeetypename;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter.Value.ToString();
			return true;
		}

		public static DataTable EmployeeTypeList()
		{
			return SmartAdmin.Data.Master.EmployeeTypeList(0);
		}

		public static DataTable EmployeeTypeList(int id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getEmployeeType", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@empTypeID", SqlDbType.Int);
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

		public static bool EmployeeTypeUpdate(int employeetypeid, string employeetypename)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("updateEmployeeType", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@empTypeID", SqlDbType.Int);
			sqlParameter.Value = employeetypeid;
			sqlCommand.Parameters.Add("@empTypeName", SqlDbType.NVarChar).Value = employeetypename;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static bool FontDelete(int fontid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("deleteFont", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@fontid", SqlDbType.Int);
			sqlParameter.Value = fontid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static bool FontInsert(string fontdesc, string fontname, string fontsize, string fontbold)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("insertFont", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@fontdesc", SqlDbType.VarChar).Value = fontdesc;
			sqlCommand.Parameters.Add("@fontname", SqlDbType.VarChar).Value = fontname;
			sqlCommand.Parameters.Add("@fontsize", SqlDbType.SmallInt).Value = fontsize;
			sqlCommand.Parameters.Add("@fontbold", SqlDbType.Char).Value = fontbold;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter.Value.ToString();
			return true;
		}

		public static DataTable FontList()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getFont", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@fontid", SqlDbType.Int);
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

		public static DataTable FontList(int id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getFont", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@fontid", SqlDbType.Int);
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

		public static bool FontUpdate(string fontid, string fontdesc, string fontname, string fontsize, string fontbold)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("updateFont", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@fontid", SqlDbType.Int).Value = fontid;
			sqlCommand.Parameters.Add("@fontdesc", SqlDbType.VarChar).Value = fontdesc;
			sqlCommand.Parameters.Add("@fontname", SqlDbType.VarChar).Value = fontname;
			sqlCommand.Parameters.Add("@fontsize", SqlDbType.Int).Value = fontsize;
			sqlCommand.Parameters.Add("@fontbold", SqlDbType.Char).Value = fontbold;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter.Value.ToString();
			return true;
		}

		public static string GetDescription(string descriptionid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getDescription", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@descriptionid", SqlDbType.VarChar).Value = descriptionid;
			string str = sqlCommand.ExecuteScalar().ToString();
			connection.Close();
			return str;
		}

		public static DataTable GetSummary()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getSummary", connection)
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

		public static DataTable MenuGroupList()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getMenuGroup", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@menugroupid", SqlDbType.Int);
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

		public static DataTable MenuGroupList(int menugroupid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getMenuGroup", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@menugroupid", SqlDbType.Int);
			sqlParameter.Value = menugroupid;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static bool MenuOptChoiceDelete(int choiceid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("deleteOptChoice", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@choiceid", SqlDbType.Int);
			sqlParameter.Value = choiceid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static bool MenuOptChoiceInsert(int optionid, string choicename, string choiceshortname)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("insertOptChoice", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@optionid", SqlDbType.Int);
			sqlParameter.Value = optionid;
			sqlCommand.Parameters.Add("@choicename", SqlDbType.NVarChar).Value = choicename;
			sqlCommand.Parameters.Add("@choiceshortname", SqlDbType.NVarChar).Value = choiceshortname;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static DataTable MenuOptChoiceList(int id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getOptChoice", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@optionID", SqlDbType.Int);
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

		public static bool MenuOptChoiceUpdate(int choiceid, string choicename, string choiceshortname)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("updateOptChoice", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@choiceid", SqlDbType.Int);
			sqlParameter.Value = choiceid;
			sqlCommand.Parameters.Add("@choicename", SqlDbType.NVarChar).Value = choicename;
			sqlCommand.Parameters.Add("@choiceshortname", SqlDbType.NVarChar).Value = choiceshortname;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static bool MenuOptDelete(int optionid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("deleteMenuOption", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@optionid", SqlDbType.Int);
			sqlParameter.Value = optionid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static DataTable MenuOptExcludeList(int menuid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getMenuOptionExcludeMenu", connection)
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

		public static bool MenuOptInsert(string optionname, string optionshortname)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("insertMenuOption", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@optionname", SqlDbType.NVarChar).Value = optionname;
			sqlCommand.Parameters.Add("@optionshortname", SqlDbType.NVarChar).Value = optionshortname;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter.Value.ToString();
			return true;
		}

		public static DataTable MenuOptList()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getMenuOption", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@optionid", SqlDbType.Int);
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

		public static DataTable MenuOptList(int id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getMenuOption", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@optionid", SqlDbType.Int);
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

		public static bool MenuOptUpdate(int optionid, string optionname, string optionshortname)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("updateMenuOption", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@optionid", SqlDbType.Int);
			sqlParameter.Value = optionid;
			sqlCommand.Parameters.Add("@optionname", SqlDbType.NVarChar).Value = optionname;
			sqlCommand.Parameters.Add("@optionshortname", SqlDbType.NVarChar).Value = optionshortname;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static bool MenuTypeDelete(int menutypeid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("deleteMenuType", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@menutypeid", SqlDbType.Int);
			sqlParameter.Value = menutypeid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static bool MenuTypeInsert(string menutypename, string menutypedescription, string tax1, string tax2, string printline, string menugroupid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("insertMenuType", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@menutypename", SqlDbType.NVarChar).Value = menutypename;
			sqlCommand.Parameters.Add("@menutypedescription", SqlDbType.NVarChar).Value = menutypedescription;
			sqlCommand.Parameters.Add("@tax1", SqlDbType.TinyInt).Value = tax1;
			sqlCommand.Parameters.Add("@tax2", SqlDbType.TinyInt).Value = tax2;
			sqlCommand.Parameters.Add("@printline", SqlDbType.Char).Value = printline;
			sqlCommand.Parameters.Add("@menugroupid", SqlDbType.TinyInt).Value = menugroupid;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter.Value.ToString();
			return true;
		}

		public static DataTable MenuTypeList()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getMenuType", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@menutypeid", SqlDbType.Int);
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

		public static DataTable MenuTypeList(int id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getMenuType", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@menutypeid", SqlDbType.Int);
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

		public static bool MenuTypeUpdate(int menutypeid, string menutypename, string menutypedescription, string tax1, string tax2, string printline, string menugroupid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("updateMenuType", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@menutypeid", SqlDbType.Int);
			sqlParameter.Value = menutypeid;
			sqlCommand.Parameters.Add("@menutypename", SqlDbType.NVarChar).Value = menutypename;
			sqlCommand.Parameters.Add("@menutypedescription", SqlDbType.NVarChar).Value = menutypedescription;
			sqlCommand.Parameters.Add("@tax1", SqlDbType.TinyInt).Value = tax1;
			sqlCommand.Parameters.Add("@tax2", SqlDbType.TinyInt).Value = tax2;
			sqlCommand.Parameters.Add("@printline", SqlDbType.Char).Value = printline;
			sqlCommand.Parameters.Add("@menugroupid", SqlDbType.TinyInt).Value = menugroupid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static DataTable MonthList()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("MonthName", typeof(string));
			dataTable.Columns.Add("MonthID", typeof(int));
			for (int i = 1; i <= 12; i++)
			{
				DataRow str = dataTable.NewRow();
				DateTime dateTime = new DateTime(DateTime.Now.Year, i, 1);
				str["MonthName"] = dateTime.ToString("MMMM", DateTimeFormatInfo.InvariantInfo);
				str["MonthID"] = i;
				dataTable.Rows.Add(str);
			}
			return dataTable;
		}

		public static bool PaymentDelete(int paymentid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("deletePayment", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@paymentid", SqlDbType.Int);
			sqlParameter.Value = paymentid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static DataTable PaymentGroupList()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getPaymentGroup", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@paymentgroupid", SqlDbType.Int);
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

		public static DataTable PaymentGroupList(int paymentgroupid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getPaymentGroup", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@paymentgroupid", SqlDbType.Int);
			sqlParameter.Value = paymentgroupid;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static bool PaymentInsert(string paymentname, string paymentgroupid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("insertPayment", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@paymentname", SqlDbType.NVarChar).Value = paymentname;
			sqlCommand.Parameters.Add("@paymentgroupid", SqlDbType.TinyInt).Value = paymentgroupid;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter.Value.ToString();
			return true;
		}

		public static DataTable PaymentList()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getPayment", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@paymentid", SqlDbType.Int);
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

		public static DataTable PaymentList(int id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getPayment", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@paymentid", SqlDbType.Int);
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

		public static bool PaymentUpdate(int paymentid, string paymentname, string paymentgroupid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("updatePayment", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@paymentid", SqlDbType.Int);
			sqlParameter.Value = paymentid;
			sqlCommand.Parameters.Add("@paymentname", SqlDbType.NVarChar).Value = paymentname;
			sqlCommand.Parameters.Add("@paymentgroupid", SqlDbType.TinyInt).Value = paymentgroupid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static bool RoadInsert(string roadname, string roadtypeid, string areaid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("insertRoad", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@roadName", SqlDbType.VarChar).Value = roadname;
			sqlCommand.Parameters.Add("@roadtypeid", SqlDbType.Int).Value = roadtypeid;
			sqlCommand.Parameters.Add("@areaid", SqlDbType.Int).Value = areaid;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter.Value.ToString();
			return true;
		}

		public static DataTable RoadList()
		{
			return SmartAdmin.Data.Master.RoadList(0);
		}

		public static DataTable RoadList(int id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getCustomerRoad", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@roadID", SqlDbType.Int);
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

		public static bool RoadTypeDelete(int roadtypeid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("deleteRoadType", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@roadTypeID", SqlDbType.Int);
			sqlParameter.Value = roadtypeid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static bool RoadTypeInsert(string roadtypename)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("insertRoadType", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@roadTypeName", SqlDbType.VarChar).Value = roadtypename;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter.Value.ToString();
			return true;
		}

		public static DataTable RoadTypeList()
		{
			return SmartAdmin.Data.Master.RoadTypeList(0);
		}

		public static DataTable RoadTypeList(int id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getRoadType", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@roadtypeid", SqlDbType.Int);
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

		public static bool RoadTypeUpdate(int roadtypeid, string roadtypename)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("updateRoadType", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@roadtypeid", SqlDbType.Int);
			sqlParameter.Value = roadtypeid;
			sqlCommand.Parameters.Add("@roadtypeName", SqlDbType.VarChar).Value = roadtypename;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static bool RoadUpdate(int roadid, string roadname, string roadtypeid, string areaid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("updateRoad", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@roadid", SqlDbType.Int);
			sqlParameter.Value = roadid;
			sqlCommand.Parameters.Add("@roadName", SqlDbType.VarChar).Value = roadname;
			sqlCommand.Parameters.Add("@roadtypeid", SqlDbType.Int).Value = roadtypeid;
			sqlCommand.Parameters.Add("@areaid", SqlDbType.Int).Value = areaid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static bool ShiftDelete(int shiftID)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DELETE shift_mst WHERE shiftid = ");
			stringBuilder.Append(shiftID);
			(new SqlCommand(stringBuilder.ToString(), connection)).ExecuteNonQuery();
			connection.Close();
			return true;
		}

		public static bool ShiftInsert(string shiftdayfrom, string shiftdayto, string shiftstart, string shiftend, string shiftdescription)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("INSERT INTO shift_mst (shiftdayfrom,shiftdayto,shiftstart,shiftend,shiftdescription) VALUES (");
			string[] strArrays = new string[] { shiftdayfrom, ",", shiftdayto, ",'", shiftstart, "','", shiftend, "','", ConnectDB.ToDB(shiftdescription) };
			stringBuilder.Append(string.Concat(strArrays));
			stringBuilder.Append("')");
			(new SqlCommand(stringBuilder.ToString(), connection)).ExecuteNonQuery();
			connection.Close();
			return true;
		}

		public static DataTable ShiftList()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT ShiftID, Shiftdayfrom,dbo.getweekdayname(Shiftdayfrom) as dayfrom,shiftdayto,dbo.getweekdayname(shiftdayto) as dayto,convert(char(8),shiftstart,108) as shiftstart,convert(char(8),shiftend,108) as shiftend,shiftdescription FROM shift_mst  ", connection);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable ShiftList(int id)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ShiftID, Shiftdayfrom,dbo.getweekdayname(Shiftdayfrom) as dayfrom,shiftdayto,dbo.getweekdayname(shiftdayto) as dayto,convert(char(8),shiftstart,108) as shiftstart,convert(char(8),shiftend,108) as shiftend,shiftdescription ");
			stringBuilder.Append("FROM Shift_mst ");
			if (id > 0)
			{
				stringBuilder.Append(" WHERE ShiftID = ");
				stringBuilder.Append(id);
			}
			SqlConnection connection = ConnectDB.GetConnection();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(stringBuilder.ToString(), connection);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static bool ShiftUpdate(int shiftID, string shiftdayfrom, string shiftdayto, string shiftstart, string shiftend, string shiftdescription)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			StringBuilder stringBuilder = new StringBuilder();
			string[] strArrays = new string[] { "UPDATE shift_mst SET shiftdayfrom = ", shiftdayfrom, ",shiftdayto=", shiftdayto, "," };
			stringBuilder.Append(string.Concat(strArrays));
			strArrays = new string[] { "shiftstart='", shiftstart, "',shiftend='", shiftend, "',shiftdescription='" };
			stringBuilder.Append(string.Concat(strArrays));
			stringBuilder.Append(ConnectDB.ToDB(shiftdescription));
			stringBuilder.Append("'");
			stringBuilder.Append(" WHERE shiftID = ");
			stringBuilder.Append(shiftID);
			(new SqlCommand(stringBuilder.ToString(), connection)).ExecuteNonQuery();
			connection.Close();
			return true;
		}

		public static DataTable ShowTimeList()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getTime", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@timeid", SqlDbType.Int);
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

		public static DataTable SlipConfigList()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getSlipConfig", connection)
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

		public static bool SlipConfigUpdate(string configid, string configvalue)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("updateSlipConfig", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@configid", SqlDbType.Int).Value = configid;
			sqlCommand.Parameters.Add("@configvalue", SqlDbType.VarChar).Value = configvalue;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter.Value.ToString();
			return true;
		}

		public static DataTable SlipStyleList()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getSlipStyleFont", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@slipid", SqlDbType.VarChar).Value = "0";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable SlipStyleList(string id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getSlipStyleFont", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@slipid", SqlDbType.VarChar).Value = id;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static bool SlipStyleUpdate(string slipid, int headerfont, int bodyfont, int option1font, int option2font)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("updateSlipStyle", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@slipid", SqlDbType.VarChar).Value = slipid;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@headerfont", SqlDbType.Int);
			sqlParameter.Value = headerfont;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@bodyfont", SqlDbType.Int);
			sqlParameter1.Value = bodyfont;
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@option1font", SqlDbType.Int);
			sqlParameter2.Value = option1font;
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@option2font", SqlDbType.Int);
			sqlParameter3.Value = option2font;
			SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter4.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter4.Value.ToString();
			return true;
		}

		public static bool TableDelete(int tableid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DELETE table_mst WHERE tableid = ");
			stringBuilder.Append(tableid);
			(new SqlCommand(stringBuilder.ToString(), connection)).ExecuteNonQuery();
			connection.Close();
			return true;
		}

		public static bool TableInsert(string tablename, string numberofseat)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("INSERT INTO table_mst (tablename,numberofseat) VALUES ('");
			stringBuilder.Append(ConnectDB.ToDB(tablename));
			stringBuilder.Append(string.Concat("',", numberofseat, ")"));
			(new SqlCommand(stringBuilder.ToString(), connection)).ExecuteNonQuery();
			connection.Close();
			return true;
		}

		public static DataTable TableList()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select tableid,numberofseat,tablename from table_mst ", connection);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable TableList(int id)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select tableid,numberofseat,tablename ");
			stringBuilder.Append("from table_mst ");
			if (id > 0)
			{
				stringBuilder.Append(" WHERE tableid = ");
				stringBuilder.Append(id);
			}
			SqlConnection connection = ConnectDB.GetConnection();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(stringBuilder.ToString(), connection);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static bool TableUpdate(int tableid, string tablename, string numberofseat)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE table_mst SET tablename = '");
			stringBuilder.Append(ConnectDB.ToDB(tablename));
			stringBuilder.Append(string.Concat("',numberofseat=", numberofseat));
			stringBuilder.Append(" WHERE tableid = ");
			stringBuilder.Append(tableid);
			(new SqlCommand(stringBuilder.ToString(), connection)).ExecuteNonQuery();
			connection.Close();
			return true;
		}

		public static bool TimeDelete(int timeid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("deleteTime", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@timeid", SqlDbType.Int);
			sqlParameter.Value = timeid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static bool TimeInsert(string timename, string timefrom, string timeto)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("insertTime", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@timename", SqlDbType.NVarChar).Value = timename;
			sqlCommand.Parameters.Add("@timefrom", SqlDbType.VarChar).Value = timefrom;
			sqlCommand.Parameters.Add("@timeto", SqlDbType.VarChar).Value = timeto;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter.Value.ToString();
			return true;
		}

		public static DataTable TimeList()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getTimemst", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@timeid", SqlDbType.Int);
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

		public static DataTable TimeList(int id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getTimemst", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@timeid", SqlDbType.Int);
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

		public static bool TimeUpdate(int timeid, string timename, string timefrom, string timeto)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("updateTime", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@timeid", SqlDbType.Int);
			sqlParameter.Value = timeid;
			sqlCommand.Parameters.Add("@timename", SqlDbType.NVarChar).Value = timename;
			sqlCommand.Parameters.Add("@timefrom", SqlDbType.VarChar).Value = timefrom;
			sqlCommand.Parameters.Add("@timeto", SqlDbType.VarChar).Value = timeto;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static DataTable WeekDayList(int id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getWeekDay", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@weekday", SqlDbType.TinyInt);
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

        public static bool SmartclientDelete(int smartclientId)
        {
            SqlConnection connection = ConnectDB.GetConnection();
            SqlCommand sqlCommand = new SqlCommand("deleteSmartclient", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.Add("@id", SqlDbType.Int);
            sqlParameter.Value = smartclientId;
            SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
            sqlParameter1.Direction = ParameterDirection.Output;
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            sqlParameter1.Value.ToString();
            return true;
        }

        public static bool SmartclientInsert(string smartclientId, string description, string localPrinter)
        {
            SqlConnection connection = ConnectDB.GetConnection();
            SqlCommand sqlCommand = new SqlCommand("insertSmartclient", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = smartclientId;
            sqlCommand.Parameters.Add("@smartclientdescription", SqlDbType.VarChar).Value = description;
            sqlCommand.Parameters.Add("@localprinter", SqlDbType.VarChar).Value = localPrinter;
            SqlParameter sqlParameter = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.Output;
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            sqlParameter.Value.ToString();
            return true;
        }

        public static DataTable SmartclientList()
        {
            return SmartAdmin.Data.Master.SmartclientList(0);
        }

        public static DataTable SmartclientList(int smartclientId)
        {
            SqlConnection connection = ConnectDB.GetConnection();
            SqlCommand sqlCommand = new SqlCommand("getSmartclient", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.Add("@id", SqlDbType.Int);
            sqlParameter.Value = smartclientId;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
            {
                SelectCommand = sqlCommand
            };
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static bool SmartclientUpdate(int smartclientId, string description, string localPrinter)
        {
            SqlConnection connection = ConnectDB.GetConnection();
            SqlCommand sqlCommand = new SqlCommand("updateSmartclient", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter sqlParameter = sqlCommand.Parameters.Add("@id", SqlDbType.Int);
            sqlParameter.Value = smartclientId;
            sqlCommand.Parameters.Add("@smartclientdescription", SqlDbType.VarChar).Value = description;
            sqlCommand.Parameters.Add("@localprinter", SqlDbType.VarChar).Value = localPrinter;
            SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
            sqlParameter1.Direction = ParameterDirection.Output;
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            sqlParameter1.Value.ToString(); 
            return true;
        }
    }
}