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
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendComment_Click(object sender, EventArgs e)
        {
            int output;  //Step 2.1
            BLL objBLL = new BLL(); // Step 2.2

            //Step 1: Instantiate UserMaster from the BusinessObjects class and assign user inputs from the form to the object objUserMaster properties.
            BusinessObjects.Feedback objUserFeedback = new BusinessObjects.Feedback();

            objUserFeedback.FullName = name.Value;
            objUserFeedback.EmailAddress = email.Value;
            objUserFeedback.Comment = comment.Value;
            objUserFeedback.Overall = Convert.ToInt32(FeedbackRL.SelectedValue);
            


            //Step 2: Call the signup method of BLL(SignUpBLL)
            output = objBLL.FeedbackBLL(objUserFeedback);

            //Step 3: Display an alert box based on the output
            //If a row is affected (Success condition), alert box will be displayed for success else error message will be displayed.
            if (output > 0)
                ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Feedback successfully sent');window.location.href = 'Default.aspx';", true);
            else
                ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Error occurred');window.location.href = 'Feedback.aspx';", true);
        }
    }
    }
