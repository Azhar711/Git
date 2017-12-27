using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebWcf
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt32(TextBox1.Text);
            ServiceReference.GoalServiceClient client = new ServiceReference.GoalServiceClient();
            ServiceReference.GoalDetails[] details = client.GetDetails(id);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < details.Length; i++)
            {
                sb.AppendFormat("<td>Goal:</td> {0}<br />", details[i].Goal);
                sb.AppendFormat("<td>Priority: </td>{0}<br />", details[i].GoalPriority);
                sb.AppendFormat("<td>StartDate: </td>{0}<br />", details[i].GoalStartDate);
                sb.AppendFormat("<tr>Achieved Date: </tr>{0}<br />", details[i].AchievedDate);
                Label1.Text = sb.ToString(); 
            }
        }
    }

}