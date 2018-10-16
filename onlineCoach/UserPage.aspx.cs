using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;


namespace onlineCoach
{
    public partial class UserPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserDetailsSession"] != null)
                {
                    double bmr = 0;
                    double calories = 0;
                    
                    Users objUser = Session["UserDetailsSession"] as Users;
                    double weightProgress = objUser.GoalWeight != null && objUser.Weight != null ? Math.Abs((double)objUser.GoalWeight - (double)objUser.Weight): 0;

                    currUser.InnerText = "Welcome" + " " + objUser.FirstName + " " + objUser.LastName;
                    name.InnerHtml = "<b>Name: </b>" + objUser.FirstName + " " + objUser.LastName;
                    gender.InnerHtml = "<b>Gender: </b>" + objUser.Gender;
                    birthday.InnerHtml = "<b>Birthday: </b>" + objUser.Birthday;
                    weight.InnerHtml = "<b>Weight(KG): </b>" + objUser.Weight;
                    height.InnerHtml = "<b>Height(CM): </b>" + objUser.Height;
                    bmi.InnerHtml = "<b>BMI: </b>" + objUser.BMI;
                    actvLvl.InnerHtml = "<b>Activity level: </b>" + objUser.ActivityLevel;
                    goalWeight.InnerHtml = "<b>Goal weight(KG): </b>" + objUser.GoalWeight;
                    about.InnerHtml = "<b>About me: </b></br>" + objUser.About;
                    email.InnerHtml = "<b>Email address: </b>" + objUser.EmailAddress;

                    profContainer.Visible = true;
                    
                    
                    if(objUser.BMI < 18.50)
                    {

                        Panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#33CCFF");
                        bmiChrt.InnerHtml = "You are underweight!";
                    }

                    else if(objUser.BMI >= 18.50 && objUser.BMI <= 24.99)
                    {
                        Panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#33FF33");
                        bmiChrt.InnerHtml = "You are healthy, nice!";

                    }

                    else if (objUser.BMI >= 25 && objUser.BMI <= 29.99)
                    {
                        Panel1.BackColor = System.Drawing.Color.Yellow;
                        bmiChrt.InnerHtml = "Be careful you are overweight";
                    }

                    else if (objUser.BMI >= 30 && objUser.BMI < 40)
                    {
                        Panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8800");
                        bmiChrt.InnerHtml = "You are obese consider decreasing your calories";
                    }

                    else if (objUser.BMI >= 40)
                    {
                        Panel1.BackColor = System.Drawing.Color.Red;
                        bmiChrt.InnerHtml = "You are extremely obese you must change your eating habits now!";
                    }

                    if(objUser.Gender.Equals("Male"))
                    {
                        if(!objUser.Birthday.Equals(""))
                            bmr = objUser.Weight != null && objUser.Height != null ? 66 + (13.7 * (double)objUser.Weight) + (5 * (double)objUser.Height) - (6.8 * (Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(objUser.Birthday.Substring(6)))):0;
                    }

                    else if(objUser.Gender.Equals("Female"))
                    {
                        if (!objUser.Birthday.Equals(""))
                            bmr = objUser.Weight != null && objUser.Height != null ? 655 + (9.6 * (double)objUser.Weight) + (1.8 * (double)objUser.Height) - (4.7 * (Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(objUser.Birthday.Substring(6)))):0;
                    }

                    if(objUser.ActivityLevel.Contains("Sedentary"))
                    {
                        calories = bmr * 1.2;
                    }
                    else if (objUser.ActivityLevel.Contains("Lightly"))
                    {
                        calories = bmr * 1.375;
                    }

                    else if (objUser.ActivityLevel.Contains("Moderatetely"))
                    {
                        calories = bmr * 1.55;
                    }

                    else if (objUser.ActivityLevel.Contains("Very"))
                    {
                        calories = bmr * 1.725;
                    }

                    else if (objUser.ActivityLevel.Contains("Extra"))
                    {
                        calories = bmr * 1.9;
                    }
                    if(objUser.Weight == objUser.GoalWeight)
                    {
                        Panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#33FF33");
                        goalChrt.InnerHtml = "You reached your goal weight!";
                        Panel2.Width = new Unit("100%");
                        currWeight.InnerHtml = "<b>Your weight progress: </b>100%";
                    }
                    else
                    {
                        goalChrt.InnerHtml = weightProgress + " KGs to go";
                    }


                    if (weightProgress >= 1 && weightProgress <= 10)
                    {
                        Panel2.Width = new Unit("90%");
                        Panel2.BackColor = System.Drawing.Color.Yellow;
                        goalChrt.InnerHtml = "Nearly there!";
                        currWeight.InnerHtml = "<b>Your weight progress: </b>90%";

                    }

                    if (weightProgress >= 11 && weightProgress < 30)
                    {
                        Panel2.Width = new Unit("80%");
                        Panel2.BackColor = System.Drawing.Color.Yellow;
                        currWeight.InnerHtml = "<b>Your weight progress: </b>80%";
                    }

                    if (weightProgress >= 30 && weightProgress < 40)
                    {
                        Panel2.Width = new Unit("70%");
                        Panel2.BackColor = System.Drawing.Color.Yellow;
                        currWeight.InnerHtml = "<b>Your weight progress: </b>70%";
                    }

                    if (weightProgress >= 40 && weightProgress < 50)
                    {
                        Panel2.Width = new Unit("60%");
                        Panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8800");
                        currWeight.InnerHtml = "<b>Your weight progress: </b>60%";
                    }

                    if (weightProgress >= 50 && weightProgress < 60)
                    {
                        Panel2.Width = new Unit("50%");
                        Panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8800");
                        currWeight.InnerHtml = "<b>Your weight progress: </b>50%";
                    }

                    if (weightProgress >= 60 && weightProgress < 70)
                    {
                        Panel2.Width = new Unit("40%");
                        Panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8800");
                        currWeight.InnerHtml = "<b>Your weight progress: </b>40%";
                    }

                    if (weightProgress >= 70 && weightProgress < 80)
                    {
                        Panel2.Width = new Unit("30%");
                        currWeight.InnerHtml = "<b>Your weight progress: </b>30%";
                    }

                    if (weightProgress >= 80 && weightProgress < 90)
                    {
                        Panel2.Width = new Unit("20%");
                        currWeight.InnerHtml = "<b>Your weight progress: </b>20%";
                    }

                    if (weightProgress >= 90 && weightProgress < 100)
                    {
                        Panel2.Width = new Unit("10%");
                        currWeight.InnerHtml = "<b>Your weight progress: </b>10%";
                    }

                    if (weightProgress >= 100)
                    {
                        Panel2.Width = new Unit("0%");
                        currWeight.InnerHtml = "<b>Your weight progress: </b>0%";
                    }

                    
                    calsInfo.InnerHtml = "<b>Your Calorie requirement breakdown: </b>";
                    maintCals.InnerHtml = "Weight maintenance: " + Math.Round(calories) +"/day";
                    loseCals.InnerHtml = "Weight loss: " + Math.Round((calories - 500))+"/day";
                    gainCals.InnerHtml = "Weight gain: " + Math.Round((calories + 500))+"/day";

                    login.Visible = false;
                    editProf.Visible = true;

                }

                else
                {
                    editProf.Visible = false;
                }
            }

        }

        protected void editProf_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUser.aspx");
        }
    }
}