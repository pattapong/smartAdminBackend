using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class Home : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Label LblUserName;

		protected Label LblEmpID;

		protected Label LblLastLoginText;

		protected Label LblEmpNickName;

		protected Label LblEmpSex;

		protected Label LblEmpType;

		protected Label LblEmpSocialID;

		protected Label LblEmpName;

		protected Label LblPromotionCnt;

		protected Label LblMenuTypeCnt;

		protected Label LblEmployeeCnt;

		protected Label LblCustomerCnt;

		protected Label LblMenuItemCnt;

		protected Label LblTableCnt;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		private static CultureInfo ci;

		static Home()
		{
			Home.ci = new CultureInfo("en-US");
		}

		public Home()
		{
		}

		private void InitializeComponent()
		{
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, null, this.CopyrightBox);
		}

		private void LoadUserInformation()
		{
			DataTable summary = SmartAdmin.Data.Employee.EmployeeList(UserAuthorize.GetUserProfile(this).EmployeeID);
			if (summary == null)
			{
				base.Response.Redirect(Pages.Url(this, Pages.HOME_PAGE));
			}
			DataRow item = summary.Rows[0];
			this.LblEmpID.Text = item["EmployeeID"].ToString();
			this.LblEmpName.Text = string.Concat(item["FirstName"].ToString(), " ", item["LastName"].ToString());
			this.LblEmpNickName.Text = item["NickName"].ToString();
			this.LblEmpSex.Text = (item["Sex"].ToString() == "M" ? "Male" : "Female");
			this.LblEmpType.Text = item["EmployeeTypeName"].ToString();
			this.LblEmpSocialID.Text = item["SocialID"].ToString();
			this.LblUserName.Text = this.LblEmpName.Text;
			if (item["LastLogin"] is DBNull || item["LastLogin"] == null)
			{
				this.LblLastLoginText.Text = "This is your first login to smartAdmin.";
			}
			else
			{
				Label lblLastLoginText = this.LblLastLoginText;
				DateTime dateTime = (DateTime)item["LastLogin"];
				lblLastLoginText.Text = string.Concat("Your last login is ", dateTime.ToString("dd MMM yyyy HH:mm:ss", Home.ci));
			}
			summary = SmartAdmin.Data.Master.GetSummary();
			if (summary != null)
			{
				item = summary.Rows[0];
				this.LblEmployeeCnt.Text = item["EmpCount"].ToString();
				this.LblMenuTypeCnt.Text = item["MenuTypeCount"].ToString();
				this.LblMenuItemCnt.Text = item["MenuItemCount"].ToString();
				this.LblPromotionCnt.Text = item["PromotionCount"].ToString();
				this.LblTableCnt.Text = item["TableCount"].ToString();
				this.LblCustomerCnt.Text = item["CustomerCount"].ToString();
			}
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.LoadMenu();
			if (!base.IsPostBack)
			{
				this.LoadUserInformation();
			}
		}
	}
}