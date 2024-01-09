using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class SalesByDiscount : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnShow;

		protected LinkButton LinkDaily;

		protected LinkButton LinkMonthly;

		protected LinkButton LinkYearly;

		protected Panel PanelDaily;

		protected TextBox TxtDayFrom;

		protected TextBox TxtDayTo;

		protected TextBox TxtYearTo;

		protected TextBox TxtYearFrom;

		protected DropDownList LstMonthFrom;

		protected DropDownList LstMonthTo;

		protected Panel PanelYearly;

		protected Panel PanelMonthly;

		protected TextBox TxtYear;

		protected Image ImgLeft;

		protected Image ImgSep1;

		protected Image ImgSep2;

		protected Image ImgRight;

		protected DataGrid ReportGrid;

		protected HtmlTableCell BgDaily;

		protected HtmlTableCell BgMonthly;

		protected HtmlTableCell BgYearly;

		private static CultureInfo ci;

		static SalesByDiscount()
		{
			SalesByDiscount.ci = new CultureInfo("en-US");
		}

		public SalesByDiscount()
		{
		}

		private void BtnShow_Click(object sender, EventArgs e)
		{
			this.LoadReport();
		}

		private void ChangeTab(int tab)
		{
			string str;
			string str1;
			this.ImgLeft.ImageUrl = (tab == 0 ? "../images/tab_left_h.gif" : "../images/tab_left.gif");
			Image imgSep1 = this.ImgSep1;
			if (tab == 0)
			{
				str = "../images/tab_sep_h_left.gif";
			}
			else
			{
				str = (tab == 1 ? "../images/tab_sep_h_right.gif" : "../images/tab_sep.gif");
			}
			imgSep1.ImageUrl = str;
			Image imgSep2 = this.ImgSep2;
			if (tab == 1)
			{
				str1 = "../images/tab_sep_h_left.gif";
			}
			else
			{
				str1 = (tab == 2 ? "../images/tab_sep_h_right.gif" : "../images/tab_sep.gif");
			}
			imgSep2.ImageUrl = str1;
			this.ImgRight.ImageUrl = (tab == 2 ? "../images/tab_right_h.gif" : "../images/tab_right.gif");
			this.LinkDaily.CssClass = (tab == 0 ? "mainmenu1" : "mainmenu0");
			this.LinkMonthly.CssClass = (tab == 1 ? "mainmenu1" : "mainmenu0");
			this.LinkYearly.CssClass = (tab == 2 ? "mainmenu1" : "mainmenu0");
			this.BgDaily.Attributes["background"] = (tab == 0 ? "../images/tab_bg_h.gif" : "../images/tab_bg.gif");
			this.BgMonthly.Attributes["background"] = (tab == 1 ? "../images/tab_bg_h.gif" : "../images/tab_bg.gif");
			this.BgYearly.Attributes["background"] = (tab == 2 ? "../images/tab_bg_h.gif" : "../images/tab_bg.gif");
		}

		private void CheckDrillDown()
		{
			string item;
			string str;
			int num;
			int num1;
			try
			{
				item = base.Request["__gridVal1"];
				str = base.Request["__gridVal2"];
			}
			catch (Exception exception)
			{
				return;
			}
			if (item == "year")
			{
				this.LstMonthFrom.SelectedIndex = 0;
				this.LstMonthTo.SelectedIndex = this.LstMonthTo.Items.Count - 1;
				this.TxtYear.Text = str;
				this.LinkMonthly_Click(null, null);
				return;
			}
			if (item == "month")
			{
				int num2 = 1;
				try
				{
					if (str != "12")
					{
						num = int.Parse(str) + 1;
						num1 = int.Parse(this.TxtYear.Text);
					}
					else
					{
						num = 0;
						num1 = int.Parse(this.TxtYear.Text) + 1;
					}
				}
				catch (Exception exception1)
				{
					return;
				}
				DateTime dateTime = new DateTime(num1, num, num2);
				DateTime dateTime1 = dateTime.Subtract(TimeSpan.FromDays(1));
				this.TxtDayFrom.Text = string.Concat("1/", str, "/", this.TxtYear.Text);
				this.TxtDayTo.Text = dateTime1.ToString("d/M/yyyy", SalesByDiscount.ci);
				this.LinkDaily_Click(null, null);
			}
		}

		private void InitializeComponent()
		{
			this.LinkDaily.Click += new EventHandler(this.LinkDaily_Click);
			this.LinkMonthly.Click += new EventHandler(this.LinkMonthly_Click);
			this.LinkYearly.Click += new EventHandler(this.LinkYearly_Click);
			this.BtnShow.Click += new EventHandler(this.BtnShow_Click);
			this.ReportGrid.ItemCreated += new DataGridItemEventHandler(this.ReportGrid_ItemCreated);
			this.ReportGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.ReportGrid_PageIndexChanged);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LinkDaily_Click(object sender, EventArgs e)
		{
			this.PanelDaily.Visible = true;
			this.PanelMonthly.Visible = false;
			this.PanelYearly.Visible = false;
			this.LoadReport();
			this.ChangeTab(0);
		}

		private void LinkMonthly_Click(object sender, EventArgs e)
		{
			this.PanelDaily.Visible = false;
			this.PanelMonthly.Visible = true;
			this.PanelYearly.Visible = false;
			this.LoadReport();
			this.ChangeTab(1);
		}

		private void LinkYearly_Click(object sender, EventArgs e)
		{
			this.PanelDaily.Visible = false;
			this.PanelMonthly.Visible = false;
			this.PanelYearly.Visible = true;
			this.LoadReport();
			this.ChangeTab(2);
		}

		private void LoadCriteria()
		{
			TextBox txtDayFrom = this.TxtDayFrom;
			int month = DateTime.Now.Month;
			string str = month.ToString();
			month = DateTime.Now.Year;
			txtDayFrom.Text = string.Concat("1/", str, "/", month.ToString());
			TextBox txtDayTo = this.TxtDayTo;
			object[] objArray = new object[5];
			month = DateTime.Now.Day;
			objArray[0] = month.ToString();
			objArray[1] = '/';
			month = DateTime.Now.Month;
			objArray[2] = month.ToString();
			objArray[3] = "/";
			month = DateTime.Now.Year;
			objArray[4] = month.ToString();
			txtDayTo.Text = string.Concat(objArray);
			month = DateTime.Now.Month;
			int num = int.Parse(month.ToString());
			if (num != 12)
			{
				num--;
			}
			else
			{
				num = 0;
			}
			this.LstMonthFrom.DataSource = SmartAdmin.Data.Master.MonthList();
			this.LstMonthFrom.DataTextField = "MonthName";
			this.LstMonthFrom.DataValueField = "MonthID";
			this.LstMonthFrom.DataBind();
			this.LstMonthFrom.SelectedIndex = num;
			this.LstMonthTo.DataSource = SmartAdmin.Data.Master.MonthList();
			this.LstMonthTo.DataTextField = "MonthName";
			this.LstMonthTo.DataValueField = "MonthID";
			this.LstMonthTo.DataBind();
			this.LstMonthTo.SelectedIndex = num;
			TextBox txtYear = this.TxtYear;
			month = DateTime.Now.Year;
			txtYear.Text = month.ToString();
			this.TxtYearFrom.Text = this.TxtYear.Text;
			this.TxtYearTo.Text = this.TxtYearFrom.Text;
			this.PanelMonthly.Visible = true;
			this.ChangeTab(1);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadReport()
		{
			DataTable dataTable = null;
			if (this.PanelDaily.Visible)
			{
				dataTable = Business.SalesByDiscount(this.TxtDayFrom.Text, this.TxtDayTo.Text, null, null, null, null);
			}
			else if (this.PanelMonthly.Visible)
			{
				dataTable = Business.SalesByDiscount(null, null, this.LstMonthFrom.SelectedItem.Value, this.LstMonthTo.SelectedItem.Value, this.TxtYear.Text, null);
			}
			else if (this.PanelYearly.Visible)
			{
				dataTable = Business.SalesByDiscount(null, null, null, null, this.TxtYearFrom.Text, this.TxtYearTo.Text);
			}
			dataTable = Business.ConvertColumnString(dataTable);
			dataTable.Columns.Add("Total", typeof(decimal));
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				decimal num = new decimal(0);
				for (int j = 2; j < dataTable.Columns.Count - 1; j++)
				{
					num += decimal.Parse(dataTable.Rows[i][j].ToString());
				}
				dataTable.Rows[i]["Total"] = num;
			}
			if (dataTable.Rows.Count > 0)
			{
				DataRow dataRow = dataTable.NewRow();
				for (int k = 2; k < dataTable.Columns.Count; k++)
				{
					object obj = dataTable.Compute(string.Concat("Sum([", dataTable.Columns[k].ColumnName.ToString(), "])"), "");
					if (obj is DBNull)
					{
						dataRow[k] = 0;
					}
					else
					{
						dataRow[k] = decimal.Parse(obj.ToString());
					}
				}
				dataTable.Rows.Add(dataRow);
			}
			this.ReportGrid.DataSource = dataTable;
			this.ReportGrid.DataBind();
		}

		private void LstType_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.LoadReport();
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.LoadMenu();
			if (base.IsPostBack)
			{
				this.CheckDrillDown();
				return;
			}
			this.LoadCriteria();
			this.LoadReport();
		}

		private void ReportGrid_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.DataItem is DataRowView)
			{
				for (int i = 2; i < e.Item.Cells.Count; i++)
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
				if (this.PanelYearly.Visible)
				{
					stringBuilder.Append("<a href=\"javascript:__gridPostBack('year','");
					stringBuilder.Append(row[0].ToString());
					stringBuilder.Append("')\">");
					stringBuilder.Append(row[0].ToString());
					stringBuilder.Append("</a>");
				}
				else if (!this.PanelMonthly.Visible)
				{
					stringBuilder.Append(row[0].ToString());
				}
				else
				{
					stringBuilder.Append("<a href=\"javascript:__gridPostBack('month','");
					stringBuilder.Append(row[0].ToString());
					stringBuilder.Append("')\">");
					stringBuilder.Append(row[0].ToString());
					stringBuilder.Append("</a>");
				}
				row[0] = stringBuilder.ToString();
			}
		}

		private void ReportGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.ReportGrid.CurrentPageIndex = e.NewPageIndex;
			this.LoadReport();
		}
	}
}