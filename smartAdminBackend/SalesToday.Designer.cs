using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class SalesToday : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnShow;

		protected DropDownList LstPeriod;

		protected DataGrid ReportGrid;

		protected DropDownList LstPayment;

		public SalesToday()
		{
		}

		private void BtnShow_Click(object sender, EventArgs e)
		{
			this.LoadReport();
		}

		private void InitializeComponent()
		{
			this.BtnShow.Click += new EventHandler(this.BtnShow_Click);
			this.ReportGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.ReportGrid_PageIndexChanged);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadCriteria()
		{
			DataTable dataTable = SmartAdmin.Data.Master.TimeList();
			DataRow dataRow = dataTable.NewRow();
			dataRow["TimeName"] = "==All==";
			dataRow["TimeID"] = "0";
			dataTable.Rows.InsertAt(dataRow, 0);
			this.LstPeriod.DataSource = dataTable;
			this.LstPeriod.DataTextField = "TimeName";
			this.LstPeriod.DataValueField = "TimeID";
			this.LstPeriod.DataBind();
			this.LstPeriod.SelectedIndex = 0;
			dataTable = SmartAdmin.Data.Master.PaymentList();
			dataRow = dataTable.NewRow();
			dataRow["paymentmethodname"] = "==All==";
			dataRow["paymentmethodid"] = "0";
			dataTable.Rows.InsertAt(dataRow, 0);
			this.LstPayment.DataSource = dataTable;
			this.LstPayment.DataTextField = "paymentmethodname";
			this.LstPayment.DataValueField = "paymentmethodid";
			this.LstPayment.DataBind();
			this.LstPayment.SelectedIndex = 0;
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadReport()
		{
			DataTable dataTable = Report.SalesToday(int.Parse(this.LstPeriod.SelectedItem.Value), int.Parse(this.LstPayment.SelectedItem.Value));
			DataRow dataRow = dataTable.NewRow();
			dataRow["Timename"] = "Total";
			dataRow["paymentmethodname"] = "";
			object obj = dataTable.Compute("Sum(sumamt)", "");
			if (obj is DBNull)
			{
				dataRow["sumamt"] = 0;
			}
			else
			{
				dataRow["sumamt"] = decimal.Parse(obj.ToString());
			}
			dataTable.Rows.Add(dataRow);
			this.ReportGrid.DataSource = dataTable;
			this.ReportGrid.DataBind();
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
				this.LoadCriteria();
				this.LoadReport();
			}
		}

		private void ReportGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.ReportGrid.CurrentPageIndex = e.NewPageIndex;
			this.LoadReport();
		}
	}
}