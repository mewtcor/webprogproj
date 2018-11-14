using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Diagnostics;


namespace AMS.TutorPages
{
    public partial class AttendanceConfirmation : System.Web.UI.Page
    {
        /*declarations*/
        //Enzo
        private string connstr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AMSConnection"].ConnectionString;
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Enzo
            int curRole = SessionManager.UserRole;
            if (curRole == 2)
            {
                lblCurrentTime.Text = DateTime.Now.ToString("hh:mm tt");
                lblCurrentDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                lblCurrentUser.Text = SessionManager.Username;
                btnConfirm.Enabled = false;
                btnSaveComment.Enabled = false;
                btnExclude.Enabled = false;
                if (!this.IsPostBack)
                {
                    Helper.PopulateDropDown(lblCurrentDate.Text, drpDown, this);
                }
            }
            else
            {

                Response.Redirect("~/401.aspx");
                return;
            }
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
        public void ShowCurrAtt()
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
                using (SqlCommand cmd = new SqlCommand("SELECT a.Id as AId, u.FirstName as UFName, u.LastName as ULName, u.Email as UEmail, a.TimeIn as ATimeIn, a.TimeOut as ATimeOut, a.Comment as AComment FROM Users u, Attendance a, Class c WHERE u.Email = a.UserID AND c.Id = a.ClassID AND a.Confirmation is NULL AND DATEPART(YEAR, a.TimeIn) = '" + curYear + "' AND DATEPART(MONTH, a.TimeIn) = '" + curMonth + "' AND DATEPART(DAY, a.TimeIn)= '" + curDay + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gdwDaysAttendance.DataSource = dt;
                            gdwDaysAttendance.DataBind();
                        }
                    }
                }
            }

        }

        protected void drpDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Enzo
            this.ShowCurrAtt();
            btnConfirm.Enabled = true;
            btnSaveComment.Enabled = false;
            btnExclude.Enabled = false;
        }

        protected void btnSaveComment_Click(object sender, EventArgs e)
        {
            //Enzo
            this.AddComment();
            inComment.Value = "";
            btnConfirm.Enabled = false;
            btnSaveComment.Enabled = true;
            btnExclude.Enabled = true;
        }
        public void AddComment()
        {
            //Enzo
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("Update Attendance set Comment=@Comment where Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", lblId.Text);
            cmd.Parameters.AddWithValue("@Comment", inComment.Value);

            conn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                Response.Write("<Script>alert('Comment has been added.');</Script>");

            }
            conn.Close();
            this.ShowCurrAtt();
        }

        public void ExcludeStudent()
        {
            //Enzo
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("Update Attendance set Confirmation=@Confirmation where Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", lblId.Text);
            cmd.Parameters.AddWithValue("@Confirmation", false);

            conn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                Response.Write("<Script>alert('Attendance is excluded!);</Script>");
            }
            conn.Close();
            this.ShowCurrAtt();
        }
        protected void btnExclude_Click(object sender, EventArgs e)
        {
            //Enzo
            this.ExcludeStudent();
            btnConfirm.Enabled = true;
            btnSaveComment.Enabled = true;
            btnExclude.Enabled = true;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            //Enzo
            conn = new SqlConnection(connstr);
            conn.Open();

            for (int i = 0; i < gdwDaysAttendance.Rows.Count; i++)
            {
                string tempId = gdwDaysAttendance.Rows[i].Cells[1].Text;
                cmd = new SqlCommand("Update Attendance set Confirmation = @Confirmation where Id = @Id AND Confirmation IS NULL", conn);
                cmd.Parameters.AddWithValue("@Id", tempId);
                cmd.Parameters.AddWithValue("@Confirmation", true);

                if (cmd.ExecuteNonQuery() == 1)
                {
                }

            }
            Response.Write("<Script>alert('Attendance is confirmed');</Script>");
            conn.Close();
            this.ShowCurrAtt();
            lblId.Text = "";
        }

        protected void gdwUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Enzo
            int rowIndex = gdwDaysAttendance.SelectedIndex;
            string FN = gdwDaysAttendance.SelectedRow.Cells[2].Text;
            string LN = gdwDaysAttendance.SelectedRow.Cells[3].Text;
            lblName.Text = FN + " " + LN;
            lblId.Text = gdwDaysAttendance.SelectedRow.Cells[1].Text;
            if (gdwDaysAttendance.SelectedRow.Cells[6].Text == "")
            {
                inComment.Value = "";
            }
            else
            {
                inComment.Value = gdwDaysAttendance.SelectedRow.Cells[7].Text;

            }
            btnConfirm.Enabled = false;
            btnSaveComment.Enabled = true;
            btnExclude.Enabled = true;
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Enzo
            gdwDaysAttendance.PageIndex = e.NewPageIndex;
            this.ShowCurrAtt();
        }
    }
}