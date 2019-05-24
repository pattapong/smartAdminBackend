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
	public class MenuTypeList : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected Button BtnAdd;

		protected DataGrid MenuTypeGrid;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		private string tax1 = "";

		private string tax2 = "";

		public MenuTypeList()
		{
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(Pages.Url(this, Pages.MAS_MENUTYPE_ADD_PAGE));
			base.Response.Redirect(stringBuilder.ToString());
		}

		private void InitializeComponent()
		{
			this.BtnAdd.Click += new EventHandler(this.BtnAdd_Click);
			this.MenuTypeGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.MenuTypeGrid_PageIndexChanged);
			this.MenuTypeGrid.ItemDataBound += new DataGridItemEventHandler(this.MenuTypeGrid_ItemDataBound);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadMenuTypeList()
		{
			this.MenuTypeGrid.Columns[3].HeaderText = SmartAdmin.Data.Master.GetDescription("TAX1");
			this.MenuTypeGrid.Columns[4].HeaderText = SmartAdmin.Data.Master.GetDescription("TAX2");
			this.MenuTypeGrid.DataSource = SmartAdmin.Data.Master.MenuTypeList();
			this.MenuTypeGrid.DataBind();
		}

		private void MenuTypeGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			if (this.tax2 == "")
			{
				e.Item.Cells[4].Visible = false;
			}
		}

		private void MenuTypeGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.MenuTypeGrid.CurrentPageIndex = e.NewPageIndex;
			this.LoadMenuTypeList();
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.LoadMenu();
			this.tax1 = SmartAdmin.Data.Master.GetDescription("TAX1");
			this.tax2 = SmartAdmin.Data.Master.GetDescription("TAX2");
			if (!base.IsPostBack)
			{
				this.LoadMenuTypeList();
			}
		}
	}
}