using SmartAdmin.Utils;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SmartAdmin.Data
{
	public class Employee
	{
		public Employee()
		{
		}

		public static bool Delete(int employeeID)
		{
			bool flag = false;
			try
			{
				SqlConnection connection = ConnectDB.GetConnection();
				SqlCommand sqlCommand = new SqlCommand("deleteEmployee", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@employeeID", SqlDbType.Int);
				sqlParameter.Value = employeeID;
				SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
				sqlParameter1.Direction = ParameterDirection.Output;
				sqlCommand.ExecuteNonQuery();
				connection.Close();
				sqlParameter1.Value.ToString();
				flag = true;
			}
			catch
			{
			}
			return flag;
		}

		public static string DeleteEmployeePermissionByEmp(string employeeid, string permissionlist)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("deleteEmployeePermissionByEmp", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@employeeid", SqlDbType.Int).Value = employeeid;
			sqlCommand.Parameters.Add("@permissionlist", SqlDbType.VarChar).Value = permissionlist;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			return sqlParameter.Value.ToString();
		}

		public static string DeleteEmployeePermissionByPer(string permissionid, string emplist)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("deleteEmployeePermissionByPer", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@permissionid", SqlDbType.Char).Value = permissionid;
			sqlCommand.Parameters.Add("@emplist", SqlDbType.VarChar).Value = emplist;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			return sqlParameter.Value.ToString();
		}

		public static DataTable EmployeeList()
		{
			return SmartAdmin.Data.Employee.EmployeeList(-1);
		}

		public static DataTable EmployeeList(int id)
		{
			return SmartAdmin.Data.Employee.EmployeeList(id.ToString());
		}

		public static DataTable EmployeeList(string id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getEmployee", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@empID", SqlDbType.Int).Value = id;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable EmployeeListByPermission(string id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getEmployeeByPermission", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@permissionid", SqlDbType.Char).Value = id;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable EmployeeListByPermissionExclude(string id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getEmployeeByPermissionExclude", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@permissionid", SqlDbType.Char).Value = id;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable EmployeeShift(string employeeid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getEmpShift", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@employeeid", SqlDbType.Int).Value = employeeid;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static bool Insert(string firstname, string lastname, string nickname, string sex, string socialID, string password, int typeID)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("insertEmployee", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
			sqlCommand.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = firstname;
			sqlCommand.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = lastname;
			sqlCommand.Parameters.Add("@nickName", SqlDbType.NVarChar).Value = nickname;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@empTypeID", SqlDbType.Int);
			sqlParameter.Value = typeID;
			sqlCommand.Parameters.Add("@sex", SqlDbType.VarChar).Value = sex;
			sqlCommand.Parameters.Add("@socialID", SqlDbType.NVarChar).Value = socialID;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static DataTable PermissionByEmpList()
		{
			return SmartAdmin.Data.Employee.PermissionByEmpList("-1");
		}

		public static DataTable PermissionByEmpList(string id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getPermissionMenuByEmp", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@empID", SqlDbType.Int).Value = id;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable PermissionListByEmpExclude(string id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getPermissionMenuByEmpExclude", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@empID", SqlDbType.Int).Value = id;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static string ShiftDelete(int employeeID, int shiftday, string timeidlist)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("deleteEmpShift", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@employeeID", SqlDbType.Int);
			sqlParameter.Value = employeeID;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@shiftday", SqlDbType.TinyInt);
			sqlParameter1.Value = shiftday;
			sqlCommand.Parameters.Add("@timeidlist", SqlDbType.VarChar).Value = timeidlist;
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter2.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			return sqlParameter2.Value.ToString();
		}

		public static string ShiftInsert(int employeeID, int shiftday, int timeid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("insertEmpShift", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@employeeID", SqlDbType.Int);
			sqlParameter.Value = employeeID;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@shiftday", SqlDbType.TinyInt);
			sqlParameter1.Value = shiftday;
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@timeid", SqlDbType.TinyInt);
			sqlParameter2.Value = timeid;
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter3.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			return sqlParameter3.Value.ToString();
		}

		public static DataTable ShiftList(int employeeID)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getEmpShift", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@employeeid", SqlDbType.Int);
			sqlParameter.Value = employeeID;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static bool Update(int employeeID, string firstname, string lastname, string nickname, string sex, string socialID, string password, int typeID)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("updateEmployee", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@employeeID", SqlDbType.Int);
			sqlParameter.Value = employeeID;
			sqlCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
			sqlCommand.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = firstname;
			sqlCommand.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = lastname;
			sqlCommand.Parameters.Add("@nickName", SqlDbType.NVarChar).Value = nickname;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@empTypeID", SqlDbType.Int);
			sqlParameter1.Value = typeID;
			sqlCommand.Parameters.Add("@sex", SqlDbType.VarChar).Value = sex;
			sqlCommand.Parameters.Add("@socialID", SqlDbType.NVarChar).Value = socialID;
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter2.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter2.Value.ToString();
			return true;
		}

		public static string UpdateEmployeePermission(string employeeid, string permissionid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("updateEmployeePermission", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@employeeid", SqlDbType.Int).Value = employeeid;
			sqlCommand.Parameters.Add("@permissionid", SqlDbType.Char).Value = permissionid;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			return sqlParameter.Value.ToString();
		}

		public static bool UpdateProfile(int employeeID, string firstname, string lastname, string nickname, string sex, string socialID, string password)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("updateEmployeeProfile", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@employeeID", SqlDbType.Int);
			sqlParameter.Value = employeeID;
			sqlCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
			sqlCommand.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = firstname;
			sqlCommand.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = lastname;
			sqlCommand.Parameters.Add("@nickName", SqlDbType.NVarChar).Value = nickname;
			sqlCommand.Parameters.Add("@sex", SqlDbType.VarChar).Value = sex;
			sqlCommand.Parameters.Add("@socialID", SqlDbType.NVarChar).Value = socialID;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}
	}
}