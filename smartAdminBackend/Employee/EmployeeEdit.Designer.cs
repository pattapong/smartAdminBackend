using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartAdmin.Employee
{
	public class EmployeeEdit : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnCancel;

		protected Button BtnSave;

		protected Label LblError;

		protected Image ImgError;

		protected TextBox TxtComfirmPassword;

		protected Label LblConfirmPassword;

		protected TextBox TxtPassword;

		protected Label LblPassword;

		protected TextBox TxtSocialID;

		protected Label LblSocialID;

		protected DropDownList LstSex;

		protected DropDownList LstType;

		protected TextBox TxtNickName;

		protected Label LblNickName;

		protected TextBox TxtLastName;

		protected Label LblLastName;

		protected TextBox TxtFirstName;

		protected Label LblFirstName;

		protected Label TxtEmployeeID;

		protected Label LblEmployeeID;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected HtmlForm AddPage;

		private int employeeID;

		private int TypeID;

		protected Repeater RepeatTime;

		protected CheckBoxList ChkDay1;

		protected CheckBoxList ChkDay2;

		protected CheckBoxList ChkDay3;

		protected CheckBoxList ChkDay4;

		protected CheckBoxList ChkDay5;

		protected CheckBoxList ChkDay6;

		protected ValidationSummary ValidationSummary1;

		protected CheckBoxList ChkDay0;

		public EmployeeEdit()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.EMPLOYEE_LIST_PAGE));
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.BackPage();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			int i;
			string[] strArrays;
			if (!this.ValidateForm())
			{
				return;
			}
			SmartAdmin.Data.Employee.Update(this.employeeID, this.TxtFirstName.Text, this.TxtLastName.Text, this.TxtNickName.Text, this.LstSex.SelectedItem.Value, this.TxtSocialID.Text, this.TxtPassword.Text, this.TypeID);
			string[] strArrays1 = new string[7];
			for (i = 0; i < this.ChkDay0.Items.Count; i++)
			{
				if (!this.ChkDay0.Items[i].Selected)
				{
					string[] strArrays2 = strArrays1;
					strArrays = strArrays2;
					strArrays2[0] = string.Concat(strArrays[0], this.ChkDay0.Items[i].Value, ",");
				}
				else
				{
					SmartAdmin.Data.Employee.ShiftInsert(this.employeeID, 0, int.Parse(this.ChkDay0.Items[i].Value));
				}
			}
			for (i = 0; i < this.ChkDay1.Items.Count; i++)
			{
				if (!this.ChkDay1.Items[i].Selected)
				{
					string[] strArrays3 = strArrays1;
					strArrays = strArrays3;
					strArrays3[1] = string.Concat(strArrays[1], this.ChkDay1.Items[i].Value, ",");
				}
				else
				{
					SmartAdmin.Data.Employee.ShiftInsert(this.employeeID, 1, int.Parse(this.ChkDay1.Items[i].Value));
				}
			}
			for (i = 0; i < this.ChkDay2.Items.Count; i++)
			{
				if (!this.ChkDay2.Items[i].Selected)
				{
					string[] strArrays4 = strArrays1;
					strArrays = strArrays4;
					strArrays4[2] = string.Concat(strArrays[2], this.ChkDay2.Items[i].Value, ",");
				}
				else
				{
					SmartAdmin.Data.Employee.ShiftInsert(this.employeeID, 2, int.Parse(this.ChkDay2.Items[i].Value));
				}
			}
			for (i = 0; i < this.ChkDay3.Items.Count; i++)
			{
				if (!this.ChkDay3.Items[i].Selected)
				{
					string[] strArrays5 = strArrays1;
					strArrays = strArrays5;
					strArrays5[3] = string.Concat(strArrays[3], this.ChkDay3.Items[i].Value, ",");
				}
				else
				{
					SmartAdmin.Data.Employee.ShiftInsert(this.employeeID, 3, int.Parse(this.ChkDay3.Items[i].Value));
				}
			}
			for (i = 0; i < this.ChkDay4.Items.Count; i++)
			{
				if (!this.ChkDay4.Items[i].Selected)
				{
					string[] strArrays6 = strArrays1;
					strArrays = strArrays6;
					strArrays6[4] = string.Concat(strArrays[4], this.ChkDay4.Items[i].Value, ",");
				}
				else
				{
					SmartAdmin.Data.Employee.ShiftInsert(this.employeeID, 4, int.Parse(this.ChkDay4.Items[i].Value));
				}
			}
			for (i = 0; i < this.ChkDay5.Items.Count; i++)
			{
				if (!this.ChkDay5.Items[i].Selected)
				{
					string[] strArrays7 = strArrays1;
					strArrays = strArrays7;
					strArrays7[5] = string.Concat(strArrays[5], this.ChkDay5.Items[i].Value, ",");
				}
				else
				{
					SmartAdmin.Data.Employee.ShiftInsert(this.employeeID, 5, int.Parse(this.ChkDay5.Items[i].Value));
				}
			}
			for (i = 0; i < this.ChkDay6.Items.Count; i++)
			{
				if (!this.ChkDay6.Items[i].Selected)
				{
					string[] strArrays8 = strArrays1;
					strArrays = strArrays8;
					strArrays8[6] = string.Concat(strArrays[6], this.ChkDay6.Items[i].Value, ",");
				}
				else
				{
					SmartAdmin.Data.Employee.ShiftInsert(this.employeeID, 6, int.Parse(this.ChkDay6.Items[i].Value));
				}
			}
			for (i = 0; i < 7; i++)
			{
				if (strArrays1[i] != null)
				{
					strArrays1[i] = strArrays1[i].Substring(0, strArrays1[i].Length - 1);
					SmartAdmin.Data.Employee.ShiftDelete(this.employeeID, i, strArrays1[i]);
				}
			}
			this.BackPage();
		}

		private void InitializeComponent()
		{
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadEmployee(int employee)
		{
			DataTable dataTable = SmartAdmin.Data.Employee.EmployeeList(this.employeeID);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				base.Response.Redirect(Pages.Url(this, Pages.EMPLOYEE_LIST_PAGE));
				return;
			}
			DataRow item = dataTable.Rows[0];
			this.TxtEmployeeID.Text = this.employeeID.ToString();
			this.TxtFirstName.Text = (string)item["FirstName"];
			this.TxtLastName.Text = (string)item["LastName"];
			this.TxtNickName.Text = (item["NickName"] is DBNull ? "" : (string)item["NickName"]);
			string str = (item["Sex"] is DBNull ? "M" : (string)item["Sex"]);
			int i = 0;
			while (i < this.LstSex.Items.Count)
			{
				if (this.LstSex.Items[i].Value != str)
				{
					i++;
				}
				else
				{
					this.LstSex.SelectedIndex = i;
					break;
				}
			}
			this.TxtSocialID.Text = (item["SocialID"] is DBNull ? "" : (string)item["SocialID"]);
			int num = (item["EmployeeTypeID"] is DBNull ? 0 : (int)item["EmployeeTypeID"]);
			for (i = 0; i < this.LstType.Items.Count; i++)
			{
				if (this.LstType.Items[i].Value == num.ToString())
				{
					this.LstType.SelectedIndex = i;
					return;
				}
			}
		}

		private void LoadEmployeeType()
		{
			this.TxtEmployeeID.Text = "New Employee ID";
			this.LstType.DataSource =SmartAdmin.Data.Master.EmployeeTypeList();
			this.LstType.DataTextField = "EmployeeTypeName";
			this.LstType.DataValueField = "EmployeeTypeID";
			this.LstType.DataBind();
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
			this.ChkDay0.DataSource =SmartAdmin.Data.Master.ShowTimeList();
			this.ChkDay0.DataTextField = "show";
			this.ChkDay0.DataValueField = "TimeID";
			this.ChkDay0.DataBind();
			this.ChkDay1.DataSource =SmartAdmin.Data.Master.ShowTimeList();
			this.ChkDay1.DataTextField = "show";
			this.ChkDay1.DataValueField = "TimeID";
			this.ChkDay1.DataBind();
			this.ChkDay2.DataSource =SmartAdmin.Data.Master.ShowTimeList();
			this.ChkDay2.DataTextField = "show";
			this.ChkDay2.DataValueField = "TimeID";
			this.ChkDay2.DataBind();
			this.ChkDay3.DataSource =SmartAdmin.Data.Master.ShowTimeList();
			this.ChkDay3.DataTextField = "show";
			this.ChkDay3.DataValueField = "TimeID";
			this.ChkDay3.DataBind();
			this.ChkDay4.DataSource =SmartAdmin.Data.Master.ShowTimeList();
			this.ChkDay4.DataTextField = "show";
			this.ChkDay4.DataValueField = "TimeID";
			this.ChkDay4.DataBind();
			this.ChkDay5.DataSource =SmartAdmin.Data.Master.ShowTimeList();
			this.ChkDay5.DataTextField = "show";
			this.ChkDay5.DataValueField = "TimeID";
			this.ChkDay5.DataBind();
			this.ChkDay6.DataSource =SmartAdmin.Data.Master.ShowTimeList();
			this.ChkDay6.DataTextField = "show";
			this.ChkDay6.DataValueField = "TimeID";
			this.ChkDay6.DataBind();
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
				this.LoadEmployeeType();
				this.LoadTime();
				this.LoadShiftTime(this.employeeID);
				this.LoadEmployee(this.employeeID);
			}
		}

		private void setTime(int dayin, string timein)
		{
			for (int i = 0; i < this.RepeatTime.Items.Count; i++)
			{
				switch (dayin)
				{
					case 0:
					{
						if (this.ChkDay0.Items[i].Value != timein)
						{
							break;
						}
						this.ChkDay0.Items[i].Selected = true;
						break;
					}
					case 1:
					{
						if (this.ChkDay1.Items[i].Value != timein)
						{
							break;
						}
						this.ChkDay1.Items[i].Selected = true;
						break;
					}
					case 2:
					{
						if (this.ChkDay2.Items[i].Value != timein)
						{
							break;
						}
						this.ChkDay2.Items[i].Selected = true;
						break;
					}
					case 3:
					{
						if (this.ChkDay3.Items[i].Value != timein)
						{
							break;
						}
						this.ChkDay3.Items[i].Selected = true;
						break;
					}
					case 4:
					{
						if (this.ChkDay4.Items[i].Value != timein)
						{
							break;
						}
						this.ChkDay4.Items[i].Selected = true;
						break;
					}
					case 5:
					{
						if (this.ChkDay5.Items[i].Value != timein)
						{
							break;
						}
						this.ChkDay5.Items[i].Selected = true;
						break;
					}
					case 6:
					{
						if (this.ChkDay6.Items[i].Value != timein)
						{
							break;
						}
						this.ChkDay6.Items[i].Selected = true;
						break;
					}
				}
			}
		}

		private bool ValidateForm()
		{
			bool flag;
			if (this.TxtFirstName.Text == "")
			{
				this.LblError.Text = "First name must be not blank.";
				this.ImgError.Visible = true;
				this.LblFirstName.CssClass = "error";
				return false;
			}
			if (this.TxtLastName.Text == "")
			{
				this.LblError.Text = "Last name must be not blank.";
				this.ImgError.Visible = true;
				this.LblLastName.CssClass = "error";
				return false;
			}
			if (this.TxtNickName.Text == "")
			{
				this.LblError.Text = "Nick name must be not blank.";
				this.ImgError.Visible = true;
				this.LblNickName.CssClass = "error";
				return false;
			}
			if (this.TxtSocialID.Text == "")
			{
				this.LblError.Text = "Social ID must be not blank.";
				this.ImgError.Visible = true;
				this.LblSocialID.CssClass = "error";
				return false;
			}
			if (this.TxtPassword.Text != this.TxtComfirmPassword.Text)
			{
				this.LblError.Text = "Password and confirm password not match.";
				this.ImgError.Visible = true;
				this.LblPassword.CssClass = "error";
				this.LblConfirmPassword.CssClass = "error";
				return false;
			}
			try
			{
				this.TypeID = int.Parse(this.LstType.SelectedItem.Value);
				return true;
			}
			catch (Exception exception)
			{
				this.LblError.Text = "Employee Type found some error.";
				this.ImgError.Visible = true;
				flag = false;
			}
			return flag;
		}
	}
}