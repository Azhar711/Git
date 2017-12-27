using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebWcf
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt32(TextBox1.Text);
            ServiceReference.GoalServiceClient client = new ServiceReference.GoalServiceClient();
            ServiceReference.GoalDetails[] details = client.GetDetails(id);

            DataTable dt = new DataTable();
            for (int i = 0; i < details.Length; i++)
            {
                //dt = details[i];
                GridView1.DataSource = details;
                GridView1.DataBind();

                GridView2.DataSource = details;
                GridView2.DataBind();
            }
                
        }
    }
}