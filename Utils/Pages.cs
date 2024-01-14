using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartAdmin.Utils
{
	public class Pages
	{
		public static string HOME_PAGE;

		public static string BUSINESS_LOGIN_PAGE;

		public static string LOGIN_PAGE;

		public static string LOGOUT_PAGE;

		public static string NOAUTHO_PAGE;

		public static string EMPLOYEE_MAIN_PAGE;

		public static string EMPLOYEE_LIST_PAGE;

		public static string EMPLOYEE_ADD_PAGE;

		public static string EMPLOYEE_EDIT_PAGE;

		public static string MAS_MAIN_PAGE;

		public static string MAS_EMPTYPE_LIST_PAGE;

		public static string MAS_EMPTYPE_ADD_PAGE;

		public static string MAS_EMPTYPE_EDIT_PAGE;

		public static string MAS_DES_LIST_PAGE;

		public static string MAS_TIME_LIST_PAGE;

		public static string MAS_TIME_ADD_PAGE;

		public static string MAS_TIME_EDIT_PAGE;

		public static string MAS_MENUTYPE_LIST_PAGE;

		public static string MAS_MENUTYPE_ADD_PAGE;

		public static string MAS_MENUTYPE_EDIT_PAGE;

		public static string MAS_MENUOPT_LIST_PAGE;

		public static string MAS_MENUOPT_ADD_PAGE;

		public static string MAS_MENUOPT_EDIT_PAGE;

		public static string MAS_TABLE_LIST_PAGE;

		public static string MAS_TABLE_ADD_PAGE;

		public static string MAS_TABLE_EDIT_PAGE;

		public static string MAS_PAYMENT_LIST_PAGE;

		public static string MAS_PAYMENT_ADD_PAGE;

		public static string MAS_PAYMENT_EDIT_PAGE;

		public static string MAS_ROADTYPE_LIST_PAGE;

		public static string MAS_ROADTYPE_ADD_PAGE;

		public static string MAS_ROADTYPE_EDIT_PAGE;

		public static string MAS_ROAD_LIST_PAGE;

		public static string MAS_ROAD_ADD_PAGE;

		public static string MAS_ROAD_EDIT_PAGE;

		public static string MAS_AREATYPE_LIST_PAGE;

		public static string MAS_AREATYPE_ADD_PAGE;

		public static string MAS_AREATYPE_EDIT_PAGE;

		public static string MAS_AREA_LIST_PAGE;

		public static string MAS_AREA_ADD_PAGE;

		public static string MAS_AREA_EDIT_PAGE;

        public static string MAS_SMARTCLIENT_LIST_PAGE;

        public static string MAS_SMARTCLIENT_ADD_PAGE;

        public static string MAS_SMARTCLIENT_EDIT_PAGE;

        public static string MENU_LIST_PAGE;

		public static string MENU_ADD_PAGE;

		public static string MENU_EDIT_PAGE;

		public static string PRO_LIST_PAGE;

		public static string PRO_ADD_PAGE;

		public static string PRO_EDIT_PAGE;

		public static string RPT_SALES_TODAY_PAGE;

		public static string RPT_SALES_HIST_PAGE;

		public static string RPT_TOP_FAV_PAGE;

		public static string RPT_GRAPH_MONTHLY_PAGE;

		public static string RPT_GRAPH_YEARLY_PAGE;

		public static string RPT_SUM_TODAY_PAGE;

		public static string RPT_SUM_THISWEEK_PAGE;

		public static string RPT_SUM_THISMONTH_PAGE;

		public static string RPT_SUM_YEAR_PAGE;

		public static string MAS_FONT_LIST_PAGE;

		public static string MAS_FONT_ADD_PAGE;

		public static string MAS_FONT_EDIT_PAGE;

		public static string MAS_SLIPSTYLE_LIST_PAGE;

		public static string MAS_SLIPSTYLE_ADD_PAGE;

		public static string MAS_SLIPSTYLE_EDIT_PAGE;

		public static string MAS_SLIPCONFIG_PAGE;

		public static string PATH_IMAGES;

		static Pages()
		{
			Pages.HOME_PAGE = "/home.aspx";
			Pages.BUSINESS_LOGIN_PAGE = "/Authentication/BusinessLogin.aspx";
			Pages.LOGIN_PAGE = "/Authentication/Login.aspx";
			Pages.LOGOUT_PAGE = "/Authentication/Logout.aspx";
			Pages.NOAUTHO_PAGE = "/Authentication/NoAuthorize.aspx";
			Pages.EMPLOYEE_MAIN_PAGE = "/Employee/Default.aspx";
			Pages.EMPLOYEE_LIST_PAGE = "/Employee/EmployeeList.aspx";
			Pages.EMPLOYEE_ADD_PAGE = "/Employee/EmployeeAdd.aspx";
			Pages.EMPLOYEE_EDIT_PAGE = "/Employee/EmployeeEdit.aspx";
			Pages.MAS_MAIN_PAGE = "/Master/Default.aspx";
			Pages.MAS_EMPTYPE_LIST_PAGE = "/Master/EmployeeTypeList.aspx";
			Pages.MAS_EMPTYPE_ADD_PAGE = "/Master/EmployeeTypeAdd.aspx";
			Pages.MAS_EMPTYPE_EDIT_PAGE = "/Master/EmployeeTypeEdit.aspx";
			Pages.MAS_DES_LIST_PAGE = "/Master/DescriptionConfig.aspx";
			Pages.MAS_TIME_LIST_PAGE = "/Master/TimeList.aspx";
			Pages.MAS_TIME_ADD_PAGE = "/Master/TimeAdd.aspx";
			Pages.MAS_TIME_EDIT_PAGE = "/Master/TimeEdit.aspx";
			Pages.MAS_MENUTYPE_LIST_PAGE = "/Master/MenuTypeList.aspx";
			Pages.MAS_MENUTYPE_ADD_PAGE = "/Master/MenuTypeAdd.aspx";
			Pages.MAS_MENUTYPE_EDIT_PAGE = "/Master/MenuTypeEdit.aspx";
			Pages.MAS_MENUOPT_LIST_PAGE = "/Master/MenuOptList.aspx";
			Pages.MAS_MENUOPT_ADD_PAGE = "/Master/MenuOptAdd.aspx";
			Pages.MAS_MENUOPT_EDIT_PAGE = "/Master/MenuOptEdit.aspx";
			Pages.MAS_TABLE_LIST_PAGE = "/Master/TableList.aspx";
			Pages.MAS_TABLE_ADD_PAGE = "/Master/TableAdd.aspx";
			Pages.MAS_TABLE_EDIT_PAGE = "/Master/TableEdit.aspx";
			Pages.MAS_PAYMENT_LIST_PAGE = "/Master/PaymentList.aspx";
			Pages.MAS_PAYMENT_ADD_PAGE = "/Master/PaymentAdd.aspx";
			Pages.MAS_PAYMENT_EDIT_PAGE = "/Master/PaymentEdit.aspx";
			Pages.MAS_ROADTYPE_LIST_PAGE = "/Master/RoadTypeList.aspx";
			Pages.MAS_ROADTYPE_ADD_PAGE = "/Master/RoadTypeAdd.aspx";
			Pages.MAS_ROADTYPE_EDIT_PAGE = "/Master/RoadTypeEdit.aspx";
			Pages.MAS_ROAD_LIST_PAGE = "/Master/RoadList.aspx";
			Pages.MAS_ROAD_ADD_PAGE = "/Master/RoadAdd.aspx";
			Pages.MAS_ROAD_EDIT_PAGE = "/Master/RoadEdit.aspx";
			Pages.MAS_AREATYPE_LIST_PAGE = "/Master/AreaTypeList.aspx";
			Pages.MAS_AREATYPE_ADD_PAGE = "/Master/AreaTypeAdd.aspx";
			Pages.MAS_AREATYPE_EDIT_PAGE = "/Master/AreaTypeEdit.aspx";
			Pages.MAS_AREA_LIST_PAGE = "/Master/AreaList.aspx";
			Pages.MAS_AREA_ADD_PAGE = "/Master/AreaAdd.aspx";
			Pages.MAS_AREA_EDIT_PAGE = "/Master/AreaEdit.aspx";
            Pages.MAS_SMARTCLIENT_LIST_PAGE = "/Master/SmartclientList.aspx";
            Pages.MAS_SMARTCLIENT_ADD_PAGE = "/Master/SmartclientAdd.aspx";
            Pages.MAS_SMARTCLIENT_EDIT_PAGE = "/Master/SmartclientEdit.aspx";
            Pages.MENU_LIST_PAGE = "/Menu/MenuList.aspx";
			Pages.MENU_ADD_PAGE = "/Menu/MenuAdd.aspx";
			Pages.MENU_EDIT_PAGE = "/Menu/MenuEdit.aspx";
			Pages.PRO_LIST_PAGE = "/Promotion/PromotionList.aspx";
			Pages.PRO_ADD_PAGE = "/Promotion/PromotionAdd.aspx";
			Pages.PRO_EDIT_PAGE = "/Promotion/PromotionEdit.aspx";
			Pages.RPT_SALES_TODAY_PAGE = "/Report/SalesToday.aspx";
			Pages.RPT_SALES_HIST_PAGE = "/Report/SalesHistory.aspx";
			Pages.RPT_TOP_FAV_PAGE = "/Report/TopFavourites.aspx";
			Pages.RPT_GRAPH_MONTHLY_PAGE = "/Report/GraphMonthly.aspx";
			Pages.RPT_GRAPH_YEARLY_PAGE = "/Report/GraphYearly.aspx";
			Pages.RPT_SUM_TODAY_PAGE = "/Report/SumToday.aspx";
			Pages.RPT_SUM_THISWEEK_PAGE = "/Report/SumWeek.aspx";
			Pages.RPT_SUM_THISMONTH_PAGE = "/Report/SumMonth.aspx";
			Pages.RPT_SUM_YEAR_PAGE = "/Report/SumYear.aspx";
			Pages.MAS_FONT_LIST_PAGE = "/Master/FontList.aspx";
			Pages.MAS_FONT_ADD_PAGE = "/Master/FontAdd.aspx";
			Pages.MAS_FONT_EDIT_PAGE = "/Master/FontEdit.aspx";
			Pages.MAS_SLIPSTYLE_LIST_PAGE = "/Master/SlipList.aspx";
			Pages.MAS_SLIPSTYLE_ADD_PAGE = "/Master/SlipAdd.aspx";
			Pages.MAS_SLIPSTYLE_EDIT_PAGE = "/Master/SlipEdit.aspx";
			Pages.MAS_SLIPCONFIG_PAGE = "/Master/SlipConfig.aspx";
			Pages.PATH_IMAGES = "/images/";
		}

		public Pages()
		{
		}

		public static bool QueryBool(Control control, string name)
		{
			bool item;
			try
			{
				item = Pages.Request(control).QueryString[name] == "1";
			}
			catch (Exception exception)
			{
				item = false;
			}
			return item;
		}

		public static int QueryInt(Control control, string name, int defValue)
		{
			int num;
			try
			{
				num = int.Parse(Pages.Request(control).QueryString[name]);
			}
			catch (Exception exception)
			{
				num = defValue;
			}
			return num;
		}

		public static string QueryStr(Control control, string name, string defValue)
		{
			string str;
			try
			{
				string item = Pages.Request(control).QueryString[name];
				str = (item == null ? defValue : item);
			}
			catch (Exception exception)
			{
				str = defValue;
			}
			return str;
		}

		public static HttpRequest Request(Control control)
		{
			if (control is Page)
			{
				return ((Page)control).Request;
			}
			if (control is UserControl)
			{
				return ((UserControl)control).Request;
			}
			if (!(control is WebControl))
			{
				return null;
			}
			return ((WebControl)control).Page.Request;
		}

		public static HttpResponse Response(Control control)
		{
			if (control is Page)
			{
				return ((Page)control).Response;
			}
			if (control is UserControl)
			{
				return ((UserControl)control).Response;
			}
			if (!(control is WebControl))
			{
				return null;
			}
			return ((WebControl)control).Page.Response;
		}

		public static HttpServerUtility Server(Control control)
		{
			if (control is Page)
			{
				return ((Page)control).Server;
			}
			if (control is UserControl)
			{
				return ((UserControl)control).Server;
			}
			if (!(control is WebControl))
			{
				return null;
			}
			return ((WebControl)control).Page.Server;
		}

		public static HttpSessionState Session(Control control)
		{
			if (control is Page)
			{
				return ((Page)control).Session;
			}
			if (control is UserControl)
			{
				return ((UserControl)control).Session;
			}
			if (!(control is WebControl))
			{
				return null;
			}
			return ((WebControl)control).Page.Session;
		}

		public static string Url(Control control, string page)
		{
			return string.Concat(Pages.Request(control).ApplicationPath, page);
		}
	}
}