using SmartAdmin.Utils;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SmartAdmin.Data
{
	public class Promotion
	{
		public Promotion()
		{
		}

		public static bool PromotionDelete(int proid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("deletePromotion", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@proid", SqlDbType.Int);
			sqlParameter.Value = proid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter1.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter1.Value.ToString();
			return true;
		}

		public static string PromotionInsert(string typeid, string description, string amount, string discount, string menuid, string point, string discountamount, string validfrom, string validto)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("insertPromotion", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@protypeid", SqlDbType.Int).Value = typeid;
			sqlCommand.Parameters.Add("@description", SqlDbType.NVarChar).Value = description;
			SqlParameter value = sqlCommand.Parameters.Add("@amount", SqlDbType.Decimal);
			if (amount == null)
			{
				value.Value = DBNull.Value;
			}
			else
			{
				value.Value = amount;
			}
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@discountpercent", SqlDbType.Decimal);
			if (discount == null)
			{
				sqlParameter.Value = DBNull.Value;
			}
			else
			{
				sqlParameter.Value = discount;
			}
			SqlParameter value1 = sqlCommand.Parameters.Add("@discountamount", SqlDbType.Decimal);
			if (discountamount == null)
			{
				value1.Value = DBNull.Value;
			}
			else
			{
				value1.Value = discountamount;
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@menuid", SqlDbType.Int);
			if (menuid == null)
			{
				sqlParameter1.Value = DBNull.Value;
			}
			else
			{
				sqlParameter1.Value = menuid;
			}
			SqlParameter value2 = sqlCommand.Parameters.Add("@point", SqlDbType.TinyInt);
			if (point == null)
			{
				value2.Value = DBNull.Value;
			}
			else
			{
				value2.Value = point;
			}
			sqlCommand.Parameters.Add("@validfrom", SqlDbType.VarChar).Value = validfrom;
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@validto", SqlDbType.VarChar);
			if (validto == null)
			{
				sqlParameter2.Value = DBNull.Value;
			}
			else
			{
				sqlParameter2.Value = validto;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter3.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			return sqlParameter3.Value.ToString();
		}

		public static DataTable PromotionList()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getPromotion", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@proid", SqlDbType.Int);
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

		public static DataTable PromotionList(int id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getPromotion", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@proid", SqlDbType.Int);
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

		public static string PromotionTimeDelete(int proid, int day, string timeidlist)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("deletePromotionTime", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@proid", SqlDbType.Int);
			sqlParameter.Value = proid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@day", SqlDbType.TinyInt);
			sqlParameter1.Value = day;
			sqlCommand.Parameters.Add("@timeidlist", SqlDbType.VarChar).Value = timeidlist;
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter2.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			return sqlParameter2.Value.ToString();
		}

		public static string PromotionTimeInsert(int proid, int day, int timeid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("insertPromotionTime", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@proid", SqlDbType.Int);
			sqlParameter.Value = proid;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@day", SqlDbType.Int);
			sqlParameter1.Value = day;
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@timeid", SqlDbType.Int);
			sqlParameter2.Value = timeid;
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter3.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			return sqlParameter3.Value.ToString();
		}

		public static DataTable PromotionTimeList(int proid)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getPromotionTime", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@proid", SqlDbType.Int);
			sqlParameter.Value = proid;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = sqlCommand
			};
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			connection.Close();
			return dataTable;
		}

		public static DataTable PromotionTypeList()
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getPromotionType", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@proTypeID", SqlDbType.Int);
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

		public static DataTable PromotionTypeList(int id)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("getPromotionType", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@proTypeID", SqlDbType.Int);
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

		public static bool PromotionUpdate(int proid, string typeid, string description, string amount, string discount, string menuid, string point, string discountamount, string validfrom, string validto)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("updatePromotion", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@proid", SqlDbType.Int);
			sqlParameter.Value = proid;
			sqlCommand.Parameters.Add("@protypeid", SqlDbType.Int).Value = typeid;
			sqlCommand.Parameters.Add("@description", SqlDbType.NVarChar).Value = description;
			SqlParameter value = sqlCommand.Parameters.Add("@amount", SqlDbType.Decimal);
			if (amount == null)
			{
				value.Value = DBNull.Value;
			}
			else
			{
				value.Value = amount;
			}
			SqlParameter value1 = sqlCommand.Parameters.Add("@discountpercent", SqlDbType.Decimal);
			if (discount == null)
			{
				value1.Value = DBNull.Value;
			}
			else
			{
				value1.Value = discount;
			}
			SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@discountamount", SqlDbType.Decimal);
			if (discountamount == null)
			{
				sqlParameter1.Value = DBNull.Value;
			}
			else
			{
				sqlParameter1.Value = discountamount;
			}
			SqlParameter value2 = sqlCommand.Parameters.Add("@menuid", SqlDbType.Int);
			if (menuid == null)
			{
				value2.Value = DBNull.Value;
			}
			else
			{
				value2.Value = menuid;
			}
			SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@point", SqlDbType.TinyInt);
			if (point == null)
			{
				sqlParameter2.Value = DBNull.Value;
			}
			else
			{
				sqlParameter2.Value = point;
			}
			sqlCommand.Parameters.Add("@validfrom", SqlDbType.VarChar).Value = validfrom;
			SqlParameter value3 = sqlCommand.Parameters.Add("@validto", SqlDbType.VarChar);
			if (validto == null)
			{
				value3.Value = DBNull.Value;
			}
			else
			{
				value3.Value = validto;
			}
			SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
			sqlParameter3.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			sqlParameter3.Value.ToString();
			return true;
		}
	}
}