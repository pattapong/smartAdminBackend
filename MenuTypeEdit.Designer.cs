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
	public class MenuTypeEdit : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnCancel;

		protected Button BtnSave;

		protected Image ImgError;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected HtmlForm AddPage;

		private int menutypeID;

		protected RequiredFieldValidator RequiredFieldValidator1;

		protected Label LblMenuTypeID;

		protected Label LblMenuTypeName;

		protected Label TxtMenuTypeID;

		protected TextBox TxtMenuTypeName;

		protected Label LblMenuTypeDescription;

		protected TextBox TxtMenuTypeDescription;

		protected RequiredFieldValidator Requiredfieldvalidator2;

		protected Label LblTax1;

		protected TextBox TxtTax1;

		protected RequiredFieldValidator Requiredfieldvalidator3;

		protected RangeValidator RangeValidator1;

		protected Label LblTax2;

		protected TextBox TxtTax2;

		protected RequiredFieldValidator Requiredfieldvalidator4;

		protected RangeValidator RangeValidator2;

		protected Label LblPrint;

		protected CheckBox CheckPrintLine;

		protected Label LblPaymentGroup;

		protected DropDownList LstMenuGroup;

		protected ValidationSummary ValidationSummary1;

		public MenuTypeEdit()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_MENUTYPE_LIST_PAGE));
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
                SmartAdmin.Data.Master.MenuTypeUpdate(this.menutypeID, this.TxtMenuTypeName.Text, this.TxtMenuTypeDescription.Text, this.TxtTax1.Text, this.TxtTax2.Text, str, this.LstMenuGroup.SelectedItem.Value);
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

		private void LoadMenuGroup(string menugroupid)
		{
			this.LstMenuGroup.DataSource = SmartAdmin.Data.Master.MenuGroupList();
			this.LstMenuGroup.DataTextField = "menugroupname";
			this.LstMenuGroup.DataValueField = "menugroupid";
			this.LstMenuGroup.DataBind();
			for (int i = 0; i < this.LstMenuGroup.Items.Count; i++)
			{
				if (this.LstMenuGroup.Items[i].Value == menugroupid)
				{
					this.LstMenuGroup.SelectedIndex = i;
				}
			}
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
				this.CheckPrintLine.Checked = false;
			}
			else
			{
				this.CheckPrintLine.Checked = true;
			}
			this.LoadMenuGroup(item["typegroupid"].ToString());
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