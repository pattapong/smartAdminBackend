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
	public class PromotionEdit : System.Web.UI.Page
	{
		protected SmartAdmin.Controls.CopyrightBox CopyrightBox;

		protected SmartAdmin.Controls.SubmenuBox SubmenuBox;

		protected SmartAdmin.Controls.HeaderBox HeaderBox;

		protected HtmlForm AddPage;

		protected Button BtnCancel;

		protected Button BtnSave;

		protected ValidationSummary ValidationSummary1;

		protected Image ImgError;

		protected CheckBoxList ChkDay0;

		protected CheckBoxList ChkDay6;

		protected CheckBoxList ChkDay5;

		protected CheckBoxList ChkDay4;

		protected CheckBoxList ChkDay3;

		protected CheckBoxList ChkDay2;

		protected CheckBoxList ChkDay1;

		protected Repeater RepeatTime;

		protected TextBox TxtValidto;

		protected RequiredFieldValidator RequiredFieldValidfrom;

		protected TextBox TxtValidfrom;

		protected RangeValidator RangePoint;

		protected RequiredFieldValidator RequiredFieldPoint;

		protected TextBox TxtPoint;

		protected ListBox LstMenu;

		protected DropDownList LstMenuType;

		protected RangeValidator RangeDiscount;

		protected RequiredFieldValidator RequiredFieldDiscount;

		protected TextBox TxtDiscount;

		protected RangeValidator RangeAmount;

		protected RequiredFieldValidator RequiredFieldAmount;

		protected TextBox TxtAmount;

		protected RequiredFieldValidator RequiredFieldValidator1;

		protected TextBox TxtDescription;

		protected Label TxtProID;

		private int proID;

		private string proFlag;

		private string protypeID;

		private string menuID;

		private string menutypeID;

		protected RequiredFieldValidator RequiredFieldDiscountAmount;

		protected RangeValidator RangeDiscountAmount;

		protected TextBox TxtDiscountAmount;

		protected Label TxtProType;

		public PromotionEdit()
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
			Promotion.PromotionUpdate(this.proID, this.protypeID, this.TxtDescription.Text, text, text1, value, text2, str1, str2, str3);
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
					Promotion.PromotionTimeInsert(this.proID, 0, int.Parse(this.ChkDay0.Items[i].Value));
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
					Promotion.PromotionTimeInsert(this.proID, 1, int.Parse(this.ChkDay1.Items[i].Value));
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
					Promotion.PromotionTimeInsert(this.proID, 2, int.Parse(this.ChkDay2.Items[i].Value));
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
					Promotion.PromotionTimeInsert(this.proID, 3, int.Parse(this.ChkDay3.Items[i].Value));
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
					Promotion.PromotionTimeInsert(this.proID, 4, int.Parse(this.ChkDay4.Items[i].Value));
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
					Promotion.PromotionTimeInsert(this.proID, 5, int.Parse(this.ChkDay5.Items[i].Value));
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
					Promotion.PromotionTimeInsert(this.proID, 6, int.Parse(this.ChkDay6.Items[i].Value));
				}
			}
			for (i = 0; i < 7; i++)
			{
				if (strArrays2[i] != null)
				{
					strArrays2[i] = strArrays2[i].Substring(0, strArrays2[i].Length - 1);
					Promotion.PromotionTimeDelete(this.proID, i, strArrays2[i]);
				}
			}
			this.BackPage();
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

		private void LoadMenu(int menuTypeID)
		{
			this.LstMenu.DataSource = SmartAdmin.Data.Menu.MenuByTypeList(menuTypeID);
			this.LstMenu.DataTextField = "MenuNameEnglish";
			this.LstMenu.DataValueField = "MenuID";
			this.LstMenu.DataBind();
			if (this.menuID == "")
			{
				if (this.LstMenu.Items.Count > 0)
				{
					this.LstMenu.SelectedIndex = 0;
				}
				return;
			}
			for (int i = 0; i < this.LstMenu.Items.Count; i++)
			{
				if (this.LstMenu.Items[i].Value == this.menuID)
				{
					this.LstMenu.SelectedIndex = i;
				}
			}
		}

		private void LoadMenuType()
		{
			this.LstMenuType.DataSource = SmartAdmin.Data.Master.MenuTypeList();
			this.LstMenuType.DataTextField = "MenuTypeName";
			this.LstMenuType.DataValueField = "MenuTypeID";
			this.LstMenuType.DataBind();
			if (this.menuID == "")
			{
				this.menutypeID = this.LstMenuType.SelectedItem.Value.ToString();
			}
			else
			{
				for (int i = 0; i < this.LstMenuType.Items.Count; i++)
				{
					if (this.LstMenuType.Items[i].Value == this.menutypeID)
					{
						this.LstMenuType.SelectedIndex = i;
					}
				}
			}
			this.LoadMenu(int.Parse(this.menutypeID));
		}

		private void LoadPromotion()
		{
			DataTable dataTable = Promotion.PromotionList(this.proID);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				base.Response.Redirect(Pages.Url(this, Pages.PRO_LIST_PAGE));
				return;
			}
			DataRow item = dataTable.Rows[0];
			this.TxtProID.Text = this.proID.ToString();
			this.protypeID = item["protypeid"].ToString();
			this.setProFlag(int.Parse(this.protypeID));
			this.TxtProType.Text = item["protypename"].ToString();
			this.TxtDescription.Text = item["description"].ToString();
			this.TxtAmount.Text = item["amountstr"].ToString();
			this.TxtDiscountAmount.Text = item["discountamountstr"].ToString();
			this.TxtDiscount.Text = item["discountstr"].ToString();
			this.menutypeID = item["menutypeid"].ToString();
			this.menuID = item["menuid"].ToString();
			this.TxtPoint.Text = item["point"].ToString();
			this.TxtValidfrom.Text = item["validfromstr"].ToString();
			this.TxtValidto.Text = item["validtostr"].ToString();
			this.proFlag = item["proflag"].ToString();
		}

		private void LoadPromotionTime()
		{
			DataTable dataTable = Promotion.PromotionTimeList(this.proID);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow item = dataTable.Rows[i];
				this.setTime(int.Parse(item["proday"].ToString()), item["timeid"].ToString());
			}
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

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.LoadMenu();
			this.proID = Pages.QueryInt(this, "id", -1);
			if (this.proID <= 0)
			{
				this.BackPage();
			}
			if (base.IsPostBack)
			{
				this.proFlag = this.ViewState["proFlag"].ToString();
				this.protypeID = this.ViewState["protypeID"].ToString();
				this.menuID = this.ViewState["menuID"].ToString();
				this.menutypeID = this.ViewState["menutypeID"].ToString();
				return;
			}
			this.LoadPromotion();
			this.LoadMenuType();
			this.LoadTime();
			this.LoadPromotionTime();
			this.ViewState["proFlag"] = this.proFlag;
			this.ViewState["protypeID"] = this.protypeID;
			this.ViewState["menuID"] = this.menuID;
			this.ViewState["menutypeID"] = this.menutypeID;
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
				flag = (this.proFlag.Substring(1, 1) != "1" ? false : true);
				this.TxtAmount.Enabled = flag;
				this.RequiredFieldAmount.Enabled = flag;
				this.RangeAmount.Enabled = flag;
				flag = (this.proFlag.Substring(2, 1) != "1" ? false : true);
				this.TxtDiscount.Enabled = flag;
				this.RequiredFieldDiscount.Enabled = flag;
				this.RangeDiscount.Enabled = flag;
				flag = (this.proFlag.Substring(3, 1) != "1" ? false : true);
				this.LstMenuType.Enabled = flag;
				this.LstMenu.Enabled = flag;
				flag = (this.proFlag.Substring(4, 1) != "1" ? false : true);
				this.TxtPoint.Enabled = flag;
				this.RequiredFieldPoint.Enabled = flag;
				this.RangePoint.Enabled = flag;
				flag = (this.proFlag.Substring(5, 1) != "1" ? false : true);
				this.TxtDiscountAmount.Enabled = flag;
				this.RequiredFieldDiscountAmount.Enabled = flag;
				this.RangeDiscountAmount.Enabled = flag;
			}
		}

		private void setTime(int dayin, string timein)
		{
			for (int i = 0; i < this.RepeatTime.Items.Count; i++)
			{
				switch (dayin)
				{
					case 0:
					{
						if (this.ChkDay0.Items[i].Value != timein)
						{
							break;
						}
						this.ChkDay0.Items[i].Selected = true;
						break;
					}
					case 1:
					{
						if (this.ChkDay1.Items[i].Value != timein)
						{
							break;
						}
						this.ChkDay1.Items[i].Selected = true;
						break;
					}
					case 2:
					{
						if (this.ChkDay2.Items[i].Value != timein)
						{
							break;
						}
						this.ChkDay2.Items[i].Selected = true;
						break;
					}
					case 3:
					{
						if (this.ChkDay3.Items[i].Value != timein)
						{
							break;
						}
						this.ChkDay3.Items[i].Selected = true;
						break;
					}
					case 4:
					{
						if (this.ChkDay4.Items[i].Value != timein)
						{
							break;
						}
						this.ChkDay4.Items[i].Selected = true;
						break;
					}
					case 5:
					{
						if (this.ChkDay5.Items[i].Value != timein)
						{
							break;
						}
						this.ChkDay5.Items[i].Selected = true;
						break;
					}
					case 6:
					{
						if (this.ChkDay6.Items[i].Value != timein)
						{
							break;
						}
						this.ChkDay6.Items[i].Selected = true;
						break;
					}
				}
			}
		}
	}
}