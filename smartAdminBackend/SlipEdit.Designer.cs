using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class SlipEdit : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected Button BtnCancel;

		protected Button BtnSave;

		protected Image ImgError;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected HtmlForm AddPage;

		protected ValidationSummary ValidationSummary1;

		private string slipID;

		protected Label TxtSlipID;

		protected DropDownList LstHeader;

		protected DropDownList LstBody;

		protected DropDownList LstOption1;

		protected DropDownList LstOption2;

		protected Label LblOption2;

		protected Label LblOption1;

		private int headerID;

		private int bodyID;

		private int option1ID;

		private int option2ID;

		public SlipEdit()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.MAS_SLIPSTYLE_LIST_PAGE));
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.BackPage();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
            SmartAdmin.Data.Master.SlipStyleUpdate(this.slipID, int.Parse(this.LstHeader.SelectedItem.Value), int.Parse(this.LstBody.SelectedItem.Value), int.Parse(this.LstOption1.SelectedItem.Value), int.Parse(this.LstOption2.SelectedItem.Value));
			this.BackPage();
		}

		private void InitializeComponent()
		{
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			this.BtnCancel.Click += new EventHandler(this.BtnCancel_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadFont()
		{
			int i;
			this.LstHeader.DataSource = SmartAdmin.Data.Master.FontList();
			this.LstHeader.DataTextField = "FontDesc";
			this.LstHeader.DataValueField = "FontID";
			this.LstHeader.DataBind();
			if (this.headerID > 0)
			{
				for (i = 0; i < this.LstHeader.Items.Count; i++)
				{
					if (int.Parse(this.LstHeader.Items[i].Value) == this.headerID)
					{
						this.LstHeader.SelectedIndex = i;
					}
				}
			}
			this.LstBody.DataSource = SmartAdmin.Data.Master.FontList();
			this.LstBody.DataTextField = "FontDesc";
			this.LstBody.DataValueField = "FontID";
			this.LstBody.DataBind();
			if (this.bodyID > 0)
			{
				for (i = 0; i < this.LstBody.Items.Count; i++)
				{
					if (int.Parse(this.LstBody.Items[i].Value) == this.bodyID)
					{
						this.LstBody.SelectedIndex = i;
					}
				}
			}
			this.LstOption1.DataSource = SmartAdmin.Data.Master.FontList();
			this.LstOption1.DataTextField = "FontDesc";
			this.LstOption1.DataValueField = "FontID";
			this.LstOption1.DataBind();
			if (this.option1ID > 0)
			{
				for (i = 0; i < this.LstOption1.Items.Count; i++)
				{
					if (int.Parse(this.LstOption1.Items[i].Value) == this.option1ID)
					{
						this.LstOption1.SelectedIndex = i;
					}
				}
			}
			this.LstOption2.DataSource = SmartAdmin.Data.Master.FontList();
			this.LstOption2.DataTextField = "FontDesc";
			this.LstOption2.DataValueField = "FontID";
			this.LstOption2.DataBind();
			if (this.option2ID > 0)
			{
				for (i = 0; i < this.LstOption2.Items.Count; i++)
				{
					if (int.Parse(this.LstOption2.Items[i].Value) == this.option2ID)
					{
						this.LstOption2.SelectedIndex = i;
					}
				}
			}
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadSlip()
		{
			DataTable dataTable =SmartAdmin.Data.Master.SlipStyleList(this.slipID);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				base.Response.Redirect(Pages.Url(this, Pages.MAS_SLIPSTYLE_LIST_PAGE));
				return;
			}
			DataRow item = dataTable.Rows[0];
			this.TxtSlipID.Text = this.slipID.ToString();
			if (this.slipID != "KIT")
			{
				this.LblOption1.Text = "Tax";
				this.LblOption2.Text = "Total";
			}
			else
			{
				this.LblOption1.Text = "Option";
				this.LblOption2.Text = "Memo";
			}
			this.headerID = int.Parse(item["HeaderFontID"].ToString());
			this.bodyID = int.Parse(item["BodyFontID"].ToString());
			this.option1ID = int.Parse(item["Option1FontID"].ToString());
			this.option2ID = int.Parse(item["Option2FontID"].ToString());
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.LoadMenu();
			this.slipID = Pages.QueryStr(this, "id", "-1");
			if (this.slipID == "-1")
			{
				this.BackPage();
			}
			if (!base.IsPostBack)
			{
				this.LoadSlip();
				this.LoadFont();
			}
		}
	}
}