using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class GraphMonthly : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnShow;

		protected DropDownList LstMonthfrom;

		protected DropDownList LstMonthto;

		protected DataGrid ReportGrid;

		protected TextBox TxtYear;

		public GraphMonthly()
		{
		}

		private void BtnShow_Click(object sender, EventArgs e)
		{
			this.LoadReport();
		}

		private void InitializeComponent()
		{
			this.BtnShow.Click += new EventHandler(this.BtnShow_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadCriteria()
		{
			int month = DateTime.Now.Month;
			if (month != 1)
			{
				month--;
			}
			else
			{
				month = 12;
			}
			this.LstMonthfrom.DataSource = SmartAdmin.Data.Master.MonthList();
			this.LstMonthfrom.DataTextField = "MonthName";
			this.LstMonthfrom.DataValueField = "MonthID";
			this.LstMonthfrom.DataBind();
			this.LstMonthfrom.SelectedIndex = month;
			this.LstMonthto.DataSource = SmartAdmin.Data.Master.MonthList();
			this.LstMonthto.DataTextField = "MonthName";
			this.LstMonthto.DataValueField = "MonthID";
			this.LstMonthto.DataBind();
			this.LstMonthto.SelectedIndex = month;
			this.TxtYear.Text = DateTime.Now.Year.ToString();
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadReport()
		{
			this.ReportGrid.DataSource = Report.SumMonthly(int.Parse(this.LstMonthfrom.SelectedItem.Value), int.Parse(this.LstMonthto.SelectedItem.Value), int.Parse(this.TxtYear.Text));
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