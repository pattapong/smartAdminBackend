using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartAdmin.Employee
{
	public class EmployeeChangeProfile : System.Web.UI.Page
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

		protected CheckBoxList ChkDay1;

		protected CheckBoxList ChkDay2;

		protected CheckBoxList ChkDay3;

		protected CheckBoxList ChkDay4;

		protected CheckBoxList ChkDay5;

		protected CheckBoxList ChkDay6;

		protected ValidationSummary ValidationSummary1;

		protected DropDownList LstSex;

		protected RequiredFieldValidator RequiredFieldValidator4;

		protected RequiredFieldValidator Requiredfieldvalidator1;

		protected RequiredFieldValidator Requiredfieldvalidator2;

		protected CompareValidator CompareValidator1;

		protected Label LblSuccess;

		protected CheckBoxList ChkDay0;

		public EmployeeChangeProfile()
		{
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			SmartAdmin.Data.Employee.UpdateProfile(this.employeeID, this.TxtFirstName.Text, this.TxtLastName.Text, this.TxtNickName.Text, this.LstSex.SelectedItem.Value, this.TxtSocialID.Text, this.TxtPassword.Text);
			this.LblSuccess.Visible = true;
		}

		private void InitializeComponent()
		{
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadEmployee(int employee)
		{
			DataTable dataTable = SmartAdmin.Data.Employee.EmployeeList(this.employeeID);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				DataRow item = dataTable.Rows[0];
				this.TxtEmployeeID.Text = this.employeeID.ToString();
				this.TxtFirstName.Text = (string)item["FirstName"];
				this.TxtLastName.Text = (string)item["LastName"];
				this.TxtNickName.Text = (item["NickName"] is DBNull ? "" : (string)item["NickName"]);
				string str = (item["Sex"] is DBNull ? "M" : (string)item["Sex"]);
				int num = 0;
				while (num < this.LstSex.Items.Count)
				{
					if (this.LstSex.Items[num].Value != str)
					{
						num++;
					}
					else
					{
						this.LstSex.SelectedIndex = num;
						break;
					}
				}
				this.TxtSocialID.Text = (item["SocialID"] is DBNull ? "" : (string)item["SocialID"]);
			}
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.LoadMenu();
			UserProfile userProfile = UserAuthorize.GetUserProfile(this);
			this.employeeID = int.Parse(userProfile.EmployeeID.ToString());
			this.LblSuccess.Visible = false;
			if (!base.IsPostBack)
			{
				this.LoadEmployee(this.employeeID);
			}
		}
	}
}