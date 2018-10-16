using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;


namespace onlineCoach
{
    public partial class UsersTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowGrid();

            }
            
        }

        protected void Search(object sender, EventArgs e)
        {
            ShowGrid();
        }

        protected void ShowGrid()
        {
            BLL dataBLL = new BLL();
            GridView1.DataSource = dataBLL.GetUsersDataBLL(txtSearch.Text.Trim());
            GridView1.DataBind();
            if (GridView1.Rows.Count == 0)
                count.InnerText = "No records found";
            else
                count.InnerText = "Number of records: " + GridView1.Rows.Count.ToString();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "viewUser")
            {
                currUserInfo.Visible = true;

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                Label lblfirstName = (Label)row.FindControl("fName");
                Label lbllastName = (Label)row.FindControl("lName");
                Label lblEmail = (Label)row.FindControl("email");
                Label lblWeight = (Label)row.FindControl("weight");
                Label lblHeight = (Label)row.FindControl("height");
                Label lblBday = (Label)row.FindControl("bday");
                Label lblActvLvl = (Label)row.FindControl("actvLvl");
                Label lblBmi = (Label)row.FindControl("bmi");
                Label lblGender = (Label)row.FindControl("gender");
                Label lblGoalWeight = (Label)row.FindControl("goalWeight");
                Label lblAbout = (Label)row.FindControl("about");

                name.InnerHtml = "<b>Name: </b>" + lblfirstName.Text + " " + lbllastName.Text;
                dGender.InnerHtml = "<b>Gender: </b>" + lblGender.Text;
                dBirthday.InnerHtml = "<b>Birthday: </b>" + lblBday.Text;
                dWeight.InnerHtml = "<b>Weight(KG): </b>" + lblWeight.Text;
                dHeight.InnerHtml = "<b>Height(KG): </b>" + lblHeight.Text;
                dBmi.InnerHtml = "<b>BMI: </b>" + lblBmi.Text;
                dActvLvl.InnerHtml = "<b>Activity level: </b>" + lblActvLvl.Text;
                dGoalWeight.InnerHtml = "<b>Goal weight: </b>" + lblGoalWeight.Text;
                dEmail.InnerHtml = "<b>Email address: </b>" + lblEmail.Text;
                dAbout.InnerHtml = "<b>About: </b>" + lblAbout.Text;

                double bmr = 0;
                double calories = 0;
                double weightProgress = Math.Abs(Convert.ToDouble(lblGoalWeight.Text) - Convert.ToDouble(lblWeight.Text));

                if (Convert.ToDouble(lblBmi.Text) < 18.50)
                {

                    Panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#33CCFF");
                    bmiChrt.InnerHtml = lblfirstName.Text +" is underweight!";
                }

                else if (Convert.ToDouble(lblBmi.Text) >= 18.50 && Convert.ToDouble(lblBmi.Text) <= 24.99)
                {
                    Panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#33FF33");
                    bmiChrt.InnerHtml = lblfirstName.Text + " is healthy";

                }

                else if (Convert.ToDouble(lblBmi.Text) >= 25 && Convert.ToDouble(lblBmi.Text) <= 29.99)
                {
                    Panel1.BackColor = System.Drawing.Color.Yellow;
                    bmiChrt.InnerHtml = lblfirstName.Text + " is overweight";
                }

                else if (Convert.ToDouble(lblBmi.Text) >= 30 && Convert.ToDouble(lblBmi.Text) < 40)
                {
                    Panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8800");
                    bmiChrt.InnerHtml = lblfirstName.Text + " is obese";
                }

                else if (Convert.ToDouble(lblBmi.Text) >= 40)
                {
                    Panel1.BackColor = System.Drawing.Color.Red;
                    bmiChrt.InnerHtml = lblfirstName.Text + " is extremely obese";
                }

                if (lblGender.Text.Equals("Male"))
                {
                    if(!lblBday.Text.Equals(""))
                        bmr = 66 + (13.7 * Convert.ToDouble(lblWeight.Text)) + (5 * Convert.ToDouble(lblHeight.Text)) - (6.8 * (Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(lblBday.Text.Substring(6))));
                }

                else if (lblGender.Text.Equals("Female"))
                {
                    if (!lblBday.Text.Equals(""))
                        bmr = 655 + (9.6 * Convert.ToDouble(lblWeight.Text)) + (1.8 * Convert.ToDouble(lblHeight.Text)) - (4.7 * (Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(lblBday.Text.Substring(6))));
                }

                if (lblActvLvl.Text.Contains("Sedentary"))
                {
                    calories = bmr * 1.2;
                }
                else if (lblActvLvl.Text.Contains("Lightly"))
                {
                    calories = bmr * 1.375;
                }

                else if (lblActvLvl.Text.Contains("Moderatetely"))
                {
                    calories = bmr * 1.55;
                }

                else if (lblActvLvl.Text.Contains("Very"))
                {
                    calories = bmr * 1.725;
                }

                else if (lblActvLvl.Text.Contains("Extra"))
                {
                    calories = bmr * 1.9;
                }
                if (Convert.ToDouble(lblWeight.Text) == Convert.ToDouble(lblGoalWeight.Text))
                {
                    Panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#33FF33");
                    goalChrt.InnerHtml = "You reached your goal weight!";
                    Panel2.Width = new Unit("100%");
                    goalChrt.InnerHtml = "100%";
                }
               


                if (weightProgress >= 1 && weightProgress <= 10)
                {
                    Panel2.Width = new Unit("90%");
                    Panel2.BackColor = System.Drawing.Color.Yellow;
                    goalChrt.InnerHtml = "Nearly there!";
                    goalChrt.InnerHtml = "90%";

                }

                if (weightProgress >= 11 && weightProgress < 30)
                {
                    Panel2.Width = new Unit("80%");
                    Panel2.BackColor = System.Drawing.Color.Yellow;
                    goalChrt.InnerHtml = "80%";
                }

                if (weightProgress >= 30 && weightProgress < 40)
                {
                    Panel2.Width = new Unit("70%");
                    Panel2.BackColor = System.Drawing.Color.Yellow;
                    goalChrt.InnerHtml = "70%";
                }

                if (weightProgress >= 40 && weightProgress < 50)
                {
                    Panel2.Width = new Unit("60%");
                    Panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8800");
                    goalChrt.InnerHtml = "60%";
                }

                if (weightProgress >= 50 && weightProgress < 60)
                {
                    Panel2.Width = new Unit("50%");
                    Panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8800");
                    goalChrt.InnerHtml = "50%";
                }

                if (weightProgress >= 60 && weightProgress < 70)
                {
                    Panel2.Width = new Unit("40%");
                    Panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8800");
                    goalChrt.InnerHtml = "40%";
                }

                if (weightProgress >= 70 && weightProgress < 80)
                {
                    Panel2.Width = new Unit("30%");
                    goalChrt.InnerHtml = "30%";
                }

                if (weightProgress >= 80 && weightProgress < 90)
                {
                    Panel2.Width = new Unit("20%");
                    goalChrt.InnerHtml = "20%";
                }

                if (weightProgress >= 90 && weightProgress < 100)
                {
                    Panel2.Width = new Unit("10%");
                    goalChrt.InnerHtml = "10%";
                }

                if (weightProgress >= 100)
                {
                    Panel2.Width = new Unit("0%");
                    goalChrt.InnerHtml = "0%";
                }


                calsInfo.InnerHtml = "<b>" + lblfirstName.Text + "'s calories breakdown: </b>";
                maintCals.InnerHtml = "Weight maintenance: " + Math.Round(calories) + "/day";
                loseCals.InnerHtml = "Weight loss: " + Math.Round((calories - 500)) + "/day";
                gainCals.InnerHtml = "Weight gain: " + Math.Round((calories + 500)) + "/day";

            }

        }


    }
}