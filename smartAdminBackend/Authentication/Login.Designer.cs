using SmartAdmin.Controls;
using SmartAdmin.Utils;
using System;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartAdmin.Authentication
{
	public class Login : System.Web.UI.Page
	{
		protected TextBox TxtPassword;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnLogin;

		protected TextBox TxtEmpID;

		protected Label LblError;

		protected HtmlForm AddPage;

		public Login()
		{
		}

		private void BtnLogin_Click(object sender, EventArgs e)
		{
			if (this.TxtEmpID.Text == "" || this.TxtPassword.Text == "")
			{
				this.LblError.Text = "Please enter user ID and password.";
				return;
			}
			try
			{
				int.Parse(this.TxtEmpID.Text);
			}
			catch (Exception exception)
			{
				this.LblError.Text = "Your user ID is wrong format.";
				return;
			}
			if (UserAuthorize.Login(this, this.TxtEmpID.Text, this.TxtPassword.Text))
			{
				base.Response.Redirect(Pages.Url(this, Pages.HOME_PAGE));
				return;
			}
			this.LblError.Text = "Your user ID or password is wrong. Or you don't have authorize to access.";
		}

		private void InitializeComponent()
		{
			this.BtnLogin.Click += new EventHandler(this.BtnLogin_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, null, null, this.CopyrightBox);
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.Session[UserAuthorize.SES_ADMINTYPE] = "ADMIN";
			this.LoadMenu();
			this.HeaderBox.IsLogin = true;
			this.HeaderBox.IsAdmin = true;
		}
	}
}