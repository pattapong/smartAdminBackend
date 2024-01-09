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
	public class MenuInfo : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected Panel PanControl;

		protected Panel PanConfirm;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected Label LblConfirmDelete;

		protected Button BtnEdit;

		protected Button BtnDelete;

		protected Button BtnYes;

		protected Button BtnNo;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Label TxtMenuID;

		protected Label TxtMenuType;

		protected Label TxtKeyID;

		protected Label TxtEnglish;

		protected Label TxtThai;

		protected Label TxtFrench;

		protected Label TxtDescription;

		protected DataGrid OptionGrid;

		protected Label TxtPrice;

		protected Label TxtShortName;

		protected Label TxtMenuSet;

		protected Label TxtMenuSetInfo;

        protected Label TxtKeyIdText;

        protected Label TxtEstimateTime;

		private int menuID;

		public MenuInfo()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MENU_LIST_PAGE));
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
			stringBuilder.Append(Pages.Url(this, Pages.MENU_EDIT_PAGE));
			stringBuilder.Append("?id=");
			stringBuilder.Append(this.menuID);
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
            SmartAdmin.Data.Menu.MenuDelete(this.menuID);
			this.BackPage();
		}

		private void InitializeComponent()
		{
			this.OptionGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.OptionGrid_PageIndexChanged);
			this.BtnEdit.Click += new EventHandler(this.BtnEdit_Click);
			this.BtnDelete.Click += new EventHandler(this.BtnDelete_Click);
			this.BtnYes.Click += new EventHandler(this.BtnYes_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadMenu(int menuID)
		{
			DataTable dataTable = SmartAdmin.Data.Menu.MenuList(menuID);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				base.Response.Redirect(Pages.Url(this, Pages.MENU_LIST_PAGE));
				return;
			}
			DataRow item = dataTable.Rows[0];
			this.TxtMenuID.Text = menuID.ToString();
			this.TxtKeyID.Text = item["menukeyID"].ToString();
			this.TxtEnglish.Text = item["menunameenglish"].ToString();
			this.TxtThai.Text = item["menunamethai"].ToString();
			this.TxtFrench.Text = item["menunamefrench"].ToString();
			this.TxtShortName.Text = item["menushortname"].ToString();
			this.TxtMenuType.Text = item["menutypename"].ToString();
			this.TxtDescription.Text = item["menudescription"].ToString();
			this.TxtPrice.Text = item["pricestr"].ToString();
			this.TxtEstimateTime.Text = item["estimatetimestr"].ToString();
            this.TxtKeyIdText.Text = item["menukeyidtext"].ToString();

            if (item["menuset"].ToString() == "False")
			{
				this.TxtMenuSet.Text = "No";
				return;
			}
			this.TxtMenuSet.Text = "Yes";
			DataTable dataTable1 = SmartAdmin.Data.Menu.SubMenuByMenuList(menuID);
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

		private void LoadMenuDefault(int menuID)
		{
			this.OptionGrid.DataSource = SmartAdmin.Data.Menu.MenuDefaultList(menuID);
			this.OptionGrid.DataBind();
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void OptionGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.OptionGrid.CurrentPageIndex = e.NewPageIndex;
			this.LoadMenuDefault(this.menuID);
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
				this.LoadMenu(this.menuID);
				this.LoadMenuDefault(this.menuID);
			}
		}
	}
}