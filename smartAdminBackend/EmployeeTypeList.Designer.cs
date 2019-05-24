using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class EmployeeTypeList : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected DataGrid EmployeeTypeGrid;

		protected Button BtnAdd;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		public EmployeeTypeList()
		{
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(Pages.Url(this, Pages.MAS_EMPTYPE_ADD_PAGE));
			base.Response.Redirect(stringBuilder.ToString());
		}

		private void EmployeeTypeGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.EmployeeTypeGrid.CurrentPageIndex = e.NewPageIndex;
			this.LoadEmployeeTypeList();
		}

		private void InitializeComponent()
		{
			this.BtnAdd.Click += new EventHandler(this.BtnAdd_Click);
			this.EmployeeTypeGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.EmployeeTypeGrid_PageIndexChanged);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadEmployeeTypeList()
		{
			this.EmployeeTypeGrid.DataSource = SmartAdmin.Data.Master.EmployeeTypeList();
			this.EmployeeTypeGrid.DataBind();
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
			if (!base.IsPostBack)
			{
				this.LoadEmployeeTypeList();
			}
		}
	}
}