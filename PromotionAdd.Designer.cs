using SmartAdmin.Controls;
using SmartAdmin.Data;
using SmartAdmin.Utils;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartAdmin
{
	public class PromotionAdd : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected DropDownList LstType;

		protected Image ImgError;

		protected Button BtnSave;

		protected Button BtnCancel;

		protected ValidationSummary ValidationSummary1;

		protected RequiredFieldValidator RequiredFieldValidator1;

		protected Label TxtProID;

		protected DropDownList LstMenuType;

		protected ListBox LstMenu;

		protected TextBox TxtDiscount;

		protected TextBox TxtPoint;

		protected TextBox TxtDescription;

		protected TextBox TxtAmount;

		protected TextBox TxtValidfrom;

		protected RequiredFieldValidator RequiredFieldAmount;

		protected RequiredFieldValidator RequiredFieldDiscount;

		protected RequiredFieldValidator RequiredFieldPoint;

		protected RequiredFieldValidator RequiredFieldValidfrom;

		protected RangeValidator RangeAmount;

		protected RangeValidator RangeDiscount;

		protected RangeValidator RangePoint;

		protected TextBox TxtValidto;

		protected CheckBoxList ChkDay0;

		protected CheckBoxList ChkDay1;

		protected CheckBoxList ChkDay2;

		protected CheckBoxList ChkDay3;

		protected CheckBoxList ChkDay4;

		protected CheckBoxList ChkDay5;

		protected CheckBoxList ChkDay6;

		protected Repeater RepeatTime;

		protected RequiredFieldValidator RequiredFieldDiscountAmount;

		protected RangeValidator RangeDiscountAmount;

		protected TextBox TxtDiscountAmount;

		private string proFlag;

		public PromotionAdd()
		{
		}

		private void BackPage()
		{
			base.Response.Redirect(Pages.Url(this, Pages.PRO_LIST_PAGE));
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.BackPage();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			int i;
			char[] chrArray;
			string[] str;
			string text = null;
			if (this.TxtAmount.Enabled)
			{
				text = this.TxtAmount.Text;
			}
			string text1 = null;
			if (this.TxtDiscount.Enabled)
			{
				text1 = this.TxtDiscount.Text;
			}
			string str1 = null;
			if (this.TxtDiscountAmount.Enabled)
			{
				str1 = this.TxtDiscountAmount.Text;
			}
			string value = null;
			if (this.LstMenu.Enabled)
			{
				value = this.LstMenu.SelectedItem.Value;
			}
			string text2 = null;
			if (this.TxtPoint.Enabled)
			{
				text2 = this.TxtPoint.Text;
			}
			string str2 = null;
			if (this.TxtValidfrom.Enabled && this.TxtValidfrom.Text != "")
			{
				string text3 = this.TxtValidfrom.Text;
				chrArray = new char[] { '/' };
				string[] strArrays = text3.Split(chrArray);
				str = new string[] { strArrays[2].ToString(), "-", strArrays[1].ToString(), "-", strArrays[0].ToString() };
				str2 = string.Concat(str);
			}
			string str3 = null;
			if (this.TxtValidto.Enabled && this.TxtValidto.Text != "")
			{
				string text4 = this.TxtValidto.Text;
				chrArray = new char[] { '/' };
				string[] strArrays1 = text4.Split(chrArray);
				str = new string[] { strArrays1[2].ToString(), "/", strArrays1[1].ToString(), "/", strArrays1[0].ToString() };
				str3 = string.Concat(str);
			}
			string str4 = Promotion.PromotionInsert(this.LstType.SelectedItem.Value, this.TxtDescription.Text, text, text1, value, text2, str1, str2, str3);
			string[] strArrays2 = new string[7];
			for (i = 0; i < this.ChkDay0.Items.Count; i++)
			{
				if (!this.ChkDay0.Items[i].Selected)
				{
					string[] strArrays3 = strArrays2;
					str = strArrays3;
					strArrays3[0] = string.Concat(str[0], this.ChkDay0.Items[i].Value, ",");
				}
				else
				{
					Promotion.PromotionTimeInsert(int.Parse(str4), 0, int.Parse(this.ChkDay0.Items[i].Value));
				}
			}
			for (i = 0; i < this.ChkDay1.Items.Count; i++)
			{
				if (!this.ChkDay1.Items[i].Selected)
				{
					string[] strArrays4 = strArrays2;
					str = strArrays4;
					strArrays4[1] = string.Concat(str[1], this.ChkDay1.Items[i].Value, ",");
				}
				else
				{
					Promotion.PromotionTimeInsert(int.Parse(str4), 1, int.Parse(this.ChkDay1.Items[i].Value));
				}
			}
			for (i = 0; i < this.ChkDay2.Items.Count; i++)
			{
				if (!this.ChkDay2.Items[i].Selected)
				{
					string[] strArrays5 = strArrays2;
					str = strArrays5;
					strArrays5[2] = string.Concat(str[2], this.ChkDay2.Items[i].Value, ",");
				}
				else
				{
					Promotion.PromotionTimeInsert(int.Parse(str4), 2, int.Parse(this.ChkDay2.Items[i].Value));
				}
			}
			for (i = 0; i < this.ChkDay3.Items.Count; i++)
			{
				if (!this.ChkDay3.Items[i].Selected)
				{
					string[] strArrays6 = strArrays2;
					str = strArrays6;
					strArrays6[3] = string.Concat(str[3], this.ChkDay3.Items[i].Value, ",");
				}
				else
				{
					Promotion.PromotionTimeInsert(int.Parse(str4), 3, int.Parse(this.ChkDay3.Items[i].Value));
				}
			}
			for (i = 0; i < this.ChkDay4.Items.Count; i++)
			{
				if (!this.ChkDay4.Items[i].Selected)
				{
					string[] strArrays7 = strArrays2;
					str = strArrays7;
					strArrays7[4] = string.Concat(str[4], this.ChkDay4.Items[i].Value, ",");
				}
				else
				{
					Promotion.PromotionTimeInsert(int.Parse(str4), 4, int.Parse(this.ChkDay4.Items[i].Value));
				}
			}
			for (i = 0; i < this.ChkDay5.Items.Count; i++)
			{
				if (!this.ChkDay5.Items[i].Selected)
				{
					string[] strArrays8 = strArrays2;
					str = strArrays8;
					strArrays8[5] = string.Concat(str[5], this.ChkDay5.Items[i].Value, ",");
				}
				else
				{
					Promotion.PromotionTimeInsert(int.Parse(str4), 5, int.Parse(this.ChkDay5.Items[i].Value));
				}
			}
			for (i = 0; i < this.ChkDay6.Items.Count; i++)
			{
				if (!this.ChkDay6.Items[i].Selected)
				{
					string[] strArrays9 = strArrays2;
					str = strArrays9;
					strArrays9[6] = string.Concat(str[6], this.ChkDay6.Items[i].Value, ",");
				}
				else
				{
					Promotion.PromotionTimeInsert(int.Parse(str4), 6, int.Parse(this.ChkDay6.Items[i].Value));
				}
			}
			this.BackPage();
		}

		private void InitializeComponent()
		{
			this.LstType.SelectedIndexChanged += new EventHandler(this.LstType_SelectedIndexChanged);
			this.LstMenuType.SelectedIndexChanged += new EventHandler(this.LstMenuType_SelectedIndexChanged);
			this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
			this.BtnCancel.Click += new EventHandler(this.BtnCancel_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		private void LoadMenu()
		{
			AdminMenu.SetMenu(this, this.HeaderBox, this.SubmenuBox, this.CopyrightBox);
		}

		private void LoadMenu(int menuTypeID)
		{
			this.LstMenu.DataSource = SmartAdmin.Data.Menu.MenuByTypeList(menuTypeID);
			this.LstMenu.DataTextField = "MenuNameEnglish";
			this.LstMenu.DataValueField = "MenuID";
			this.LstMenu.DataBind();
			if (this.LstMenu.Items.Count > 0)
			{
				this.LstMenu.SelectedIndex = 0;
			}
		}

		private void LoadMenuType()
		{
			this.LstMenuType.DataSource = SmartAdmin.Data.Master.MenuTypeList();
			this.LstMenuType.DataTextField = "MenuTypeName";
			this.LstMenuType.DataValueField = "MenuTypeID";
			this.LstMenuType.DataBind();
			string str = this.LstMenuType.SelectedItem.Value.ToString();
			if (str != null)
			{
				this.LoadMenu(int.Parse(str));
			}
		}

		private void LoadPromotionType()
		{
			this.LstType.DataSource = Promotion.PromotionTypeList();
			this.LstType.DataTextField = "ProTypeName";
			this.LstType.DataValueField = "ProTypeID";
			this.LstType.DataBind();
			this.setProFlag(int.Parse(this.LstType.SelectedItem.Value));
		}

		private void LoadTime()
		{
			this.RepeatTime.DataSource = SmartAdmin.Data.Master.ShowTimeList();
			this.RepeatTime.DataMember = "TimeName";
			this.RepeatTime.DataBind();
			this.ChkDay0.DataSource = SmartAdmin.Data.Master.ShowTimeList();
			this.ChkDay0.DataTextField = "show";
			this.ChkDay0.DataValueField = "TimeID";
			this.ChkDay0.DataBind();
			this.ChkDay1.DataSource = SmartAdmin.Data.Master.ShowTimeList();
			this.ChkDay1.DataTextField = "show";
			this.ChkDay1.DataValueField = "TimeID";
			this.ChkDay1.DataBind();
			this.ChkDay2.DataSource = SmartAdmin.Data.Master.ShowTimeList();
			this.ChkDay2.DataTextField = "show";
			this.ChkDay2.DataValueField = "TimeID";
			this.ChkDay2.DataBind();
			this.ChkDay3.DataSource = SmartAdmin.Data.Master.ShowTimeList();
			this.ChkDay3.DataTextField = "show";
			this.ChkDay3.DataValueField = "TimeID";
			this.ChkDay3.DataBind();
			this.ChkDay4.DataSource = SmartAdmin.Data.Master.ShowTimeList();
			this.ChkDay4.DataTextField = "show";
			this.ChkDay4.DataValueField = "TimeID";
			this.ChkDay4.DataBind();
			this.ChkDay5.DataSource = SmartAdmin.Data.Master.ShowTimeList();
			this.ChkDay5.DataTextField = "show";
			this.ChkDay5.DataValueField = "TimeID";
			this.ChkDay5.DataBind();
			this.ChkDay6.DataSource = SmartAdmin.Data.Master.ShowTimeList();
			this.ChkDay6.DataTextField = "show";
			this.ChkDay6.DataValueField = "TimeID";
			this.ChkDay6.DataBind();
		}

		private void LstMenuType_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.LoadMenu(int.Parse(this.LstMenuType.SelectedItem.Value));
		}

		private void LstType_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.setProFlag(int.Parse(this.LstType.SelectedItem.Value));
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
				this.LoadPromotionType();
				this.LoadMenuType();
				TextBox txtValidfrom = this.TxtValidfrom;
				string[] str = new string[5];
				int day = DateTime.Now.Day;
				str[0] = day.ToString();
				str[1] = "/";
				day = DateTime.Now.Month;
				str[2] = day.ToString();
				str[3] = "/";
				day = DateTime.Now.Year;
				str[4] = day.ToString();
				txtValidfrom.Text = string.Concat(str);
				this.LoadTime();
			}
		}

		private void setProFlag(int proflagID)
		{
			bool flag;
			DataTable dataTable = Promotion.PromotionTypeList(proflagID);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				DataRow item = dataTable.Rows[0];
				this.proFlag = item["ProFlag"].ToString();
			}
			if (this.proFlag != "")
			{
				if (this.proFlag.Substring(1, 1) != "1")
				{
					flag = false;
				}
				else
				{
					flag = true;
					this.TxtAmount.Text = "0";
				}
				this.TxtAmount.Enabled = flag;
				this.RequiredFieldAmount.Enabled = flag;
				this.RangeAmount.Enabled = flag;
				if (this.proFlag.Substring(2, 1) != "1")
				{
					flag = false;
				}
				else
				{
					flag = true;
					this.TxtDiscount.Text = "0";
				}
				this.TxtDiscount.Enabled = flag;
				this.RequiredFieldDiscount.Enabled = flag;
				this.RangeDiscount.Enabled = flag;
				flag = (this.proFlag.Substring(3, 1) != "1" ? false : true);
				this.LstMenuType.Enabled = flag;
				this.LstMenu.Enabled = flag;
				if (this.proFlag.Substring(4, 1) != "1")
				{
					flag = false;
				}
				else
				{
					flag = true;
					this.TxtPoint.Text = "0";
				}
				this.TxtPoint.Enabled = flag;
				this.RequiredFieldPoint.Enabled = flag;
				this.RangePoint.Enabled = flag;
				if (this.proFlag.Substring(5, 1) != "1")
				{
					flag = false;
				}
				else
				{
					flag = true;
					this.TxtDiscountAmount.Text = "0";
				}
				this.TxtDiscountAmount.Enabled = flag;
				this.RequiredFieldDiscountAmount.Enabled = flag;
				this.RangeDiscountAmount.Enabled = flag;
			}
		}
	}
}