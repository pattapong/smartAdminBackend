using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartAdmin.Employee
{
	public class EmployeeAdd : System.Web.UI.Page
	{
		protected TextBox TxtPassword;

		protected TextBox TxtComfirmPassword;

		protected DropDownList LstType;

		protected Button BtnSave;

		protected Button BtnCancel;

		protected TextBox TxtFirstName;

		protected TextBox TxtLastName;

		protected Label LblFirstName;

		protected Label LblLastName;

		protected Label LblPassword;

		protected Label LblConfirmPassword;

		protected Label LblError;

		protected Image ImgError;

		protected Label LblEmployeeID;

		protected Label LblNickName;

		protected TextBox TxtNickName;

		protected Label TxtEmployeeID;

		protected DropDownList LstSex;

		protected Label LblSocialID;

		protected TextBox TxtSocialID;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		private int TypeID;

		public EmployeeAdd()
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
			if (!this.ValidateForm())
			{
				return;
			}
			SmartAdmin.Data.Employee.Insert(this.TxtFirstName.Text, this.TxtLastName.Text, this.TxtNickName.Text, this.LstSex.SelectedItem.Value, this.TxtSocialID.Text, this.TxtPassword.Text, this.TypeID);
			this.BackPage();
		}

		private void InitializeComponent()
		{
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			this.BtnCancel.Click += new EventHandler(this.BtnCancel_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadEmployeeType()
		{
			this.TxtEmployeeID.Text = "New Employee ID";
			this.LstType.DataSource = SmartAdmin.Data.Master.EmployeeTypeList();
			this.LstType.DataTextField = "EmployeeTypeName";
			this.LstType.DataValueField = "EmployeeTypeID";
			this.LstType.DataBind();
			this.LstType.SelectedIndex = 3;
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
			if (!base.IsPostBack)
			{
				this.LoadEmployeeType();
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
			if (this.TxtPassword.Text == "")
			{
				this.LblError.Text = "Password must be not blank.";
				this.ImgError.Visible = true;
				this.LblPassword.CssClass = "error";
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