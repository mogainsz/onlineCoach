using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using BusinessObjects;

namespace onlineCoach
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sign_Click(object sender, EventArgs e)
        {
            Users objUserMasterOutput = new Users(); //Section 6.2.3 step 
            Users objUserMasterInput = new Users();//Section 6.2.3  step 4.2
            objUserMasterInput.EmailAddress = email.Value; //Section 6.2.3  step 4.4
            string usrPassword = password.Value;//Section 6.2.3  step 4.4

            BLL objBLL = new BLL();//Section 6.2.3  step 4.3
            objUserMasterOutput = objBLL.SignInBLL(objUserMasterInput, usrPassword);//Section 6.2.3  step 4.5

            // We are putting the entire output object objUserMasterOutput into the session variables so that all the user details
            // will be accessible throughout the application on all the pages.
            if (objUserMasterOutput != null) //Section 6.2.3  step 4.6
            {
                Session["UserDetailsSession"] = objUserMasterOutput;
                Response.Redirect("UserPage.aspx");

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "UserNotFound", "alert('User not found.')", true);//Section 6.2.3  step 4.7
            }

        }
    }

}
    
