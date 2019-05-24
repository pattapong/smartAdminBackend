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
	public class MenuEdit : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnCancel;

		protected Button BtnSave;

		protected Image ImgError;

		protected DropDownList LstType;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected HtmlForm AddPage;

		protected Button BtnAdd;

		protected Label TxtMenuID;

		protected TextBox TxtKeyID;

		protected RequiredFieldValidator RequiredFieldValidator1;

		protected TextBox TxtEnglish;

		protected RequiredFieldValidator RequiredFieldValidator2;

		protected TextBox TxtThai;

		protected TextBox TxtFrench;

		protected TextBox TxtDescription;

		protected TextBox TxtPrice;

		protected RequiredFieldValidator RequiredFieldValidator3;

		protected RangeValidator RangeValidator1;

		protected ValidationSummary ValidationSummary1;

		protected RadioButtonList RadioChoice;

		protected DropDownList LstOption;

		protected DataGrid MenuDefaultGrid;

		protected RangeValidator Rangevalidator2;

		private int menuID;

		protected TextBox TxtShortName;

		protected RequiredFieldValidator Requiredfieldvalidator4;

		protected Label TxtMenuSet;

		protected Label TxtMenuSetInfo;

		protected TextBox TxtEstimateTime;

		protected RegularExpressionValidator RegularExpressionValidator1;

		private string menutypeID;

		public MenuEdit()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MENU_LIST_PAGE));
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			SmartAdmin.Data.Menu.MenuDefaultInsert(this.menuID, int.Parse(this.LstOption.SelectedItem.Value), int.Parse(this.RadioChoice.SelectedItem.Value));
			this.LoadMenuOptionDefault();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.BackPage();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			SmartAdmin.Data.Menu.MenuUpdate(this.menuID, this.TxtKeyID.Text, this.LstType.SelectedItem.Value, this.TxtEnglish.Text, this.TxtThai.Text, this.TxtFrench.Text, this.TxtShortName.Text, this.TxtDescription.Text, this.TxtPrice.Text, this.TxtEstimateTime.Text);
			this.BackPage();
		}

		private void InitializeComponent()
		{
			this.LstOption.SelectedIndexChanged += new EventHandler(this.LstOption_SelectedIndexChanged);
			this.BtnAdd.Click += new EventHandler(this.BtnAdd_Click);
			this.MenuDefaultGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.MenuDefaultGrid_PageIndexChanged);
			this.MenuDefaultGrid.DeleteCommand += new DataGridCommandEventHandler(this.MenuDefaultGrid_DeleteCommand);
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			this.BtnCancel.Click += new EventHandler(this.BtnCancel_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadChoice(int OptionID)
		{
			this.RadioChoice.DataSource = SmartAdmin.Data.Master.MenuOptChoiceList(OptionID);
			this.RadioChoice.DataTextField = "ChoiceName";
			this.RadioChoice.DataValueField = "ChoiceID";
			this.RadioChoice.DataBind();
			this.RadioChoice.SelectedIndex = 0;
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadMenuDetail()
		{
			DataTable dataTable = SmartAdmin.Data.Menu.MenuList(this.menuID);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				base.Response.Redirect(Pages.Url(this, Pages.MENU_LIST_PAGE));
				return;
			}
			DataRow item = dataTable.Rows[0];
			this.TxtMenuID.Text = this.menuID.ToString();
			this.TxtKeyID.Text = item["menukeyID"].ToString();
			this.TxtEnglish.Text = item["menunameenglish"].ToString();
			this.TxtThai.Text = item["menunamethai"].ToString();
			this.TxtFrench.Text = item["menunamefrench"].ToString();
			this.TxtShortName.Text = item["menushortname"].ToString();
			this.TxtDescription.Text = item["menudescription"].ToString();
			this.TxtPrice.Text = item["pricestr"].ToString();
			this.TxtEstimateTime.Text = item["estimatetimestr"].ToString();
			this.menutypeID = item["menutypeid"].ToString();
			if (item["menuset"].ToString() == "False")
			{
				this.TxtMenuSet.Text = "No";
				return;
			}
			this.TxtMenuSet.Text = "Yes";
			DataTable dataTable1 = SmartAdmin.Data.Menu.SubMenuByMenuList(this.menuID);
			string str = "";
			for (int i = 0; i < dataTable1.Rows.Count; i++)
			{
				str = string.Concat(str, dataTable1.Rows[i]["menunameenglish"].ToString(), ", ");
			}
			if (str != "")
			{
				str = str.Substring(0, str.Length - 2);
			}
			this.TxtMenuSetInfo.Text = str;
		}

		private void LoadMenuOptionDefault()
		{
			this.LstOption.DataSource = SmartAdmin.Data.Master.MenuOptExcludeList(this.menuID);
			this.LstOption.DataTextField = "OptionName";
			this.LstOption.DataValueField = "OptionID";
			this.LstOption.DataBind();
			if (this.LstOption.Items.Count > 0)
			{
				string str = this.LstOption.SelectedItem.Value.ToString();
				if (str != null)
				{
					this.LoadChoice(int.Parse(str));
				}
			}
			this.MenuDefaultGrid.DataSource = SmartAdmin.Data.Menu.MenuDefaultList(this.menuID);
			this.MenuDefaultGrid.DataBind();
		}

		private void LoadMenuType()
		{
			this.LstType.DataSource = SmartAdmin.Data.Master.MenuTypeList();
			this.LstType.DataTextField = "MenuTypeName";
			this.LstType.DataValueField = "MenuTypeID";
			this.LstType.DataBind();
			if (this.menuID > 0)
			{
				for (int i = 0; i < this.LstType.Items.Count; i++)
				{
					if (this.LstType.Items[i].Value == this.menutypeID)
					{
						this.LstType.SelectedIndex = i;
					}
				}
			}
		}

		private void LstOption_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.LoadChoice(int.Parse(this.LstOption.SelectedItem.Value));
		}

		private void MenuDefaultGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
		{
			SmartAdmin.Data.Menu.MenuDefaultDelete(this.menuID, int.Parse(e.Item.Cells[0].Text));
			this.LoadMenuOptionDefault();
		}

		private void MenuDefaultGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.MenuDefaultGrid.CurrentPageIndex = e.NewPageIndex;
			this.LoadMenuOptionDefault();
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.LoadMenu();
			this.menuID = Pages.QueryInt(this, "id", -1);
			if (this.menuID <= 0)
			{
				this.BackPage();
			}
			if (!base.IsPostBack)
			{
				this.LoadMenuDetail();
				this.LoadMenuType();
				this.LoadMenuOptionDefault();
			}
		}
	}
}