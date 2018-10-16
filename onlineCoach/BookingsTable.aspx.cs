using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace onlineCoach
{
    public partial class BookingsTable : System.Web.UI.Page
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
            GridView1.DataSource = dataBLL.GetBookingDataBLL(txtSearch.Text.Trim());
            GridView1.DataBind();
            if (GridView1.Rows.Count != 0)
                count.InnerText = "Number of records: " + GridView1.Rows.Count.ToString();
            else
                count.InnerText = "No records found";
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            DropDownList status = (DropDownList)row.FindControl("status");
            Label id = (Label)row.FindControl("id");
            TextBox name = (TextBox)row.FindControl("name");
            TextBox email = (TextBox)row.FindControl("email");
            TextBox conNo = (TextBox)row.FindControl("conNo");
            TextBox lecDate = (TextBox)row.FindControl("lecDate");
            if (e.CommandName == "saveBooking")
            {
                
                int output;
                BLL updateBooking = new BLL();
                output = updateBooking.UpdateBookingBLL(name.Text, email.Text,Convert.ToInt32(conNo.Text) ,status.SelectedValue, lecDate.Text, Convert.ToInt32(id.Text));
                if (output > 0)
                    ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('updated successfully');", true);
            }

            else if(e.CommandName == "deleteBooking")
            {
                
                int output;
                BLL deleteBooking = new BLL();
                output = deleteBooking.DeleteBookingBLL(Convert.ToInt32(id.Text));
                if (output > 0)
                    ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('deleted successfully');", true);

                ShowGrid();
            }
        }

      
    }
}