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
	public class SumYear : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnShow;

		protected TextBox TxtYearfrom;

		protected TextBox TxtYearto;

		protected DataGrid ReportGrid;

		public SumYear()
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
			string str = DateTime.Now.Year.ToString();
			this.TxtYearfrom.Text = str;
			this.TxtYearto.Text = str;
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadReport()
		{
			DataTable dataTable = Report.SumYear(int.Parse(this.TxtYearfrom.Text), int.Parse(this.TxtYearto.Text));
			DataRow dataRow = dataTable.NewRow();
			dataRow["yr"] = "Total";
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