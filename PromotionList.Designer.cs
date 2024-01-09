using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class PromotionList : System.Web.UI.Page
	{
		protected HtmlForm AddPage;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected DataGrid PromotionGrid;

		protected Button BtnAdd;

		public PromotionList()
		{
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(Pages.Url(this, Pages.PRO_ADD_PAGE));
			base.Response.Redirect(stringBuilder.ToString());
		}

		private void InitializeComponent()
		{
			this.BtnAdd.Click += new EventHandler(this.BtnAdd_Click);
			this.PromotionGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.PrmotionGrid_PageIndexChanged);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadPromotionList()
		{
			this.PromotionGrid.DataSource = Promotion.PromotionList();
			this.PromotionGrid.DataBind();
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
				this.LoadPromotionList();
			}
		}

		private void PrmotionGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.PromotionGrid.CurrentPageIndex = e.NewPageIndex;
			this.LoadPromotionList();
		}
	}
}