using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;

namespace SmartAdmin.Utils
{
	public class UserAuthorize
	{
		private const string SES_USERPROFILE = "SES_USERPROFILE";

		public static string SES_ADMINTYPE;

		static UserAuthorize()
		{
			UserAuthorize.SES_ADMINTYPE = "SES_ADMINTYPE";
		}

		public UserAuthorize()
		{
		}

		public static void CheckAuthorize(Control control)
		{
			Pages.Session(control);
			HttpResponse httpResponse = Pages.Response(control);
			string rawUrl = Pages.Request(control).RawUrl;
			int num = rawUrl.IndexOf("?");
			if (num >= 0)
			{
				rawUrl = rawUrl.Substring(0, num);
			}
			num = rawUrl.IndexOf("#");
			if (num >= 0)
			{
				rawUrl = rawUrl.Substring(0, num);
			}
			if (rawUrl.Length > Pages.LOGIN_PAGE.Length && rawUrl.ToUpper().Substring(rawUrl.Length - Pages.LOGIN_PAGE.Length) == Pages.LOGIN_PAGE.ToUpper() || rawUrl.Length > Pages.BUSINESS_LOGIN_PAGE.Length && rawUrl.ToUpper().Substring(rawUrl.Length - Pages.BUSINESS_LOGIN_PAGE.Length) == Pages.BUSINESS_LOGIN_PAGE.ToUpper() || rawUrl.Length > Pages.NOAUTHO_PAGE.Length && rawUrl.ToUpper().Substring(rawUrl.Length - Pages.NOAUTHO_PAGE.Length) == Pages.NOAUTHO_PAGE.ToUpper())
			{
				return;
			}
			UserProfile userProfile = UserAuthorize.GetUserProfile(control);
			if (userProfile == null)
			{
				object item = Pages.Session(control)[UserAuthorize.SES_ADMINTYPE];
				if (item == null || !(item.ToString() == "BUSINESS"))
				{
					httpResponse.Redirect(Pages.Url(control, Pages.LOGIN_PAGE));
				}
				else
				{
					httpResponse.Redirect(Pages.Url(control, Pages.BUSINESS_LOGIN_PAGE));
				}
			}
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("admin_CheckAuthorize", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@url", SqlDbType.VarChar).Value = rawUrl;
			SqlParameter employeeID = sqlCommand.Parameters.Add("@empID", SqlDbType.Int);
			employeeID.Value = userProfile.EmployeeID;
			object obj = sqlCommand.ExecuteScalar();
			connection.Close();
			if (obj is DBNull || obj == null)
			{
				httpResponse.Redirect(Pages.Url(control, Pages.NOAUTHO_PAGE));
			}
		}

		public static UserProfile GetUserProfile(Control control)
		{
			HttpSessionState httpSessionStates = Pages.Session(control);
			if (httpSessionStates["SES_USERPROFILE"] == null)
			{
				return null;
			}
			return (UserProfile)httpSessionStates["SES_USERPROFILE"];
		}

		public static bool Login(Control control, string employeeID, string password)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("checkLogin", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@employeeid", SqlDbType.Int).Value = employeeID;
			sqlCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
			object obj = sqlCommand.ExecuteScalar();
			connection.Close();
			if (obj is DBNull || !((string)obj != ""))
			{
				Pages.Session(control).Remove("SES_USERPROFILE");
				return false;
			}
			UserProfile userProfile = new UserProfile()
			{
				EmployeeID = employeeID
			};
			Pages.Session(control)["SES_USERPROFILE"] = userProfile;
			return true;
		}

		public static bool Logout(Control control)
		{
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("checkLogout", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter employeeID = sqlCommand.Parameters.Add("@employeeid", SqlDbType.Int);
			employeeID.Value = UserAuthorize.GetUserProfile(control).EmployeeID;
			sqlCommand.ExecuteNonQuery();
			connection.Close();
			Pages.Session(control).Remove("SES_USERPROFILE");
			return true;
		}
	}
}