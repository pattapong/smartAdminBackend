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
    public class SmartclientEdit : System.Web.UI.Page
    {
        protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

        protected Button BtnCancel;

        protected Button BtnSave;

        protected Image ImgError;

        protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

        protected SmartAdmin.Controls.HeaderBox HeaderBox;

        protected HtmlForm AddPage;

        private int smartclientID;

        protected RequiredFieldValidator RequiredFieldValidator1;

        protected Label LblSmartclientID;

        protected Label LblSmartclientName;

        protected Label LblSmartclientLocalPrinter;

        protected Label TxtSmartclientID;

        protected TextBox TxtSmartclientName;

        protected TextBox TxtSmartclientLocalPrinter;

        protected ValidationSummary ValidationSummary1;

        public SmartclientEdit()
        {
        }

        private void BackPage()
        {
            base.Response.Redirect(Pages.Url(this, Pages.MAS_SMARTCLIENT_LIST_PAGE));
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                SmartAdmin.Data.Master.SmartclientUpdate(this.smartclientID, this.TxtSmartclientName.Text, this.TxtSmartclientLocalPrinter.Text);
                this.BackPage();
            }
        }

        private void InitializeComponent()
        {
            this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void LoadSmartclient()
        {
            DataTable dataTable = SmartAdmin.Data.Master.SmartclientList(this.smartclientID);
            if (dataTable == null || dataTable.Rows.Count <= 0)
            {
                base.Response.Redirect(Pages.Url(this, Pages.MAS_SMARTCLIENT_LIST_PAGE));
                return;
            }
            DataRow item = dataTable.Rows[0];
            this.TxtSmartclientID.Text = this.smartclientID.ToString();
            this.TxtSmartclientName.Text = item["smartclientdescription"].ToString();
            this.TxtSmartclientLocalPrinter.Text = item["localprinter"].ToString();
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
            this.smartclientID = Pages.QueryInt(this, "id", -1);
            if (this.smartclientID <= 0)
            {
                this.BackPage();
            }
            if (!base.IsPostBack)
            {
                this.LoadSmartclient();
            }
        }
    }
}