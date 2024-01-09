using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class ReserveByPeriodDetail : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected Panel PanControl;

		protected Panel PanConfirm;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected DataGrid ReportGrid;

		private int cols = 0;

		private string datein;

		private string monthin;

		private string yearin;

		private string pageType;

		protected Label TxtMenuType;

		public ReserveByPeriodDetail()
		{
		}

		private void InitializeComponent()
		{
			this.ReportGrid.ItemCreated += new DataGridItemEventHandler(this.ReportGrid_ItemCreated);
			this.ReportGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.ReportGrid_PageIndexChanged);
			this.ReportGrid.ItemDataBound += new DataGridItemEventHandler(this.ReportGrid_ItemDataBound);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadDetail()
		{
			string str = "";
			if (this.datein != "")
			{
				str = string.Concat(" ( Date:", this.datein, ")");
				this.pageType = "Day";
			}
			else if (!(this.monthin != "") || !(this.yearin != ""))
			{
				str = string.Concat(" ( Year:", this.yearin, ")");
				this.pageType = "Year";
			}
			else
			{
				string[] strArrays = new string[] { " ( Month: ", this.monthin, " Year:", this.yearin, ")" };
				str = string.Concat(strArrays);
				this.pageType = "Month";
			}
			this.TxtMenuType.Text = string.Concat("Reserve", str);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadReport()
		{
			DataTable dataTable = null;
			this.cols = 1;
			if (this.pageType == "Day")
			{
				dataTable = Business.ReserveTableDetail(this.datein, null, null);
			}
			else if (this.pageType == "Month")
			{
				dataTable = Business.ReserveTableDetail(null, this.monthin, this.yearin);
			}
			else if (this.pageType == "Year")
			{
				dataTable = Business.ReserveTableDetail(null, null, this.yearin);
			}
			dataTable = Business.ConvertColumnString(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				DataRow dataRow = dataTable.NewRow();
				for (int i = this.cols; i < dataTable.Columns.Count; i++)
				{
					object obj = dataTable.Compute(string.Concat("Sum([", dataTable.Columns[i].ColumnName.ToString(), "])"), "");
					if (obj is DBNull)
					{
						dataRow[i] = 0;
					}
					else
					{
						dataRow[i] = decimal.Parse(obj.ToString());
					}
				}
				dataTable.Rows.Add(dataRow);
			}
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
			this.datein = Pages.QueryStr(this, "datein", "");
			this.monthin = Pages.QueryStr(this, "monthin", "");
			this.yearin = Pages.QueryStr(this, "yearin", "");
			if (!base.IsPostBack)
			{
				this.LoadDetail();
				this.LoadReport();
			}
		}

		private void ReportGrid_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.DataItem is DataRowView)
			{
				for (int i = this.cols; i < e.Item.Cells.Count; i++)
				{
					e.Item.Cells[i].HorizontalAlign = HorizontalAlign.Right;
				}
				DataRow row = ((DataRowView)e.Item.DataItem).Row;
				if (row[0].ToString() == "")
				{
					e.Item.CssClass = "gridTotal";
					return;
				}
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(row[0].ToString());
				row[0] = stringBuilder.ToString();
			}
		}

		private void ReportGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
		}

		private void ReportGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.ReportGrid.CurrentPageIndex = e.NewPageIndex;
			this.LoadReport();
		}
	}
}