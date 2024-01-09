using SmartAdmin.Controls;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartAdmin.Utils
{
	public class AdminMenu
	{
		public const int MENU_HOME = 0;

		public AdminMenu()
		{
		}

		private static ListItemCollection GetMainMenu(Control control)
		{
			ListItemCollection listItemCollections = new ListItemCollection();
			ArrayList arrayLists = new ArrayList();
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("admin_AdminMainMenu", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter employeeID = sqlCommand.Parameters.Add("@employeeid", SqlDbType.Int);
			employeeID.Value = UserAuthorize.GetUserProfile(control).EmployeeID;
			SqlDataReader sqlDataReaders = sqlCommand.ExecuteReader();
			int num = 0;
			while (sqlDataReaders.Read())
			{
				string item = (string)sqlDataReaders["adminmenuid"];
				string str = (string)sqlDataReaders["adminmenutext"];
				string item1 = (string)sqlDataReaders["link"];
				if ((int)sqlDataReaders["menucnt"] == 0 && (item1 == null || item1 == ""))
				{
					item1 = string.Concat(Pages.Url(control, Pages.NOAUTHO_PAGE), "?type=", num);
				}
				else if (item1 != "")
				{
					item1 = Pages.Url(control, item1);
				}
				listItemCollections.Add(new ListItem(str, item1));
				arrayLists.Add(item);
				num++;
			}
			sqlDataReaders.Close();
			connection.Close();
			Pages.Session(control)["MAINMENU"] = listItemCollections;
			Pages.Session(control)["MAINMENUID"] = arrayLists;
			return (ListItemCollection)Pages.Session(control)["MAINMENU"];
		}

		private static ListItemCollection GetSubMenu(Control control, int menuType)
		{
			if (Pages.Session(control)["MAINMENU"] == null || Pages.Session(control)["MAINMENUID"] == null)
			{
				return null;
			}
			ArrayList item = (ArrayList)Pages.Session(control)["MAINMENUID"];
			ListItemCollection listItemCollections = (ListItemCollection)Pages.Session(control)["MAINMENU"];
			ListItemCollection listItemCollections1 = new ListItemCollection();
			SqlConnection connection = ConnectDB.GetConnection();
			SqlCommand sqlCommand = new SqlCommand("admin_AdminSubMenu", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter employeeID = sqlCommand.Parameters.Add("@employeeid", SqlDbType.Int);
			employeeID.Value = UserAuthorize.GetUserProfile(control).EmployeeID;
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@rootid", SqlDbType.Char);
			sqlParameter.Value = (string)item[menuType];
			SqlDataReader sqlDataReaders = sqlCommand.ExecuteReader();
			string str = null;
			while (sqlDataReaders.Read())
			{
				string item1 = (string)sqlDataReaders["adminmenutext"];
				string str1 = (string)sqlDataReaders["link"];
				if (item1 == "-" && item1 == str)
				{
					continue;
				}
				if (str1 != "")
				{
					str1 = Pages.Url(control, str1);
				}
				listItemCollections1.Add(new ListItem(item1, str1));
				str = item1;
			}
			if (listItemCollections1.Count > 0 && listItemCollections1[listItemCollections1.Count - 1].Text == "-")
			{
				listItemCollections1.RemoveAt(listItemCollections1.Count - 1);
			}
			sqlDataReaders.Close();
			connection.Close();
			Pages.Session(control)[string.Concat("SUBMENU", menuType)] = listItemCollections1;
			return (ListItemCollection)Pages.Session(control)[string.Concat("SUBMENU", menuType)];
		}

		private static void SetCopyright(Control control, CopyrightBox copyright)
		{
			copyright.Text = "Copyright &copy; 2004 smartService Solution. All rights reserved.";
			if (UserAuthorize.GetUserProfile(control) != null)
			{
				copyright.EmployeeID = UserAuthorize.GetUserProfile(control).EmployeeID;
			}
		}

		private static void SetMainMenu(Control control, HeaderBox header)
		{
			header.HomeUrl = Pages.Url(control, Pages.HOME_PAGE);
			header.Items = AdminMenu.GetMainMenu(control);
		}

		public static void SetMenu(Control control, HeaderBox header, SubmenuBox sub, CopyrightBox copyright)
		{
			UserAuthorize.CheckAuthorize(control);
			if (Pages.Request(control).Form["_menuTab_"] == "-1")
			{
				Pages.Response(control).Redirect(Pages.Url(control, Pages.LOGOUT_PAGE));
			}
			if (header != null)
			{
				AdminMenu.SetMainMenu(control, header);
				object item = Pages.Session(control)[UserAuthorize.SES_ADMINTYPE];
				header.IsAdmin = (item == null ? true : item.ToString() != "BUSINESS");
			}
			if (sub != null)
			{
				sub.Items = AdminMenu.GetSubMenu(control, header.ActiveIndex);
			}
			if (copyright != null)
			{
				AdminMenu.SetCopyright(control, copyright);
			}
		}
	}
}