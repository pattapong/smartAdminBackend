using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class SlipList : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected DataGrid SlipGrid;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		public SlipList()
		{
		}

		private void InitializeComponent()
		{
			this.SlipGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.SlipGrid_PageIndexChanged);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadSlipList()
		{
			this.SlipGrid.DataSource = SmartAdmin.Data.Master.SlipStyleList();
			this.SlipGrid.DataBind();
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
				this.LoadSlipList();
			}
		}

		private void SlipGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.SlipGrid.CurrentPageIndex = e.NewPageIndex;
			this.LoadSlipList();
		}
	}
}