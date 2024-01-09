using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartAdmin.Employee
{
	public class EmployeeSetPermission : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnCancel;

		protected Button BtnSave;

		protected Label LblError;

		protected Image ImgError;

		protected DropDownList LstType;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected HtmlForm AddPage;

		protected Label LblType;

		protected DropDownList LstEmployee;

		protected ListBox LstFrom;

		protected Button BtnAdd;

		protected Button BtnRemove;

		protected ListBox LstTo;

		protected Label LblSet;

		protected Label LblSuccess;

		protected DropDownList LstPermission;

		public EmployeeSetPermission()
		{
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			int count = this.LstTo.Items.Count;
			for (int i = this.LstFrom.Items.Count - 1; i >= 0; i--)
			{
				if (this.LstFrom.Items[i].Selected)
				{
					this.LstTo.Items.Insert(count, this.LstFrom.Items[i]);
					this.LstFrom.Items.RemoveAt(i);
				}
			}
		}

		private void BtnRemove_Click(object sender, EventArgs e)
		{
			int count = this.LstFrom.Items.Count;
			for (int i = this.LstTo.Items.Count - 1; i >= 0; i--)
			{
				if (this.LstTo.Items[i].Selected)
				{
					this.LstFrom.Items.Insert(count, this.LstTo.Items[i]);
					this.LstTo.Items.RemoveAt(i);
				}
			}
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			int i;
			if (this.LstType.SelectedItem.Value != "Employee")
			{
				for (i = 0; i < this.LstTo.Items.Count; i++)
				{
					SmartAdmin.Data.Employee.UpdateEmployeePermission(this.LstTo.Items[i].Value, this.LstPermission.SelectedItem.Value);
				}
			}
			else
			{
				for (i = 0; i < this.LstTo.Items.Count; i++)
				{
					SmartAdmin.Data.Employee.UpdateEmployeePermission(this.LstEmployee.SelectedItem.Value, this.LstTo.Items[i].Value);
				}
			}
			string str = "";
			for (i = 0; i < this.LstFrom.Items.Count; i++)
			{
				str = string.Concat(str, this.LstFrom.Items[i].Value, ",");
			}
			if (str != "")
			{
				str = str.Substring(0, str.Length - 1);
				if (this.LstType.SelectedItem.Value != "Employee")
				{
					SmartAdmin.Data.Employee.DeleteEmployeePermissionByPer(this.LstPermission.SelectedItem.Value, str);
				}
				else
				{
					SmartAdmin.Data.Employee.DeleteEmployeePermissionByEmp(this.LstEmployee.SelectedItem.Value, str);
				}
			}
			this.LblSuccess.Visible = true;
		}

		private void ChooseChoice(string typein)
		{
			if (typein == "Employee")
			{
				this.LstTo.DataSource = SmartAdmin.Data.Employee.PermissionByEmpList(this.LstEmployee.SelectedItem.Value);
				this.LstTo.DataTextField = "Name";
				this.LstTo.DataValueField = "AdminMenuID";
				this.LstTo.DataBind();
				this.LstFrom.DataSource = SmartAdmin.Data.Employee.PermissionListByEmpExclude(this.LstEmployee.SelectedItem.Value);
				this.LstFrom.DataTextField = "Name";
				this.LstFrom.DataValueField = "AdminMenuID";
				this.LstFrom.DataBind();
				return;
			}
			this.LstTo.DataSource = SmartAdmin.Data.Employee.EmployeeListByPermission(this.LstPermission.SelectedItem.Value);
			this.LstTo.DataTextField = "Name";
			this.LstTo.DataValueField = "EmployeeID";
			this.LstTo.DataBind();
			this.LstFrom.DataSource = SmartAdmin.Data.Employee.EmployeeListByPermissionExclude(this.LstPermission.SelectedItem.Value);
			this.LstFrom.DataTextField = "Name";
			this.LstFrom.DataValueField = "EmployeeID";
			this.LstFrom.DataBind();
		}

		private void ChooseType(string typein)
		{
			if (typein != "Employee")
			{
				this.LblType.Text = "Select Permission";
				this.LblSet.Text = "Select Employee for selected Permission";
				this.LstEmployee.Visible = false;
				this.LstPermission.Visible = true;
			}
			else
			{
				this.LblType.Text = "Select Employee Name";
				this.LblSet.Text = "Select Permission for selected Employee";
				this.LstEmployee.Visible = true;
				this.LstPermission.Visible = false;
			}
			this.ChooseChoice(typein);
		}

		private void InitializeComponent()
		{
			this.LstType.SelectedIndexChanged += new EventHandler(this.LstType_SelectedIndexChanged);
			this.LstEmployee.SelectedIndexChanged += new EventHandler(this.LstEmployee_SelectedIndexChanged);
			this.LstPermission.SelectedIndexChanged += new EventHandler(this.LstPermission_SelectedIndexChanged);
			this.BtnAdd.Click += new EventHandler(this.BtnAdd_Click);
			this.BtnRemove.Click += new EventHandler(this.BtnRemove_Click);
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadCriteria()
		{
			this.LstEmployee.DataSource = SmartAdmin.Data.Employee.EmployeeList();
			this.LstEmployee.DataTextField = "Name";
			this.LstEmployee.DataValueField = "EmployeeID";
			this.LstEmployee.DataBind();
			this.LstEmployee.SelectedIndex = 0;
			this.LstPermission.DataSource = SmartAdmin.Data.Employee.PermissionByEmpList();
			this.LstPermission.DataTextField = "Name";
			this.LstPermission.DataValueField = "AdminMenuID";
			this.LstPermission.DataBind();
			this.LstPermission.SelectedIndex = 0;
			this.ChooseType("Employee");
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LstEmployee_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.ChooseChoice(this.LstType.SelectedItem.Value);
		}

		private void LstPermission_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.ChooseChoice(this.LstType.SelectedItem.Value);
		}

		private void LstType_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.ChooseType(this.LstType.SelectedItem.Value);
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.LoadMenu();
			this.LblSuccess.Visible = false;
			if (!base.IsPostBack)
			{
				this.LoadCriteria();
			}
		}
	}
}