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
	public class TableInfo : System.Web.UI.Page
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

		protected Label LblTableID;

		protected Label TxtTableID;

		protected Label TxtTableName;

		protected Label LblNumOfSeat;

		protected Label TxtNumberOfSeat;

		protected Label Label1;

		private int tableID;

		public TableInfo()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_TABLE_LIST_PAGE));
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
			stringBuilder.Append(Pages.Url(this, Pages.MAS_TABLE_EDIT_PAGE));
			stringBuilder.Append("?id=");
			stringBuilder.Append(this.tableID);
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
            SmartAdmin.Data.Master.TableDelete(this.tableID);
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