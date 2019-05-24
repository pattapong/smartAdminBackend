using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class EmployeeTypeEdit : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnCancel;

		protected Button BtnSave;

		protected Image ImgError;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected HtmlForm AddPage;

		private int employeeTypeID;

		protected Label LblEmpTypeID;

		protected Label TxtEmpTypeID;

		protected TextBox TxtEmpTypeName;

		protected RequiredFieldValidator RequiredFieldValidator1;

		protected ValidationSummary ValidationSummary1;

		protected Label LblEmpTypeName;

		public EmployeeTypeEdit()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_EMPTYPE_LIST_PAGE));
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
                SmartAdmin.Data.Master.EmployeeTypeUpdate(this.employeeTypeID, this.TxtEmpTypeName.Text);
				this.BackPage();
			}
		}

		private void InitializeComponent()
		{
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadEmployeeType()
		{
			DataTable dataTable = SmartAdmin.Data.Master.EmployeeTypeList(this.employeeTypeID);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				base.Response.Redirect(Pages.Url(this, Pages.MAS_EMPTYPE_LIST_PAGE));
				return;
			}
			DataRow item = dataTable.Rows[0];
			this.TxtEmpTypeID.Text = this.employeeTypeID.ToString();
			this.TxtEmpTypeName.Text = item["employeeTypeName"].ToString();
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.LoadMenu();
			this.employeeTypeID = Pages.QueryInt(this, "id", -1);
			if (this.employeeTypeID <= 0)
			{
				this.BackPage();
			}
			if (!base.IsPostBack)
			{
				this.LoadEmployeeType();
			}
		}
	}
}