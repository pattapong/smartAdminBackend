using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartAdmin.Controls
{
	public abstract class ScheduleControl : UserControl
	{
		protected ScheduleControl()
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
		}

		public void SetShift(DataTable shiftTable)
		{
			if (shiftTable == null || shiftTable.Rows.Count <= 0)
			{
				return;
			}
			Literal literal = new Literal()
			{
				Text = "<script language='javascript'>\r\n"
			};
			Literal literal1 = literal;
			literal1.Text = string.Concat(literal1.Text, "function createScheduleData() {\r\n");
			this.Controls.Add(literal);
			for (int i = 0; i < shiftTable.Rows.Count; i++)
			{
				int item = (int)shiftTable.Rows[i]["ShiftID"];
				int num = (int)shiftTable.Rows[i]["ShiftDayFrom"];
				int item1 = (int)shiftTable.Rows[i]["ShiftDayTo"];
				string str = (string)shiftTable.Rows[i]["ShiftStart"];
				string str1 = (string)shiftTable.Rows[i]["ShiftEnd"];
				literal = new Literal();
				object[] objArray = new object[] { "\tnew periodObject(", item, ", ", num, ", ", item1, ", '", str, "', '", str1, "', '');\r\n" };
				literal.Text = string.Concat(objArray);
				this.Controls.Add(literal);
			}
			literal = new Literal()
			{
				Text = "}\r\n</script>\r\n"
			};
			this.Controls.Add(literal);
		}
	}
}