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
	public class AreaTypeList : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected Button BtnAdd;

		protected DataGrid AreaTypeGrid;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		public AreaTypeList()
		{
		}

		private void AreaTypeGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.AreaTypeGrid.CurrentPageIndex = e.NewPageIndex;
			this.LoadAreaTypeList();
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(Pages.Url(this, Pages.MAS_AREATYPE_ADD_PAGE));
			base.Response.Redirect(stringBuilder.ToString());
		}

		private void InitializeComponent()
		{
			this.BtnAdd.Click += new EventHandler(this.BtnAdd_Click);
			this.AreaTypeGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.AreaTypeGrid_PageIndexChanged);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadAreaTypeList()
		{
			this.AreaTypeGrid.DataSource = SmartAdmin.Data.Master.AreaTypeList();
			this.AreaTypeGrid.DataBind();
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
				this.LoadAreaTypeList();
			}
		}
	}
}