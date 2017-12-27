using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicalSummaryWeb
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            ServiceReference.GoalDetails client = new ServiceReference.GoalDetails();
            GridView1.DataSource = client.Goal;
            GridView1.DataSource = client.AchievedDate;
            GridView1.DataSource = client.CompletionDate;
            GridView1.DataSource = client.AchievedDate;
            GridView1.DataBind();
        }
    }
}