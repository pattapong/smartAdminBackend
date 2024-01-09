using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class TableAdd : System.Web.UI.Page
	{
		protected Button BtnSave;

		protected Button BtnCancel;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected ValidationSummary ValidationSummary1;

		protected RequiredFieldValidator RequiredFieldValidator1;

		protected Label LblTableID;

		protected Label TxtTableID;

		protected Label LblTableName;

		protected TextBox TxtTableName;

		protected Label LblNumSeat;

		protected TextBox TxtNumberOfSeat;

		protected RequiredFieldValidator Requiredfieldvalidator2;

		protected RangeValidator RangeValidator1;

		protected Image ImgError;

		public TableAdd()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_TABLE_LIST_PAGE));
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.BackPage();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
                SmartAdmin.Data.Master.TableInsert(this.TxtTableName.Text, this.TxtNumberOfSeat.Text);
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

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.LoadMenu();
		}
	}
}