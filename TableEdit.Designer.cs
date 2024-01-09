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
	public class TableEdit : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnCancel;

		protected Button BtnSave;

		protected Image ImgError;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected HtmlForm AddPage;

		private int tableID;

		protected RequiredFieldValidator RequiredFieldValidator1;

		protected Label LblTableID;

		protected Label TxtTableID;

		protected Label LblTableName;

		protected TextBox TxtTableName;

		protected Label LblNumSeat;

		protected TextBox TxtNumberOfSeat;

		protected RequiredFieldValidator Requiredfieldvalidator2;

		protected RangeValidator RangeValidator1;

		protected ValidationSummary ValidationSummary1;

		public TableEdit()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_TABLE_LIST_PAGE));
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
                SmartAdmin.Data.Master.TableUpdate(this.tableID, this.TxtTableName.Text, this.TxtNumberOfSeat.Text);
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

		private void LoadTable()
		{
			DataTable dataTable = SmartAdmin.Data.Master.TableList(this.tableID);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				base.Response.Redirect(Pages.Url(this, Pages.MAS_TABLE_LIST_PAGE));
				return;
			}
			DataRow item = dataTable.Rows[0];
			this.TxtTableID.Text = this.tableID.ToString();
			this.TxtTableName.Text = item["tablename"].ToString();
			this.TxtNumberOfSeat.Text = item["numberofseat"].ToString();
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.LoadMenu();
			this.tableID = Pages.QueryInt(this, "id", -1);
			if (this.tableID <= 0)
			{
				this.BackPage();
			}
			if (!base.IsPostBack)
			{
				this.LoadTable();
			}
		}
	}
}