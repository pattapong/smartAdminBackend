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
	public class MenuTypeInfo : System.Web.UI.Page
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

		protected Label LblMenuTypeID;

		protected Label TxtMenuTypeID;

		protected Label LblMenuTypeName;

		protected Label TxtMenuTypeName;

		protected Label TxtMenuTypeDescription;

		protected Label LblMenuTypeDescription;

		protected Label LblTax2;

		protected Label TxtTax2;

		protected Label LblTax1;

		protected Label TxtTax1;

		protected Label Lblprintline;

		protected Label TxtPrintLine;

		protected Label LblMenuGroup;

		protected Label TxtMenuGroup;

		private int menutypeID;

		public MenuTypeInfo()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_MENUTYPE_LIST_PAGE));
		}

		private void BtnDelete_Click(object sender, EventArgs e)
		{
			this.LblConfirmDelete.Visible = true;
			this.PanConfirm.Visible = true;
			this.PanControl.Visible = false;
		}

		private void BtnEdit_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(Pages.Url(this, Pages.MAS_MENUTYPE_EDIT_PAGE));
			stringBuilder.Append("?id=");
			stringBuilder.Append(this.menutypeID);
			base.Response.Redirect(stringBuilder.ToString());
		}

		private void BtnNo_Click(object sender, EventArgs e)
		{
			this.LblConfirmDelete.Visible = false;
			this.PanConfirm.Visible = false;
			this.PanControl.Visible = true;
		}

		private void BtnYes_Click(object sender, EventArgs e)
		{
            SmartAdmin.Data.Master.MenuTypeDelete(this.menutypeID);
			this.BackPage();
		}

		private void InitializeComponent()
		{
			this.BtnEdit.Click += new EventHandler(this.BtnEdit_Click);
			this.BtnDelete.Click += new EventHandler(this.BtnDelete_Click);
			this.BtnYes.Click += new EventHandler(this.BtnYes_Click);
			this.BtnNo.Click += new EventHandler(this.BtnNo_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadMenuType()
		{
			DataTable dataTable = SmartAdmin.Data.Master.MenuTypeList(this.menutypeID);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				base.Response.Redirect(Pages.Url(this, Pages.MAS_MENUTYPE_LIST_PAGE));
				return;
			}
			DataRow item = dataTable.Rows[0];
			this.TxtMenuTypeID.Text = this.menutypeID.ToString();
			this.TxtMenuTypeName.Text = item["menutypename"].ToString();
			this.TxtMenuTypeDescription.Text = item["menutypedescription"].ToString();
			this.TxtTax1.Text = item["tax1"].ToString();
			this.TxtTax2.Text = item["tax2"].ToString();
			if (item["printline"].ToString() != "1")
			{
				this.TxtPrintLine.Text = "No";
			}
			else
			{
				this.TxtPrintLine.Text = "Yes";
			}
			this.TxtMenuGroup.Text = item["menugroupname"].ToString();
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.LoadMenu();
			this.LblTax1.Text = SmartAdmin.Data.Master.GetDescription("TAX1");
			this.LblTax2.Text = SmartAdmin.Data.Master.GetDescription("TAX2");
			if (this.LblTax2.Text == "")
			{
				this.LblTax2.Visible = false;
				this.TxtTax2.Visible = false;
			}
			this.menutypeID = Pages.QueryInt(this, "id", -1);
			if (this.menutypeID <= 0)
			{
				this.BackPage();
			}
			if (!base.IsPostBack)
			{
				this.LoadMenuType();
			}
		}
	}
}