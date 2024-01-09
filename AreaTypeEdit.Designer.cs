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
	public class AreaTypeEdit : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnCancel;

		protected Button BtnSave;

		protected Image ImgError;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected HtmlForm AddPage;

		private int areaTypeID;

		protected RequiredFieldValidator RequiredFieldValidator1;

		protected Label LblAreaTypeID;

		protected Label LblAreaTypeName;

		protected Label TxtAreaTypeID;

		protected TextBox TxtAreaTypeName;

		protected ValidationSummary ValidationSummary1;

		public AreaTypeEdit()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_AREATYPE_LIST_PAGE));
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
                SmartAdmin.Data.Master.AreaTypeUpdate(this.areaTypeID, this.TxtAreaTypeName.Text);
				this.BackPage();
			}
		}

		private void InitializeComponent()
		{
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadAreaType()
		{
			DataTable dataTable = SmartAdmin.Data.Master.AreaTypeList(this.areaTypeID);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				base.Response.Redirect(Pages.Url(this, Pages.MAS_AREATYPE_LIST_PAGE));
				return;
			}
			DataRow item = dataTable.Rows[0];
			this.TxtAreaTypeID.Text = this.areaTypeID.ToString();
			this.TxtAreaTypeName.Text = item["areaTypeName"].ToString();
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
			this.areaTypeID = Pages.QueryInt(this, "id", -1);
			if (this.areaTypeID <= 0)
			{
				this.BackPage();
			}
			if (!base.IsPostBack)
			{
				this.LoadAreaType();
			}
		}
	}
}