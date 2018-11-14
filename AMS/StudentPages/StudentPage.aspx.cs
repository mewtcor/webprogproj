using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Diagnostics;


namespace StudentPageTest
{
    
    public partial class StudentPage : System.Web.UI.Page
    {
        /*declarations*/
        private string connstr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AMSConnection"].ConnectionString;
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        public static int ClassID;
        public static int Id;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Enzo
            int curRole = SessionManager.UserRole;
            if (curRole == 3)
            {
                lblCurrentTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
                lblCurrentDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                TimeOutButton.Enabled = false;
                TimeInButton.Enabled = false;
                lblTimeIn.Text = "";
                lblTimeOut.Text = "";
                lblCurrentUser.Text = SessionManager.Username;
                this.DisableTextboxes();
                if (!this.IsPostBack)
                {
                    this.PopulateDropDown();
                }

            }
            else
            {

                Response.Redirect("~/401.aspx");
                return;
            }
        }
     
        public void DisableTextboxes()
        {
            //Enzo
            txtClassName.ReadOnly = true;
            txtStatus.ReadOnly = true;
            txtStartTime.ReadOnly = true;
            txtEndTime.ReadOnly = true;
            txtDate.ReadOnly = true;
            txtHours.ReadOnly = true;
            txtPractical.ReadOnly = true;
            txtTheory.ReadOnly = true;
            txtEnrolments.ReadOnly = true;
            txtTrainer.ReadOnly = true;
            txtVenue.ReadOnly = true;
        }
        protected void TimeInButton_Click(object sender, EventArgs e)
        {
            /*Time In Button Function*/
            //Lean
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("Insert into Attendance (UserID,ClassID,TimeIn) " +
                "values (@UserID,@ClassID,@TimeIn)", conn);
            cmd.Parameters.AddWithValue("@UserID", SessionManager.Username);
            cmd.Parameters.AddWithValue("@ClassID", ClassID);
            cmd.Parameters.AddWithValue("@TimeIn",DateTime.Now);
            Response.Write(ClassID);

            conn.Open();
            if (cmd.ExecuteNonQuery()==1)
            {
                Response.Write("<Script>alert('Time In submitted!');</Script>");
                this.ShowAttTimeInStamp();
            }
            conn.Close();
            this.TimeInButton.Enabled = false;
            this.TimeOutButton.Enabled = true;
        }
        protected void TimeOutButton_Click(object sender, EventArgs e)
        {
            /*Time Out Button Method*/
            //Lean with Enzo's updat on the SQL DATEPART statement
            string curDate = lblCurrentDate.Text;
            DateTime date = Convert.ToDateTime(curDate);
            int curYear = date.Year;
            int curMonth = date.Month;
            int curDay = date.Day;
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("Update Attendance" +
              " Set TimeOut = @TimeOut" +
              " where UserID = @UserID" +
              " and ClassID = @ClassID " +
              "and DATEPART(YEAR,TimeIn) = '" + curYear + "' AND DATEPART(MONTH, TimeIn) = '" + curMonth + "' AND DATEPART(DAY,TimeIn)= '" + curDay + "' " +
              "and TimeIn is not null", conn);
            cmd.Parameters.AddWithValue("@UserID", SessionManager.Username);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@TimeOut", DateTime.Now);
            cmd.Parameters.AddWithValue("@ClassID", ClassID);

            conn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                Response.Write("<Script>alert('Time Out submitted!');</Script>");
                this.ShowAttTimeInStamp();
                this.ShowAttTimeOutStamp();

            }
            conn.Close();
            TimeInButton.Enabled = false;
            TimeOutButton.Enabled = false;
        }
       
        public void ShowClassSched()
        {
            // Show Class Schedule Method
            //Lean
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("select * from Class where Id = @Id and AttStatus = 'True'", conn);
            cmd.Parameters.AddWithValue("@Id", drpDown.SelectedItem.Value);
            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    txtClassName.Text = rdr["ClassName"].ToString();
                    ClassID = (int)rdr["Id"];
                    txtStatus.Text = rdr["Status"].ToString();

                    //Enzo Update on the Start, End Time and Date formatting
                    string startTime = rdr["StartTime"].ToString();
                    if (!string.IsNullOrEmpty(startTime))
                    {
                        DateTime dtStart = DateTime.Parse(startTime);
                        txtStartTime.Text = dtStart.ToString("hh:mm:ss tt");
                    }
                    else
                    {
                        txtStartTime.Text = "";
                    }

                    string endTime = rdr["EndTime"].ToString();
                    if (!string.IsNullOrEmpty(endTime))
                    {
                        DateTime dtEnd = DateTime.Parse(endTime);
                        txtEndTime.Text = dtEnd.ToString("hh:mm:ss tt");
                    }
                    else
                    {
                        txtEndTime.Text = "";
                    }
                        txtDate.Text = Convert.ToDateTime(rdr["Date"]).ToString("MM/dd/yyyy");
                    //end of Enzo update
                        txtHours.Text = rdr["Hours"].ToString();
                        txtPractical.Text = rdr["Practical"].ToString();
                        txtTheory.Text = rdr["Theory"].ToString();
                        txtEnrolments.Text = rdr["Enrolments"].ToString();
                        txtTrainer.Text = rdr["Trainer"].ToString();
                        txtVenue.Text = rdr["Venue"].ToString();
                }
               
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {

                //Debug.WriteLine("Label content: " + Label1.Text);
                conn.Close();
                conn.Dispose();
            }

        }

        public void PopulateDropDown()
        {
            //Enzo
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("SELECT ClassName, Id FROM Class WHERE Date='" + lblCurrentDate.Text + "' and AttStatus = 'True'", conn);
            System.Data.DataTable dt = new System.Data.DataTable();
            conn.Open();
            rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                drpDown.DataSource = rdr;
                drpDown.DataTextField = "ClassName";
                drpDown.DataValueField = "Id";
                drpDown.DataBind();

                if (drpDown.Text == "Please select")
                {
                    return;
                }
                else
                {
                    drpDown.Items.Insert(0, new ListItem("Please select a class name", "NA")); //updated code
                    drpDown.SelectedIndex = 0;
                }
            }
            else
            {
                Response.Write("<Script>alert('No subject availabe, please contact the Administrator.');</Script>");
                drpDown.Enabled = false;
            }
            conn.Close();
        }

        public void ShowAttTimeInStamp()
        {
            // Show Attendance Time Stamp
            //Enzo
            string curDate = lblCurrentDate.Text;
            DateTime date = Convert.ToDateTime(curDate);
            int curYear = date.Year;
            int curMonth = date.Month;
            int curDay = date.Day;
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand(" SELECT u.Email, c.Date, c.Id, att.TimeIn, att.TimeOut FROM Users AS u INNER JOIN Attendance AS att ON u.Email = att.UserID INNER JOIN Class AS c ON att.ClassID = c.Id AND c.Id = @Id AND u.Email = '" + SessionManager.Username +"' AND c.Date = '" + lblCurrentDate.Text + "' WHERE DATEPART(YEAR,TimeIn) = '" + curYear + "' AND DATEPART(MONTH, TimeIn) = '" + curMonth + "' AND DATEPART(DAY,TimeIn)= '" + curDay + "'", conn);
            cmd.Parameters.AddWithValue("@Id", drpDown.SelectedItem.Value);

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
           if (rdr.Read())
            {
                string timeInStamp = rdr["TimeIn"].ToString();
                if (!string.IsNullOrEmpty(timeInStamp))
                {
                    DateTime dtStart = DateTime.Parse(timeInStamp);
                    lblTimeIn.Text = dtStart.ToString("hh:mm:ss tt");
                }
                else
                {
                    lblTimeIn.Text = "";
                }
            }
        }
        public void ShowAttTimeOutStamp()
        {
            // Show Attendance Time Stamp
            //Enzo
            string curDate = lblCurrentDate.Text;
            DateTime date = Convert.ToDateTime(curDate);
            int curYear = date.Year;
            int curMonth = date.Month;
            int curDay = date.Day;
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand(" SELECT u.Email, c.Date, c.Id, att.TimeIn, att.TimeOut FROM Users AS u INNER JOIN Attendance AS att ON u.Email = att.UserID INNER JOIN Class AS c ON att.ClassID = c.Id AND c.Id = @Id AND u.Email = '" + SessionManager.Username + "' AND c.Date = '" + lblCurrentDate.Text + "' WHERE DATEPART(YEAR,TimeIn) = '" + curYear + "' AND DATEPART(MONTH, TimeIn) = '" + curMonth + "' AND DATEPART(DAY,TimeIn)= '" + curDay + "'", conn);
            cmd.Parameters.AddWithValue("@Id", drpDown.SelectedItem.Value);

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                string timeOutStamp = rdr["TimeOut"].ToString();
                if (!string.IsNullOrEmpty(timeOutStamp))
                {
                    DateTime dtEnd = DateTime.Parse(timeOutStamp);
                    lblTimeOut.Text = dtEnd.ToString("hh:mm:ss tt");
                }
                else
                {
                    lblTimeOut.Text = "";
                }
            }
        }

        protected void drpDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Enzo
            if (drpDown.SelectedIndex == 0)
            {
                return;
            }
            else
            {
                this.ShowClassSched();
                this.ShowAttTimeInStamp();
                this.ShowAttTimeOutStamp();

                if ((lblTimeIn.Text == "") && (lblTimeOut.Text == ""))
                {
                    TimeInButton.Enabled = true;
                    TimeOutButton.Enabled = false;
                }
                else if ((lblTimeIn.Text != "") && (lblTimeOut.Text == ""))
                {
                    TimeInButton.Enabled = false;
                    TimeOutButton.Enabled = true;
                }
                else
                {
                    TimeInButton.Enabled = false;
                    TimeOutButton.Enabled = false;
                }
            }
        }

        protected void TimerTime_Tick(object sender, EventArgs e)
        {
            //Enzo
            lblCurrentTime.Text = DateTime.Now.ToString("hh:mm:ss tt");

        }

        protected void lgOff_Click(object sender, EventArgs e)
        {
            //Enzo
            SessionManager.LogOut();
            Response.Redirect("~/Login.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Enzo
            Response.Redirect("ChangePW.aspx");
        }

    }
}