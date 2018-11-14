using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.SessionState;



namespace AMS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        //Enzo
        private string connstr =
             System.Web.Configuration.WebConfigurationManager.ConnectionStrings
             ["AMSConnection"].ConnectionString;
        private SqlConnection conn;
        private SqlCommand cmd;
        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            //Enzo
            SessionManager.LogIn(email.Value);
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("select * from Users where Email='" + email.Value + "' and Password = '" + password.Value + "'", conn);
            cmd.Parameters.AddWithValue("@Email", email.Value);
            cmd.Parameters.AddWithValue("@Password", password.Value);
            conn.Open();

            var rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    int roleLevel = Convert.ToInt32(rd["roleId"].ToString());
                    SessionManager.LogInRole(roleLevel);

                    switch (roleLevel)
                    {
                        case 1:
                            Response.Redirect("~/AdminPages/Administrator.aspx");
                            break;
                        case 2:
                            Response.Redirect("~/TutorPages/Tutor.aspx");
                            break;
                        case 3:
                            Response.Redirect("~/StudentPages/StudentPage.aspx");
                            break;
                    }

                }
            }
            else
            {            
                Response.Write("<Script>alert('Whoops! Please check your login details and try again.');</Script>");
            }
        }
    
    }
}