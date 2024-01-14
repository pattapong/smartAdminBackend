using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
    public class SmartclientAdd : System.Web.UI.Page
    {
        protected Button BtnSave;

        protected Button BtnCancel;

        protected SmartAdmin.Controls.HeaderBox HeaderBox;

        protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

        protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

        protected ValidationSummary ValidationSummary1;

        protected RequiredFieldValidator RequiredFieldValidator1;

        protected Label LbSmartclientID;

        protected Label LblSmartclientName;

        protected Label LblSmartclientLocalPrinter;

        protected TextBox TxtSmartclientID;

        protected TextBox TxtSmartclientName;

        protected TextBox TxtSmartclientLocalPrinter;


        protected Image ImgError;

        public SmartclientAdd()
        {
        }

        private void BackPage()
        {
            base.Response.Redirect(Pages.Url(this, Pages.MAS_SMARTCLIENT_LIST_PAGE));
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.BackPage();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                SmartAdmin.Data.Master.SmartclientInsert(this.TxtSmartclientID.Text, this.TxtSmartclientName.Text, this.TxtSmartclientLocalPrinter.Text);
                this.BackPage();
            }
        }

        private void InitializeComponent()
        {
            this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
            this.BtnCancel.Click += new EventHandler(this.BtnCancel_Click);
            base.Load += new EventHandler(this.Page_Load);
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
        }
    }
}