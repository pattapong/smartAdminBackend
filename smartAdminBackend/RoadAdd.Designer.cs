using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class RoadAdd : System.Web.UI.Page
	{
		protected Button BtnSave;

		protected Button BtnCancel;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected ValidationSummary ValidationSummary1;

		protected RequiredFieldValidator RequiredFieldValidator1;

		protected Label LblRoadID;

		protected Label TxtRoadID;

		protected Label LblRoadName;

		protected TextBox TxtRoadName;

		protected Label LblRoadType;

		protected DropDownList LstRoadType;

		protected Label LblArea;

		protected DropDownList LstArea;

		protected Image ImgError;

		public RoadAdd()
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
                SmartAdmin.Data.Master.RoadInsert(this.TxtRoadName.Text, this.LstRoadType.SelectedItem.Value, this.LstArea.SelectedItem.Value);
				this.BackPage();
			}
		}

		private void InitializeComponent()
		{
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			this.BtnCancel.Click += new EventHandler(this.BtnCancel_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadArea()
		{
			this.LstArea.DataSource = SmartAdmin.Data.Master.AreaList();
			this.LstArea.DataTextField = "areaname";
			this.LstArea.DataValueField = "areaid";
			this.LstArea.DataBind();
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadRoadType()
		{
			this.LstRoadType.DataSource = SmartAdmin.Data.Master.RoadTypeList();
			this.LstRoadType.DataTextField = "roadtypename";
			this.LstRoadType.DataValueField = "roadtypeid";
			this.LstRoadType.DataBind();
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
				this.LoadRoadType();
				this.LoadArea();
			}
		}
	}
}