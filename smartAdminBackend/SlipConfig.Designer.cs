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
	public class SlipConfig : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnCancel;

		protected Button BtnSave;

		protected Image ImgError;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected HtmlForm AddPage;

		protected CheckBoxList ChkConfig;

		protected ValidationSummary ValidationSummary1;

		public SlipConfig()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_SLIPCONFIG_PAGE));
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.BackPage();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			int count = this.ChkConfig.Items.Count;
			string str = "";
			for (int i = 0; i < count; i++)
			{
				str = (!this.ChkConfig.Items[i].Selected ? "0" : "1");
                SmartAdmin.Data.Master.SlipConfigUpdate(this.ChkConfig.Items[i].Value, str);
			}
			this.BackPage();
		}

		private void InitializeComponent()
		{
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			this.BtnCancel.Click += new EventHandler(this.BtnCancel_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadConfig()
		{
			DataTable dataTable = SmartAdmin.Data.Master.SlipConfigList();
			this.ChkConfig.DataSource = dataTable;
			this.ChkConfig.DataTextField = "configname";
			this.ChkConfig.DataValueField = "configid";
			this.ChkConfig.DataBind();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				if (dataTable.Rows[i]["configvalue"].ToString() == "1")
				{
					this.ChkConfig.Items[i].Selected = true;
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
			if (!base.IsPostBack)
			{
				this.LoadConfig();
			}
		}
	}
}