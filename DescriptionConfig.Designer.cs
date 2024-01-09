using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class DescriptionConfig : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected DataGrid DescriptionGrid;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		public DescriptionConfig()
		{
		}

		private void DescriptionGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.DescriptionGrid.CurrentPageIndex = e.NewPageIndex;
			this.LoadDescriptionList();
		}

		private void InitializeComponent()
		{
			this.DescriptionGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.DescriptionGrid_PageIndexChanged);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadDescriptionList()
		{
			this.DescriptionGrid.DataSource = SmartAdmin.Data.Master.DescriptionList();
			this.DescriptionGrid.DataBind();
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
				this.LoadDescriptionList();
			}
		}
	}
}