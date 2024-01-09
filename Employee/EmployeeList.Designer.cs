using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartAdmin.Employee
{
	public class EmployeeList : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnAdd;

		protected DataGrid EmployeeGrid;

		public EmployeeList()
		{
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(Pages.Url(this, Pages.EMPLOYEE_ADD_PAGE));
			base.Response.Redirect(stringBuilder.ToString());
		}

		private void EmployeeGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.EmployeeGrid.CurrentPageIndex = e.NewPageIndex;
			this.LoadEmployeeList();
		}

		private void InitializeComponent()
		{
			this.EmployeeGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.EmployeeGrid_PageIndexChanged);
			this.BtnAdd.Click += new EventHandler(this.BtnAdd_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadEmployeeList()
		{
			this.EmployeeGrid.DataSource = SmartAdmin.Data.Employee.EmployeeList();
			this.EmployeeGrid.DataBind();
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
				this.LoadEmployeeList();
			}
		}
	}
}