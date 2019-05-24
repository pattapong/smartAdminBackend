using SmartAdmin.Utils;
using System;
using System.Web;
using System.Web.UI;

namespace SmartAdmin.Authentication
{
	public class Logout : System.Web.UI.Page
	{
		public Logout()
		{
		}

		private void InitializeComponent()
		{
			base.Load += new EventHandler(this.Page_Load);
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			UserAuthorize.Logout(this);
			base.Response.Redirect(Pages.Url(this, Pages.HOME_PAGE));
		}
	}
}