using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class GraphYearly : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnShow;

		protected TextBox TxtYearfrom;

		protected TextBox TxtYearto;

		protected DataGrid ReportGrid;

		public GraphYearly()
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
			this.ReportGrid.DataSource = Report.SumYearly(int.Parse(this.TxtYearfrom.Text), int.Parse(this.TxtYearto.Text));
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