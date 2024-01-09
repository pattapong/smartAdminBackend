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
	public class RoadEdit : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnCancel;

		protected Button BtnSave;

		protected Image ImgError;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected HtmlForm AddPage;

		protected RequiredFieldValidator RequiredFieldValidator1;

		protected Label LblAreaID;

		protected Label TxtRoadID;

		protected Label LblRoadName;

		protected TextBox TxtRoadName;

		protected Label LblRoadType;

		protected DropDownList LstRoadType;

		protected Label LblArea;

		protected DropDownList LstArea;

		protected ValidationSummary ValidationSummary1;

		private int roadID;

		public RoadEdit()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_ROAD_LIST_PAGE));
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.BackPage();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
                SmartAdmin.Data.Master.RoadUpdate(this.roadID, this.TxtRoadName.Text, this.LstRoadType.SelectedItem.Value, this.LstArea.SelectedItem.Value);
				this.BackPage();
			}
		}

		private void InitializeComponent()
		{
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			this.BtnCancel.Click += new EventHandler(this.BtnCancel_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadArea(string areaid)
		{
			this.LstArea.DataSource = SmartAdmin.Data.Master.AreaList();
			this.LstArea.DataTextField = "areaname";
			this.LstArea.DataValueField = "areaid";
			this.LstArea.DataBind();
			for (int i = 0; i < this.LstArea.Items.Count; i++)
			{
				if (this.LstArea.Items[i].Value == areaid)
				{
					this.LstArea.SelectedIndex = i;
				}
			}
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
			this.LoadRoadType(item["roadtypeid"].ToString());
			this.LoadArea(item["areaid"].ToString());
		}

		private void LoadRoadType(string roadtypeid)
		{
			this.LstRoadType.DataSource = SmartAdmin.Data.Master.RoadTypeList();
			this.LstRoadType.DataTextField = "roadtypename";
			this.LstRoadType.DataValueField = "roadtypeid";
			this.LstRoadType.DataBind();
			for (int i = 0; i < this.LstRoadType.Items.Count; i++)
			{
				if (this.LstRoadType.Items[i].Value == roadtypeid)
				{
					this.LstRoadType.SelectedIndex = i;
				}
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