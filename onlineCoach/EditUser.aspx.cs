using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using BusinessLogicLayer;

namespace onlineCoach
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserDetailsSession"] != null)
                {

                    Users objUser = Session["UserDetailsSession"] as Users;
                    fName.Value = objUser.FirstName;
                    lName.Value = objUser.LastName;
                    gender.SelectedValue = objUser.Gender;
                    birthday.Value = Convert.ToString(objUser.Birthday);
                    weight.Value = Convert.ToString(objUser.Weight);
                    height.Value = Convert.ToString(objUser.Height);
                    bmiLabel.InnerHtml = "BMI: " + Convert.ToString(Math.Round((double)(objUser.Weight/(objUser.Height*objUser.Height))*10000,2));
                    actvLvl.SelectedValue =  objUser.ActivityLevel;
                    goalWeight.Value =  Convert.ToString(objUser.GoalWeight);
                    about.Value = objUser.About;
                    email.Value = objUser.EmailAddress;




                }
            }
        }
        protected void save_Click(object sender, EventArgs e)
        {
            int output;  //Step 2.1
            BLL objBLL = new BLL(); // Step 2.2
            Users objUser = Session["UserDetailsSession"] as Users;
            
            objUser.FirstName = fName.Value;
            objUser.LastName = lName.Value;
            objUser.EmailAddress = email.Value;
            objUser.Weight = weight.Value != "" ? Convert.ToDouble(weight.Value) : 0;
            objUser.Height = height.Value != "" ? Convert.ToDouble(height.Value): 0;
            objUser.Birthday = birthday.Value;
            objUser.ActivityLevel = actvLvl.SelectedValue;
            objUser.BMI = weight.Value != "" && height.Value != "" ? Convert.ToDouble(Math.Round((double)(objUser.Weight / (objUser.Height * objUser.Height)) * 10000, 2)) : 0;
            objUser.About = about.Value;
            objUser.GoalWeight = goalWeight.Value != "" ? Convert.ToDouble(goalWeight.Value): 0;
            objUser.Gender = gender.SelectedValue;

            output = objBLL.UpdateUserBLL(objUser);
           
            //Step 3: Display an alert box based on the output
            //If a row is affected (Success condition), alert box will be displayed for success else error message will be displayed.
            if (output > 0)
                ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Changes saved');window.location.href = 'UserPage.aspx';", true);
                
            else
                ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Error occurred');window.location.href = 'EditUser.aspx';", true);
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserPage.aspx");
        }
    }
    }
