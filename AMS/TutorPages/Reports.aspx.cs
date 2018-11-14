using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Configuration;

namespace AMS.TutorPages
{
    public partial class Tutor : System.Web.UI.Page
    {
        //Lean
        private string connstr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AMSConnection"].ConnectionString;
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Enzo
            lblCurrentTime.Text = DateTime.Now.ToString("hh:mm tt");
            lblCurrentDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            lblCurrentUser.Text = SessionManager.Username;
            this.DisableTextBoxes();
            if (!this.IsPostBack)
            {
                Helper.PopulateDropDown(lblCurrentDate.Text, ClassReportDropDownList, this);
            }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Enzo
            gdwConfirm.PageIndex = e.NewPageIndex;
            this.SelectClass();
        }
        public void DisableTextBoxes()
        {
            //Enzo
            inDate.Disabled = true;
            inClassName.Disabled = true;
            inStatus.Disabled = true;
            inStartTime.Disabled = true;
            inEndTime.Disabled = true;
            inHours.Disabled = true;
            inPractical.Disabled = true;
            inTheory.Disabled = true;
            inEnrolment.Disabled = true;
            inTrainer.Disabled = true;
            inVenue.Disabled = true;
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Enzo
            SessionManager.LogOut();
            Response.Redirect("~/Login.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //Enzo
            lblCurrentTime.Text = DateTime.Now.ToString("hh:mm:ss tt");

        }

        protected void ClassReportDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Lean
            this.SelectClass();
        }
        public void SelectClass()
        {
            //Lean
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("select * from Class where Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", ClassReportDropDownList.SelectedItem.Value);

            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    
                    inClassName.Value = rdr["ClassName"].ToString();
                    inStatus.Value = rdr["Status"].ToString();
                    //Enzo's Update for the starttime, endtime and date formatting
                    string xDate = rdr["Date"].ToString();
                    DateTime iDate = DateTime.Parse(xDate);
                    inDate.Value = iDate.ToString("dd/yy/yyyy");
                    string startTime = rdr["StartTime"].ToString();
                    if (!string.IsNullOrEmpty(startTime))
                    {
                        DateTime dtStart = DateTime.Parse(startTime);
                        inStartTime.Value = dtStart.ToString("hh:mm:ss tt");
                    }
                    else
                    {
                        inStartTime.Value = "";
                    }

                    string endTime = rdr["EndTime"].ToString();
                    if (!string.IsNullOrEmpty(endTime))
                    {
                        DateTime dtEnd = DateTime.Parse(endTime);
                       inEndTime.Value = dtEnd.ToString("hh:mm:ss tt");
                    }
                    else
                    {
                        inEndTime.Value = "";
                    }
                    //end of update
                    inHours.Value = rdr["Hours"].ToString();
                    inPractical.Value = rdr["Practical"].ToString();
                    inTheory.Value = rdr["Theory"].ToString();
                    inEnrolment.Value = rdr["Enrolments"].ToString();
                    inTrainer.Value = rdr["Trainer"].ToString();
                    inVenue.Value = rdr["Venue"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            this.FillGrid();            
        }
        public void FillGrid()
        {
            //Enzo
            string curDate = lblCurrentDate.Text;
            DateTime date = Convert.ToDateTime(curDate);
            int curYear = date.Year;
            int curMonth = date.Month;
            int curDay = date.Day;
            string constr = ConfigurationManager.ConnectionStrings["AMSConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                //Lean SQL statement with Enzo's update on DATEPART
                using (SqlCommand cmd = new SqlCommand("SELECT a.Id as AId, u.FirstName as UFName, u.LastName as ULName, u.Email as UEmail, a.TimeIn as ATimeIn, a.TimeOut as ATimeOut, a.Comment as AComment FROM Users u, Attendance a, Class c WHERE u.Email = a.UserID AND c.Id = a.ClassID AND a.Confirmation = 1 AND DATEPART(YEAR, a.TimeIn) = '" + curYear + "' AND DATEPART(MONTH, a.TimeIn) = '" + curMonth + "' AND DATEPART(DAY, a.TimeIn)= '" + curDay + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gdwConfirm.DataSource = dt;
                            gdwConfirm.DataBind();
                        }
                    }
                }
            }
        }

        protected void ExportButton_Click(object sender, EventArgs e)
        {
            //Leann
            Response.Clear();
            Response.AddHeader("content-disposition", "attachament;filename=Attendance.xls");
            Response.Charset = "";
            Response.ContentType = "application/excel";
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            divExport.RenderControl(htmlTextWriter);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //Leann
            //this class resolves the error of gridview exporting to excel  
            //verifies that the control is rendered
        }
    }
}