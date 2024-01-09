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
	public class FontInfo : System.Web.UI.Page
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

		protected Label LblMenuTypeName;

		protected Label LblFontID;

		protected Label TxtFontID;

		protected Label TxtFontDesc;

		protected Label LblFontName;

		protected Label TxtFontName;

		protected Label LblFontSize;

		protected Label TxtFontSize;

		protected Label LblFontBold;

		protected Label TxtFontBold;

		private int fontID;

		public FontInfo()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_FONT_LIST_PAGE));
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
			stringBuilder.Append(Pages.Url(this, Pages.MAS_FONT_EDIT_PAGE));
			stringBuilder.Append("?id=");
			stringBuilder.Append(this.fontID);
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
            SmartAdmin.Data.Master.FontDelete(this.fontID);
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
				this.TxtFontBold.Text = "Yes";
				return;
			}
			this.TxtFontBold.Text = "No";
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