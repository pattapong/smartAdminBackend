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
	public class TimeStampByEmp : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnShow;

		protected LinkButton LinkYearly;

		protected Image ImgLeft;

		protected Image ImgSep1;

		protected Image ImgSep2;

		protected Image ImgRight;

		protected HtmlTableCell BgDaily;

		protected HtmlTableCell BgMonthly;

		protected HtmlTableCell BgYearly;

		protected Panel PanelMonthly;

		protected TextBox TxtDayTo;

		protected TextBox TxtDayFrom;

		protected Panel PanelDaily;

		protected LinkButton LinkDaily;

		protected LinkButton LinkMonthly;

		protected TextBox TxtYearTo;

		protected TextBox TxtYearFrom;

		protected Panel PanelYearly;

		protected DropDownList LstEmployee;

		protected DropDownList LstMonthFrom;

		protected DropDownList LstMonthTo;

		protected TextBox TxtYear;

		protected DataGrid ReportGrid;

		private static CultureInfo ci;

		private int startcol = 0;

		static TimeStampByEmp()
		{
			TimeStampByEmp.ci = new CultureInfo("en-US");
		}

		public TimeStampByEmp()
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
				this.TxtDayTo.Text = dateTime1.ToString("d/M/yyyy", TimeStampByEmp.ci);
				this.LinkDaily_Click(null, null);
			}
		}

		private void InitializeComponent()
		{
			this.LinkDaily.Click += new EventHandler(this.LinkDaily_Click);
			this.LstEmployee.SelectedIndexChanged += new EventHandler(this.LstEmployee_SelectedIndexChanged);
			this.BtnShow.Click += new EventHandler(this.BtnShow_Click);
			this.ReportGrid.ItemCreated += new DataGridItemEventHandler(this.ReportGrid_ItemCreated);
			this.ReportGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.ReportGrid_PageIndexChanged);
			this.ReportGrid.ItemDataBound += new DataGridItemEventHandler(this.ReportGrid_ItemDataBound);
			this.LinkMonthly.Click += new EventHandler(this.LinkMonthly_Click);
			this.LinkYearly.Click += new EventHandler(this.LinkYearly_Click);
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
			DataTable dataTable = null;
			dataTable = SmartAdmin.Data.Employee.EmployeeList();
			DataRow dataRow = dataTable.NewRow();
			dataRow["EmployeeID"] = "-1";
			dataRow["Name"] = "==All==";
			dataTable.Rows.Add(dataRow);
			this.LstEmployee.DataSource = dataTable;
			this.LstEmployee.DataTextField = "Name";
			this.LstEmployee.DataValueField = "EmployeeID";
			this.LstEmployee.DataBind();
			this.LstEmployee.SelectedIndex = dataTable.Rows.Count - 1;
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
				dataTable = Business.TimeStampByEmp(this.LstEmployee.SelectedItem.Value, this.TxtDayFrom.Text, this.TxtDayTo.Text, null, null, null, null);
			}
			else if (this.PanelMonthly.Visible)
			{
				dataTable = Business.TimeStampByEmp(this.LstEmployee.SelectedItem.Value, null, null, this.LstMonthFrom.SelectedItem.Value, this.LstMonthTo.SelectedItem.Value, this.TxtYear.Text, null);
			}
			else if (this.PanelYearly.Visible)
			{
				dataTable = Business.TimeStampByEmp(this.LstEmployee.SelectedItem.Value, null, null, null, null, this.TxtYearFrom.Text, this.TxtYearTo.Text);
			}
			dataTable = Business.ConvertColumnString(dataTable);
			if (this.LstEmployee.SelectedItem.Value != "-1")
			{
				this.startcol = 3;
			}
			else
			{
				this.startcol = 4;
			}
			if (dataTable.Rows.Count > 0)
			{
				DataRow dataRow = dataTable.NewRow();
				for (int i = this.startcol; i < dataTable.Columns.Count; i++)
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

		private void LstEmployee_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.LoadReport();
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
			if (this.LstEmployee.SelectedItem.Value != "-1")
			{
				this.startcol = 3;
			}
			else
			{
				this.startcol = 4;
			}
			if (e.Item.DataItem is DataRowView)
			{
				for (int i = this.startcol; i < e.Item.Cells.Count; i++)
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

		private void ReportGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			e.Item.Cells[1].Visible = false;
		}

		private void ReportGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.ReportGrid.CurrentPageIndex = e.NewPageIndex;
			this.LoadReport();
		}
	}
}