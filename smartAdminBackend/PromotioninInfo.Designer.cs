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
	public class PromotioninInfo : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected Panel PanControl;

		protected Panel PanConfirm;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected Label LblConfirmDelete;

		protected Button BtnEdit;

		protected Button BtnDelete;

		protected Button BtnYes;

		protected Button BtnNo;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Label TxtDescription;

		protected Label TxtProID;

		protected Label TxtPromoType;

		protected Label TxtAmount;

		protected Label TxtDiscount;

		protected Label TxtMenuType;

		protected Label TxtMenu;

		protected Label TxtPoint;

		protected Label TxtValidfrom;

		protected Label TxtValidto;

		protected Label TxtDiscountAmount;

		protected Repeater RptDay6;

		protected Repeater RptDay5;

		protected Repeater RptDay4;

		protected Repeater RptDay3;

		protected Repeater RptDay2;

		protected Repeater RptDay1;

		protected Repeater RptDay0;

		protected Repeater RepeatTime;

		private int proID;

		public PromotioninInfo()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.PRO_LIST_PAGE));
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
			stringBuilder.Append(Pages.Url(this, Pages.PRO_EDIT_PAGE));
			stringBuilder.Append("?id=");
			stringBuilder.Append(this.proID);
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
			Promotion.PromotionDelete(this.proID);
			this.BackPage();
		}

		private void InitializeComponent()
		{
			this.BtnEdit.Click += new EventHandler(this.BtnEdit_Click);
			this.BtnDelete.Click += new EventHandler(this.BtnDelete_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadPromotion(int proID)
		{
			DataTable dataTable = Promotion.PromotionList(proID);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				base.Response.Redirect(Pages.Url(this, Pages.PRO_LIST_PAGE));
				return;
			}
			DataRow item = dataTable.Rows[0];
			this.TxtProID.Text = proID.ToString();
			this.TxtPromoType.Text = item["protypename"].ToString();
			this.TxtDescription.Text = item["description"].ToString();
			this.TxtAmount.Text = item["amountstr"].ToString();
			this.TxtDiscount.Text = item["discountstr"].ToString();
			this.TxtDiscountAmount.Text = item["discountamountstr"].ToString();
			this.TxtMenuType.Text = item["menutypename"].ToString();
			this.TxtMenu.Text = item["menunameenglish"].ToString();
			this.TxtMenuType.Text = item["menutypename"].ToString();
			this.TxtPoint.Text = item["point"].ToString();
			this.TxtValidfrom.Text = item["validfromstr"].ToString();
			this.TxtValidto.Text = item["validtostr"].ToString();
		}

		private void LoadPromotionTime(int proID)
		{
			DataTable dataTable = Promotion.PromotionTimeList(proID);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow item = dataTable.Rows[i];
				this.setTime(int.Parse(item["proday"].ToString()), item["timeid"].ToString());
			}
		}

		private void LoadTime()
		{
			this.RepeatTime.DataSource = SmartAdmin.Data.Master.ShowTimeList();
			this.RepeatTime.DataMember = "TimeName";
			this.RepeatTime.DataBind();
			DataTable dataTable = SmartAdmin.Data.Master.ShowTimeList();
			dataTable.Columns.Add("Selected", typeof(string));
			this.RptDay0.DataSource = dataTable;
			this.RptDay0.DataBind();
			dataTable = SmartAdmin.Data.Master.ShowTimeList();
			dataTable.Columns.Add("Selected", typeof(string));
			this.RptDay1.DataSource = dataTable;
			this.RptDay1.DataBind();
			dataTable = SmartAdmin.Data.Master.ShowTimeList();
			dataTable.Columns.Add("Selected", typeof(string));
			this.RptDay2.DataSource = dataTable;
			this.RptDay2.DataBind();
			dataTable = SmartAdmin.Data.Master.ShowTimeList();
			dataTable.Columns.Add("Selected", typeof(string));
			this.RptDay3.DataSource = dataTable;
			this.RptDay3.DataBind();
			dataTable = SmartAdmin.Data.Master.ShowTimeList();
			dataTable.Columns.Add("Selected", typeof(string));
			this.RptDay4.DataSource = dataTable;
			this.RptDay4.DataBind();
			dataTable = SmartAdmin.Data.Master.ShowTimeList();
			dataTable.Columns.Add("Selected", typeof(string));
			this.RptDay5.DataSource = dataTable;
			this.RptDay5.DataBind();
			dataTable = SmartAdmin.Data.Master.ShowTimeList();
			dataTable.Columns.Add("Selected", typeof(string));
			this.RptDay6.DataSource = dataTable;
			this.RptDay6.DataBind();
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.LoadMenu();
			this.proID = Pages.QueryInt(this, "id", -1);
			if (this.proID <= 0)
			{
				this.BackPage();
			}
			if (!base.IsPostBack)
			{
				this.LoadPromotion(this.proID);
				this.LoadTime();
				this.LoadPromotionTime(this.proID);
			}
		}

		private void setTime(int dayin, string timein)
		{
			Repeater rptDay0;
			switch (dayin)
			{
				case 0:
				{
					rptDay0 = this.RptDay0;
					break;
				}
				case 1:
				{
					rptDay0 = this.RptDay1;
					break;
				}
				case 2:
				{
					rptDay0 = this.RptDay2;
					break;
				}
				case 3:
				{
					rptDay0 = this.RptDay3;
					break;
				}
				case 4:
				{
					rptDay0 = this.RptDay4;
					break;
				}
				case 5:
				{
					rptDay0 = this.RptDay5;
					break;
				}
				case 6:
				{
					rptDay0 = this.RptDay6;
					break;
				}
				default:
				{
					return;
				}
			}
			for (int i = 0; i < this.RepeatTime.Items.Count; i++)
			{
				DataTable dataSource = (DataTable)rptDay0.DataSource;
				if (dataSource.Rows[i]["TimeID"].ToString() == timein)
				{
					dataSource.Rows[i]["Selected"] = "1";
					rptDay0.DataBind();
				}
			}
		}
	}
}