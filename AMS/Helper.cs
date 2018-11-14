using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public static class Helper
{
    public static string connstr
    {
        //Leann
        get
        {
            return System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AMSConnection"].ConnectionString;
        }
    }


    public static void PopulateDropDown(string date, DropDownList ddl, Page cxt)
    {
        //Lean
        ddl.Enabled = true;
        SqlConnection conn = new SqlConnection(connstr);
        //Enzo modified SQL query
        SqlCommand cmd = new SqlCommand("SELECT ClassName, Id FROM Class WHERE Date='" + date + "' AND TrainerEmail = '" + SessionManager.Username + "'", conn);
        System.Data.DataTable dt = new System.Data.DataTable();
        conn.Open();
        SqlDataReader rdr = cmd.ExecuteReader();

        if (rdr.HasRows)
        {
            ddl.DataSource = rdr;
            ddl.DataTextField = "ClassName";
            ddl.DataValueField = "Id";
            ddl.DataBind();
            if (ddl.Text == "Please select")
            {
                return;
            }
            else
            {
                ddl.Items.Insert(0, new ListItem("Please select a class name", "NA")); //updated code
                ddl.SelectedIndex = 0;
            }
        }
        else
        {
            cxt.Response.Write("<Script>alert('No subject availabe, please contact the Administrator.');</Script>");
            ddl.Enabled = false;
        }
        conn.Close();
    }

    public static void ShowClassSched(DropDownList ddl3, TextBox txtClassName, TextBox txtStatus, TextBox txtStartTime, TextBox txtEndTime, TextBox txtDate, TextBox txtHours, TextBox txtPractical, TextBox txtTheory, TextBox txtEnrolments, TextBox txtTrainer, TextBox txtVenue)
    {
        // Show Class Schedule Method
        //Lean
        SqlConnection conn = new SqlConnection(connstr);
        //Enzo modified Sql Command
        SqlCommand cmd = new SqlCommand("select * from Class where Id = @Id and AttStatus = 'True'", conn);
        cmd.Parameters.AddWithValue("@Id", ddl3.SelectedItem.Value);

        try
        {
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                txtClassName.Text = rdr["ClassName"].ToString();
                txtStatus.Text = rdr["Status"].ToString();


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
            conn.Close();
            conn.Dispose();
        }

    }

    public static void ShowClassSchedTutor(DropDownList ddl3, TextBox txtClassName, TextBox txtStatus, TextBox txtStartTime, TextBox txtEndTime, TextBox txtDate, TextBox txtHours, TextBox txtPractical, TextBox txtTheory, TextBox txtEnrolments, TextBox txtTrainer, TextBox txtVenue)
    {
        // Show Class Schedule Method
        //Leann
        SqlConnection conn = new SqlConnection(connstr);
        SqlCommand cmd = new SqlCommand("select * from Class where Id = @Id", conn);
        cmd.Parameters.AddWithValue("@Id", ddl3.SelectedItem.Value);

        try
        {
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                txtClassName.Text = rdr["ClassName"].ToString();
                txtStatus.Text = rdr["Status"].ToString();


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
            conn.Close();
            conn.Dispose();
        }

    }

    public static void ShowAttTimeStamp(string TI, string TO, DropDownList ddl2, string date2)
    {
        // Show Attendance Time Stamp
        //Leann
        SqlConnection conn = new SqlConnection(connstr);
        SqlCommand cmd = new SqlCommand(" SELECT u.Email, c.Date, c.Id, att.TimeIn, att.TimeOut FROM Users AS u INNER JOIN Attendance AS att ON u.Email = att.UserID INNER JOIN Class AS c ON att.ClassID = c.Id AND c.Id = @Id AND u.Email = '" + SessionManager.Username + "' AND c.Date = '" + date2 + "'", conn);
        cmd.Parameters.AddWithValue("@Id", ddl2.SelectedItem.Value);

        conn.Open();
        SqlDataReader rdr = cmd.ExecuteReader();
        if (rdr.Read())
        {
            string timeInStamp = rdr["TimeIn"].ToString();
            if (!string.IsNullOrEmpty(timeInStamp))
            {
                DateTime dtStart = DateTime.Parse(timeInStamp);
                TI = dtStart.ToString("hh:mm:ss tt");
            }
            else
            {
                TI = "";
            }

            string timeOutStamp = rdr["TimeOut"].ToString();
            if (!string.IsNullOrEmpty(timeOutStamp))
            {
                DateTime dtEnd = DateTime.Parse(timeOutStamp);
                TO = dtEnd.ToString("hh:mm:ss tt");
            }
            else
            {
                TO = "";
            }
        }

    }


}