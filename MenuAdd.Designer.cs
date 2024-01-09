using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class MenuAdd : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected DropDownList LstType;

		protected TextBox TxtKeyID;

		protected TextBox TxtEnglish;

		protected TextBox TxtThai;

		protected TextBox TxtFrench;

		protected TextBox TxtPrice;

		protected Image ImgError;

		protected Button BtnSave;

		protected Button BtnCancel;

		protected TextBox TxtDescription;

		protected ValidationSummary ValidationSummary1;

		protected RequiredFieldValidator RequiredFieldValidator1;

		protected RequiredFieldValidator RequiredFieldValidator2;

		protected RequiredFieldValidator RequiredFieldValidator3;

		protected RangeValidator RangeValidator1;

		protected TextBox TxtShortName;

		protected RequiredFieldValidator RequiredFieldValidator4;

		protected RadioButtonList MenuSet;

		protected Button BtnAdd;

		protected DataGrid SubMenuGrid;

		protected DropDownList LstSubMenu;

		protected DropDownList LstMenuType;

		protected Label TxtMenuID;

		protected TextBox TxtEstimateTime;

		protected HtmlTableRow MenuSetInfo_Row;

		protected HtmlTableRow MenuSetType_Row;

		protected HtmlTableRow MenuSetMenu_Row;

		private DataTable dt = new DataTable();

		protected TextBox TxtKeyText;

		protected RequiredFieldValidator Requiredfieldvalidator5;

		protected RegularExpressionValidator RegularExpressionValidator1;

		private DataRow row;

		public MenuAdd()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MENU_LIST_PAGE));
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			this.row = this.dt.NewRow();
			this.row["menuid"] = this.LstSubMenu.SelectedItem.Value;
			this.row["menuname"] = this.LstSubMenu.SelectedItem.Text;
			this.dt.Rows.Add(this.row);
			this.LoadSubMenuGrid();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.BackPage();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			int num = SmartAdmin.Data.Menu.MenuInsert(this.TxtKeyID.Text, this.LstType.SelectedItem.Value, this.TxtEnglish.Text, this.TxtThai.Text, this.TxtFrench.Text, this.TxtShortName.Text, this.TxtDescription.Text, this.TxtPrice.Text, this.MenuSet.SelectedItem.Value, this.TxtEstimateTime.Text);
			for (int i = 0; i < this.dt.Rows.Count; i++)
			{
                SmartAdmin.Data.Menu.SubMenuInsert(num, int.Parse(this.dt.Rows[i]["menuid"].ToString()));
			}
			this.NextPage();
		}

		private void InitializeComponent()
		{
			this.MenuSet.SelectedIndexChanged += new EventHandler(this.MenuSet_SelectedIndexChanged);
			this.BtnAdd.Click += new EventHandler(this.BtnAdd_Click);
			this.SubMenuGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.SubMenuGrid_PageIndexChanged);
			this.SubMenuGrid.DeleteCommand += new DataGridCommandEventHandler(this.SubMenuGrid_DeleteCommand);
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			this.BtnCancel.Click += new EventHandler(this.BtnCancel_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadMenuType()
		{
			this.LstType.DataSource = SmartAdmin.Data.Master.MenuTypeList();
			this.LstType.DataTextField = "MenuTypeName";
			this.LstType.DataValueField = "MenuTypeID";
			this.LstType.DataBind();
			this.LstMenuType.DataSource = SmartAdmin.Data.Master.MenuTypeList();
			this.LstMenuType.DataTextField = "MenuTypeName";
			this.LstMenuType.DataValueField = "MenuTypeID";
			this.LstMenuType.DataBind();
			this.LstMenuType.SelectedIndex = 0;
			this.LoadSubMenu(int.Parse(this.LstMenuType.SelectedItem.Value));
		}

		private void LoadSubMenu(int menutypeid)
		{
			this.LstSubMenu.DataSource = SmartAdmin.Data.Menu.SubMenuByTypeList(menutypeid);
			this.LstSubMenu.DataTextField = "MenuNameEnglish";
			this.LstSubMenu.DataValueField = "MenuID";
			this.LstSubMenu.DataBind();
		}

		private void LoadSubMenuGrid()
		{
			this.SubMenuGrid.DataSource = this.dt;
			this.SubMenuGrid.DataBind();
			this.SubMenuGrid.Visible = true;
		}

		private void LstMenuType_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.LoadSubMenu(int.Parse(this.LstMenuType.SelectedItem.Value));
		}

		private void MenuSet_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.MenuSet.SelectedItem.Value == "1")
			{
				this.MenuSetInfo_Row.Visible = true;
				this.MenuSetType_Row.Visible = true;
				this.MenuSetMenu_Row.Visible = true;
				return;
			}
			this.MenuSetInfo_Row.Visible = false;
			this.MenuSetType_Row.Visible = false;
			this.MenuSetMenu_Row.Visible = false;
		}

		private void NextPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MENU_EDIT_PAGE));
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.LoadMenu();
			if (base.IsPostBack)
			{
				this.dt = (DataTable)this.Session["submenu"];
				return;
			}
			this.dt.Columns.Add("menuid", typeof(string));
			this.dt.Columns.Add("menuname", typeof(string));
			this.Session["submenu"] = this.dt;
			this.TxtEstimateTime.Text = "00:00";
			this.MenuSetInfo_Row.Visible = false;
			this.MenuSetType_Row.Visible = false;
			this.MenuSetMenu_Row.Visible = false;
			this.LoadMenuType();
		}

		private void SubMenuGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
		{
			this.dt.Rows.RemoveAt(e.Item.ItemIndex);
			this.LoadSubMenuGrid();
		}

		private void SubMenuGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.SubMenuGrid.CurrentPageIndex = e.NewPageIndex;
			this.LoadSubMenuGrid();
		}
	}
}