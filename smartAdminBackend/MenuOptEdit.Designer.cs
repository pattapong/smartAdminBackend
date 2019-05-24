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
	public class MenuOptEdit : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnCancel;

		protected Button BtnSave;

		protected Image ImgError;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected HtmlForm AddPage;

		private int optionID;

		protected RequiredFieldValidator RequiredFieldValidator1;

		protected Label LblMenuOptionID;

		protected Label TxtMenuOptionID;

		protected Label LblMenuOptionName;

		protected TextBox TxtMenuOptionName;

		protected RequiredFieldValidator Requiredfieldvalidator2;

		protected DataGrid OptionChoiceGrid;

		protected Button BtnAdd;

		protected Label LblMenuOptionShortName;

		protected TextBox TxtMenuOptionShortName;

		protected RequiredFieldValidator Requiredfieldvalidator3;

		protected Label LblMenuOptionChoiceShort;

		protected TextBox TxtMenuOptionChoiceShort;

		protected Label LblMenuOptionChoice;

		protected TextBox TxtMenuOptionChoice;

		protected RequiredFieldValidator Requiredfieldvalidator4;

		protected ValidationSummary ValidationSummary1;

		public MenuOptEdit()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_MENUOPT_LIST_PAGE));
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
				if (this.ViewState["choiceID"] == null)
				{
                    SmartAdmin.Data.Master.MenuOptChoiceInsert(this.optionID, this.TxtMenuOptionChoice.Text, this.TxtMenuOptionChoiceShort.Text);
					this.BtnAdd.Text = "Add";
					this.LoadMenuOptionChoice();
					return;
				}
                SmartAdmin.Data.Master.MenuOptChoiceUpdate(int.Parse(this.ViewState["choiceID"].ToString()), this.TxtMenuOptionChoice.Text, this.TxtMenuOptionChoiceShort.Text);
				this.ViewState["choiceID"] = null;
				this.BtnAdd.Text = "Add";
				this.LoadMenuOptionChoice();
			}
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
            SmartAdmin.Data.Master.MenuOptUpdate(this.optionID, this.TxtMenuOptionName.Text, this.TxtMenuOptionShortName.Text);
			this.BackPage();
		}

		private void InitializeComponent()
		{
			this.BtnAdd.Click += new EventHandler(this.BtnAdd_Click);
			this.OptionChoiceGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.OptionChoiceGrid_PageIndexChanged);
			this.OptionChoiceGrid.EditCommand += new DataGridCommandEventHandler(this.OptionChoiceGrid_EditCommand);
			this.OptionChoiceGrid.DeleteCommand += new DataGridCommandEventHandler(this.OptionChoiceGrid_DeleteCommand);
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadMenuOption()
		{
			DataTable dataTable = SmartAdmin.Data.Master.MenuOptList(this.optionID);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				base.Response.Redirect(Pages.Url(this, Pages.MAS_MENUOPT_LIST_PAGE));
				return;
			}
			DataRow item = dataTable.Rows[0];
			this.TxtMenuOptionID.Text = this.optionID.ToString();
			this.TxtMenuOptionName.Text = item["optionname"].ToString();
			this.TxtMenuOptionShortName.Text = item["optionshortname"].ToString();
		}

		private void LoadMenuOptionChoice()
		{
			this.OptionChoiceGrid.DataSource = SmartAdmin.Data.Master.MenuOptChoiceList(this.optionID);
			this.OptionChoiceGrid.DataBind();
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void OptionChoiceGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
		{
            SmartAdmin.Data.Master.MenuOptChoiceDelete(int.Parse(this.OptionChoiceGrid.DataKeys[e.Item.ItemIndex].ToString()));
			this.LoadMenuOptionChoice();
		}

		private void OptionChoiceGrid_EditCommand(object source, DataGridCommandEventArgs e)
		{
			this.TxtMenuOptionChoice.Text = e.Item.Cells[1].Text;
			this.ViewState["choiceID"] = int.Parse(this.OptionChoiceGrid.DataKeys[e.Item.ItemIndex].ToString());
			this.BtnAdd.Text = "Save Edit";
		}

		private void OptionChoiceGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.OptionChoiceGrid.CurrentPageIndex = e.NewPageIndex;
			this.LoadMenuOptionChoice();
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.LoadMenu();
			this.optionID = Pages.QueryInt(this, "id", -1);
			if (this.optionID <= 0)
			{
				this.BackPage();
			}
			if (!base.IsPostBack)
			{
				this.LoadMenuOption();
				this.LoadMenuOptionChoice();
			}
		}
	}
}