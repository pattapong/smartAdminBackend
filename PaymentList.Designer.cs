using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class PaymentList : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected DataGrid PaymentGrid;

		protected Button BtnAdd;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		public PaymentList()
		{
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(Pages.Url(this, Pages.MAS_PAYMENT_ADD_PAGE));
			base.Response.Redirect(stringBuilder.ToString());
		}

		private void InitializeComponent()
		{
			this.BtnAdd.Click += new EventHandler(this.BtnAdd_Click);
			this.PaymentGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.PaymentGrid_PageIndexChanged);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadPaymentList()
		{
			this.PaymentGrid.DataSource = SmartAdmin.Data.Master.PaymentList();
			this.PaymentGrid.DataBind();
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
				this.LoadPaymentList();
			}
		}

		private void PaymentGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.PaymentGrid.CurrentPageIndex = e.NewPageIndex;
			this.LoadPaymentList();
		}
	}
}