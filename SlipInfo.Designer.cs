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
	public class SlipInfo : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected Panel PanControl;

		protected Panel PanConfirm;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected Button BtnEdit;

		protected Button BtnYes;

		protected Button BtnNo;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Label TxtSlipID;

		protected Label TxtHeader;

		protected Label TxtBody;

		protected Label TxtOption1;

		protected Label TxtOption2;

		protected Label LblOption1;

		protected Label LblOption2;

		private string slipID;

		public SlipInfo()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_SLIPSTYLE_LIST_PAGE));
		}

		private void BtnEdit_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(Pages.Url(this, Pages.MAS_SLIPSTYLE_EDIT_PAGE));
			stringBuilder.Append("?id=");
			stringBuilder.Append(this.slipID);
			base.Response.Redirect(stringBuilder.ToString());
		}

		private void InitializeComponent()
		{
			this.BtnEdit.Click += new EventHandler(this.BtnEdit_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadSlip(string slipID)
		{
			DataTable dataTable =SmartAdmin.Data.Master.SlipStyleList(slipID);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				base.Response.Redirect(Pages.Url(this, Pages.MAS_SLIPSTYLE_LIST_PAGE));
				return;
			}
			DataRow item = dataTable.Rows[0];
			this.TxtSlipID.Text = slipID.ToString();
			this.TxtHeader.Text = item["HeaderFontDesc"].ToString();
			this.TxtBody.Text = item["BodyFontDesc"].ToString();
			this.TxtOption1.Text = item["Option1FontDesc"].ToString();
			this.TxtOption2.Text = item["Option2FontDesc"].ToString();
			if (slipID == "KIT")
			{
				this.LblOption1.Text = "Option";
				this.LblOption2.Text = "Memo";
				return;
			}
			this.LblOption1.Text = "Tax";
			this.LblOption2.Text = "Total";
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.LoadMenu();
			this.slipID = Pages.QueryStr(this, "id", "-1");
			if (this.slipID == "-1")
			{
				this.BackPage();
			}
			if (!base.IsPostBack)
			{
				this.LoadSlip(this.slipID);
			}
		}
	}
}