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
	public class FontEdit : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnCancel;

		protected Button BtnSave;

		protected Image ImgError;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected HtmlForm AddPage;

		private int fontID;

		protected RequiredFieldValidator RequiredFieldValidator1;

		protected RequiredFieldValidator Requiredfieldvalidator2;

		protected Label LblFontID;

		protected Label TxtFontID;

		protected Label LblFontDesc;

		protected TextBox TxtFontDesc;

		protected Label LblFontName;

		protected TextBox TxtFontName;

		protected Label LblFontSize;

		protected TextBox TxtFontSize;

		protected RequiredFieldValidator Requiredfieldvalidator3;

		protected RangeValidator RangeValidator1;

		protected RadioButtonList RadioFontBold;

		protected ValidationSummary ValidationSummary1;

		public FontEdit()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_FONT_LIST_PAGE));
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
                SmartAdmin.Data.Master.FontUpdate(this.fontID.ToString(), this.TxtFontDesc.Text, this.TxtFontName.Text, this.TxtFontSize.Text, this.RadioFontBold.SelectedItem.Value);
				this.BackPage();
			}
		}

		private void InitializeComponent()
		{
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadFont()
		{
			DataTable dataTable = SmartAdmin.Data.Master.FontList(this.fontID);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				base.Response.Redirect(Pages.Url(this, Pages.MAS_FONT_LIST_PAGE));
				return;
			}
			DataRow item = dataTable.Rows[0];
			this.TxtFontID.Text = this.fontID.ToString();
			this.TxtFontDesc.Text = item["fontdesc"].ToString();
			this.TxtFontName.Text = item["fontname"].ToString();
			this.TxtFontSize.Text = item["fontsize"].ToString();
			if (item["fontbold"].ToString() == "1")
			{
				this.RadioFontBold.SelectedIndex = 0;
				return;
			}
			this.RadioFontBold.SelectedIndex = 1;
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
			this.fontID = Pages.QueryInt(this, "id", -1);
			if (this.fontID <= 0)
			{
				this.BackPage();
			}
			if (!base.IsPostBack)
			{
				this.LoadFont();
			}
		}
	}
}