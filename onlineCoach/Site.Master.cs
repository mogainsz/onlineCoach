using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;


namespace onlineCoach
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Session["UserDetailsSession"] != null)
                {

                    Users objUser = Session["UserDetailsSession"] as Users;
                    currUser.InnerHtml = "Hello " + objUser.FirstName;
                    signout.Visible = true;
                    signin.Visible = false;
                    if (objUser.Role.Contains("Admin"))
                    {
                        usersT.Visible = true;
                        bookingT.Visible = true;
                        feedbackT.Visible = true;
                        analyticsT.Visible = true;
                        
                    }


                }

                else
                {
                    signin.Visible = true;
                    signout.Visible = false;
                }
            }
        }
    }
}