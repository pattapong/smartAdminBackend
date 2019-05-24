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
	public class ShiftEdit : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnCancel;

		protected Button BtnSave;

		protected Image ImgError;

		protected HtmlForm AddPage;

		private int TimeID;

		protected RequiredFieldValidator RequiredFieldValidator1;

		protected RequiredFieldValidator RequiredFieldValidator2;

		protected RequiredFieldValidator RequiredFieldValidator3;

		protected ValidationSummary ValidationSummary1;

		protected Label TxtTimeID;

		protected Label LblTimeID;

		protected Label LblTimename;

		protected TextBox TxtTimename;

		protected Label LblTimefrom;

		protected TextBox TxtTimefrom;

		protected TextBox TxtTimeto;

		protected Label LblTimeto;

		public ShiftEdit()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_TIME_LIST_PAGE));
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
                SmartAdmin.Data.Master.TimeUpdate(this.TimeID, this.TxtTimename.Text, this.TxtTimefrom.Text, this.TxtTimeto.Text);
				this.BackPage();
			}
		}

		private void InitializeComponent()
		{
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadTimeInfo()
		{
			DataTable dataTable = SmartAdmin.Data.Master.TimeList(this.TimeID);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				base.Response.Redirect(Pages.Url(this, Pages.MAS_TIME_LIST_PAGE));
				return;
			}
			DataRow item = dataTable.Rows[0];
			this.TxtTimeID.Text = this.TimeID.ToString();
			this.TxtTimename.Text = item["timename"].ToString();
			this.TxtTimefrom.Text = item["timefrom"].ToString();
			this.TxtTimeto.Text = item["timeto"].ToString();
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.LoadMenu();
			this.TimeID = Pages.QueryInt(this, "id", -1);
			if (this.TimeID <= 0)
			{
				this.BackPage();
			}
			if (!base.IsPostBack)
			{
				this.LoadTimeInfo();
			}
		}
	}
}