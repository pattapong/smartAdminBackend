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
	public class MenuCancelDetail : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected Panel PanControl;

		protected Panel PanConfirm;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected DataGrid ReportGrid;

		private int menutypeID;

		private string pageType = "";

		private int cols = 0;

		private string dayfrom;

		private string dayto;

		private string monthfrom;

		private string monthto;

		private string yearfrom;

		private string yearto;

		private string details;

		protected Label TxtMenuType;

		public MenuCancelDetail()
		{
		}

		private void InitializeComponent()
		{
			this.ReportGrid.ItemCreated += new DataGridItemEventHandler(this.ReportGrid_ItemCreated);
			this.ReportGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.ReportGrid_PageIndexChanged);
			this.ReportGrid.ItemDataBound += new DataGridItemEventHandler(this.ReportGrid_ItemDataBound);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadDetail(int menuTypeID)
		{
			string[] strArrays;
			DataTable dataTable = SmartAdmin.Data.Master.MenuTypeList(menuTypeID);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				DataRow item = dataTable.Rows[0];
				string str = "";
				if (this.dayfrom != "" && this.dayto != "")
				{
					strArrays = new string[] { " (From Date:", this.dayfrom, " to ", this.dayto, ")" };
					str = string.Concat(strArrays);
					this.pageType = "Day";
				}
				else if (!(this.monthfrom != "") || !(this.monthto != ""))
				{
					strArrays = new string[] { " (From Year:", this.yearfrom, " ", this.yearto, ")" };
					str = string.Concat(strArrays);
					this.pageType = "Year";
				}
				else
				{
					strArrays = new string[] { " (From Month:", this.monthfrom, " to ", this.monthto, " Year:", this.yearfrom, ")" };
					str = string.Concat(strArrays);
					this.pageType = "Month";
				}
				this.TxtMenuType.Text = string.Concat(item["menutypename"].ToString(), str);
			}
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadReport()
		{
			DataTable dataTable = null;
			if (this.details == "")
			{
				this.cols = 3;
				if (this.pageType == "Day")
				{
					dataTable = Business.MenuCancel(this.dayfrom, this.dayto, null, null, null, null, this.menutypeID.ToString());
				}
				else if (this.pageType == "Month")
				{
					dataTable = Business.MenuCancel(null, null, this.monthfrom, this.monthto, this.yearfrom, null, this.menutypeID.ToString());
				}
				else if (this.pageType == "Year")
				{
					dataTable = Business.MenuCancel(null, null, null, null, this.yearfrom, this.yearto, this.menutypeID.ToString());
				}
			}
			else
			{
				this.cols = 1;
				if (this.pageType == "Day")
				{
					dataTable = Business.MenuCancelDetail(this.dayfrom, this.dayto, null, null, null, null, this.menutypeID.ToString());
				}
				else if (this.pageType == "Month")
				{
					dataTable = Business.MenuCancelDetail(null, null, this.monthfrom, this.monthto, this.yearfrom, null, this.menutypeID.ToString());
				}
				else if (this.pageType == "Year")
				{
					dataTable = Business.MenuCancelDetail(null, null, null, null, this.yearfrom, this.yearto, this.menutypeID.ToString());
				}
			}
			dataTable = Business.ConvertColumnString(dataTable);
			if (this.details == "" && dataTable.Rows.Count > 0)
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
			this.menutypeID = Pages.QueryInt(this, "id", -1);
			this.dayfrom = Pages.QueryStr(this, "dayfrom", "");
			this.dayto = Pages.QueryStr(this, "dayto", "");
			this.monthfrom = Pages.QueryStr(this, "monthfrom", "");
			this.monthto = Pages.QueryStr(this, "monthto", "");
			this.yearfrom = Pages.QueryStr(this, "yearfrom", "");
			this.yearto = Pages.QueryStr(this, "yearto", "");
			this.details = Pages.QueryStr(this, "details", "");
			if (!base.IsPostBack)
			{
				this.LoadDetail(this.menutypeID);
				this.LoadReport();
			}
		}

		private void ReportGrid_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			object[] item;
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
				if (this.details != "")
				{
					stringBuilder.Append(row[0].ToString());
				}
				else
				{
					if (this.pageType == "Day")
					{
						item = new object[] { "<a href=\"MenuCancelDetail.aspx?details=true&id=", row["MenuTypeID"], "&dayfrom=", row[0].ToString(), "&dayto=", row[0].ToString(), "\">" };
						stringBuilder.Append(string.Concat(item));
					}
					else if (this.pageType == "Month")
					{
						item = new object[] { "<a href=\"MenuCancelDetail.aspx?details=true&id=", row["MenuTypeID"], "&monthfrom=", this.monthfrom, "&monthto=", this.monthto, "&yearfrom=", this.yearfrom, "\">" };
						stringBuilder.Append(string.Concat(item));
					}
					else if (this.pageType == "Year")
					{
						item = new object[] { "<a href=\"MenuCancelDetail.aspx?details=true&id=", row["MenuTypeID"], "&yearfrom=", this.yearfrom, "&yearto=", this.yearto, "\">" };
						stringBuilder.Append(string.Concat(item));
					}
					stringBuilder.Append(row[0].ToString());
					stringBuilder.Append("</a>");
				}
				row[0] = stringBuilder.ToString();
			}
		}

		private void ReportGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			if (this.details == "")
			{
				e.Item.Cells[1].Visible = false;
				e.Item.Cells[2].Visible = false;
			}
		}

		private void ReportGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.ReportGrid.CurrentPageIndex = e.NewPageIndex;
			this.LoadReport();
		}
	}
}