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

namespace SmartAdmin.Employee
{
	public class EmployeeInfo : System.Web.UI.Page
	{
		protected Label LblSocialID;

		protected Label LblNickName;

		protected Label LblLastName;

		protected Label LblFirstName;

		protected Label LblEmployeeID;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected Label TxtEmployeeID;

		protected Label TxtLastName;

		protected Label TxtNickName;

		protected Label TxtEmployeeType;

		protected Label TxtSex;

		protected Label TxtSocialID;

		protected HtmlForm AddPage;

		protected Label TxtFirstName;

		protected Button BtnEdit;

		protected Button BtnDelete;

		protected Label LblConfirmDelete;

		protected Panel PanControl;

		protected Button BtnYes;

		protected Panel PanConfirm;

		protected Button BtnNo;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Repeater RepeatTime;

		protected Repeater RptDay0;

		protected Repeater RptDay1;

		protected Repeater RptDay2;

		protected Repeater RptDay3;

		protected Repeater RptDay4;

		protected Repeater RptDay5;

		protected Repeater RptDay6;

		private int employeeID;

		public EmployeeInfo()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.EMPLOYEE_LIST_PAGE));
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
			stringBuilder.Append(Pages.Url(this, Pages.EMPLOYEE_EDIT_PAGE));
			stringBuilder.Append("?id=");
			stringBuilder.Append(this.employeeID);
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
			if (SmartAdmin.Data.Employee.Delete(this.employeeID))
			{
				this.BackPage();
				return;
			}
			this.LblConfirmDelete.Text = "Sorry,can't delete this employee.This employee already have some logs in this system.";
			this.LblConfirmDelete.Visible = true;
			this.BtnYes.Visible = false;
		}

		private void InitializeComponent()
		{
			this.BtnEdit.Click += new EventHandler(this.BtnEdit_Click);
			this.BtnDelete.Click += new EventHandler(this.BtnDelete_Click);
			this.BtnYes.Click += new EventHandler(this.BtnYes_Click);
			this.BtnNo.Click += new EventHandler(this.BtnNo_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadEmployee(int employeeID)
		{
			string str;
			DataTable dataTable = SmartAdmin.Data.Employee.EmployeeList(employeeID);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				base.Response.Redirect(Pages.Url(this, Pages.EMPLOYEE_LIST_PAGE));
				return;
			}
			DataRow item = dataTable.Rows[0];
			this.TxtEmployeeID.Text = employeeID.ToString();
			this.TxtFirstName.Text = (string)item["FirstName"];
			this.TxtLastName.Text = (string)item["LastName"];
			this.TxtNickName.Text = (item["NickName"] is DBNull ? "" : (string)item["NickName"]);
			Label txtSex = this.TxtSex;
			if (item["Sex"] is DBNull)
			{
				str = "";
			}
			else
			{
				str = ((string)item["Sex"] == "M" ? "Male" : "Female");
			}
			txtSex.Text = str;
			this.TxtSocialID.Text = (item["SocialID"] is DBNull ? "" : (string)item["SocialID"]);
			this.TxtEmployeeType.Text = (item["EmployeeTypeName"] is DBNull ? "" : (string)item["EmployeeTypeName"]);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadShiftTime(int employeeID)
		{
			DataTable dataTable = SmartAdmin.Data.Employee.ShiftList(employeeID);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow item = dataTable.Rows[i];
				this.setTime(int.Parse(item["shiftday"].ToString()), item["timeid"].ToString());
			}
		}

		private void LoadTime()
		{
			this.RepeatTime.DataSource =SmartAdmin.Data.Master.ShowTimeList();
			this.RepeatTime.DataMember = "TimeName";
			this.RepeatTime.DataBind();
			DataTable dataTable =SmartAdmin.Data.Master.ShowTimeList();
			dataTable.Columns.Add("Selected", typeof(string));
			this.RptDay0.DataSource = dataTable;
			this.RptDay0.DataBind();
			dataTable =SmartAdmin.Data.Master.ShowTimeList();
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
			this.employeeID = Pages.QueryInt(this, "id", -1);
			if (this.employeeID <= 0)
			{
				this.BackPage();
			}
			if (!base.IsPostBack)
			{
				this.LoadEmployee(this.employeeID);
				this.LoadTime();
				this.LoadShiftTime(this.employeeID);
				this.LblConfirmDelete.Text = "Are you sure to delete this employee?";
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