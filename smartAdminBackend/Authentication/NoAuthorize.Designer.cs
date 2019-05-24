using SmartAdmin.Controls;
using SmartAdmin.Utils;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;

namespace SmartAdmin.Authentication
{
	public class NoAuthorize : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		private int menuType;

		public NoAuthorize()
		{
		}

		private void InitializeComponent()
		{
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, null, this.CopyrightBox);
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			try
			{
				this.menuType = int.Parse(base.Request.QueryString["type"]);
			}
			catch (Exception exception)
			{
				this.menuType = 0;
			}
			this.LoadMenu();
		}
	}
}