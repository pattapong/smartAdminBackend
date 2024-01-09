using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class TimeAdd : System.Web.UI.Page
	{
		protected Button BtnSave;

		protected Button BtnCancel;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected ValidationSummary ValidationSummary1;

		protected Label LblShiftID;

		protected Label TxtShiftID;

		protected Label LblShiftDayto;

		protected DropDownList LstShiftDayto;

		protected TextBox TxtShiftTimefrom;

		protected RequiredFieldValidator Requiredfieldvalidator2;

		protected TextBox TxtShiftTimeto;

		protected RequiredFieldValidator Requiredfieldvalidator3;

		protected Label LblShiftDescription;

		protected TextBox TxtShiftDescription;

		protected RequiredFieldValidator Requiredfieldvalidator4;

		protected Label LblShiftDayfrom;

		protected DropDownList LstShiftDayfrom;

		protected Image ImgError;

		protected Label LblTimeID;

		protected Label TxtTimeID;

		protected RequiredFieldValidator Requiredfieldvalidator1;

		protected TextBox TxtTimefrom;

		protected TextBox TxtTimeto;

		protected Label LblTimename;

		protected TextBox TxtTimename;

		protected Label LblTimefrom;

		protected Label LblTimeto;

		public TimeAdd()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_TIME_LIST_PAGE));
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.BackPage();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
                SmartAdmin.Data.Master.TimeInsert(this.TxtTimename.Text, this.TxtTimefrom.Text, this.TxtTimeto.Text);
				this.BackPage();
			}
		}

		private void InitializeComponent()
		{
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			this.BtnCancel.Click += new EventHandler(this.BtnCancel_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadDefaultDate()
		{
			this.TxtTimefrom.Text = "08:00:00";
			this.TxtTimeto.Text = "12:00:00";
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
			if (!base.IsPostBack)
			{
				this.LoadDefaultDate();
			}
		}
	}
}