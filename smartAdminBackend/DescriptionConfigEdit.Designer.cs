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
	public class DescriptionConfigEdit : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnCancel;

		protected Button BtnSave;

		protected Image ImgError;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected HtmlForm AddPage;

		private string descriptionID;

		protected RequiredFieldValidator RequiredFieldValidator1;

		protected Label LblDescription;

		protected TextBox TxtDescription;

		protected Label LblDescriptionID;

		protected Label TxtDescriptionID;

		protected Label LblLinkID;

		protected Label LblTypeName;

		protected Label TxtTypeName;

		protected Label TxtLinkID;

		protected ValidationSummary ValidationSummary1;

		public DescriptionConfigEdit()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_DES_LIST_PAGE));
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
                SmartAdmin.Data.Master.DescriptionUpdate(this.descriptionID, this.TxtDescription.Text, this.TxtLinkID.Text);
				this.BackPage();
			}
		}

		private void InitializeComponent()
		{
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadDescription()
		{
			DataTable dataTable = SmartAdmin.Data.Master.DescriptionList(this.descriptionID.ToString());
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				base.Response.Redirect(Pages.Url(this, Pages.MAS_DES_LIST_PAGE));
				return;
			}
			DataRow item = dataTable.Rows[0];
			this.TxtTypeName.Text = item["descriptiontypename"].ToString();
			this.TxtDescriptionID.Text = this.descriptionID.ToString();
			this.TxtDescription.Text = item["descriptiontext"].ToString();
			this.TxtLinkID.Text = item["descriptionlinkid"].ToString();
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
			this.descriptionID = Pages.QueryStr(this, "id", "");
			if (this.descriptionID == "")
			{
				this.BackPage();
			}
			if (!base.IsPostBack)
			{
				this.LoadDescription();
			}
		}
	}
}