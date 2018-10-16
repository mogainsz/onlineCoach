using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;

namespace onlineCoach
{
    public partial class AnalyticalDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BLL dataBLL = new BLL();

                //Rating chart
                DataTable dtOverall = dataBLL.GetOverallDataBLL();
                string[] x = new string[dtOverall.Rows.Count];
                int[] y = new int[dtOverall.Rows.Count];
                for (int i = 0; i < dtOverall.Rows.Count; i++)
                {
                    x[i] = dtOverall.Rows[i][0].ToString();
                    y[i] = Convert.ToInt32(dtOverall.Rows[i][1]);
                }
				
                Chart1.Series[0].Points.DataBindXY(x,y);
                Chart1.Series[0].ChartType = SeriesChartType.Column;
                Chart1.Series[0].Label = "#PERCENT{P2}";
                Chart1.Series[0].Font = new Font("Calibri (body)", 12.0f);
                Chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                Chart1.Series[0].BorderColor = Color.Red;
                for (int i = 0; i < x.Length; i++) 
                {
                    if (i == 0) 
                        Chart1.Series[0].Points[i].Color = Color.Red;
                    if (i == 1)
                        Chart1.Series[0].Points[i].Color = Color.Yellow;
                    if (i == 2)
                        Chart1.Series[0].Points[i].Color = Color.Violet;
                    if (i == 3)
                        Chart1.Series[0].Points[i].Color = Color.SkyBlue;
                    if (i == 4)
                        Chart1.Series[0].Points[i].Color = Color.Orange;
                    if (i == 5)
                        Chart1.Series[0].Points[i].Color = System.Drawing.ColorTranslator.FromHtml("#33FF33");
                }

                //Booking chart
                DataTable dtBooking = dataBLL.GetBookingCountDataBLL();
                string[] a = new string[dtBooking.Rows.Count];
                int[] b = new int[dtBooking.Rows.Count];
                for (int i = 0; i < dtBooking.Rows.Count; i++)
                {
                    a[i] = dtBooking.Rows[i][0].ToString();
                    b[i] = Convert.ToInt32(dtBooking.Rows[i][1]);
                }
                Chart2.Series[0].Points.DataBindXY(a, b);
                Chart2.Series[0].ChartType = SeriesChartType.Pie;
                Chart2.Series[0].Font = new Font("Calibri (body)", 12.0f);
               

                Chart2.Series[0].Points[0].AxisLabel = "Pending #PERCENT{P2}";
                Chart2.Series[0].Points[0].Color = System.Drawing.Color.Red;
                Chart2.Series[0].Points[0].LabelForeColor = System.Drawing.Color.White;
              

    
                Chart2.Series[0].Points[1].AxisLabel = "Finished #PERCENT{P2}";
                Chart2.Series[0].Points[1].Color = System.Drawing.ColorTranslator.FromHtml("#33FF33"); 
                Chart2.Series[0].Points[1].LabelForeColor = System.Drawing.Color.White;
                
            }
        }
    }
}