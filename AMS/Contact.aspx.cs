using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMS
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //Enzo
            int whereto = SessionManager.UserRole;
            switch (whereto)
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
    
}