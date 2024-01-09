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
	public class PaymentEdit : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnCancel;

		protected Button BtnSave;

		protected Image ImgError;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected HtmlForm AddPage;

		private int paymentID;

		protected RequiredFieldValidator RequiredFieldValidator1;

		protected Label LblPaymentID;

		protected Label TxtPaymentID;

		protected Label LblPaymentName;

		protected TextBox TxtPaymentName;

		protected Label LblPaymentGroup;

		protected DropDownList LstPaymentGroup;

		protected ValidationSummary ValidationSummary1;

		public PaymentEdit()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_PAYMENT_LIST_PAGE));
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
                SmartAdmin.Data.Master.PaymentUpdate(this.paymentID, this.TxtPaymentName.Text, this.LstPaymentGroup.SelectedItem.Value);
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

		private void LoadPayment()
		{
			DataTable dataTable = SmartAdmin.Data.Master.PaymentList(this.paymentID);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				base.Response.Redirect(Pages.Url(this, Pages.MAS_PAYMENT_LIST_PAGE));
				return;
			}
			DataRow item = dataTable.Rows[0];
			this.TxtPaymentID.Text = this.paymentID.ToString();
			this.TxtPaymentName.Text = item["paymentmethodname"].ToString();
			this.LoadPaymentGroup(item["paymentgroupid"].ToString());
		}

		private void LoadPaymentGroup(string paymentgroupid)
		{
			this.LstPaymentGroup.DataSource = SmartAdmin.Data.Master.PaymentGroupList();
			this.LstPaymentGroup.DataTextField = "paymentgroupname";
			this.LstPaymentGroup.DataValueField = "paymentgroupid";
			this.LstPaymentGroup.DataBind();
			for (int i = 0; i < this.LstPaymentGroup.Items.Count; i++)
			{
				if (this.LstPaymentGroup.Items[i].Value == paymentgroupid)
				{
					this.LstPaymentGroup.SelectedIndex = i;
				}
			}
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.LoadMenu();
			this.paymentID = Pages.QueryInt(this, "id", -1);
			if (this.paymentID <= 0)
			{
				this.BackPage();
			}
			if (!base.IsPostBack)
			{
				this.LoadPayment();
			}
		}
	}
}