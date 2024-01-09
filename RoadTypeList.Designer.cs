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
	public class RoadTypeList : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected Button BtnAdd;

		protected DataGrid RoadTypeGrid;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		public RoadTypeList()
		{
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(Pages.Url(this, Pages.MAS_ROADTYPE_ADD_PAGE));
			base.Response.Redirect(stringBuilder.ToString());
		}

		private void InitializeComponent()
		{
			this.BtnAdd.Click += new EventHandler(this.BtnAdd_Click);
			this.RoadTypeGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.RoadTypeGrid_PageIndexChanged);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadRoadTypeList()
		{
			this.RoadTypeGrid.DataSource = SmartAdmin.Data.Master.RoadTypeList();
			this.RoadTypeGrid.DataBind();
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
				this.LoadRoadTypeList();
			}
		}

		private void RoadTypeGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.RoadTypeGrid.CurrentPageIndex = e.NewPageIndex;
			this.LoadRoadTypeList();
		}
	}
}