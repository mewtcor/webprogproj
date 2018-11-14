using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMS
{
    public partial class http404 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkbLogin_Click(object sender, EventArgs e)
        {
            //Enzo
            SessionManager.LogOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}