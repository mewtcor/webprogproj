using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace AMS.StudentPages
{
    public partial class ChangePW : System.Web.UI.Page
    {
        //Maikel
        private string connstr =
            System.Web.Configuration.WebConfigurationManager.ConnectionStrings
            ["AMSConnection"].ConnectionString;
        private SqlConnection conn;
        private SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            int curUser = SessionManager.UserRole;
            if (curUser == 3)
            {
                lblCurrentTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
                lblCurrentDate.Text = DateTime.Now.ToString("MM/dd/yyyy");  
                lblCurrentUser.Text = SessionManager.Username;
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

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            //Maikel
            conn = new SqlConnection(connstr);
            SqlDataAdapter sda = new SqlDataAdapter("select Password from Users where Email ='" + SessionManager.Username + "' and Password ='" + txtCurrentPass.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count.ToString() == "1")
            {
                if (TxtNewPass.Text == txtConfNewPass.Text)
                {
                    conn.Open();
                    cmd = new SqlCommand("Update Users set password = '" + txtConfNewPass.Text + "' where Email ='" + SessionManager.Username + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    LblMSG.Text = "Succesfully Update";
                    txtConfNewPass.Text = "";
                    txtCurrentPass.Text = "";
                    TxtNewPass.Text = "";
                    txtCurrentPass.Focus();
                }
                else
                {
                    LblMSG.Text = "New password and confirm new password does not match!!!";
                }

            }
            else
            {
                LblMSG.Text = "Please enter your old password!";
            }
        }
    }
    
}