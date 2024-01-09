using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class RoadInfo : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected HtmlForm AddPage;

		protected Button BtnEdit;

		protected Button BtnDelete;

		protected Label LblConfirmDelete;

		protected Panel PanControl;

		protected Button BtnYes;

		protected Panel PanConfirm;

		protected Button BtnNo;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Label LblRoadID;

		protected Label TxtRoadID;

		protected Label LblRoadName;

		protected Label TxtRoadName;

		protected Label LbRoadType;

		protected Label TxtRoadType;

		protected Label LbArea;

		protected Label TxtArea;

		private int roadID;

		public RoadInfo()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_AREA_LIST_PAGE));
		}

		private void BtnEdit_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(Pages.Url(this, Pages.MAS_ROAD_EDIT_PAGE));
			stringBuilder.Append("?id=");
			stringBuilder.Append(this.roadID);
			base.Response.Redirect(stringBuilder.ToString());
		}

		private void BtnNo_Click(object sender, EventArgs e)
		{
			this.LblConfirmDelete.Visible = false;
			this.PanConfirm.Visible = false;
			this.PanControl.Visible = true;
		}

		private void InitializeComponent()
		{
			this.BtnEdit.Click += new EventHandler(this.BtnEdit_Click);
			this.BtnNo.Click += new EventHandler(this.BtnNo_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadRoad()
		{
			DataTable dataTable = SmartAdmin.Data.Master.RoadList(this.roadID);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				base.Response.Redirect(Pages.Url(this, Pages.MAS_AREA_LIST_PAGE));
				return;
			}
			DataRow item = dataTable.Rows[0];
			this.TxtRoadID.Text = this.roadID.ToString();
			this.TxtRoadName.Text = item["roadname"].ToString();
			this.TxtRoadType.Text = item["roadtypename"].ToString();
			this.TxtArea.Text = item["areaname"].ToString();
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.LoadMenu();
			this.roadID = Pages.QueryInt(this, "id", -1);
			if (this.roadID <= 0)
			{
				this.BackPage();
			}
			if (!base.IsPostBack)
			{
				this.LoadRoad();
			}
		}
	}
}