using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace onlineCoach
{
    public partial class FeedbackTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL dataBLL = new BLL();
            GridView1.DataSource = dataBLL.GetFeedbackDataBLL();
            GridView1.DataBind();
            

        }


    }
}