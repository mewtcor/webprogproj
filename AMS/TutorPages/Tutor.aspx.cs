using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AMS.TutorPages
{
    public partial class Tutor1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Enzo
            int curRole = SessionManager.UserRole;
            if (curRole == 2)
            {
                lblCurrentTime.Text = DateTime.Now.ToString("hh:mm tt");
                lblCurrentDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                lblCurrentUser.Text = SessionManager.Username;
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


        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //Enzo
            lblCurrentTime.Text = DateTime.Now.ToString("hh:mm:ss tt");

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Enzo
            SessionManager.LogOut();
            Response.Redirect("~/Login.aspx");
        }
        protected void ClassRButton_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Lean
            if (ClassRButton.SelectedValue == "Enable")
            {
                string connstr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AMSConnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(connstr);
                //Enzo modified SQL query
                SqlCommand cmd = new SqlCommand("Update Class set Attstatus = @Attstatus where Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", drpDown.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Attstatus", true);

                conn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    return;
                }
                conn.Close();
                lblClassStatus.Text = "Enabled";
            }
            else
            {
                string connstr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AMSConnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(connstr);
                SqlCommand cmd = new SqlCommand("Update Class set Attstatus = @Attstatus where Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", drpDown.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Attstatus", false);

                conn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    return;
                }
                conn.Close();
                lblClassStatus.Text = "Disabled";
            }
        }

        protected void ShowClassStatus()
        {
            //Lean Update
            string connstr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AMSConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand("select Attstatus from Class where Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", drpDown.SelectedItem.Value);

            try
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {


                    bool ClassStat = (bool)rdr["Attstatus"];
                    if (ClassStat == true)
                    {
                        ClassRButton.SelectedValue = "Enable";
                        lblClassStatus.Text = "Enabled";
                    }
                    else
                    {
                        ClassRButton.SelectedValue = "Disable";
                        lblClassStatus.Text = "Disabled";
                    }
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

        }

        protected void btnClassStatus_Click(object sender, EventArgs e)
        {
            //Enzo
            ClassRButton.Enabled = true;
            btnClassStatus.Enabled = false;
        }

        protected void drpDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Leann
            if (drpDown.SelectedIndex == 0)
            {
                return;
            }
            else
            {
                Helper.ShowClassSchedTutor(drpDown, txtClassName, txtStatus, txtStartTime, txtEndTime, txtDate, txtHours, txtPractical, txtTheory, txtEnrolments, txtTrainer, txtVenue);
                this.ShowClassStatus();
                btnClassStatus.Enabled = true;
            }
        }
    }
}