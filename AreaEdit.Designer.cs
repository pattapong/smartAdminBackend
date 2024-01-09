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
	public class AreaEdit : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnCancel;

		protected Button BtnSave;

		protected Image ImgError;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected HtmlForm AddPage;

		private int areaID;

		protected RequiredFieldValidator RequiredFieldValidator1;

		protected Label LblAreaID;

		protected Label LblAreaName;

		protected TextBox TxtAreaName;

		protected Label LblAreaType;

		protected DropDownList LstAreaType;

		protected Label TxtAreaID;

		protected ValidationSummary ValidationSummary1;

		public AreaEdit()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_AREA_LIST_PAGE));
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
                SmartAdmin.Data.Master.AreaUpdate(this.areaID, this.TxtAreaName.Text, this.LstAreaType.SelectedItem.Value);
				this.BackPage();
			}
		}

		private void InitializeComponent()
		{
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadArea()
		{
			DataTable dataTable = SmartAdmin.Data.Master.AreaList(this.areaID);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				base.Response.Redirect(Pages.Url(this, Pages.MAS_PAYMENT_LIST_PAGE));
				return;
			}
			DataRow item = dataTable.Rows[0];
			this.TxtAreaID.Text = this.areaID.ToString();
			this.TxtAreaName.Text = item["areaname"].ToString();
			this.LoadAreaType(item["areatypeid"].ToString());
		}

		private void LoadAreaType(string areatypeid)
		{
			this.LstAreaType.DataSource = SmartAdmin.Data.Master.AreaTypeList();
			this.LstAreaType.DataTextField = "areatypename";
			this.LstAreaType.DataValueField = "areatypeid";
			this.LstAreaType.DataBind();
			for (int i = 0; i < this.LstAreaType.Items.Count; i++)
			{
				if (this.LstAreaType.Items[i].Value == areatypeid)
				{
					this.LstAreaType.SelectedIndex = i;
				}
			}
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
			this.areaID = Pages.QueryInt(this, "id", -1);
			if (this.areaID <= 0)
			{
				this.BackPage();
			}
			if (!base.IsPostBack)
			{
				this.LoadArea();
			}
		}
	}
}