using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;


namespace AMS
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Enzo
            int curRole = SessionManager.UserRole;
            if (curRole == 1)
            {
                lblCurrentTime.Text = DateTime.Now.ToString("hh:mm tt");
                lblCurrentDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                lblCurrentUser.Text = SessionManager.Username;
            }
            else
            {

                Response.Redirect("~/401.aspx");
                return;
            }
        }

        protected void btnUserRegister_Click(object sender, EventArgs e)
        {
            //Enzo
            Response.Redirect("UserRegistration.aspx");
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
    }
}