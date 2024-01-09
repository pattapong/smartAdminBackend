using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class MenuTypeAdd : System.Web.UI.Page
	{
		protected Button BtnSave;

		protected Button BtnCancel;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected ValidationSummary ValidationSummary1;

		protected RequiredFieldValidator RequiredFieldValidator1;

		protected Label LblMenuTypeID;

		protected Label TxtMenuTypeID;

		protected Label LblMenuTypeName;

		protected TextBox TxtMenuTypeName;

		protected Label LblMenuTypeDescription;

		protected TextBox TxtMenuTypeDescription;

		protected RequiredFieldValidator Requiredfieldvalidator2;

		protected Label LblTax1;

		protected TextBox TxtTax1;

		protected RequiredFieldValidator Requiredfieldvalidator3;

		protected Label LblTax2;

		protected TextBox TxtTax2;

		protected RequiredFieldValidator Requiredfieldvalidator4;

		protected RangeValidator RangeValidator1;

		protected RangeValidator RangeValidator2;

		protected Label LblPrint;

		protected CheckBox CheckPrintLine;

		protected Label LblPaymentGroup;

		protected DropDownList LstMenuGroup;

		protected Image ImgError;

		public MenuTypeAdd()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_MENUTYPE_LIST_PAGE));
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.BackPage();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
				string str = "0";
				if (this.CheckPrintLine.Checked)
				{
					str = "1";
				}
                SmartAdmin.Data.Master.MenuTypeInsert(this.TxtMenuTypeName.Text, this.TxtMenuTypeDescription.Text, this.TxtTax1.Text, this.TxtTax2.Text, str, this.LstMenuGroup.SelectedItem.Value);
				this.BackPage();
			}
		}

		private void InitializeComponent()
		{
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			this.BtnCancel.Click += new EventHandler(this.BtnCancel_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadMenuGroup()
		{
			this.LstMenuGroup.DataSource = SmartAdmin.Data.Master.MenuGroupList();
			this.LstMenuGroup.DataTextField = "menugroupname";
			this.LstMenuGroup.DataValueField = "menugroupid";
			this.LstMenuGroup.DataBind();
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
			this.LoadMenuGroup();
		}
	}
}