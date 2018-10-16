using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using System.Web.Security;

namespace onlineCoach
{
    public partial class SignOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users objUser = Session["UserDetailsSession"] as Users;
            userOut.InnerHtml = "Goodbye " + objUser.FirstName;
            FormsAuthentication.SignOut();
            Session.Clear();
            Response.AddHeader("REFRESH", "3;URL=Default.aspx");
        }
    }
}